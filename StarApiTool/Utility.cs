using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StarApiTool
{
    public class Utility
    {
        public static void ConvertMD2Html(string fromPath, string toPath, string pandocPath, string cssPath)
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

        static bool StartProcess(string runFilePath, string args)
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

        static void ReplaceHtml(string htmlPath)
        {
            Stream myStream = new FileStream(htmlPath, FileMode.Open);
            //Encoding encode = Encoding.GetEncoding("gb2312");//若是格式为utf-8的需要将gb2312替换
            StreamReader myStreamReader = new StreamReader(myStream);
            string strhtml = myStreamReader.ReadToEnd();
            string stroutput = Regex.Replace(strhtml, "<col style=\"width: (.*?)\" />", "");
            stroutput = stroutput.Replace(@"\\", @"\");
            stroutput = stroutput.Replace(@".md)", @".html)");
            stroutput = stroutput.Replace(@".md]", @"]");
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
        public static List<string> GetFiles(string folderName, bool useOnlyName = false)
        {
            List<string> fileNameList = new List<string>() { };
            DirectoryInfo theFolder = new DirectoryInfo(folderName);
            DirectoryInfo[] dirInfo = theFolder.GetDirectories();

            fileNameList = GetFileList(dirInfo, fileNameList, useOnlyName);
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
        public static List<string> GetFileList(DirectoryInfo[] dirInfos, List<string> fileNameList, bool useOnlyName = false)
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
                    GetFileList(sonFolder.GetDirectories(), fileNameList, useOnlyName);
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
        /// <summary>
        /// 检查指定文件夹是否为空
        /// </summary>
        /// <returns></returns>
        public static bool CheckFolderEmpty(string path)
        {
            if (Directory.GetDirectories(path).Length > 0 || Directory.GetFiles(path).Length > 0)
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// 清空指定文件夹中的内容
        /// </summary>
        /// <param name="path"></param>
        public static void ClearDirectory(string path)

        {

            if (Directory.Exists(path))

            {

                DirectoryInfo[] _di = new DirectoryInfo(path).GetDirectories();

                for (int i = 0; i < _di.Length; i++)

                {

                    ClearDirectory(_di[i].FullName);

                    Directory.Delete(_di[i].FullName);

                }

                FileInfo[] _files = new DirectoryInfo(path).GetFiles();

                for (int i = 0; i < _files.Length; i++)

                {

                    File.Delete(_files[i].FullName);

                }

            }

        }
    }
}
