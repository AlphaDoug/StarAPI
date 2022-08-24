using System.Diagnostics;
using System.Text.RegularExpressions;

namespace StarApiTool
{        // �����ļ��ķ�ʽ
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

        public MainForm()
        {
            InitializeComponent();
#if DEBUG
            Environment.CurrentDirectory = Directory.GetCurrentDirectory() + "\\..\\..\\..\\";
#endif

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
            //ConvertMD2Html(@"C:\Users\shang.ma\Documents\StarApi\UBaseInventoryComponent\UBaseInventoryComponent.md",
            //  @"C:\Users\shang.ma\Documents\StarApi\UBaseInventoryComponent\UBaseInventoryComponentAUTO.html");

            if (fromPath == string.Empty || toPath == string.Empty)
            {
                MessageBox.Show("��ѡ���ļ���");
                return;
            }
            if (!Directory.Exists(fromPath) || !Directory.Exists(toPath))
            {
                MessageBox.Show("·��������");
                return;
            }
            var paths = getFiles(fromPath);
            foreach (string path in paths)
            {
                if (path.EndsWith(".md"))
                {
                    //��MD�ļ�����Ҫת��
                    string to = path.Replace(".md", ".html");
                    to = to.Replace(fromPath, toPath);
                    ConvertMD2Html(path, to);
                }
            }
            if (IsCopyResCheckBox.Checked)
            {
                //����Res�ļ���
                CopyFileAndDir(fromPath + @"\Resources", toPath + @"\Resources");
            }
            MessageBox.Show("ת�����");
        }

        private void ConvertMD2Html(string fromPath = "", string toPath = "")
        {
            if (!File.Exists(toPath))
            {
                CreateFileOrDirectory(toPath);
                //File.Create(toPath);
            }
            Console.WriteLine(fromPath + toPath);
            string s = string.Format(@"--standalone --self-contained --css github.css {0} --output {1}", fromPath, toPath);
            StartProcess(@"pandoc.exe", s);
            ReplaceHtml(toPath);
            return;
        }

       bool StartProcess(string runFilePath, string args)
        {
            args = args.Trim();
            var output = "";
            using (Process process = new Process())//�������̶���    
            {
                process.StartInfo.FileName = runFilePath;  // ���ý�����
                process.StartInfo.UseShellExecute = false;    //�Ƿ�ʹ�ò���ϵͳ��shell����
                process.StartInfo.RedirectStandardInput = true;      //�������Ե��ó��������
                process.StartInfo.RedirectStandardOutput = true;     //�ɵ��ó����ȡ�����Ϣ
                process.StartInfo.CreateNoWindow = true;             //����ʾ���ó���Ĵ��� 
                process.StartInfo.RedirectStandardError = true;   //�ض����׼�������
                if (runFilePath != "cmd.exe")
                {
                    process.StartInfo.Arguments = args;
                    process.Start(); // ����������
                }
                else // ��ֱ�ӵ���cmd��������ʱ���ݲ����ķ�����һ��
                {
                    process.Start(); // ����������
                    process.StandardInput.WriteLine(args + "&exit");
                    process.StandardInput.AutoFlush = true;
                }

                output = process.StandardOutput.ReadToEnd(); // ����ǻ�ȡ����֮��ķ���ֵ  ���Բ���
                process.WaitForExit(); // �ȴ�exeִ�����
                //�������н����Żش���Ϊ0
                if (process.ExitCode != 0)
                {
                    // ��ȡ������Ϣ
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
            //Encoding encode = Encoding.GetEncoding("gb2312");//���Ǹ�ʽΪutf-8����Ҫ��gb2312�滻
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
        /// ��ȡ������Ҫ���ļ���·���ַ�������
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
        /// �ݹ��ȡ�ļ�����������ļ����������ļ����ڵ��ļ���
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

                // �������ļ����ǵùر�
                fileInfo.Create().Close();
            }
        }

        /// <summary>
        /// �����ļ����µ������ļ���Ŀ¼��ָ�����ļ���
        /// </summary>
        /// <param name="dir">Դ�ļ��е�ַ</param>
        /// <param name="desDir">ָ�����ļ��е�ַ</param>
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

                    //������ļ�
                    var fileExist = File.Exists(item);
                    if (fileExist)
                    {
                        //�����ļ���ָ��Ŀ¼��                     
                        File.Copy(item, desPath, true);
                        continue;
                    }

                    //������ļ���                   
                    CopyFileAndDir(item, desPath);

                }
            }
        }

    }


}