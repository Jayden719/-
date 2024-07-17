using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using log4net;
using System.IO;
using WindowsFormsApp2;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Web.Configuration;
using System.Security.Cryptography;
using System.Threading;

namespace FileProgram
{
    public partial class Form1 : Form
    {
        public EventHandler ClickHandler;

        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filepath);

        [DllImport("kernel32")]
        private static extern long GetPrivateProfileString(string section, string key, string def, StringBuilder reVal, int size, string filepath);

        public DirectoryInfo iniDirectory = new DirectoryInfo(Application.StartupPath + @"\folderCopy.ini");

        private void INI_WRITE(string section, string key, string value)
        {
            WritePrivateProfileString(section, key, value, iniDirectory.ToString());
        }

        private string INI_READ(string inputSection, string inputKey)
        {
            StringBuilder sb = new StringBuilder(255);
            GetPrivateProfileString(inputSection, inputKey, "", sb, 255, iniDirectory.ToString());

            return sb.ToString();
        }

        private static readonly ILog log = LogManager.GetLogger(typeof(Form1));

        private static string logPath = Application.StartupPath + "\\log\\log_" + DateTime.Now.ToString("yyyyMMdd") + ".txt";

        private static string CurTime = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");

        string fc_df = "";
        string fc_dt = "";
        string fd_df = "";
        string fdc_df = "";
        string fdc_dt = "";
        string fdd_df = "";
        string td_df = "";
        string td_dt = "";
        string td_mt = "";

  
        public Form1()
        {
            InitializeComponent();

       /*      if (IsExistProcessMutex(Process.GetCurrentProcess().ProcessName))
             {
                 MessageBox.Show("이미실행중입니다.");
                 Application.Exit();
             }
             else
             {
                 try
                 {
                     Application.EnableVisualStyles();
                     Application.SetCompatibleTextRenderingDefault(false);
                     Application.Run(new Form1());
                 }
                 catch (InvalidOperationException io)
                 {
                     MessageBox.Show(io.Message);
                 }
             }

*/
            fc_df = INI_READ("file_copy", "DirectFrom");
            fc_dt = INI_READ("file_copy", "DirectTo");
            fd_df = INI_READ("file_delete", "DirectFrom");
            fdc_df = INI_READ("folder_copy", "DirectFrom");
            fdc_dt = INI_READ("folder_copy", "DirectTo");
            //fdd_df = INI_READ("folder_delete", "DirectFrom");
            td_df = INI_READ("time_delete", "DeleteFrom");
            td_dt = INI_READ("time_delete_date", "DeleteDate");
            //td_mt = INI_READ("time_delete_method", "수정기간(W)/생성기간(C)");   


/*
            INI_WRITE("file_copy", "복사할 파일의 경로", null);
            INI_WRITE("file_copy", "설명", "복사 해놓을 디렉토리(폴더) 경로;");
            INI_WRITE("file_delete", "설명", "삭제하려는 파일의 경로;");
            INI_WRITE("folder_copy", "설명", "복사하려는 디렉토리(폴더) 경로;");
            INI_WRITE("folder_copy", "설명", "복사 해놓을 디렉토리(폴더) 경로;");
            INI_WRITE("folder_delete", "DirectFrom 설명", "삭제 하려는 디렉토리(폴더) 경로");
            INI_WRITE("time_delete", "설명", "10일 전 수정된 파일 정리할 디렉토리(폴더) 경로;");*/
        


            if (fc_df=="" && fc_dt=="" && fd_df=="" && fdc_df=="" && fdc_dt=="" && fdd_df == "" && td_df=="")
            {
                INI_WRITE("file_copy", "DirectFrom", "c:\\test\\test.txt");
                INI_WRITE("file_copy", "DirectTo", "D:\\");
                INI_WRITE("file_delete", "DirectFrom", "D:\\test(복사본).txt");
                INI_WRITE("folder_copy", "DirectFrom", "c:\\test_folder");
                INI_WRITE("folder_copy", "DirectTo", "D:\\test_folder");
                INI_WRITE("folder_delete", "DirectFrom", "D:\\test_folder");
                INI_WRITE("time_delete", "DeleteFrom", "C:\\Users\\shinan\\Desktop\\TEST");
                INI_WRITE("time_delete_date", "DeleteDate", "10");
                INI_WRITE("time_delete_method", "DeleteMethod", "1");
                INI_WRITE("log_number", "number", "30");

            }
           else { }

            //String DateDeleteDir = td_df;
            //dateCompareDelete(DateDeleteDir);
            
        }

