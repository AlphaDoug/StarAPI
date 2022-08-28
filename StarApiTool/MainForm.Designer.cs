namespace StarApiTool
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ChooseOriginBtn = new System.Windows.Forms.Button();
            this.OriginFolderTxtBox = new System.Windows.Forms.TextBox();
            this.TargetFolderTxtBox = new System.Windows.Forms.TextBox();
            this.ChooseTargetBtn = new System.Windows.Forms.Button();
            this.ExportBtn = new System.Windows.Forms.Button();
            this.IsCopyResCheckBox = new System.Windows.Forms.CheckBox();
            this.PandocTxtBox = new System.Windows.Forms.TextBox();
            this.ChoosePandocBtn = new System.Windows.Forms.Button();
            this.CSSTxtBox = new System.Windows.Forms.TextBox();
            this.ChooseCssBtn = new System.Windows.Forms.Button();
            this.ExportProgressBar = new System.Windows.Forms.ProgressBar();
            this.IsTotalExportCheckBox = new System.Windows.Forms.CheckBox();
            this.ThreadComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ChooseOriginBtn
            // 
            this.ChooseOriginBtn.Location = new System.Drawing.Point(381, 12);
            this.ChooseOriginBtn.Name = "ChooseOriginBtn";
            this.ChooseOriginBtn.Size = new System.Drawing.Size(111, 32);
            this.ChooseOriginBtn.TabIndex = 0;
            this.ChooseOriginBtn.Text = "源文件夹";
            this.ChooseOriginBtn.UseVisualStyleBackColor = true;
            this.ChooseOriginBtn.Click += new System.EventHandler(this.ChooseOriginBtn_Click);
            // 
            // OriginFolderTxtBox
            // 
            this.OriginFolderTxtBox.Location = new System.Drawing.Point(17, 17);
            this.OriginFolderTxtBox.Name = "OriginFolderTxtBox";
            this.OriginFolderTxtBox.ReadOnly = true;
            this.OriginFolderTxtBox.Size = new System.Drawing.Size(337, 23);
            this.OriginFolderTxtBox.TabIndex = 1;
            this.OriginFolderTxtBox.TextChanged += new System.EventHandler(this.OriginFolderTxtBox_TextChanged);
            // 
            // TargetFolderTxtBox
            // 
            this.TargetFolderTxtBox.Location = new System.Drawing.Point(17, 67);
            this.TargetFolderTxtBox.Name = "TargetFolderTxtBox";
            this.TargetFolderTxtBox.ReadOnly = true;
            this.TargetFolderTxtBox.Size = new System.Drawing.Size(337, 23);
            this.TargetFolderTxtBox.TabIndex = 3;
            // 
            // ChooseTargetBtn
            // 
            this.ChooseTargetBtn.Location = new System.Drawing.Point(381, 62);
            this.ChooseTargetBtn.Name = "ChooseTargetBtn";
            this.ChooseTargetBtn.Size = new System.Drawing.Size(111, 32);
            this.ChooseTargetBtn.TabIndex = 2;
            this.ChooseTargetBtn.Text = "目标文件夹";
            this.ChooseTargetBtn.UseVisualStyleBackColor = true;
            this.ChooseTargetBtn.Click += new System.EventHandler(this.ChooseTargetBtn_Click);
            // 
            // ExportBtn
            // 
            this.ExportBtn.Location = new System.Drawing.Point(17, 262);
            this.ExportBtn.Name = "ExportBtn";
            this.ExportBtn.Size = new System.Drawing.Size(475, 60);
            this.ExportBtn.TabIndex = 4;
            this.ExportBtn.Text = "导出";
            this.ExportBtn.UseVisualStyleBackColor = true;
            this.ExportBtn.Click += new System.EventHandler(this.ExportBtn_Click);
            // 
            // IsCopyResCheckBox
            // 
            this.IsCopyResCheckBox.AutoSize = true;
            this.IsCopyResCheckBox.Location = new System.Drawing.Point(17, 206);
            this.IsCopyResCheckBox.Name = "IsCopyResCheckBox";
            this.IsCopyResCheckBox.Size = new System.Drawing.Size(132, 21);
            this.IsCopyResCheckBox.TabIndex = 5;
            this.IsCopyResCheckBox.Text = "是否复制Res文件夹";
            this.IsCopyResCheckBox.UseVisualStyleBackColor = true;
            this.IsCopyResCheckBox.CheckedChanged += new System.EventHandler(this.IsCopyResCheckBox_CheckedChanged);
            // 
            // PandocTxtBox
            // 
            this.PandocTxtBox.Location = new System.Drawing.Point(17, 118);
            this.PandocTxtBox.Name = "PandocTxtBox";
            this.PandocTxtBox.ReadOnly = true;
            this.PandocTxtBox.Size = new System.Drawing.Size(337, 23);
            this.PandocTxtBox.TabIndex = 7;
            // 
            // ChoosePandocBtn
            // 
            this.ChoosePandocBtn.Location = new System.Drawing.Point(381, 113);
            this.ChoosePandocBtn.Name = "ChoosePandocBtn";
            this.ChoosePandocBtn.Size = new System.Drawing.Size(111, 32);
            this.ChoosePandocBtn.TabIndex = 6;
            this.ChoosePandocBtn.Text = "选择Pandoc文件";
            this.ChoosePandocBtn.UseVisualStyleBackColor = true;
            this.ChoosePandocBtn.Click += new System.EventHandler(this.ChoosePandocBtn_Click);
            // 
            // CSSTxtBox
            // 
            this.CSSTxtBox.Location = new System.Drawing.Point(17, 169);
            this.CSSTxtBox.Name = "CSSTxtBox";
            this.CSSTxtBox.ReadOnly = true;
            this.CSSTxtBox.Size = new System.Drawing.Size(337, 23);
            this.CSSTxtBox.TabIndex = 9;
            // 
            // ChooseCssBtn
            // 
            this.ChooseCssBtn.Location = new System.Drawing.Point(381, 164);
            this.ChooseCssBtn.Name = "ChooseCssBtn";
            this.ChooseCssBtn.Size = new System.Drawing.Size(111, 32);
            this.ChooseCssBtn.TabIndex = 8;
            this.ChooseCssBtn.Text = "选择CSS文件";
            this.ChooseCssBtn.UseVisualStyleBackColor = true;
            this.ChooseCssBtn.Click += new System.EventHandler(this.ChooseCssBtn_Click);
            // 
            // ExportProgressBar
            // 
            this.ExportProgressBar.Location = new System.Drawing.Point(17, 233);
            this.ExportProgressBar.Name = "ExportProgressBar";
            this.ExportProgressBar.Size = new System.Drawing.Size(475, 23);
            this.ExportProgressBar.TabIndex = 10;
            // 
            // IsTotalExportCheckBox
            // 
            this.IsTotalExportCheckBox.AutoSize = true;
            this.IsTotalExportCheckBox.Location = new System.Drawing.Point(155, 206);
            this.IsTotalExportCheckBox.Name = "IsTotalExportCheckBox";
            this.IsTotalExportCheckBox.Size = new System.Drawing.Size(99, 21);
            this.IsTotalExportCheckBox.TabIndex = 11;
            this.IsTotalExportCheckBox.Text = "是否全部导出";
            this.IsTotalExportCheckBox.UseVisualStyleBackColor = true;
            this.IsTotalExportCheckBox.CheckedChanged += new System.EventHandler(this.IsTotalExportCheckBox_CheckedChanged);
            // 
            // ThreadComboBox
            // 
            this.ThreadComboBox.FormattingEnabled = true;
            this.ThreadComboBox.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.ThreadComboBox.Location = new System.Drawing.Point(453, 202);
            this.ThreadComboBox.Name = "ThreadComboBox";
            this.ThreadComboBox.Size = new System.Drawing.Size(39, 25);
            this.ThreadComboBox.TabIndex = 12;
            this.ThreadComboBox.Text = "3";
            this.ThreadComboBox.SelectedIndexChanged += new System.EventHandler(this.ThreadComboBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(379, 205);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 17);
            this.label1.TabIndex = 13;
            this.label1.Text = "多线程导出";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(510, 332);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ThreadComboBox);
            this.Controls.Add(this.IsTotalExportCheckBox);
            this.Controls.Add(this.ExportProgressBar);
            this.Controls.Add(this.CSSTxtBox);
            this.Controls.Add(this.ChooseCssBtn);
            this.Controls.Add(this.PandocTxtBox);
            this.Controls.Add(this.ChoosePandocBtn);
            this.Controls.Add(this.IsCopyResCheckBox);
            this.Controls.Add(this.ExportBtn);
            this.Controls.Add(this.TargetFolderTxtBox);
            this.Controls.Add(this.ChooseTargetBtn);
            this.Controls.Add(this.OriginFolderTxtBox);
            this.Controls.Add(this.ChooseOriginBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "API转换工具";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button ChooseOriginBtn;
        private TextBox OriginFolderTxtBox;
        private TextBox TargetFolderTxtBox;
        private Button ChooseTargetBtn;
        private Button ExportBtn;
        private CheckBox IsCopyResCheckBox;
        private TextBox PandocTxtBox;
        private Button ChoosePandocBtn;
        private TextBox CSSTxtBox;
        private Button ChooseCssBtn;
        private ProgressBar ExportProgressBar;
        private CheckBox IsTotalExportCheckBox;
        private ComboBox ThreadComboBox;
        private Label label1;
    }
}