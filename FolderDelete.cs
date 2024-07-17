using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    delegate void MyDelegate(string a);
    public partial class FolderDelete : Form
    {
        public EventHandler NextGo;

        private string logPath = Application.StartupPath + "\\log\\log_" + DateTime.Now.ToString("yyyyMMdd") + ".txt";

        private string CurTime = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");

        public DirectoryInfo iniDirectory = new DirectoryInfo(Application.StartupPath + @"\folderCopy.ini");

        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filepath);

        [DllImport("kernel32")]
        private static extern long GetPrivateProfileString(string section, string key, string def, StringBuilder reVal, int size, string filepath);

        List<string> sourceDirectory = new List<string>();
        List<string> iniSourceDirectory = new List<string>();
        string folderDeleteDirect = "";
        string timeDeleteDirect = "";

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

        public FolderDelete()
        {
            InitializeComponent();
        }

        public void button1_Click(object sender, EventArgs e)
        {
            /* INI_WRITE("sourcePath", null, null);

             sourceDirectory.Clear();

             CommonOpenFileDialog cofd = new CommonOpenFileDialog();
             cofd.IsFolderPicker = true;
             cofd.Multiselect = true;
             cofd.Title = "삭제할 폴더 찾기";

             if (cofd.ShowDialog() == CommonFileDialogResult.Ok)
             {
                 foreach(string file in cofd.FileNames)
                 {
                     try
                     {
                         sourceDirectory.Add(file);

                     }catch(Exception ex)
                     {
                         MessageBox.Show(ex.Message);
                     }
                 }
                 textBox1.Text = string.Join(", ", sourceDirectory);

                 for(int i=0; i<sourceDirectory.Count; i++)
                 {
                     INI_WRITE("sourcePath", "path" + i, sourceDirectory[i]);
                 }
                 NextGo += new EventHandler(button2_Click);
                 NextGo.Invoke(null, EventArgs.Empty);
             }*/

            // 폴더 삭제 기능

            // 기간 이후 삭제
         
            timeDeleteDirect = INI_READ("time_delete", "DeleteFrom");
            //String deleteDirect = "";
            //folderDeleteDirect = INI_READ("folder_delete", "DirectFrom");

           /* if (timeDeleteDirect == "" && folderDeleteDirect !="")
            {
                deleteDirect = folderDeleteDirect;
            }else if(folderDeleteDirect == "" && timeDeleteDirect !="")
            {
                deleteDirect = timeDeleteDirect;

            }else if(timeDeleteDirect =="" && folderDeleteDirect == "")
            {
                MessageBox.Show("time_delete 에 경로를 넣으세요");
                return;
            }
            else
            {
                MessageBox.Show("time_delete 에만 경로를 넣으세요");
                return;
            }*/

        /* 전체 삭제 기능
         * 
                DirectoryInfo di = new DirectoryInfo(folderDeleteDirect);
                if (di.Exists)
                {
                    FileInfo[] files = di.GetFiles();
                    foreach (var fi in files)
                    {
                        if ((fi.Attributes & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
                        {
                            fi.Attributes = FileAttributes.Normal;
                        }
                    }

                    foreach (var file in files)
                    {
                        file.Delete();
                        File.AppendAllText(logPath, "\r\n" + CurTime + " " + file + "파일을 삭제하였습니다", Encoding.Default);
                    }
                    try
                    {
                        Directory.Delete(folderDeleteDirect, true);
                        File.AppendAllText(logPath, "\r\n" + CurTime + " " + folderDeleteDirect + "폴더를 삭제하였습니다", Encoding.Default);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("삭제할 폴더가 없습니다.");
                }
            */
                String DateDeleteDir = timeDeleteDirect;

            MyDelegate a = dateCompareDelete;
            a.BeginInvoke(DateDeleteDir, null, null);

                //dateCompareDelete(DateDeleteDir);

            

            // 특정기간 지난 디렉토리 삭제 기능


        }

        private void dateCompareDelete(string deleteCompareDir)
        {
            string td_dt = INI_READ("time_delete_date", "DeleteDate");
            string td_mt = INI_READ("time_delete_method", "DeleteMethod");
            int td_mtt = int.Parse(td_mt);
            int deleteDay = int.Parse(td_dt);

           

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
                        // string[] dirs = Directory.GetDirectories(deleteCompareDir, "*", SearchOption.AllDirectories);
                        foreach (string file in files)
                        {
                            string IDate = DateTime.Today.AddDays(-deleteDay).ToString("yyyyMMdd");
                            var info = new FileInfo(file);
                            if (td_mtt < 1)
                            {
                                //Console.WriteLine("c입니다");
                                if (IDate.CompareTo(info.CreationTime.ToString("yyyyMMdd")) > 0)
                                {
                                    info.Attributes = FileAttributes.Normal;
                                    info.Delete();
                                    File.AppendAllText(logPath, "\r\n" + CurTime + " " + deleteDay + "일 이상이 지난 " + info.Name + "파일을 자동삭제하였습니다", Encoding.Default);
                                }

                            }
                            else
                            {
                                //Console.WriteLine("d입니다");
                                if (IDate.CompareTo(info.LastWriteTime.ToString("yyyyMMdd")) > 0)
                                {
                                    info.Attributes = FileAttributes.Normal;
                                    info.Delete();
                                    File.AppendAllText(logPath, "\r\n" + CurTime + " " + deleteDay + "일 이상이 지난 " + info.Name + "파일을 자동삭제하였습니다", Encoding.Default);
                                }

                            }


                        }
                    }
           
                MessageBox.Show("작업이 완료되었습니다");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for(int i=0; i<sourceDirectory.Count; i++)
            {
                iniSourceDirectory.Add(INI_READ("sourcePath", "path" + i.ToString()));
            }

            for(int i=0; i<iniSourceDirectory.Count; i++)
            {
                DirectoryInfo di = new DirectoryInfo(iniSourceDirectory[i]);
                string[] deleteFiles = Directory.GetFiles(iniSourceDirectory[i],"*", SearchOption.AllDirectories);
                di.Delete(true);
                File.AppendAllText(logPath, "\r\n" + CurTime + " " + iniSourceDirectory[i] + "폴더를 삭제하였습니다", Encoding.Default);
                foreach(var file in deleteFiles)
                {
                File.AppendAllText(logPath, "\r\n" + CurTime + " " + file + "파일을 삭제하였습니다", Encoding.Default);
                }
            }
            label2.Text = "선택한 폴더가 삭제 되었습니다";
            INI_WRITE("sourcePath", null, null);
        }
    }
}