        private static void dateCompareDelete(string deleteCompareDir)
        {
            int deleteDay = 10;
            if (deleteCompareDir == "")
            {
                MessageBox.Show("ini 파일을 수정하세요");
                return;
            }
            else
            {
                DirectoryInfo di = new DirectoryInfo(deleteCompareDir);
                if (di.Exists)
                {
                    string[] files = Directory.GetFiles(deleteCompareDir, "*", SearchOption.AllDirectories);
                    string[] dirs = Directory.GetDirectories(deleteCompareDir, "*", SearchOption.AllDirectories);
                    foreach (string file in files)
                    {
                        string IDate = DateTime.Today.AddDays(-deleteDay).ToString("yyyyMMdd");
                        var info = new FileInfo(file);
                        if (IDate.CompareTo(info.LastWriteTime.ToString("yyyyMMdd")) > 0)
                        {
                            info.Attributes = FileAttributes.Normal;
                            info.Delete();
                            File.AppendAllText(logPath, "\r\n" + CurTime + " " + deleteDay + "일 이상이 지난 " + info.Name + "파일을 자동삭제하였습니다", Encoding.Default);
                        }

                    }
                    /* foreach(string dir in dirs)
                     {
                         Console.WriteLine("dir : " + dir);
                         DirectoryInfo subdir = new DirectoryInfo(dir);
                         DateTime dt = Directory.GetCreationTime(dir);
                         if (DateTime.Now.Subtract(dt).TotalDays > 10)
                         {
                             if (!Directory.Exists(dir))
                             {
                                 return;
                             }
                             else
                             {
                                 dateCompareDelete(dir);
                                 try
                                 {
                                     subdir.Delete(true);

                                 }catch(IOException aa)
                                 {
                                     MessageBox.Show(aa.Message);
                                 }
                             }
                         }
                     }
                     DateTime dm = Directory.GetCreationTime(di.FullName);
                     if (DateTime.Now.Subtract(dm).TotalDays > 10)
                     {
                         Directory.Delete(deleteCompareDir);
                     }*/



                    /*foreach(DirectoryInfo mmf in diss)
                    {
                        Console.WriteLine("mmf.FullName : " +mmf.FullName);
                    }
                    foreach(DirectoryInfo dis in diss)
                    {
                        FileInfo[] files = dis.GetFiles();
                        string IDate = DateTime.Today.AddDays(-deleteDay).ToString("yyyyMMdd");
                        foreach (FileInfo file in files)
                        {                     
                            if (IDate.CompareTo(file.LastWriteTime.ToString("yyyyMMdd")) > 0)
                            {                    
                                file.Attributes = FileAttributes.Normal;
                                file.Delete();
                                File.AppendAllText(logPath, "\r\n" + CurTime + " " + deleteDay + "일 이상이 지난 " + file.Name + "파일을 자동삭제하였습니다", Encoding.Default);                      
                            }
                        }
                        String[] subdirs = Directory.GetDirectories(dis.FullName);
                        foreach(string subdir in subdirs)
                        {
                            DateTime dt = Directory.GetCreationTime(subdir);
                            if (DateTime.Now.Subtract(dt).TotalDays > 10)
                            {
                                if (!Directory.Exists(subdir))
                                {
                                    return;
                                }
                                else
                                {
                                dateCompareDelete(subdir);
                                Console.WriteLine(subdir);

                                }
                            }
                        }
                    }*/
                }



                /* string[] folders = Directory.GetDirectories(deleteCompareDir);



                     DateTime ord = Directory.GetCreationTime(deleteCompareDir);
                     if (di.Exists)
                     {                         
                             FileInfo[] files = di.GetFiles();
                             string IDate = DateTime.Today.AddDays(-deleteDay).ToString("yyyyMMdd");
                             foreach(FileInfo file in files)
                             {                           
                                 if (IDate.CompareTo(file.LastWriteTime.ToString("yyyyMMdd")) > 0)
                                 {
                                     file.Attributes = FileAttributes.Normal;
                                     file.Delete();
                                     File.AppendAllText(logPath, "\r\n" + CurTime + " " + deleteDay + "일 이상이 지난 " + file.Name + "파일을 자동삭제하였습니다", Encoding.Default);
                                 }
                             }


                             foreach(string folder in folders)
                             {

                                 DateTime dt = Directory.GetCreationTime(folder);

                                 if (DateTime.Now.Subtract(dt).TotalDays > 10)
                                 {

                                     Directory.Delete(folder, true);                               
                                 }
                             }

                     if (DateTime.Now.Subtract(ord).TotalDays > 10)
                     {
                         Directory.Delete(deleteCompareDir);
                     }
                 }  */
            }
        }

     

        private void 파일복사ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem msp = sender as ToolStripMenuItem;
            var EventLog = msp.Tag.ToString();
            File.AppendAllText(logPath, "\r\n" + CurTime + " " + EventLog, Encoding.Default);
         
