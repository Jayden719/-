using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.ComponentModel;

namespace WindowsFormsApp2
{

    public partial class FolderCopy : Form
    {
        public EventHandler NextGo;

        private string logPath = Application.StartupPath + "\\log\\log_" + DateTime.Now.ToString("yyyyMMdd") + ".txt";

        private string CurTime = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");

        public DirectoryInfo iniDirectory = new DirectoryInfo(Application.StartupPath + @"\folderCopy.ini");

        string fileName = "test_pwi_";
        string folderDirectory = "";
        string newDir = "";
        string newDestFolder = "";
        List<string> sourceDirectory = new List<string>();
        List<string> iniSourceDirectory = new List<string>();

        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filepath);

        [DllImport("kernel32")]
        private static extern long GetPrivateProfileString(string section, string key, string def, StringBuilder reVal, int size, string filepath);

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


        public FolderCopy()
        {
            InitializeComponent();
        }

        public async void button1_Click(object sender, EventArgs e)
        {
            folderDirectory = INI_READ("folder_copy", "DirectFrom");
            newDir = INI_READ("folder_copy", "DirectTo");
            newDestFolder = newDir + @"\" + folderDirectory.Substring(folderDirectory.LastIndexOf(@"\") + 1);
            
            CopyDirectory(folderDirectory, newDestFolder);
            File.AppendAllText(logPath, "\r\n" + CurTime + " " + folderDirectory + " 폴더를 " + newDestFolder + "에 복사했습니다", Encoding.Default);
            DirectoryInfo di = new DirectoryInfo(folderDirectory);
            FileInfo[] fi = di.GetFiles("*");
            await Task.Run(async () =>
            {
                for (int i = 0; i < fi.Length; i++)
                {
                    File.AppendAllText(logPath, "\r\n" + CurTime + " " + fi[i].Name + " 파일을 " + newDestFolder + "에 복사했습니다", Encoding.Default);
                }
            });
        }

        private void button2_Click(object sender, EventArgs e)
        {
            INI_WRITE("sourcePath", null, null);

            sourceDirectory.Clear();
            
            CommonOpenFileDialog cofd = new CommonOpenFileDialog();

            cofd.IsFolderPicker = true;
            cofd.Multiselect = true;
            cofd.Title = "복사할 폴더 선택";

            if(cofd.ShowDialog() == CommonFileDialogResult.Ok)
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
                textBox2.Text = string.Join(", ", sourceDirectory);
                for(int i=0; i<sourceDirectory.Count; i++)
                {
                    INI_WRITE("sourcePath", "path" + i, sourceDirectory[i]);
                }
                NextGo -= new EventHandler(button2_Click);
                NextGo += new EventHandler(button3_Click);
                NextGo.Invoke(null, EventArgs.Empty);
               
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
                            
        }

        private async void CopyDirectory(string sourceFolder, string destFolder)
        {
            string[] folders = Directory.GetDirectories(sourceFolder);
            Directory.CreateDirectory(destFolder);
            try
            {
                await Task.Run(async () =>
                {
                    foreach (string file in Directory.GetFiles(sourceFolder))
                    {
                        string destFile = Path.Combine(destFolder, Path.GetFileName(file));
                        Console.WriteLine("destFile : " + destFile);
                        File.Copy(file, destFile);

                    }
                    foreach (string folder in folders)
                    {
                        string name = Path.GetFileName(folder);
                        string dest = Path.Combine(destFolder, name);
                        CopyDirectory(folder, dest);
                    }
                });
                MessageBox.Show("작업이 완료되었습니다");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
