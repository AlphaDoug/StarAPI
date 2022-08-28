using System;
using IniTest.Utils;

namespace StarApiTool
{        // 创建文件的方式
    public enum CreateType
    {
        Overrite,
        NewName,
        DoNothing,
    }

    public struct ThreadParam
    {
        public List<string> paths;
        public int totalPathsNum;
        public ThreadParam(List<string> _paths, int _total)
        {
            paths = _paths;
            totalPathsNum = _total;
        }
    }
    
    public partial class MainForm : Form
    {
        private string fromPath = string.Empty;
        private string toPath = string.Empty;
        private string pandocPath = string.Empty;
        private string cssPath = string.Empty;
        private bool copyRes = false;
        private bool isTotalExport = false;
        private int maxThreadNum = 3;

        private string INI_PATH                 = Directory.GetCurrentDirectory() + "\\config.ini";
        private const string INI_FROMPATH       = "INI_FROMPATH";
        private const string INI_TOPATH         = "INI_TOPATH";
        private const string INI_PANDOCPATH     = "INI_PANDOCPATH";
        private const string INI_CSSPATH        = "INI_CSSPATH";
        private const string INI_COPYRES        = "INI_COPYRES";
        private const string INI_TOTALEXPORT    = "INI_TOTALEXPORT";
        private const string INI_MAXTHREADNUM   = "INI_MAXTHREADNUM";

        private const string INI_SECTION    = "DEFAULT";
        private const string INI_FILE_INFO  = "FILE_INFO";


        /// <summary>
        /// 当前运行的线程数量
        /// </summary>
        private int curThreadNum = 0;
        /// <summary>
        /// 导出的文件数量
        /// </summary>
        private int exportFileCount = 0;
        /// <summary>
        /// 已经处理的文件数量
        /// </summary>
        private int curOperatedFile = 0;

        private long startSec = 0;
        private long endSec = 0;
        public MainForm()
        {
            InitializeComponent();
            LoadConfig();
        }

        #region 按钮事件
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
            if (!Utility.CheckFolderEmpty(pathName))
            {
                //MessageBox.Show("目标文件夹不为空，导出操作将会清空目标文件夹！");
            }
        }

        private void ExportBtn_Click(object sender, EventArgs e)
        {
            SaveConfig();
            if (curThreadNum > 0)
            {
                MessageBox.Show("当前正在转换中");
                return;
            }
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
            ExportProgressBar.Value = 0;
            var fromPaths = Utility.GetFiles(fromPath);
            var splitList = Utility.SpiltList(fromPaths, maxThreadNum);
            startSec = DateTimeOffset.Now.ToUnixTimeSeconds();
            for (int i = 0; i < splitList.Count; i++)
            {
                ParameterizedThreadStart thStart = new ParameterizedThreadStart(ExportThread);//threadStart委托 
                Thread thread = new Thread(thStart);
                thread.Priority = ThreadPriority.Highest;
                thread.IsBackground = true; //关闭窗体继续执行
                thread.Start(new ThreadParam(splitList[i], fromPaths.Count));           
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

        private void IsCopyResCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            copyRes = IsCopyResCheckBox.Checked;
        }

        private void IsTotalExportCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            isTotalExport = IsTotalExportCheckBox.Checked;
        }

