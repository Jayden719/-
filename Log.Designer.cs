namespace FileProgram
{
    partial class Log
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
            this.datetimestart = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimeend = new System.Windows.Forms.DateTimePicker();
            this.logSave = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.logcopy = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // datetimestart
            // 
            this.datetimestart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datetimestart.Location = new System.Drawing.Point(45, 73);
            this.datetimestart.Name = "datetimestart";
            this.datetimestart.Size = new System.Drawing.Size(153, 21);
            this.datetimestart.TabIndex = 0;
            this.datetimestart.Tag = "Log.cs\\start_datepicker";
            this.datetimestart.ValueChanged += new System.EventHandler(this.datetimestart_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(42, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "로그 기간 설정";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(204, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "~";
            // 
            // dateTimeend
            // 
            this.dateTimeend.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimeend.Location = new System.Drawing.Point(230, 73);
            this.dateTimeend.Name = "dateTimeend";
            this.dateTimeend.Size = new System.Drawing.Size(161, 21);
            this.dateTimeend.TabIndex = 3;
            this.dateTimeend.Tag = "Log.cs\\end_datepicker";
            this.dateTimeend.ValueChanged += new System.EventHandler(this.dateTimeend_ValueChanged);
            // 
            // logSave
            // 
            this.logSave.Location = new System.Drawing.Point(417, 73);
            this.logSave.Name = "logSave";
            this.logSave.Size = new System.Drawing.Size(108, 20);
            this.logSave.TabIndex = 4;
            this.logSave.Tag = "Log.cs\\saveLog_button";
            this.logSave.Text = "로그저장";
            this.logSave.UseVisualStyleBackColor = true;
            this.logSave.Click += new System.EventHandler(this.logSave_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // logcopy
            // 
            this.logcopy.AutoSize = true;
            this.logcopy.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.logcopy.Location = new System.Drawing.Point(121, 128);
            this.logcopy.Name = "logcopy";
            this.logcopy.Size = new System.Drawing.Size(0, 16);
            this.logcopy.TabIndex = 5;
            // 
            // Log
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 213);
            this.Controls.Add(this.logcopy);
            this.Controls.Add(this.logSave);
            this.Controls.Add(this.dateTimeend);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.datetimestart);
            this.Name = "Log";
            this.Text = "로그저장";
            this.Load += new System.EventHandler(this.Log_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker datetimestart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimeend;
        private System.Windows.Forms.Button logSave;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Label logcopy;
    }
}