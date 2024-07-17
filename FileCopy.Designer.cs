namespace FileProgram
{
    partial class FileCopy
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.openFile = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.originfile = new System.Windows.Forms.Label();
            this.copyfile = new System.Windows.Forms.Label();
            this.pbValue = new System.Windows.Forms.ProgressBar();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.copyFile2 = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // openFile
            // 
            this.openFile.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.openFile.Location = new System.Drawing.Point(62, 43);
            this.openFile.Name = "openFile";
            this.openFile.Size = new System.Drawing.Size(104, 47);
            this.openFile.TabIndex = 0;
            this.openFile.Tag = "FileCopy.cs\\openFile_button";
            this.openFile.Text = "파일 열기";
            this.openFile.UseVisualStyleBackColor = false;
            this.openFile.Click += new System.EventHandler(this.openFile_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(177, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "원본 파일 : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(177, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "복사 파일 : ";
            // 
            // originfile
            // 
            this.originfile.AutoSize = true;
            this.originfile.Location = new System.Drawing.Point(274, 60);
            this.originfile.Name = "originfile";
            this.originfile.Size = new System.Drawing.Size(0, 12);
            this.originfile.TabIndex = 4;
            // 
            // copyfile
            // 
            this.copyfile.AutoSize = true;
            this.copyfile.Location = new System.Drawing.Point(278, 132);
            this.copyfile.Name = "copyfile";
            this.copyfile.Size = new System.Drawing.Size(0, 12);
            this.copyfile.TabIndex = 5;
            this.copyfile.Click += new System.EventHandler(this.copyfile_Click);
            // 
            // pbValue
            // 
            this.pbValue.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pbValue.Location = new System.Drawing.Point(62, 189);
            this.pbValue.Name = "pbValue";
            this.pbValue.Size = new System.Drawing.Size(548, 17);
            this.pbValue.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pbValue.TabIndex = 6;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // copyFile2
            // 
            this.copyFile2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.copyFile2.Location = new System.Drawing.Point(62, 117);
            this.copyFile2.Name = "copyFile2";
            this.copyFile2.Size = new System.Drawing.Size(104, 43);
            this.copyFile2.TabIndex = 7;
            this.copyFile2.Tag = "FileCopy.cs\\copyFile_button";
            this.copyFile2.Text = "파일 복사";
            this.copyFile2.UseVisualStyleBackColor = false;
            this.copyFile2.Click += new System.EventHandler(this.copyFile2_Click);
            // 
            // FileCopy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(680, 285);
            this.Controls.Add(this.copyFile2);
            this.Controls.Add(this.pbValue);
            this.Controls.Add(this.copyfile);
            this.Controls.Add(this.originfile);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.openFile);
            this.Name = "FileCopy";
            this.Text = "파일복사";
            this.Load += new System.EventHandler(this.FileCopy_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button openFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label originfile;
        private System.Windows.Forms.Label copyfile;
        private System.Windows.Forms.ProgressBar pbValue;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button copyFile2;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}