        private void ThreadComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            maxThreadNum = int.Parse(ThreadComboBox.Text);
        }
        #endregion


        private void ExportThread(object _pathStruct)
        {
            if (_pathStruct == null)
            {
                return;
            }
            curThreadNum += 1;
            var pathStruct = (ThreadParam)_pathStruct;//Utility.GetFiles(fromPath);
            var paths = pathStruct.paths;
            var totalCount = pathStruct.totalPathsNum;
            //Utility.ClearDirectory(toPath);
            for (int i = 0; i < paths.Count; i++)
            {
                var path = paths[i];
                curOperatedFile += 1;
                if (path.EndsWith(".md"))
                {
                    //是MD文件，进行文件信息比对
                    string fileInfo = GetFileInfo(path);
                    string curFileInfo = IniHelper.Read(INI_FILE_INFO, path.Replace(fromPath + @"\", ""), "", INI_PATH);
                    if (isTotalExport || curFileInfo != fileInfo && !isTotalExport)
                    {
                        exportFileCount++;
                        //文件信息发生更改或者强制导出时候，进行转换
                        string to = path.Replace(".md", ".html");
                        to = to.Replace(fromPath, toPath);
                        Utility.ConvertMD2Html(path, to, pandocPath, cssPath);
                        
                        if (ExportProgressBar.InvokeRequired)//不同线程访问了
                            ExportProgressBar.Invoke(new Action<ProgressBar, float>(UpdateProgress), ExportProgressBar, (float)curOperatedFile / totalCount * 100);//跨线程了
                        else//同线程直接赋值
                            ExportProgressBar.Value = (int)Math.Floor((float)curOperatedFile / totalCount * 100);
                    }

                }
            }
            curThreadNum -= 1;
            if (curThreadNum <= 0)
            {
                curThreadNum = 0;
                if (copyRes)
                {
                    //导出Res文件夹
                    Utility.CopyFileAndDir(fromPath + @"\Resources", toPath + @"\Resources");
                }
                SaveFileInfo();
                endSec = DateTimeOffset.Now.ToUnixTimeSeconds();
                MessageBox.Show("转化完成，生成文件数量：" + (exportFileCount == 0 ? "没有文件更改" : exportFileCount.ToString()) + "，用时：" + (endSec - startSec).ToString() + "秒");
                exportFileCount = 0;
                curOperatedFile = 0;
            }
        }

        void UpdateProgress(ProgressBar progressBar, float v)
        {
            progressBar.Value = (int)Math.Floor(v);
        }

        private void SaveConfig()
        {
            IniHelper.Write(INI_SECTION, INI_FROMPATH, fromPath, INI_PATH);
            IniHelper.Write(INI_SECTION, INI_TOPATH, toPath, INI_PATH);
            IniHelper.Write(INI_SECTION, INI_CSSPATH, cssPath, INI_PATH);
            IniHelper.Write(INI_SECTION, INI_PANDOCPATH, pandocPath, INI_PATH);
            IniHelper.Write(INI_SECTION, INI_COPYRES, copyRes.ToString(), INI_PATH);
            IniHelper.Write(INI_SECTION, INI_TOTALEXPORT, isTotalExport.ToString(), INI_PATH);
            IniHelper.Write(INI_SECTION, INI_MAXTHREADNUM, maxThreadNum.ToString(), INI_PATH);
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
            isTotalExport = bool.Parse(IniHelper.Read(INI_SECTION, INI_TOTALEXPORT, "False", INI_PATH));
            maxThreadNum = int.Parse(IniHelper.Read(INI_SECTION, INI_MAXTHREADNUM, "3", INI_PATH));

            OriginFolderTxtBox.Text = fromPath;
            TargetFolderTxtBox.Text = toPath;
            PandocTxtBox.Text = pandocPath;
            CSSTxtBox.Text = cssPath;
            IsCopyResCheckBox.Checked = copyRes;
            IsTotalExportCheckBox.Checked = isTotalExport;
            ThreadComboBox.Text = maxThreadNum.ToString();
        }

        private void OriginFolderTxtBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void SaveFileInfo()
        {
            var paths = Utility.GetFiles(fromPath);
            foreach (var path in paths)
            {
                if (path.EndsWith(".md"))
                {
                    IniHelper.Write(INI_FILE_INFO, path.Replace(fromPath + @"\", ""), GetFileInfo(path), INI_PATH);
                }
            }
        }

        string GetFileInfo(string filePath)
        {
            var file = new FileInfo(filePath);
            long fileLength = file.Length;
            DateTime lastWriteTime = file.LastWriteTime;
            return fileLength.ToString() + "|" + lastWriteTime.ToString();
        }

    }
}