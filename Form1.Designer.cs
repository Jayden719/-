namespace FileProgram
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.파일ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.파일복사ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.파일삭제ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.폴더ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.폴더복사ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.폴더삭제ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.로그ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.로그생성ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.로그숫자ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.데이터ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.조회ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.분류ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.파일ToolStripMenuItem,
            this.폴더ToolStripMenuItem,
            this.로그ToolStripMenuItem,
            this.데이터ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(484, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 파일ToolStripMenuItem
            // 
            this.파일ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.파일복사ToolStripMenuItem,
            this.파일삭제ToolStripMenuItem});
            this.파일ToolStripMenuItem.Name = "파일ToolStripMenuItem";
            this.파일ToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.파일ToolStripMenuItem.Tag = "Form1.cs\\file_meunItem";
            this.파일ToolStripMenuItem.Text = "파일";
            this.파일ToolStripMenuItem.Click += new System.EventHandler(this.파일ToolStripMenuItem_Click);
            // 
            // 파일복사ToolStripMenuItem
            // 
            this.파일복사ToolStripMenuItem.Name = "파일복사ToolStripMenuItem";
            this.파일복사ToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.파일복사ToolStripMenuItem.Tag = "Form1.cs\\fileCopy_meunItem";
            this.파일복사ToolStripMenuItem.Text = "파일복사";
            this.파일복사ToolStripMenuItem.Click += new System.EventHandler(this.파일복사ToolStripMenuItem_Click);
            // 
            // 파일삭제ToolStripMenuItem
            // 
            this.파일삭제ToolStripMenuItem.Name = "파일삭제ToolStripMenuItem";
            this.파일삭제ToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.파일삭제ToolStripMenuItem.Tag = "Form1.cs\\fileDelete_meunItem";
            this.파일삭제ToolStripMenuItem.Text = "파일삭제";
            this.파일삭제ToolStripMenuItem.Click += new System.EventHandler(this.파일삭제ToolStripMenuItem_Click);
            // 
            // 폴더ToolStripMenuItem
            // 
            this.폴더ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.폴더복사ToolStripMenuItem,
            this.폴더삭제ToolStripMenuItem});
            this.폴더ToolStripMenuItem.Name = "폴더ToolStripMenuItem";
            this.폴더ToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.폴더ToolStripMenuItem.Text = "폴더";
            // 
            // 폴더복사ToolStripMenuItem
            // 
            this.폴더복사ToolStripMenuItem.Name = "폴더복사ToolStripMenuItem";
            this.폴더복사ToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.폴더복사ToolStripMenuItem.Text = "폴더복사";
            this.폴더복사ToolStripMenuItem.Click += new System.EventHandler(this.폴더복사ToolStripMenuItem_Click);
            // 
            // 폴더삭제ToolStripMenuItem
            // 
            this.폴더삭제ToolStripMenuItem.Name = "폴더삭제ToolStripMenuItem";
            this.폴더삭제ToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.폴더삭제ToolStripMenuItem.Text = "폴더삭제";
            this.폴더삭제ToolStripMenuItem.Click += new System.EventHandler(this.폴더삭제ToolStripMenuItem_Click);
            // 
            // 로그ToolStripMenuItem
            // 
            this.로그ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.로그생성ToolStripMenuItem,
            this.로그숫자ToolStripMenuItem});
            this.로그ToolStripMenuItem.Name = "로그ToolStripMenuItem";
            this.로그ToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.로그ToolStripMenuItem.Tag = "Form1.cs\\log_meunItem";
            this.로그ToolStripMenuItem.Text = "로그";
            this.로그ToolStripMenuItem.Click += new System.EventHandler(this.로그ToolStripMenuItem_Click);
            // 
            // 로그생성ToolStripMenuItem
            // 
            this.로그생성ToolStripMenuItem.Name = "로그생성ToolStripMenuItem";
            this.로그생성ToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.로그생성ToolStripMenuItem.Tag = "Form1.cs\\logSave_meunItem";
            this.로그생성ToolStripMenuItem.Text = "로그저장";
            this.로그생성ToolStripMenuItem.Click += new System.EventHandler(this.로그생성ToolStripMenuItem_Click);
            // 
            // 로그숫자ToolStripMenuItem
            // 
            this.로그숫자ToolStripMenuItem.Name = "로그숫자ToolStripMenuItem";
            this.로그숫자ToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.로그숫자ToolStripMenuItem.Text = "로그숫자";
            this.로그숫자ToolStripMenuItem.Click += new System.EventHandler(this.로그숫자ToolStripMenuItem_Click);
            // 
            // 데이터ToolStripMenuItem
            // 
            this.데이터ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.조회ToolStripMenuItem,
            this.분류ToolStripMenuItem});
            this.데이터ToolStripMenuItem.Name = "데이터ToolStripMenuItem";
            this.데이터ToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.데이터ToolStripMenuItem.Text = "데이터";
            // 
            // 조회ToolStripMenuItem
            // 
            this.조회ToolStripMenuItem.Name = "조회ToolStripMenuItem";
            this.조회ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.조회ToolStripMenuItem.Text = "조회";
            this.조회ToolStripMenuItem.Click += new System.EventHandler(this.조회ToolStripMenuItem_Click);
            // 
            // 분류ToolStripMenuItem
            // 
            this.분류ToolStripMenuItem.Name = "분류ToolStripMenuItem";
            this.분류ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.분류ToolStripMenuItem.Text = "분류";
            this.분류ToolStripMenuItem.Click += new System.EventHandler(this.분류ToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 248);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "파일운영 프로그램";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 파일ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 파일복사ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 파일삭제ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 로그ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 로그생성ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 폴더ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 폴더복사ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 폴더삭제ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 로그숫자ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 데이터ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 조회ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 분류ToolStripMenuItem;
    }
}

