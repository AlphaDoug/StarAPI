using System;
using IniTest.Utils;

namespace StarApiTool
{        // �����ļ��ķ�ʽ
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
        /// ��ǰ���е��߳�����
        /// </summary>
        private int curThreadNum = 0;
        /// <summary>
        /// �������ļ�����
        /// </summary>
        private int exportFileCount = 0;
        /// <summary>
        /// �Ѿ�������ļ�����
        /// </summary>
        private int curOperatedFile = 0;

        private long startSec = 0;
        private long endSec = 0;
        public MainForm()
        {
            InitializeComponent();
            LoadConfig();
        }

        #region ��ť�¼�
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
                //MessageBox.Show("Ŀ���ļ��в�Ϊ�գ����������������Ŀ���ļ��У�");
            }
        }

        private void ExportBtn_Click(object sender, EventArgs e)
        {
            SaveConfig();
            if (curThreadNum > 0)
            {
                MessageBox.Show("��ǰ����ת����");
                return;
            }
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
            ExportProgressBar.Value = 0;
            var fromPaths = Utility.GetFiles(fromPath);
            var splitList = Utility.SpiltList(fromPaths, maxThreadNum);
            startSec = DateTimeOffset.Now.ToUnixTimeSeconds();
            for (int i = 0; i < splitList.Count; i++)
            {
                ParameterizedThreadStart thStart = new ParameterizedThreadStart(ExportThread);//threadStartί�� 
                Thread thread = new Thread(thStart);
                thread.Priority = ThreadPriority.Highest;
                thread.IsBackground = true; //�رմ������ִ��
                thread.Start(new ThreadParam(splitList[i], fromPaths.Count));           
            }

        }
        private void ChoosePandocBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = false;//��ֵȷ���Ƿ����ѡ�����ļ�
            dialog.Title = "��ѡ���ļ�";
            dialog.Filter = "��ִ���ļ�|pandoc.exe";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                pandocPath = dialog.FileName;
                PandocTxtBox.Text = dialog.FileName;
            }
        }

        private void ChooseCssBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = false;//��ֵȷ���Ƿ����ѡ�����ļ�
            dialog.Title = "��ѡ���ļ�";
            dialog.Filter = "CSS�ļ�|*.css";
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
                    //��MD�ļ��������ļ���Ϣ�ȶ�
                    string fileInfo = GetFileInfo(path);
                    string curFileInfo = IniHelper.Read(INI_FILE_INFO, path.Replace(fromPath + @"\", ""), "", INI_PATH);
                    if (isTotalExport || curFileInfo != fileInfo && !isTotalExport)
                    {
                        exportFileCount++;
                        //�ļ���Ϣ�������Ļ���ǿ�Ƶ���ʱ�򣬽���ת��
                        string to = path.Replace(".md", ".html");
                        to = to.Replace(fromPath, toPath);
                        Utility.ConvertMD2Html(path, to, pandocPath, cssPath);
                        
                        if (ExportProgressBar.InvokeRequired)//��ͬ�̷߳�����
                            ExportProgressBar.Invoke(new Action<ProgressBar, float>(UpdateProgress), ExportProgressBar, (float)curOperatedFile / totalCount * 100);//���߳���
                        else//ͬ�߳�ֱ�Ӹ�ֵ
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
                    //����Res�ļ���
                    Utility.CopyFileAndDir(fromPath + @"\Resources", toPath + @"\Resources");
                }
                SaveFileInfo();
                endSec = DateTimeOffset.Now.ToUnixTimeSeconds();
                MessageBox.Show("ת����ɣ������ļ�������" + (exportFileCount == 0 ? "û���ļ�����" : exportFileCount.ToString()) + "����ʱ��" + (endSec - startSec).ToString() + "��");
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