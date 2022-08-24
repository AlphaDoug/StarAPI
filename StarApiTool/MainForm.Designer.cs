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
            this.SuspendLayout();
            // 
            // ChooseOriginBtn
            // 
            this.ChooseOriginBtn.Location = new System.Drawing.Point(438, 25);
            this.ChooseOriginBtn.Name = "ChooseOriginBtn";
            this.ChooseOriginBtn.Size = new System.Drawing.Size(86, 32);
            this.ChooseOriginBtn.TabIndex = 0;
            this.ChooseOriginBtn.Text = "源文件夹";
            this.ChooseOriginBtn.UseVisualStyleBackColor = true;
            this.ChooseOriginBtn.Click += new System.EventHandler(this.ChooseOriginBtn_Click);
            // 
            // OriginFolderTxtBox
            // 
            this.OriginFolderTxtBox.Location = new System.Drawing.Point(74, 30);
            this.OriginFolderTxtBox.Name = "OriginFolderTxtBox";
            this.OriginFolderTxtBox.ReadOnly = true;
            this.OriginFolderTxtBox.Size = new System.Drawing.Size(337, 23);
            this.OriginFolderTxtBox.TabIndex = 1;
            // 
            // TargetFolderTxtBox
            // 
            this.TargetFolderTxtBox.Location = new System.Drawing.Point(74, 80);
            this.TargetFolderTxtBox.Name = "TargetFolderTxtBox";
            this.TargetFolderTxtBox.ReadOnly = true;
            this.TargetFolderTxtBox.Size = new System.Drawing.Size(337, 23);
            this.TargetFolderTxtBox.TabIndex = 3;
            // 
            // ChooseTargetBtn
            // 
            this.ChooseTargetBtn.Location = new System.Drawing.Point(438, 75);
            this.ChooseTargetBtn.Name = "ChooseTargetBtn";
            this.ChooseTargetBtn.Size = new System.Drawing.Size(86, 32);
            this.ChooseTargetBtn.TabIndex = 2;
            this.ChooseTargetBtn.Text = "目标文件夹";
            this.ChooseTargetBtn.UseVisualStyleBackColor = true;
            this.ChooseTargetBtn.Click += new System.EventHandler(this.ChooseTargetBtn_Click);
            // 
            // ExportBtn
            // 
            this.ExportBtn.Location = new System.Drawing.Point(74, 158);
            this.ExportBtn.Name = "ExportBtn";
            this.ExportBtn.Size = new System.Drawing.Size(450, 60);
            this.ExportBtn.TabIndex = 4;
            this.ExportBtn.Text = "导出";
            this.ExportBtn.UseVisualStyleBackColor = true;
            this.ExportBtn.Click += new System.EventHandler(this.ExportBtn_Click);
            // 
            // IsCopyResCheckBox
            // 
            this.IsCopyResCheckBox.AutoSize = true;
            this.IsCopyResCheckBox.Location = new System.Drawing.Point(392, 122);
            this.IsCopyResCheckBox.Name = "IsCopyResCheckBox";
            this.IsCopyResCheckBox.Size = new System.Drawing.Size(132, 21);
            this.IsCopyResCheckBox.TabIndex = 5;
            this.IsCopyResCheckBox.Text = "是否复制Res文件夹";
            this.IsCopyResCheckBox.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 230);
            this.Controls.Add(this.IsCopyResCheckBox);
            this.Controls.Add(this.ExportBtn);
            this.Controls.Add(this.TargetFolderTxtBox);
            this.Controls.Add(this.ChooseTargetBtn);
            this.Controls.Add(this.OriginFolderTxtBox);
            this.Controls.Add(this.ChooseOriginBtn);
            this.Name = "MainForm";
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
    }
}