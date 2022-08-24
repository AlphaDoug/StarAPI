using System.Diagnostics;
using System.Text.RegularExpressions;
using IniTest.Utils;

namespace StarApiTool
{        // 创建文件的方式
    public enum CreateType
    {
        Overrite,
        NewName,
        DoNothing,
    }
    
    public partial class MainForm : Form
    {
        private string fromPath = string.Empty;
        private string toPath = string.Empty;
        private string pandocPath = string.Empty;
        private string cssPath = string.Empty;
        private bool copyRes = false;

        private string INI_PATH             = Directory.GetCurrentDirectory() + "\\config.ini";
        private const string INI_FROMPATH   = "INI_FROMPATH";
        private const string INI_TOPATH     = "INI_TOPATH";
        private const string INI_PANDOCPATH = "INI_PANDOCPATH";
        private const string INI_CSSPATH    = "INI_CSSPATH";
        private const string INI_COPYRES    = "INI_COPYRES";

        private const string INI_SECTION    = "DEFAULT";
        public MainForm()
        {
            InitializeComponent();
            LoadConfig();

        }

        private void ChooseOriginBtn_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.ShowDialog();
            string pathName = dialog.SelectedPath;
            OriginFolderTxtBox.Text = pathName;
            fromPath = pathName;
        }

