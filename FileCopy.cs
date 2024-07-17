using log4net;
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
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using WindowsFormsApp2;

namespace FileProgram
{
    public partial class FileCopy : Form
    {
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


        public EventHandler NextGo;

        private string logPath = Application.StartupPath + "\\log\\log_" + DateTime.Now.ToString("yyyyMMdd") + ".txt";

        private string CurTime = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");

        private List<string> originString = new List<string>();
        private static readonly ILog log = LogManager.GetLogger(typeof(FileCopy));
        string strDestFolder = "";
        string Direct = "";
        string TargetDirect = "";
        string TargetDirectFile = "";
        string file_name = "";

        public FileCopy()
        {
            InitializeComponent();
           

        }

        public void openFile_Click(object sender, EventArgs e)
        {
            /*Button msp = sender as Button;
            var EventLog = msp.Tag.ToString();
            File.AppendAllText(logPath, "\r\n" + CurTime + " " + EventLog, Encoding.Default);*/

            /* OpenFileDialog ofd = new OpenFileDialog();
             ofd.Multiselect = true;
             ofd.Title = "복사할 파일 찾기";

             if(ofd.ShowDialog() == DialogResult.OK)
             {             
                 for (int i = 0; i < ofd.FileNames.Length; i++)
                 {
                     originString.Add(ofd.FileNames[i]);
                 }
                     originfile.Text = string.Join("", originString.ToArray());              

                 File.AppendAllText(logPath, "\r\n" + CurTime + " " + "파일 " + originfile.Text + " 을 열었습니다", Encoding.Default);
                 NextGo += new EventHandler(copyFile2_Click);
                 NextGo.Invoke(null, EventArgs.Empty);
             }*/
            Direct = INI_READ("file_copy", "DirectFrom");
            TargetDirect = INI_READ("file_copy", "DirectTo");

            bool fileExist = File.Exists(Direct);
            if (fileExist)
            {
               
            }
            else
            {
                var directory = Path.GetDirectoryName(Direct);
                Directory.CreateDirectory(directory);
                //File.WriteAllText(Direct, "파일 복사 테스트");
            }
            file_name = Path.GetFileName(Direct);     
            TargetDirectFile = System.IO.Path.Combine(TargetDirect, file_name);
            bool fileTargetExist = File.Exists(TargetDirectFile);
            if (fileTargetExist)
            {
                MessageBox.Show("이미 복사하셨습니다");
            }
            else
            {
                File.Copy(Direct, TargetDirectFile, true);
                File.AppendAllText(logPath, "\r\n" + CurTime + " " + "파일 " + Direct + " 을 " + TargetDirectFile + "로 복사하였습니다", Encoding.Default);
            }
        }

        private void copyFile2_Click(object sender, EventArgs e)
        {
           /*     Button msp = sender as Button;
                var EventLog = msp.Tag.ToString();
                string strDestFolder = "";

                File.AppendAllText(logPath, "\r\n" + CurTime + " " + EventLog, Encoding.Default);*/

                FolderBrowserDialog fbd = new FolderBrowserDialog();
                

                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    copyfile.Text = fbd.SelectedPath;
                }

                if(originfile.Text == "")
                {
                    MessageBox.Show("원본 파일을 선택하세요", "알림");
                }
                else
                {
                    for(int i=0; i< originString.Count; ++i)
                    {
                        System.IO.FileInfo fi = new System.IO.FileInfo(originString[i]);
                        long lSize = 0;
                        long lTotalSize = fi.Length;
                        byte[] bTmp = new byte[lTotalSize];

                        pbValue.Minimum = 0;
                        pbValue.Maximum = (int)lTotalSize;
                
                        strDestFolder = copyfile.Text;
            
                        System.IO.FileStream fsRead = new System.IO.FileStream(originString[i], System.IO.FileMode.Open);
                        System.IO.FileStream fsWrite = new System.IO.FileStream(strDestFolder + "\\" + fi.Name, System.IO.FileMode.Create);

                        while (lSize < lTotalSize)
                        {
                            int iLen = fsRead.Read(bTmp, 0, bTmp.Length);
                            lSize += iLen;
                            fsWrite.Write(bTmp, 0, iLen);

                            pbValue.Value = (int)lSize;
                        }

                        pbValue.Value = pbValue.Maximum;
                        fsWrite.Flush();
                        fsWrite.Close();
                        fsRead.Close();

                    }
                    File.AppendAllText(logPath, "\r\n" + CurTime + " " + "파일 " + originfile.Text + " 을 " + strDestFolder +"로 복사하였습니다", Encoding.Default);
                    copyfile.Text = originString.Count + "개 복사 완료 ";
            
              
                }
        }
         
        

        private void FileCopy_Load(object sender, EventArgs e)
        {

        }

        private void copyfile_Click(object sender, EventArgs e)
        {

        }
    }
}
