using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using log4net;
using System.Drawing.Text;
using System.Diagnostics;
using System.IO.Compression;
using System.Web.Caching;

namespace FileProgram
{
    public partial class Log : Form
    {
        public string logPath = Application.StartupPath + "\\log\\log_" + DateTime.Now.ToString("yyyyMMdd") + ".txt";

        private string CurTime = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");

        private static readonly ILog log = LogManager.GetLogger(typeof(Log));

        public string dateStart;
        public string dateEnd;
        private string startLog;
        private string endLog;
        private string originPath;
        private string copyPath;

        public Log()
        {
            InitializeComponent();
            
        }

        private void Log_Load(object sender, EventArgs e)
        {

        }

        private void datetimestart_ValueChanged(object sender, EventArgs e)
        {
            DateTimePicker msp = sender as DateTimePicker;
            var EventLog = msp.Tag.ToString();

            File.AppendAllText(logPath, "\r\n" + CurTime + " " + EventLog, Encoding.Default);
        }

        private void dateTimeend_ValueChanged(object sender, EventArgs e)
        {
            DateTimePicker msp = sender as DateTimePicker;
            var EventLog = msp.Tag.ToString();

            File.AppendAllText(logPath, "\r\n" + CurTime + " " + EventLog, Encoding.Default);
        }

        private void logSave_Click(object sender, EventArgs e)
        {
            Button msp = sender as Button;
            var EventLog = msp.Tag.ToString();
            string result = "";
            string zipNameAgain = "";
            string zipPath = "";

            File.AppendAllText(logPath, "\r\n" + CurTime + " " + EventLog, Encoding.Default);

            string dateStart = datetimestart.Value.ToString("yyyyMMdd");
            string dateEnd = dateTimeend.Value.ToString("yyyyMMdd");
            string LogFolder = Application.StartupPath + "\\log";
            
            if(datetimestart.Value > DateTime.Now)
            {
                MessageBox.Show("시작날짜는 현재시간 이전이여야 합니다","알림");
                return;
            }
            
            if(dateTimeend.Value > DateTime.Now)
            {
                MessageBox.Show("최종날짜는 현재시간 이내여야 합니다", "알림");
                return;
            }

            DirectoryInfo di = new DirectoryInfo(LogFolder);
            
            String downPath = Path.GetDirectoryName(Environment.GetFolderPath(Environment.SpecialFolder.Personal));
            downPath = Path.Combine(downPath, "log_");
            var zipName = downPath + dateStart + " ~ " + "log_" + dateEnd;
            DirectoryInfo diz = new DirectoryInfo(zipName);

            // 압축 대상 폴더 생성
            if(diz.Exists == false)
            {
                Directory.CreateDirectory(zipName);
            }
    
            startLog = "log_" + dateStart + ".txt";
            endLog = "log_" + dateEnd + ".txt";
         
            foreach (FileInfo file in di.GetFiles())
            {
                DateTime findfile = DateTime.ParseExact(file.Name.Substring(4, 8), "yyyyMMdd", null);
                int startResult = DateTime.Compare(DateTime.ParseExact(dateStart, "yyyyMMdd", null).AddHours(-12), findfile);
                int endResult = DateTime.Compare(DateTime.ParseExact(dateEnd, "yyyyMMdd", null).AddHours(12), findfile);
              
                // Console.WriteLine((dateTimeend.Value - datetimestart.Value).Days + 1);
               // return;
               
                if (startResult == -1)
                {
                    if(endResult == 1)
                    {
                        var sourceFile = System.IO.Path.Combine(LogFolder, file.Name);
               
                        var destFile = System.IO.Path.Combine(zipName, file.Name);

                        FileInfo info = new FileInfo(sourceFile);

                        // 로그파일 존재유무 확인
                        if (info.Exists)
                        {

                            Console.WriteLine("sourceFile : " + sourceFile);
                            Console.WriteLine("destFile : " + destFile);
                           
                            // 압축할 대상 파일 복사
                            System.IO.File.Copy(sourceFile, destFile, true);

                             zipPath = zipName + ".zip";

                           /* try
                            {

                                // 폴더 압축
                                ZipFile.CreateFromDirectory(zipName, zipPath);
                                // 압축 대상 폴더 삭제
                                Directory.Delete(zipName, true);

                            }
                            catch (IOException io)
                            {
                                MessageBox.Show("이미 저장하였습니다");
                                File.AppendAllText(logPath, "\r\n" + CurTime + " " + io.Message, Encoding.Default);
                            }
*/
                            result += file.Name + ", ";
                            /* originPath = Application.StartupPath + "\\log\\" + file.Name;
                              FolderBrowserDialog fbd = new FolderBrowserDialog();
                                 System.IO.FileInfo fi = new System.IO.FileInfo(originPath);

                                 long lSize = 0;
                                 long lTotalSize = fi.Length;
                                 byte[] bTmp = new byte[lTotalSize];

                                 if (fbd.ShowDialog() == DialogResult.OK)
                                 {
                                     copyPath = fbd.SelectedPath;

                                         //var fsRead = File.Open(originPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                                         System.IO.FileStream fsRead = new System.IO.FileStream(originPath, FileMode.Open, FileAccess.Read, FileShare.Read);
                                         System.IO.FileStream fsWrite = new System.IO.FileStream(copyPath + "\\" + fi.Name, System.IO.FileMode.Create);


                                         while (lSize < lTotalSize)
                                         {
                                             int iLen = fsRead.Read(bTmp, 0, bTmp.Length);
                                             lSize += iLen;
                                             fsWrite.Write(bTmp, 0, iLen);
                                         }


                                             fsWrite.Flush();
                                             fsWrite.Close();
                                             fsRead.Close();
                                 }*/

                        }
                        else
                        {
                            MessageBox.Show("누락된 로그 파일이 있습니다. 다시 선택해주세요");
                            return;
                        }
                    }
                }             
            }
            try
            {

                // 폴더 압축
                ZipFile.CreateFromDirectory(zipName, zipPath);
                // 압축 대상 폴더 삭제
                Directory.Delete(zipName, true);
                logcopy.Text = "로그 파일 압축 완료";
                File.AppendAllText(logPath, "\r\n" + CurTime + " " + zipName + ".zip" + " 에 로그 기록 파일 " + result + " 를 저장하였습니다 ", Encoding.Default);
            }
            catch (IOException io)
            {
                MessageBox.Show("이미 저장하였습니다");
                File.AppendAllText(logPath, "\r\n" + CurTime + " " + io.Message, Encoding.Default);
                Directory.Delete(zipName, true);
                File.AppendAllText(logPath, "\r\n" + CurTime + " " + zipName + "중복 폴더 삭제 완료", Encoding.Default);
            }
        }
    }
}
