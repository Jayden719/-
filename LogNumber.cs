using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Windows.Forms.VisualStyles;

namespace WindowsFormsApp2
{
    
    delegate void myDelegate(int a);

    public partial class LogNumber : Form
    {
        private BackgroundWorker worker;

        private ManualResetEvent _pauseEvent = new ManualResetEvent(true);

        private string logPath = Application.StartupPath + "\\log\\log_" + DateTime.Now.ToString("yyyyMMdd") + ".txt";

        private string CurTime = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");

        public DirectoryInfo iniDirectory = new DirectoryInfo(Application.StartupPath + @"\folderCopy.ini");

        CancellationTokenSource tokenSource = new CancellationTokenSource();

        private Boolean flag;
        private Boolean stop;
        private long num = 1;

        [DllImport("kernel32")]
        private static extern long GetPrivateProfileString(string section, string key, string def, StringBuilder reVal, int size, string filepath);

        private string INI_READ(string inputSection, string inputKey)
        {
            StringBuilder sb = new StringBuilder(255);
            GetPrivateProfileString(inputSection, inputKey, "", sb, 255, iniDirectory.ToString());

            return sb.ToString();
        }

        string logNum = "";
        string logNumPath = "";
        int logN;
        private Thread rTh;
    

        public LogNumber()
        {
            InitializeComponent();
        }

        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show("에러 : " + e.Error.Message);
            }
            else if (e.Cancelled == true)
            {
                MessageBox.Show("작업 취소");
            }
            else
            {
                MessageBox.Show("작업 완료");
            }
        }

        public void LogNumberStart(object sender, EventArgs e)
        {
            logNum = INI_READ("log_number", "number");
            logN = int.Parse(logNum);
            CreateFile();
        }

        private void CreateFile()
        {         
           
            logNumPath = Application.StartupPath + "\\log" + @"\logNum.txt";
            
            if (!File.Exists(logNumPath))
            {
                FileStream numStream = File.Create(logNumPath);
                numStream.Close();
            }
            File.SetAttributes(logNumPath, System.IO.FileAttributes.Normal);
         
            rTh = new Thread(WriteLogNum);
            rTh.Start();
        
        }
     
        private void WriteLogNum()
        {
            FileStream fs = new FileStream(logNumPath, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);
            StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);
            fs.SetLength(0);
           
            stop = true;
            flag = true;
            while (stop)
            {
                while (flag)
                {                           
                    sw.WriteLine(num);
                    num++;                   
                }            
            }
            sw.Close();
            sw.Dispose();
            File.SetAttributes(logNumPath, System.IO.FileAttributes.ReadOnly);                             
            return;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                stop = false;
                //rTh.Abort();
                MessageBox.Show("스레드가 종료되었습니다");
            }
            catch(ThreadStateException ea)
            {
                MessageBox.Show(ea.Message);
            }
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (rTh.IsAlive)
            {
                try
                {
                    //rTh.Suspend();
                    this.flag = false;
                    MessageBox.Show("스레드가 일시 정지되었습니다");
                }
                catch (ThreadStateException es)
                {
                    MessageBox.Show(es.Message);
                }
            }
            else
            {
                MessageBox.Show("스레드가 이미 종료되었습니다");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (rTh.IsAlive)
            {
                try
                {
                    //rTh.Resume();
                    this.flag = true;
                    MessageBox.Show("스레드가 재기되었습니다");
                }
                catch (ThreadStateException eaa)
                {
                    MessageBox.Show(eaa.Message);
                }
            }
            else
            {
                MessageBox.Show("스레드가 이미 종료되었습니다");
            }
        }
    }
}
