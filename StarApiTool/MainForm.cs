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
        private const string INI_FILE_INFO  = "FILE_INFO";

        private bool isExporting = false;
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
            if (isExporting)
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
            ThreadStart thStart = new ThreadStart(ExportThread);//threadStartί�� 
            Thread thread = new Thread(thStart);
            thread.Priority = ThreadPriority.Highest;
            thread.IsBackground = true; //�رմ������ִ��
            thread.Start();

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
        #endregion


        private void ExportThread()
        {
            isExporting = true;
            var paths = Utility.GetFiles(fromPath);
            //Utility.ClearDirectory(toPath);
            int fileCount = 0;
            for (int i = 0; i < paths.Count; i++)
            {
                var path = paths[i];
                if (path.EndsWith(".md"))
                {
                    //��MD�ļ��������ļ���Ϣ�ȶ�
                    string fileInfo = GetFileInfo(path);
                    string curFileInfo = IniHelper.Read(INI_FILE_INFO, path.Replace(fromPath + @"\", ""), "", INI_PATH);
                    if (curFileInfo != fileInfo)
                    {
                        fileCount++;
                        //�ļ���Ϣ�������ģ�����ת��
                        string to = path.Replace(".md", ".html");
                        to = to.Replace(fromPath, toPath);
                        Utility.ConvertMD2Html(path, to, pandocPath, cssPath);
                        if (ExportProgressBar.InvokeRequired)//��ͬ�̷߳�����
                            ExportProgressBar.Invoke(new Action<ProgressBar, float>(UpdateProgress), ExportProgressBar, (float)(i + 1) / paths.Count * 100);//���߳���
                        else//ͬ�߳�ֱ�Ӹ�ֵ
                            ExportProgressBar.Value = (int)(0.0f / paths.Count * 100);
                    }

                }
            }
            if (copyRes)
            {
                //����Res�ļ���
                Utility.CopyFileAndDir(fromPath + @"\Resources", toPath + @"\Resources");
            }
            SaveFileInfo();
            MessageBox.Show("ת����ɣ������ļ�������" + (fileCount == 0 ? "û���ļ�����" : fileCount.ToString()));
            isExporting = false;
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