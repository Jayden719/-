using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;

namespace FileProgram
{
    public partial class FileDelete : Form
    {
        [DllImport("kernel32")]
        private static extern long GetPrivateProfileString(string section, string key, string def, StringBuilder reVal, int size, string filepath);

        public DirectoryInfo iniDirectory = new DirectoryInfo(Application.StartupPath + @"\folderCopy.ini");

        private string INI_READ(string inputSection, string inputKey)
        {
            StringBuilder sb = new StringBuilder(255);
            GetPrivateProfileString(inputSection, inputKey, "", sb, 255, iniDirectory.ToString());

            return sb.ToString();
        }

        public EventHandler NextGo;

        private string logPath = Application.StartupPath + "\\log\\log_" + DateTime.Now.ToString("yyyyMMdd") + ".txt";

        private string CurTime = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");

        private List<string> fileDeleteList = new List<string>();
        private string strDelete;

        string Direct = "";

        public FileDelete()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
/*            Button msp = sender as Button;
            var EventLog = msp.Tag.ToString();

            File.AppendAllText(logPath, "\r\n" + CurTime + " " + EventLog, Encoding.Default);*/

            //string strDelete = textBox1.Text;
            for (int a=0; a<fileDeleteList.Count; a++)
            {
                if (System.IO.File.Exists(fileDeleteList[a]))
                {
                    try
                    {
                        System.IO.File.Delete(fileDeleteList[a]);
                    }
                    catch (System.IO.IOException)
                    {
                   
                    }
                }        
            }
                    resultlabel.Text = fileDeleteList.Count + "개 삭제되었습니다";
                    File.AppendAllText(logPath, "\r\n" + CurTime + " " + "파일 " + textBox1.Text + " 삭제되었습니다 ", Encoding.Default);
        }

        public void button1_Click(object sender, EventArgs e)
        {
            /*Button msp = sender as Button;
            var EventLog = msp.Tag.ToString();

            File.AppendAllText(logPath, "\r\n" + CurTime + " " + EventLog, Encoding.Default);*/

            /*    OpenFileDialog ofd = new OpenFileDialog();
                ofd.Multiselect = true;
                ofd.Title = "삭제할 파일 선택";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    for(int i=0; i<ofd.FileNames.Length; i++)
                    {
                        fileDeleteList.Add(ofd.FileNames[i]);
                    }              
                        textBox1.Text = string.Join("", fileDeleteList.ToArray());
                }
                File.AppendAllText(logPath, "\r\n" + CurTime + " " + "삭제할 파일 " + textBox1.Text + " 을 선택하였습니다 ", Encoding.Default);


                NextGo += new EventHandler(button2_Click);
                NextGo.Invoke(null, EventArgs.Empty);
    */
            Direct = INI_READ("file_delete", "DirectFrom");

            if (File.Exists(Direct))
            {
                try
                {
                    File.Delete(Direct);
                    File.AppendAllText(logPath, "\r\n" + CurTime + Direct + " 을 삭제하였습니다 ", Encoding.Default);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("삭제할 대상 파일이 존재하지 않습니다");
            }


        }
    }
}