            FileCopy fc = new FileCopy();
            fc.Tag = this;
            ClickHandler += new EventHandler(fc.openFile_Click);
            ClickHandler.Invoke(null, EventArgs.Empty);      
            ClickHandler -= new EventHandler(fc.openFile_Click);
            //fc.Show();                      
        }

        private void 파일삭제ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem msp = sender as ToolStripMenuItem;
            var EventLog = msp.Tag.ToString();
            File.AppendAllText(logPath, "\r\n" + CurTime + " " + EventLog, Encoding.Default);

            FileDelete fd = new FileDelete();
            fd.Tag = this;
            ClickHandler += new EventHandler(fd.button1_Click);
            ClickHandler.Invoke(null, EventArgs.Empty);
            ClickHandler -= new EventHandler(fd.button1_Click);
            //fd.Show();

        }

        private void 로그생성ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            ToolStripMenuItem msp = sender as ToolStripMenuItem;
            var EventLog = msp.Tag.ToString();
            File.AppendAllText(logPath, "\r\n" + CurTime + " " + EventLog, Encoding.Default);

            Log lg = new Log();
            lg.Tag = this;
            lg.Show();
            
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            /* System.Diagnostics.Process[] processes = null;
             string strCurrentProcess = System.Diagnostics.Process.GetCurrentProcess().ProcessName.ToUpper();
             processes = System.Diagnostics.Process.GetProcessesByName(strCurrentProcess);
             if (processes.Length > 1)
             {
                 MessageBox.Show(string.Format("'{0}' 프로그램이 이미 실행 중입니다.", System.Diagnostics.Process.GetCurrentProcess().ProcessName));
                 Application.Exit();
             }*/

           if (IsExistProcessMutex())
            {
                MessageBox.Show("이미실행중입니다.");
                Application.Exit();
            }
            else
            {
               /* try
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new Form1());
                }
                catch (InvalidOperationException io)
                {
                    MessageBox.Show(io.Message);
                }*/
            }

            string folderPath = Application.StartupPath + "\\log";
            DirectoryInfo di = new DirectoryInfo(folderPath);

            if(di.Exists==false)
            {
                di.Create();
            }

            System.IO.FileInfo fi = new System.IO.FileInfo(logPath);
            if (!fi.Exists)
            {
                string curTime = DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss");
                System.IO.File.WriteAllText(logPath, curTime + " Log 파일 최초 생성 ", Encoding.Default);
            }
        }

        private static bool IsExistProcessMutex()
        {
            bool createdNew;

            Mutex mutex = new Mutex(true, "INFMutex", out createdNew);

            if (createdNew == true)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void 로그시작ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 파일ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem msp = sender as ToolStripMenuItem;
            var EventLog = msp.Tag.ToString();

            File.AppendAllText(logPath, "\r\n" + CurTime + " " + EventLog, Encoding.Default);
        }

        private void 로그ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem msp = sender as ToolStripMenuItem;
            var EventLog = msp.Tag.ToString();

            File.AppendAllText(logPath, "\r\n" + CurTime + " " + EventLog, Encoding.Default);
        }

        private void 폴더복사ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderCopy fc = new FolderCopy();
            fc.Tag = this;
            ClickHandler += new EventHandler(fc.button1_Click);
            ClickHandler.Invoke(null, EventArgs.Empty);
            ClickHandler -= new EventHandler(fc.button1_Click);
            //fc.Show();
        }

        private void 폴더삭제ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderDelete fd = new FolderDelete();
            fd.Tag = this;
            ClickHandler += new EventHandler(fd.button1_Click);
            ClickHandler.Invoke(null, EventArgs.Empty);
            ClickHandler -= new EventHandler(fd.button1_Click);
            //fd.Show();
        }

      

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void 로그숫자ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LogNumber ln = new LogNumber();
            ln.Tag = this;
            ClickHandler += new EventHandler(ln.LogNumberStart);
            ClickHandler.Invoke(null, EventArgs.Empty);
            ClickHandler -= new EventHandler(ln.LogNumberStart);
            ln.Show();

        }

        private void 작업중지ToolStripMenuItem_Click(object sender, EventArgs e)
        {
          /*  LogNumber ln = new LogNumber();
            ln.Tag = this;
            ClickHandler += new EventHandler(ln.logNumStop);
            ClickHandler.Invoke(null, EventArgs.Empty);
            ClickHandler -= new EventHandler(ln.logNumStop);*/
      
        }

        private void 조회ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataSelect ds = new DataSelect();
            ds.Tag = this;
            ds.Show();
        }

        private void 분류ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataClass dc = new DataClass();
            dc.Tag = this;
            dc.Show();

        }

        private void r실습ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Rdata rd = new Rdata();
            rd.Tag = this;
            rd.Show();
        }
    }
}
