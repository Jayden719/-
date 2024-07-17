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
using System.Net.Http.Headers;
using FileProgram;
using log4net;
using Microsoft.WindowsAPICodePack.Dialogs;
using System.Diagnostics;





namespace WindowsFormsApp2
{


    public partial class FolderCopy_old : Form
    {
  

        private string logPath = Application.StartupPath + "\\log\\log_" + DateTime.Now.ToString("yyyyMMdd") + ".txt";

        private string CurTime = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
      
        private static readonly ILog log = LogManager.GetLogger(typeof(FileCopy));

        private bool firstLoad = false;
        string sourcePath = "";
        string destinationPath = "";
        string folderName = "";

        public FolderCopy_old()
        {
            InitializeComponent();
        }

  

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void FolderCopy_Load(object sender, EventArgs e)
        {
            // 이미지 리스트 객체 생성
            ImageList imgList = new ImageList();

            // 이미지 리스트에 인덱스 별 값 추가
            imgList.Images.Add(Properties.Resources.folder);
            imgList.Images.Add(Properties.Resources.images);

            treeDir.ImageList = imgList;
            treeDir.ImageIndex = 0;
            treeDir.SelectedImageIndex = 1;

            try
            {
                LoadDirectory();
            }
            catch(Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }

        private void LoadDirectory()
        {
            radioButton1.Checked = true;
            try
            {
                firstLoad = true;

                string[] drivers = Directory.GetLogicalDrives();
                foreach(string drive in drivers)
                {
                    TreeNode root = new TreeNode(drive);
                    treeDir.Nodes.Add(root);

                    DirectoryInfo dir = new DirectoryInfo(drive);
                    if (dir.Exists)
                    {
                        AddDirectoryNodes(root, dir, false);
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        private void AddDirectoryNodes(TreeNode root, DirectoryInfo dir, bool isLoop)
        {          
            try
            {
                DirectoryInfo[] drivers = dir.GetDirectories();
                foreach(DirectoryInfo drive in drivers)
                {
                    TreeNode childRoot = new TreeNode(drive.Name);
                    root.Nodes.Add(childRoot);

                    if (isLoop)
                    {
                        AddDirectoryNodes(childRoot, drive, false);
                    }
                }
            }
            catch(Exception error)
            {
                if (isLoop == false)
                {
                    MessageBox.Show(error.ToString());
                }
            }

        }

        private void treeDir_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string fullpath = e.Node.FullPath;

            try
            {
                listView1.Clear();

                DirectoryInfo dir = new DirectoryInfo(fullpath);

                DirectoryInfo[] folders = dir.GetDirectories();
                FileInfo[] files = dir.GetFiles();

                listView1.BeginUpdate();

                listView1.View = View.Details;

                listView1.LargeImageList = imageList1;
                listView1.SmallImageList = imageList1;

                foreach (DirectoryInfo folder in folders)
                {
                    ListViewItem item = new ListViewItem(folder.Name);
                    item.SubItems.Add("");
                    item.SubItems.Add(folder.Root.ToString() + folder.Parent.ToString());
                    item.SubItems.Add(folder.LastWriteTime.ToString());
                    item.ImageIndex = 1;

                    listView1.Items.Add(item);
                }

                foreach (FileInfo file in files)
                {
                    ListViewItem items = new ListViewItem(file.Name);

                    if (file.Length > 1024 * 1024 * 1024)
                    {
                        items.SubItems.Add(Convert.ToString(file.Length / 1024 / 1024 / 1024) + "GB");

                    }
                    else if (file.Length > 1024 * 1024)
                    {
                        items.SubItems.Add(Convert.ToString(file.Length / 1024 / 1024) + "MB");

                    }
                    else if (file.Length > 1024)
                    {
                        items.SubItems.Add(Convert.ToString(file.Length / 1024) + "KB");

                    }
                    else
                    {
                        items.SubItems.Add("1KB");
                    }

                    items.SubItems.Add(file.DirectoryName.ToString());
                    items.SubItems.Add(file.LastWriteTime.ToString());
                    items.ImageIndex = 0;

                    listView1.Items.Add(items);
                }
             }catch(UnauthorizedAccessException ex){ 

             } 

                listView1.Columns.Add("파일명", 200, HorizontalAlignment.Left);
                listView1.Columns.Add("사이즈", 70, HorizontalAlignment.Left);
                listView1.Columns.Add("디렉토리", 70, HorizontalAlignment.Left);
                listView1.Columns.Add("날짜", 150, HorizontalAlignment.Left);

                listView1.EndUpdate();    
           
        }

        private void treeDir_AfterExpand(object sender, TreeViewEventArgs e)
        {
            DirectoryInfo dir = new DirectoryInfo(e.Node.FullPath);
            e.Node.Nodes.Clear();
            AddDirectoryNodes(e.Node, dir, true);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            listView1.View = View.Details;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            listView1.View = View.Tile;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog ofd = new CommonOpenFileDialog();
            ofd.IsFolderPicker = true;

            if(ofd.ShowDialog() == CommonFileDialogResult.Ok)
            {
                textBox2.Text = ofd.FileName;
                destinationPath = textBox2.Text;
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string directRoot = "";
            string directName = "";
            
           if(listView1.SelectedItems.Count == 1)
            {
                ListView.SelectedListViewItemCollection items = listView1.SelectedItems;
                
                foreach(ListViewItem item in items)
                {
                    directRoot = item.SubItems[2].Text;                  
                    directName = @"\" + item.SubItems[0].Text;
                    folderName = item.SubItems[0].Text;


                }
                sourcePath = directRoot + directName;
                destinationPath = textBox2.Text;
               // Console.Write(destinationPath);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Console.WriteLine(sourcePath);
            return;
            CopyDirectory(sourcePath, destinationPath);
        }

        private void progressBarF_Click(object sender, EventArgs e)
        {

        }

        private void CopyDirectory(string sourceDir, string targetDir)
        {
            string newDir = "";
            //Console.WriteLine("targetDir : " + targetDir);
            DirectoryInfo sd = new DirectoryInfo(sourceDir);
            newDir = targetDir + @"\" + sd.Name;

            FileAttributes chkfile = File.GetAttributes(sourceDir);
            if((chkfile & FileAttributes.Directory) == FileAttributes.Directory)
            {
                Directory.CreateDirectory(newDir);

                foreach (string file in Directory.GetFiles(sourceDir))
                {
                    string destFile = Path.Combine(newDir, Path.GetFileName(file));

                    if (File.Exists(destFile))
                    {
                        MessageBox.Show("이미 동일한 폴더가 존재합니다");
                        return;
                    }
                    else
                    {
                    File.Copy(file, destFile);

                    }
                               
                }

                foreach(string subDir in Directory.GetDirectories(sourceDir))
                {
                    string destSubDir = Path.Combine(newDir, Path.GetFileName(subDir));
                    CopyDirectory(subDir, destSubDir);
                }
                File.AppendAllText(logPath, "\r\n" + CurTime + " " + folderName + "폴더를 " + destinationPath + "로 복사하였습니다" , Encoding.Default);
                label1.Text = "복사 완료";
            }
            else
            {
                MessageBox.Show("폴더를 선택하세요");
                return;
            }
            
        }

     
    }
}