        private void ChooseTargetBtn_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.ShowDialog();
            string pathName = dialog.SelectedPath;
            TargetFolderTxtBox.Text = pathName;
            toPath = pathName;
        }

        private void ExportBtn_Click(object sender, EventArgs e)
        {
            SaveConfig();
            if (fromPath == string.Empty || toPath == string.Empty)
            {
                MessageBox.Show("请选择文件夹");
                return;
            }
            if (!Directory.Exists(fromPath) || !Directory.Exists(toPath))
            {
                MessageBox.Show("路径不存在");
                return;
            }
            var paths = getFiles(fromPath);
            foreach (string path in paths)
            {
                if (path.EndsWith(".md"))
                {
                    //是MD文件，需要转化
                    string to = path.Replace(".md", ".html");
                    to = to.Replace(fromPath, toPath);
                    ConvertMD2Html(path, to);
                }
            }
            if (copyRes)
            {
                //导出Res文件夹
                CopyFileAndDir(fromPath + @"\Resources", toPath + @"\Resources");
            }
            MessageBox.Show("转化完成");
        }

        private void ConvertMD2Html(string fromPath = "", string toPath = "")
        {
            if (!File.Exists(toPath))
            {
                CreateFileOrDirectory(toPath);
                //File.Create(toPath);
            }
            Console.WriteLine(fromPath + toPath);
            string s = string.Format(@"--standalone --self-contained --css {0} {1} --output {2}", cssPath, fromPath, toPath);
            StartProcess(pandocPath, s);
            ReplaceHtml(toPath);
            return;
        }

       bool StartProcess(string runFilePath, string args)
        {
            args = args.Trim();
            var output = "";
            using (Process process = new Process())//创建进程对象    
            {
                process.StartInfo.FileName = runFilePath;  // 调用进程名
                process.StartInfo.UseShellExecute = false;    //是否使用操作系统的shell启动
                process.StartInfo.RedirectStandardInput = true;      //接受来自调用程序的输入
                process.StartInfo.RedirectStandardOutput = true;     //由调用程序获取输出信息
                process.StartInfo.CreateNoWindow = true;             //不显示调用程序的窗口 
                process.StartInfo.RedirectStandardError = true;   //重定向标准错误输出
                if (runFilePath != "cmd.exe")
                {
                    process.StartInfo.Arguments = args;
                    process.Start(); // 后启动程序
                }
                else // 当直接调用cmd输入命令时传递参数的方法不一样
                {
                    process.Start(); // 先启动程序
                    process.StandardInput.WriteLine(args + "&exit");
                    process.StandardInput.AutoFlush = true;
                }

                output = process.StandardOutput.ReadToEnd(); // 这个是获取命令之后的返回值  可以不用
                process.WaitForExit(); // 等待exe执行完成
                //正常运行结束放回代码为0
                if (process.ExitCode != 0)
                {
                    // 读取错误信息
                    output = process.StandardError.ReadToEnd();
                    output = output.ToString().Replace(Environment.NewLine, string.Empty);
                    output = output.ToString().Replace("\n", string.Empty);
                    MessageBox.Show(output);
                    return false;
                }
                else
                {
                    output = process.StandardOutput.ReadToEnd();
                }
                process.Close();
            }

            return true;
        }

       void ReplaceHtml(string htmlPath)
        {
            Stream myStream = new FileStream(htmlPath, FileMode.Open);
            //Encoding encode = Encoding.GetEncoding("gb2312");//若是格式为utf-8的需要将gb2312替换
            StreamReader myStreamReader = new StreamReader(myStream);
            string strhtml = myStreamReader.ReadToEnd();
            string stroutput = Regex.Replace(strhtml, "<col style=\"width: (.*?)\" />", "");
            stroutput = Regex.Replace(stroutput, @"\\", @"\");
            myStream.Close();

            myStream = new FileStream(htmlPath, FileMode.Create);
            StreamWriter sw = new StreamWriter(myStream);
            sw.Write(stroutput);
            sw.Close();
            myStream.Close();
        }

        /// <summary>
        /// 获取最终需要的文件夹路径字符串集合
        /// </summary>
        /// <param name="folderName"></param>
        /// <returns></returns>
        private List<string> getFiles(string folderName, bool useOnlyName = false)
        {
            List<string> fileNameList = new List<string>() { };
            DirectoryInfo theFolder = new DirectoryInfo(folderName);
            DirectoryInfo[] dirInfo = theFolder.GetDirectories();

            fileNameList = getFileList(dirInfo, fileNameList, useOnlyName);
            FileInfo[] fileInfo = theFolder.GetFiles();
            for (int i = 0; i < fileInfo.Length; i++)
            {
                if (useOnlyName)
                {
                    fileNameList.Add(fileInfo[i].Name);
                }
                else
                {
                    fileNameList.Add(fileInfo[i].FullName);
                }
            }
            return fileNameList;
        }

        /// <summary>
        /// 递归获取文件夹里的所有文件（包括子文件夹内的文件）
        /// </summary>
        /// <param name="dirInfos"></param>
        /// <param name="fileNameList"></param>
        /// <returns></returns>
        private List<string> getFileList(DirectoryInfo[] dirInfos, List<string> fileNameList, bool useOnlyName = false)
        {
            foreach (DirectoryInfo sonFolder in dirInfos)
            {
                FileInfo[] fileInfo = sonFolder.GetFiles();
                for (int i = 0; i < fileInfo.Length; i++)
                {
                    if (useOnlyName)
                    {
                        fileNameList.Add(fileInfo[i].Name);
                    }
                    else
                    {
                        fileNameList.Add(fileInfo[i].FullName);
                    }

                }
                if (sonFolder.GetDirectories() != null)
                {
                    getFileList(sonFolder.GetDirectories(), fileNameList, useOnlyName);
                }
            }
            return fileNameList;
        }
        public static void CreateFileOrDirectory(string path, CreateType createType = CreateType.DoNothing)
        {
            if (path.Contains("."))
            {
                FileInfo fileInfo = new FileInfo(path);

                CreateFile(fileInfo, createType);
            }
            else
            {
                Directory.CreateDirectory(path);
            }
        }


        public static void CreateFile(FileInfo fileInfo, CreateType createType = CreateType.DoNothing)
        {
            if (fileInfo.Exists)
            {
                switch (createType)
                {
                    case CreateType.Overrite:
                        {
                            fileInfo.Create().Close();
                        }
                        break;

                    case CreateType.NewName:
                        {
                            string directoryName = fileInfo.DirectoryName;
                            string fileName = fileInfo.Name;

                            string[] fileNameAndSuffix = fileName.Split('.');
                            string fileHead = fileNameAndSuffix[0];
                            string suffix = fileNameAndSuffix[1];

                            int i = 1;
                            string newFilePath;
                            do
                            {
                                string newFileName = $"{fileHead}_{i}.{suffix}";
                                newFilePath = $@"{directoryName}\{newFileName}";

                                i++;
                            } while (File.Exists(newFilePath));

                            File.Create(newFilePath).Close();
                        }
                        break;

                    case CreateType.DoNothing:
                        break;
                }
            }
            else
            {
                Directory.CreateDirectory(fileInfo.DirectoryName);

                // 创建完文件，记得关闭
                fileInfo.Create().Close();
            }
        }

        /// <summary>
        /// 复制文件夹下的所有文件、目录到指定的文件夹
        /// </summary>
        /// <param name="dir">源文件夹地址</param>
        /// <param name="desDir">指定的文件夹地址</param>
        public static void CopyFileAndDir(string dir, string desDir)
        {
            if (!Directory.Exists(desDir))
            {
                Directory.CreateDirectory(desDir);
            }
            IEnumerable<string> files = Directory.EnumerateFileSystemEntries(dir);
            if (files != null && files.Count() > 0)
            {
                foreach (var item in files)
                {
                    string desPath = Path.Combine(desDir, Path.GetFileName(item));

                    //如果是文件
                    var fileExist = File.Exists(item);
                    if (fileExist)
                    {
                        //复制文件到指定目录下                     
                        File.Copy(item, desPath, true);
                        continue;
                    }

                    //如果是文件夹                   
                    CopyFileAndDir(item, desPath);

                }
            }
        }

        private void ChoosePandocBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = false;//该值确定是否可以选择多个文件
            dialog.Title = "请选择文件";
            dialog.Filter = "可执行文件|pandoc.exe";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                pandocPath = dialog.FileName;
                PandocTxtBox.Text = dialog.FileName;
            }
        }

        private void ChooseCssBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = false;//该值确定是否可以选择多个文件
            dialog.Title = "请选择文件";
            dialog.Filter = "CSS文件|*.css";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                cssPath = dialog.FileName;
                CSSTxtBox.Text = dialog.FileName;
            }
        }

        private void SaveConfig()
        {
            IniHelper.Write(INI_SECTION, INI_FROMPATH, fromPath, INI_PATH);
            IniHelper.Write(INI_SECTION, INI_TOPATH, toPath, INI_PATH);
            IniHelper.Write(INI_SECTION, INI_CSSPATH, cssPath, INI_PATH);
            IniHelper.Write(INI_SECTION, INI_PANDOCPATH, pandocPath, INI_PATH);
            IniHelper.Write(INI_SECTION, INI_COPYRES, copyRes.ToString(), INI_PATH);
        }

        private void LoadConfig()
        {
            if (!File.Exists(INI_PATH))
            {
                File.Create(INI_PATH);
            }
            fromPath = IniHelper.Read(INI_SECTION, INI_FROMPATH, "", INI_PATH);
            toPath = IniHelper.Read(INI_SECTION, INI_TOPATH, "", INI_PATH);
            pandocPath = IniHelper.Read(INI_SECTION, INI_PANDOCPATH, "", INI_PATH);
            cssPath = IniHelper.Read(INI_SECTION, INI_CSSPATH, "", INI_PATH);
            copyRes = bool.Parse(IniHelper.Read(INI_SECTION, INI_COPYRES, "False", INI_PATH));

            OriginFolderTxtBox.Text = fromPath;
            TargetFolderTxtBox.Text = toPath;
            PandocTxtBox.Text = pandocPath;
            CSSTxtBox.Text = cssPath;
            IsCopyResCheckBox.Checked = copyRes;
        }

        private void IsCopyResCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            copyRes = IsCopyResCheckBox.Checked;
        }
    }


}