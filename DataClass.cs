using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.Reflection;

namespace WindowsFormsApp2
{
    delegate void CDelegate(string a, string b, string c, string d, string e);
    delegate void RDelegate(string a, string b, string c, string d, string e);

    public partial class DataClass : Form
    {
        string dbId = "";
        string dbPw = "";
        string dbIp = "";
        string Asql = "";
        string Bsql = "";
        string Csql = "";
        string cgroupName = "";
        string bgroupName = "";
        string agroupName = "";
        string agroupCode = "";
        string bgroup = "";
        string bgroupN = "";
        string DelGroup = "";
        string DelGroupN = "";
        string delGroupName = "";
        string delGroupCode = "";
        string agroupCnt="";
        string bgroupCnt = "";
        string cgroupCnt ="";
        string cgcode = "";
        ListViewItem Clv;

        List<List<string>> aList = new List<List<string>>();
         

        public DataClass()
        {
            InitializeComponent();
   
            listViewSmall.GetType().GetProperty("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(listViewSmall, true);
            listView18.GetType().GetProperty("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(listView18, true);
            CheckForIllegalCrossThreadCalls = false;
            dataGridView1.DoubleBuffered(true);

            dbId = "sa"; //INI_READ("ClvMk", "DbId");
            dbPw = "oracle"; //INI_READ("ClvMk", "DbPw");
            dbIp = "192.168.0.15"; //INI_READ("ClvMk", "DbIp");
  
            listView1.ItemCheck += new ItemCheckEventHandler(listview_checkbox);
            listView2.ItemCheck += new ItemCheckEventHandler(listview2_checkbox);
            listView3.ItemCheck += new ItemCheckEventHandler(listview3_checkbox);
            listView4.ItemCheck += new ItemCheckEventHandler(listview4_checkbox);
            listView5.ItemCheck += new ItemCheckEventHandler(listview5_checkbox);
            listView6.ItemCheck += new ItemCheckEventHandler(listview6_checkbox);
            listView7.ItemCheck += new ItemCheckEventHandler(listview7_checkbox);
            listView8.ItemCheck += new ItemCheckEventHandler(listview8_checkbox);
            listView9.ItemCheck += new ItemCheckEventHandler(listview9_checkbox);
            listView10.ItemCheck += new ItemCheckEventHandler(listview10_checkbox);
            listView11.ItemCheck += new ItemCheckEventHandler(listview11_checkbox);
            listView12.ItemCheck += new ItemCheckEventHandler(listview12_checkbox);
            listView13.ItemCheck += new ItemCheckEventHandler(listview13_checkbox);
            listView14.ItemCheck += new ItemCheckEventHandler(listview14_checkbox);
            listView15.ItemCheck += new ItemCheckEventHandler(listview15_checkbox);
            listView16.ItemCheck += new ItemCheckEventHandler(listview16_checkbox);
            listView17.ItemCheck += new ItemCheckEventHandler(listview17_checkbox);
            listView18.ItemCheck += new ItemCheckEventHandler(listview18_checkbox);
            listView19.ItemCheck += new ItemCheckEventHandler(listview19_checkbox);
            listView20.ItemCheck += new ItemCheckEventHandler(listview20_checkbox);
            listView21.ItemCheck += new ItemCheckEventHandler(listview21_checkbox);
            listView22.ItemCheck += new ItemCheckEventHandler(listview22_checkbox);
          
            ColumnHeader columnHeader_check = new System.Windows.Forms.ColumnHeader();
            ColumnHeader columnHeader_1 = new System.Windows.Forms.ColumnHeader();
            ColumnHeader columnHeader_2 = new System.Windows.Forms.ColumnHeader();
            //ColumnHeader columnHeader_3 = new System.Windows.Forms.ColumnHeader();
       
            columnHeader_1.Text = "업종";
            columnHeader_2.Text = "개수";
            //columnHeader_3.Text = "코드";
            columnHeader_2.TextAlign = HorizontalAlignment.Center;

            listViewSmall.DrawColumnHeader += new DrawListViewColumnHeaderEventHandler(drawListColumnHeader);
            listViewSmall.DrawItem += new DrawListViewItemEventHandler(lv_DrawItem);
            listViewSmall.DrawSubItem += new DrawListViewSubItemEventHandler(lv_DrawSubItem);

            listViewSmall.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { columnHeader_check, columnHeader_1, columnHeader_2 });
            listViewSmall.Columns[0].Width = 22;
            listViewSmall.Columns[1].Width = 150;       
        }
     
        
        private void drawListColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                e.DrawBackground();
                bool value = false;
                try
                {
                    value = Convert.ToBoolean(e.Header.Tag);
                }
                catch (Exception)
                {
                }
                CheckBoxRenderer.DrawCheckBox(e.Graphics, new Point(e.Bounds.Left + 4, e.Bounds.Top + 4),
                    value ? System.Windows.Forms.VisualStyles.CheckBoxState.CheckedNormal :
                    System.Windows.Forms.VisualStyles.CheckBoxState.UncheckedNormal);
            }
            else e.DrawDefault = true;
        }
        private async void lv1_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            await Task.Run(() =>
            {
                foreach (ListViewItem listitem in listView1.Items)
                {
                    if (listitem.Checked == false)
                    {
                        listitem.Checked = true;
                    }
                    else
                    {
                        listitem.Checked = false;
                    }
                }

            });


        }
        private async void lv2_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            await Task.Run(() =>
            {
                foreach (ListViewItem listitem in listView2.Items)
                {
                    if (listitem.Checked == false)
                    {
                        listitem.Checked = true;
                    }
                    else
                    {
                        listitem.Checked = false;
                    }
                }

            });
        }
        private async void lv3_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            await Task.Run(() =>
            {
                foreach (ListViewItem listitem in listView3.Items)
                {
                    if (listitem.Checked == false)
                    {
                        listitem.Checked = true;
                    }
                    else
                    {
                        listitem.Checked = false;
                    }
                }

            });
        }
        private async void lv4_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            await Task.Run(() =>
            {
                foreach (ListViewItem listitem in listView4.Items)
                {
                    if (listitem.Checked == false)
                    {
                        listitem.Checked = true;
                    }
                    else
                    {
                        listitem.Checked = false;
                    }
                }

            });
        }
        private async void lv5_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            await Task.Run(() =>
            {
                foreach (ListViewItem listitem in listView5.Items)
                {
                    if (listitem.Checked == false)
                    {
                        listitem.Checked = true;
                    }
                    else
                    {
                        listitem.Checked = false;
                    }
                }

            });
        }
        private async void lv6_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            await Task.Run(() =>
            {
                foreach (ListViewItem listitem in listView6.Items)
                {
                    if (listitem.Checked == false)
                    {
                        listitem.Checked = true;
                    }
                    else
                    {
                        listitem.Checked = false;
                    }
                }

            });
        }
        private async void lv7_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            await Task.Run(() =>
            {
                foreach (ListViewItem listitem in listView7.Items)
                {
                    if (listitem.Checked == false)
                    {
                        listitem.Checked = true;
                    }
                    else
                    {
                        listitem.Checked = false;
                    }
                }

            });
        }
        private async void lv8_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            await Task.Run(() =>
            {
                foreach (ListViewItem listitem in listView8.Items)
                {
                    if (listitem.Checked == false)
                    {
                        listitem.Checked = true;
                    }
                    else
                    {
                        listitem.Checked = false;
                    }
                }

            });
        }
        private async void lv9_ColumnClick(object sender, ColumnClickEventArgs e)
        {

            await Task.Run(() =>
            {
                foreach (ListViewItem listitem in listView9.Items)
                {
                    if (listitem.Checked == false)
                    {
                        listitem.Checked = true;
                    }
                    else
                    {
                        listitem.Checked = false;
                    }
                }

            });
        }
        private async void lv10_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            await Task.Run(() =>
            {
                foreach (ListViewItem listitem in listView10.Items)
                {
                    if (listitem.Checked == false)
                    {
                        listitem.Checked = true;
                    }
                    else
                    {
                        listitem.Checked = false;
                    }
                }

            });
        }
        private async void lv11_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            await Task.Run(() =>
            {
                foreach (ListViewItem listitem in listView11.Items)
                {
                    if (listitem.Checked == false)
                    {
                        listitem.Checked = true;
                    }
                    else
                    {
                        listitem.Checked = false;
                    }
                }

            });
        }
        private async void lv12_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            await Task.Run(() =>
            {
                foreach (ListViewItem listitem in listView12.Items)
                {
                    if (listitem.Checked == false)
                    {
                        listitem.Checked = true;
                    }
                    else
                    {
                        listitem.Checked = false;
                    }
                }

            });
        }
        private async void lv13_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            await Task.Run(() =>
            {
                foreach (ListViewItem listitem in listView13.Items)
                {
                    if (listitem.Checked == false)
                    {
                        listitem.Checked = true;
                    }
                    else
                    {
                        listitem.Checked = false;
                    }
                }

            });
        }
        private async void lv14_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            await Task.Run(() =>
            {
                foreach (ListViewItem listitem in listView14.Items)
                {
                    if (listitem.Checked == false)
                    {
                        listitem.Checked = true;
                    }
                    else
                    {
                        listitem.Checked = false;
                    }
                }

            });
        }
        private async void lv15_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            await Task.Run(() =>
            {
                foreach (ListViewItem listitem in listView15.Items)
                {
                    if (listitem.Checked == false)
                    {
                        listitem.Checked = true;
                    }
                    else
                    {
                        listitem.Checked = false;
                    }
                }

            });
        }
        private async void lv16_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            await Task.Run(() =>
            {
                foreach (ListViewItem listitem in listView16.Items)
                {
                    if (listitem.Checked == false)
                    {
                        listitem.Checked = true;
                    }
                    else
                    {
                        listitem.Checked = false;
                    }
                }

            });
        }
        private async void lv17_ColumnClick(object sender, ColumnClickEventArgs e)
        {

            await Task.Run(() =>
            {
                foreach (ListViewItem listitem in listView17.Items)
                {
                    if (listitem.Checked == false)
                    {
                        listitem.Checked = true;
                    }
                    else
                    {
                        listitem.Checked = false;
                    }
                }

            });

        }
        private async void lv18_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            await Task.Run(() =>
            {
                foreach (ListViewItem listitem in listView18.Items)
                {
                    if (listitem.Checked == false)
                    {
                        listitem.Checked = true;
                    }
                    else
                    {
                        listitem.Checked = false;
                    }
                }

            });

        }
        private async void lv19_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            await Task.Run(() =>
            {
                foreach (ListViewItem listitem in listView19.Items)
                {
                    if (listitem.Checked == false)
                    {
                        listitem.Checked = true;
                    }
                    else
                    {
                        listitem.Checked = false;
                    }
                }

            });
        }
        private async void lv20_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            await Task.Run(() =>
            {
                foreach (ListViewItem listitem in listView20.Items)
                {
                    if (listitem.Checked == false)
                    {
                        listitem.Checked = true;
                    }
                    else
                    {
                        listitem.Checked = false;
                    }
                }

            });
        }
        private async void lv21_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            await Task.Run(() =>
            {
                foreach (ListViewItem listitem in listView21.Items)
                {
                    if (listitem.Checked == false)
                    {
                        listitem.Checked = true;
                    }
                    else
                    {
                        listitem.Checked = false;
                    }
                }

            });
        }
        private async void lv22_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            await Task.Run(() =>
            {
                foreach (ListViewItem listitem in listView22.Items)
                {
                    if (listitem.Checked == false)
                    {
                        listitem.Checked = true;
                    }
                    else
                    {
                        listitem.Checked = false;
                    }
                }

            });
        }

        private async void lvSmall_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            await Task.Run(() =>
            {
                foreach (ListViewItem listitem in listViewSmall.Items)
                {
                    if (listitem.Checked == false)
                    {
                        listitem.Checked = true;
                    }
                    else
                    {
                        listitem.Checked = false;
                    }
                }

            });
        }
        private void lv_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawDefault = true;
        }
        private void lv_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            e.DrawDefault = true;
        }
        void listview_checkbox(object sender, ItemCheckEventArgs e)
        {
           
                if(e.CurrentValue == CheckState.Unchecked)
                {
                    // 체크박스 선택 시
                    bgroup = this.listView1.Items[e.Index].SubItems[3].Text;
                    bgroupN = this.listView1.Items[e.Index].SubItems[1].Text;
                    GetCgroup(dbId, dbPw, dbIp, bgroup, bgroupN);
                            
                }
                else if(e.CurrentValue == CheckState.Checked)
                {
                    //체크박스 해제 시
                    DelGroup = this.listView1.Items[e.Index].SubItems[3].Text;
                    DelGroupN = this.listView1.Items[e.Index].SubItems[1].Text;
                    RemoveCgroup(dbId, dbPw, dbIp, DelGroup, DelGroupN);
       
                }

            
        }

        void listview2_checkbox(object sender, ItemCheckEventArgs e)
        {
            if (e.CurrentValue == CheckState.Unchecked)
            {
                // 체크박스 선택 시
                bgroup = this.listView2.Items[e.Index].SubItems[3].Text;
                bgroupN = this.listView2.Items[e.Index].SubItems[1].Text;
                GetCgroup(dbId, dbPw, dbIp, bgroup, bgroupN);
            }
            else if (e.CurrentValue == CheckState.Checked)
            {
                //체크박스 해제 시
                DelGroup = this.listView2.Items[e.Index].SubItems[3].Text;
                DelGroupN = this.listView2.Items[e.Index].SubItems[1].Text;
                RemoveCgroup(dbId, dbPw, dbIp, DelGroup, DelGroupN);
            }
        }

        void listview3_checkbox(object sender, ItemCheckEventArgs e)
        {
            if (e.CurrentValue == CheckState.Unchecked)
            {
                // 체크박스 선택 시
                bgroup = this.listView3.Items[e.Index].SubItems[3].Text;
                bgroupN = this.listView3.Items[e.Index].SubItems[1].Text;
                GetCgroup(dbId, dbPw, dbIp, bgroup, bgroupN);
            }
            else if (e.CurrentValue == CheckState.Checked)
            {
                //체크박스 해제 시
                DelGroup = this.listView3.Items[e.Index].SubItems[3].Text;
                DelGroupN = this.listView3.Items[e.Index].SubItems[1].Text;
                RemoveCgroup(dbId, dbPw, dbIp, DelGroup, DelGroupN);
            }
        }

        void listview4_checkbox(object sender, ItemCheckEventArgs e)
        {
            if (e.CurrentValue == CheckState.Unchecked)
            {
                // 체크박스 선택 시
                bgroup = this.listView4.Items[e.Index].SubItems[3].Text;
                bgroupN = this.listView4.Items[e.Index].SubItems[1].Text;
                GetCgroup(dbId, dbPw, dbIp, bgroup, bgroupN);
            }
            else if (e.CurrentValue == CheckState.Checked)
            {
                //체크박스 해제 시
                DelGroup = this.listView4.Items[e.Index].SubItems[3].Text;
                DelGroupN = this.listView4.Items[e.Index].SubItems[1].Text;
                RemoveCgroup(dbId, dbPw, dbIp, DelGroup, DelGroupN);
            }
        }

        void listview5_checkbox(object sender, ItemCheckEventArgs e)
        {
            if (e.CurrentValue == CheckState.Unchecked)
            {
                // 체크박스 선택 시
                bgroup = this.listView5.Items[e.Index].SubItems[3].Text;
                bgroupN = this.listView5.Items[e.Index].SubItems[1].Text;
                GetCgroup(dbId, dbPw, dbIp, bgroup, bgroupN);
            }
            else if (e.CurrentValue == CheckState.Checked)
            {
                //체크박스 해제 시
                DelGroup = this.listView5.Items[e.Index].SubItems[3].Text;
                DelGroupN = this.listView5.Items[e.Index].SubItems[1].Text;
                RemoveCgroup(dbId, dbPw, dbIp, DelGroup, DelGroupN);
            }
        }

        void listview6_checkbox(object sender, ItemCheckEventArgs e)
        {
            if (e.CurrentValue == CheckState.Unchecked)
            {
                // 체크박스 선택 시
                bgroup = this.listView6.Items[e.Index].SubItems[3].Text;
                bgroupN = this.listView6.Items[e.Index].SubItems[1].Text;
                GetCgroup(dbId, dbPw, dbIp, bgroup, bgroupN);
            }
            else if (e.CurrentValue == CheckState.Checked)
            {
                //체크박스 해제 시
                DelGroup = this.listView6.Items[e.Index].SubItems[3].Text;
                DelGroupN = this.listView6.Items[e.Index].SubItems[1].Text;
                RemoveCgroup(dbId, dbPw, dbIp, DelGroup, DelGroupN);
            }
        }

        void listview7_checkbox(object sender, ItemCheckEventArgs e)
        {
            if (e.CurrentValue == CheckState.Unchecked)
            {
                // 체크박스 선택 시
                bgroup = this.listView7.Items[e.Index].SubItems[3].Text;
                bgroupN = this.listView7.Items[e.Index].SubItems[1].Text;
                GetCgroup(dbId, dbPw, dbIp, bgroup, bgroupN);
            }
            else if (e.CurrentValue == CheckState.Checked)
            {
                //체크박스 해제 시
                DelGroup = this.listView7.Items[e.Index].SubItems[3].Text;
                DelGroupN = this.listView7.Items[e.Index].SubItems[1].Text;
                RemoveCgroup(dbId, dbPw, dbIp, DelGroup, DelGroupN);
            }
        }

        void listview8_checkbox(object sender, ItemCheckEventArgs e)
        {
            if (e.CurrentValue == CheckState.Unchecked)
            {
                // 체크박스 선택 시
                bgroup = this.listView8.Items[e.Index].SubItems[3].Text;
                bgroupN = this.listView8.Items[e.Index].SubItems[1].Text;
                GetCgroup(dbId, dbPw, dbIp, bgroup, bgroupN);
            }
            else if (e.CurrentValue == CheckState.Checked)
            {
                //체크박스 해제 시
                DelGroup = this.listView8.Items[e.Index].SubItems[3].Text;
                DelGroupN = this.listView8.Items[e.Index].SubItems[1].Text;
                RemoveCgroup(dbId, dbPw, dbIp, DelGroup, DelGroupN);
            }
        }

        void listview9_checkbox(object sender, ItemCheckEventArgs e)
        {
            if (e.CurrentValue == CheckState.Unchecked)
            {
                // 체크박스 선택 시
                bgroup = this.listView9.Items[e.Index].SubItems[3].Text;
                bgroupN = this.listView9.Items[e.Index].SubItems[1].Text;
                GetCgroup(dbId, dbPw, dbIp, bgroup, bgroupN);
            }
            else if (e.CurrentValue == CheckState.Checked)
            {
                //체크박스 해제 시
                DelGroup = this.listView9.Items[e.Index].SubItems[3].Text;
                DelGroupN = this.listView9.Items[e.Index].SubItems[1].Text;
                RemoveCgroup(dbId, dbPw, dbIp, DelGroup, DelGroupN);
            }
        }

        void listview10_checkbox(object sender, ItemCheckEventArgs e)
        {
            if (e.CurrentValue == CheckState.Unchecked)
            {
                // 체크박스 선택 시
                bgroup = this.listView10.Items[e.Index].SubItems[3].Text;
                bgroupN = this.listView10.Items[e.Index].SubItems[1].Text;
                GetCgroup(dbId, dbPw, dbIp, bgroup, bgroupN);
            }
            else if (e.CurrentValue == CheckState.Checked)
            {
                //체크박스 해제 시
                DelGroup = this.listView10.Items[e.Index].SubItems[3].Text;
                DelGroupN = this.listView10.Items[e.Index].SubItems[1].Text;
                RemoveCgroup(dbId, dbPw, dbIp, DelGroup, DelGroupN);
            }
        }

        void listview11_checkbox(object sender, ItemCheckEventArgs e)
        {
            if (e.CurrentValue == CheckState.Unchecked)
            {
                // 체크박스 선택 시
                bgroup = this.listView11.Items[e.Index].SubItems[3].Text;
                bgroupN = this.listView11.Items[e.Index].SubItems[1].Text;
                GetCgroup(dbId, dbPw, dbIp, bgroup, bgroupN);
            }
            else if (e.CurrentValue == CheckState.Checked)
            {
                //체크박스 해제 시
                DelGroup = this.listView11.Items[e.Index].SubItems[3].Text;
                DelGroupN = this.listView11.Items[e.Index].SubItems[1].Text;
                RemoveCgroup(dbId, dbPw, dbIp, DelGroup, DelGroupN);
            }
        }

        void listview12_checkbox(object sender, ItemCheckEventArgs e)
        {
            if (e.CurrentValue == CheckState.Unchecked)
            {
                // 체크박스 선택 시
                bgroup = this.listView12.Items[e.Index].SubItems[3].Text;
                bgroupN = this.listView12.Items[e.Index].SubItems[1].Text;
                GetCgroup(dbId, dbPw, dbIp, bgroup, bgroupN);
            }
            else if (e.CurrentValue == CheckState.Checked)
            {
                //체크박스 해제 시
                DelGroup = this.listView12.Items[e.Index].SubItems[3].Text;
                DelGroupN = this.listView12.Items[e.Index].SubItems[1].Text;
                RemoveCgroup(dbId, dbPw, dbIp, DelGroup, DelGroupN);
            }
        }

        void listview13_checkbox(object sender, ItemCheckEventArgs e)
        {
            if (e.CurrentValue == CheckState.Unchecked)
            {
                // 체크박스 선택 시
                bgroup = this.listView13.Items[e.Index].SubItems[3].Text;
                bgroupN = this.listView13.Items[e.Index].SubItems[1].Text;
                GetCgroup(dbId, dbPw, dbIp, bgroup, bgroupN);
            }
            else if (e.CurrentValue == CheckState.Checked)
            {
                //체크박스 해제 시
                DelGroup = this.listView13.Items[e.Index].SubItems[3].Text;
                DelGroupN = this.listView13.Items[e.Index].SubItems[1].Text;
                RemoveCgroup(dbId, dbPw, dbIp, DelGroup, DelGroupN);
            }
        }

        void listview14_checkbox(object sender, ItemCheckEventArgs e)
        {
            if (e.CurrentValue == CheckState.Unchecked)
            {
                // 체크박스 선택 시
                bgroup = this.listView14.Items[e.Index].SubItems[3].Text;
                bgroupN = this.listView14.Items[e.Index].SubItems[1].Text;
                GetCgroup(dbId, dbPw, dbIp, bgroup, bgroupN);
            }
            else if (e.CurrentValue == CheckState.Checked)
            {
                //체크박스 해제 시
                DelGroup = this.listView14.Items[e.Index].SubItems[3].Text;
                DelGroupN = this.listView14.Items[e.Index].SubItems[1].Text;
                RemoveCgroup(dbId, dbPw, dbIp, DelGroup, DelGroupN);
            }
        }

        void listview15_checkbox(object sender, ItemCheckEventArgs e)
        {
            if (e.CurrentValue == CheckState.Unchecked)
            {
                // 체크박스 선택 시
                bgroup = this.listView15.Items[e.Index].SubItems[3].Text;
                bgroupN = this.listView15.Items[e.Index].SubItems[1].Text;
                GetCgroup(dbId, dbPw, dbIp, bgroup, bgroupN);
            }
            else if (e.CurrentValue == CheckState.Checked)
            {
                //체크박스 해제 시
                DelGroup = this.listView15.Items[e.Index].SubItems[3].Text;
                DelGroupN = this.listView15.Items[e.Index].SubItems[1].Text;
                RemoveCgroup(dbId, dbPw, dbIp, DelGroup, DelGroupN);
            }
        }

        void listview16_checkbox(object sender, ItemCheckEventArgs e)
        {
            if (e.CurrentValue == CheckState.Unchecked)
            {
                // 체크박스 선택 시
                bgroup = this.listView16.Items[e.Index].SubItems[3].Text;
                bgroupN = this.listView16.Items[e.Index].SubItems[1].Text;
                GetCgroup(dbId, dbPw, dbIp, bgroup, bgroupN);
            }
            else if (e.CurrentValue == CheckState.Checked)
            {
                //체크박스 해제 시
                DelGroup = this.listView16.Items[e.Index].SubItems[3].Text;
                DelGroupN = this.listView16.Items[e.Index].SubItems[1].Text;
                RemoveCgroup(dbId, dbPw, dbIp, DelGroup, DelGroupN);
            }
        }

        void listview17_checkbox(object sender, ItemCheckEventArgs e)
        {
            if (e.CurrentValue == CheckState.Unchecked)
            {
             
                // 체크박스 선택 시
                bgroup = this.listView17.Items[e.Index].SubItems[3].Text;
                bgroupN = this.listView17.Items[e.Index].SubItems[1].Text;
                GetCgroup(dbId, dbPw, dbIp, bgroup, bgroupN);
            }
            else if (e.CurrentValue == CheckState.Checked)
            {
                //체크박스 해제 시
                DelGroup = this.listView17.Items[e.Index].SubItems[3].Text;
                DelGroupN = this.listView17.Items[e.Index].SubItems[1].Text;
                RemoveCgroup(dbId, dbPw, dbIp, DelGroup, DelGroupN);
            }
        }

        void listview18_checkbox(object sender, ItemCheckEventArgs e)
        {            
                if (e.CurrentValue == CheckState.Unchecked)
                {               
                    // 체크박스 선택                    
                    bgroup = this.listView18.Items[e.Index].SubItems[3].Text;
                    bgroupN = this.listView18.Items[e.Index].SubItems[1].Text;                       
                    GetCgroup(dbId, dbPw, dbIp, bgroup, bgroupN);                  
                }
                else if (e.CurrentValue == CheckState.Checked)
                {
                    //체크박스 해제 시
                    DelGroup = this.listView18.Items[e.Index].SubItems[3].Text;
                    DelGroupN = this.listView18.Items[e.Index].SubItems[1].Text;            
                    RemoveCgroup(dbId, dbPw, dbIp, DelGroup, DelGroupN);
                      
                }          

            
        }

        void listview19_checkbox(object sender, ItemCheckEventArgs e)
        {
            if (e.CurrentValue == CheckState.Unchecked)
            {
                // 체크박스 선택 시
                bgroup = this.listView19.Items[e.Index].SubItems[3].Text;
                bgroupN = this.listView19.Items[e.Index].SubItems[1].Text;
                GetCgroup(dbId, dbPw, dbIp, bgroup, bgroupN);
            }
            else if (e.CurrentValue == CheckState.Checked)
            {
                //체크박스 해제 시
                DelGroup = this.listView19.Items[e.Index].SubItems[3].Text;
                DelGroupN = this.listView19.Items[e.Index].SubItems[1].Text;
                RemoveCgroup(dbId, dbPw, dbIp, DelGroup, DelGroupN);
            }
        }

        void listview20_checkbox(object sender, ItemCheckEventArgs e)
        {
            if (e.CurrentValue == CheckState.Unchecked)
            {
                // 체크박스 선택 시
                bgroup = this.listView20.Items[e.Index].SubItems[3].Text;
                bgroupN = this.listView20.Items[e.Index].SubItems[1].Text;
                GetCgroup(dbId, dbPw, dbIp, bgroup, bgroupN);
            }
            else if (e.CurrentValue == CheckState.Checked)
            {
                //체크박스 해제 시
                DelGroup = this.listView20.Items[e.Index].SubItems[3].Text;
                DelGroupN = this.listView20.Items[e.Index].SubItems[1].Text;
                RemoveCgroup(dbId, dbPw, dbIp, DelGroup, DelGroupN);
            }
        }

        void listview21_checkbox(object sender, ItemCheckEventArgs e)
        {
            if (e.CurrentValue == CheckState.Unchecked)
            {
                // 체크박스 선택 시
                bgroup = this.listView21.Items[e.Index].SubItems[3].Text;
                bgroupN = this.listView21.Items[e.Index].SubItems[1].Text;
                GetCgroup(dbId, dbPw, dbIp, bgroup, bgroupN);
            }
            else if (e.CurrentValue == CheckState.Checked)
            {
                //체크박스 해제 시
                DelGroup = this.listView21.Items[e.Index].SubItems[3].Text;
                DelGroupN = this.listView21.Items[e.Index].SubItems[1].Text;
                RemoveCgroup(dbId, dbPw, dbIp, DelGroup, DelGroupN);
            }
        }

        void listview22_checkbox(object sender, ItemCheckEventArgs e)
        {
            if (e.CurrentValue == CheckState.Unchecked)
            {
                // 체크박스 선택 시
                bgroup = this.listView22.Items[e.Index].SubItems[3].Text;
                bgroupN = this.listView22.Items[e.Index].SubItems[1].Text;
                GetCgroup(dbId, dbPw, dbIp, bgroup, bgroupN);
            }
            else if (e.CurrentValue == CheckState.Checked)
            {
                //체크박스 해제 시
                DelGroup = this.listView22.Items[e.Index].SubItems[3].Text;
                DelGroupN = this.listView22.Items[e.Index].SubItems[1].Text;
                RemoveCgroup(dbId, dbPw, dbIp, DelGroup, DelGroupN);
            }
        }

        private void GetAgroup(string dbId, string dbPw, string dbIp)
        {
            string strConn = "Server=" + dbIp + ";database=Intranet;" + "uid=" + dbId + ";pwd=" + dbPw + ";";
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                Asql = "select Format(count(AGroup),'#,#') as agroupCnt, (select description from CommCode with(nolock) where AGroup = code) as agroupName, agroup as agroupCode from CLV2Data(nolock) group by aGroup";

                conn.Open();

                SqlCommand dbcmd = new SqlCommand(Asql, conn);
                SqlDataReader reader = dbcmd.ExecuteReader();

                while (reader.Read())
                {
                    agroupName = reader["agroupName"].ToString();
                    agroupCnt = reader["agroupCnt"].ToString();
                    agroupCode = reader["agroupCode"].ToString();
                    aList.Add(new List<string> { agroupName, agroupCnt.ToString(), agroupCode });


                }
                reader.Close();
            }
        }

        private void GetBgroup(string dbId, string dbPw, string dbIp)
        {
            string strConn = "Server="+ dbIp + ";database=Intranet;" + "uid=" + dbId + ";pwd=" + dbPw + ";";
            using (SqlConnection conn = new SqlConnection(strConn))
            {
            Bsql = "select count(BGroup) as bgroupCnt, (select description from CommCode with(nolock) where BGroup = code) as bgroupName, bgroup from CLV2Data(nolock) where  agroup='A001' group by bGroup";

            conn.Open();

            SqlCommand dbcmd = new SqlCommand(Bsql, conn);
            SqlDataReader reader = dbcmd.ExecuteReader();
    
                while (reader.Read())
                {
                    bgroupName = reader["bgroupName"].ToString();
                    bgroupCnt = reader["bgroupCnt"].ToString();
                    bgroup = reader["bgroup"].ToString();
                }
                reader.Close();            

            }

        }

        private void RemoveCgroup(string dbId, string dbPw, string dbIp, string bgroupCode, string bgroupName)
        {
         
            string strConn = "Server=" + dbIp + ";database=Intranet;" + "uid=" + dbId + ";pwd=" + dbPw + ";";
            SqlConnection conn = new SqlConnection(strConn);

            Csql = "select count(CGroup) as cgroupCnt, (select description from CommCode with(nolock) where CGroup = code) as cgroup, cgroup as cgroupCode from CLV2Data(nolock)";
            Csql = Csql + " where bgroup= @bgroupCode group by CGroup order by cgroupCnt desc";

            conn.Open();
            SqlCommand dbcmd = new SqlCommand(Csql, conn);

            SqlParameter paramBgroupCode = new SqlParameter("@bgroupCode", SqlDbType.NVarChar, 15);
            paramBgroupCode.Value = bgroupCode;
            dbcmd.Parameters.Add(paramBgroupCode);

            SqlDataReader reader = dbcmd.ExecuteReader();

            while (reader.Read())
            {
                delGroupName = reader["cgroup"].ToString();
                delGroupCode = reader["cgroupCode"].ToString();
                if (delGroupName != null || delGroupName != "")
                {
                    var item = listViewSmall.FindItemWithText(delGroupName);
                    if (item != null)
                    {
                        int ind = listViewSmall.Items.IndexOf(item);
                        try
                        {
                            listViewSmall.BeginUpdate();
                            listViewSmall.Items.RemoveAt(ind);
                        }
                        finally
                        {
                            listViewSmall.EndUpdate();
                        }

                    }
                }               
            }       
                conn.Close();
        }

        private void GetCgroup(string dbId, string dbPw, string dbIp, string bgroupCode, string bgroupName)
        {
            string strConn = "Server=" + dbIp + ";database=Intranet;" + "uid=" + dbId + ";pwd=" + dbPw + ";";
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                Csql = "select count(CGroup) as cgroupCnt, (select description from CommCode with(nolock) where CGroup = code) as cgroup, cgroup as cgcode from CLV2Data(nolock)"; 
                Csql = Csql + " where bgroup= @bgroupCode group by CGroup order by cgcode asc ";
         
                conn.Open();
                SqlCommand dbcmd = new SqlCommand(Csql, conn);
                SqlParameter paramBgroupCode = new SqlParameter("@bgroupCode", SqlDbType.NVarChar, 15);          
                paramBgroupCode.Value = bgroupCode;
                dbcmd.Parameters.Add(paramBgroupCode);
                SqlDataReader reader = dbcmd.ExecuteReader();

                while (reader.Read())
                {         
                    cgroupName = reader["cgroup"].ToString();
                    cgroupCnt = reader["cgroupCnt"].ToString();
                    cgcode = reader["cgcode"].ToString();

                    ListViewItem Dlv = new ListViewItem();
                    Dlv.Name = cgroupName;
                    Dlv.SubItems.Add(cgroupName);
                    Dlv.SubItems.Add(cgroupCnt);
                    Dlv.SubItems.Add(cgcode);
                    Dlv.Checked = true;
                    
                    if (listViewSmall.Items.ContainsKey(cgroupName.Trim().ToString()))
                    {           
                    }
                    else
                    {
                        try
                        {                            
                            listViewSmall.BeginUpdate();
                            listViewSmall.Items.Add(Dlv);
                        }
                        finally
                        {
                            listViewSmall.EndUpdate();
                        }               
                    }
                }
                reader.Close();
            }
          
        }

        [DllImport("kernel32")]
        private static extern long GetPrivateProfileString(string section, string key, string def, StringBuilder reVal, int size, string filepath);

        public DirectoryInfo DbDirectory = new DirectoryInfo(Application.StartupPath + @"\dbAccount.ini");

        private string INI_READ(string inputSection, string inputKey)
        {
            StringBuilder sb = new StringBuilder(255);
            GetPrivateProfileString(inputSection, inputKey, "", sb, 255, DbDirectory.ToString());

            return sb.ToString();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        private void DataClass_Load(object sender, EventArgs e)
        {
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.MultiSelect = true;
            dataGridView1.ReadOnly = true;
            dataGridView1.ColumnHeadersVisible = true;

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dataGridView1.RowHeadersWidth = 60;

            listViewSmall.View = System.Windows.Forms.View.Details;
            listViewSmall.GridLines = true;
            listViewSmall.CheckBoxes = true;
            listViewSmall.Groups.Clear();
            listViewSmall.Items.Clear();
            listViewSmall.ColumnClick += new ColumnClickEventHandler(lvSmall_ColumnClick);

            listView1.View = System.Windows.Forms.View.Details;
            listView1.CheckBoxes = true;
            listView1.GridLines = true;
            listView1.Groups.Clear();
            listView1.Items.Clear();

            listView2.View = System.Windows.Forms.View.Details;
            listView2.CheckBoxes = true;
            listView2.GridLines = true;
            listView2.Groups.Clear();
            listView2.Items.Clear();

            listView3.View = System.Windows.Forms.View.Details;
            listView3.CheckBoxes = true;
            listView3.GridLines = true;
            listView3.Groups.Clear();
            listView3.Items.Clear();

            listView4.View = System.Windows.Forms.View.Details;
            listView4.CheckBoxes = true;
            listView4.GridLines = true;
            listView4.Groups.Clear();
            listView4.Items.Clear();

            listView5.View = System.Windows.Forms.View.Details;
            listView5.CheckBoxes = true;
            listView5.GridLines = true;
            listView5.Groups.Clear();
            listView5.Items.Clear();

            listView6.View = System.Windows.Forms.View.Details;
            listView6.CheckBoxes = true;
            listView6.GridLines = true;
            listView6.Groups.Clear();
            listView6.Items.Clear();

            listView7.View = System.Windows.Forms.View.Details;
            listView7.CheckBoxes = true;
            listView7.GridLines = true;
            listView7.Groups.Clear();
            listView7.Items.Clear();

            listView8.View = System.Windows.Forms.View.Details;
            listView8.CheckBoxes = true;
            listView8.GridLines = true;
            listView8.Groups.Clear();
            listView8.Items.Clear();

            listView9.View = System.Windows.Forms.View.Details;
            listView9.CheckBoxes = true;
            listView9.GridLines = true;
            listView9.Groups.Clear();
            listView9.Items.Clear();

            listView10.View = System.Windows.Forms.View.Details;
            listView10.CheckBoxes = true;
            listView10.GridLines = true;
            listView10.Groups.Clear();
            listView10.Items.Clear();
            
            listView11.View = System.Windows.Forms.View.Details;
            listView11.CheckBoxes = true;
            listView11.GridLines = true;
            listView11.Groups.Clear();
            listView11.Items.Clear();

            listView12.View = System.Windows.Forms.View.Details;
            listView12.CheckBoxes = true;
            listView12.GridLines = true;
            listView12.Groups.Clear();
            listView12.Items.Clear();

            listView13.View = System.Windows.Forms.View.Details;
            listView13.CheckBoxes = true;
            listView13.GridLines = true;
            listView13.Groups.Clear();
            listView13.Items.Clear();

            listView14.View = System.Windows.Forms.View.Details;
            listView14.CheckBoxes = true;
            listView14.GridLines = true;
            listView14.Groups.Clear();
            listView14.Items.Clear();

            listView15.View = System.Windows.Forms.View.Details;
            listView15.CheckBoxes = true;
            listView15.GridLines = true;
            listView15.Groups.Clear();
            listView15.Items.Clear();

            listView16.View = System.Windows.Forms.View.Details;
            listView16.CheckBoxes = true;
            listView16.GridLines = true;
            listView16.Groups.Clear();
            listView16.Items.Clear();

            listView17.View = System.Windows.Forms.View.Details;
            listView17.CheckBoxes = true;
            listView17.GridLines = true;
            listView17.Groups.Clear();
            listView17.Items.Clear();

            listView18.View = System.Windows.Forms.View.Details;
            listView18.CheckBoxes = true;
            listView18.GridLines = true;
            listView18.Groups.Clear();
            listView18.Items.Clear();

            listView19.View = System.Windows.Forms.View.Details;
            listView19.CheckBoxes = true;
            listView19.GridLines = true;
            listView19.Groups.Clear();
            listView19.Items.Clear();
            
            listView20.View = System.Windows.Forms.View.Details;
            listView20.CheckBoxes = true;
            listView20.GridLines = true;
            listView20.Groups.Clear();

            listView21.View = System.Windows.Forms.View.Details;
            listView21.CheckBoxes = true;
            listView21.GridLines = true;
            listView21.Groups.Clear();
            listView21.Items.Clear();

            listView22.View = System.Windows.Forms.View.Details;
            listView22.CheckBoxes = true;
            listView22.GridLines = true;
            listView22.Groups.Clear();
            listView22.Items.Clear();

            GetAgroup(dbId, dbPw, dbIp);
            listview1Agroup(dbId, dbPw, dbIp);
            listview2Agroup(dbId, dbPw, dbIp);
            listview3Agroup(dbId, dbPw, dbIp);
            listview4Agroup(dbId, dbPw, dbIp);
            listview5Agroup(dbId, dbPw, dbIp);
            listview6Agroup(dbId, dbPw, dbIp);
            listview7Agroup(dbId, dbPw, dbIp);
            listview8Agroup(dbId, dbPw, dbIp);
            listview9Agroup(dbId, dbPw, dbIp);
            listview10Agroup(dbId, dbPw, dbIp);
            listview11Agroup(dbId, dbPw, dbIp);
            listview12Agroup(dbId, dbPw, dbIp);
            listview13Agroup(dbId, dbPw, dbIp);
            listview14Agroup(dbId, dbPw, dbIp);
            listview15Agroup(dbId, dbPw, dbIp);
            listview16Agroup(dbId, dbPw, dbIp);
            listview17Agroup(dbId, dbPw, dbIp);
            listview18Agroup(dbId, dbPw, dbIp);
            listview19Agroup(dbId, dbPw, dbIp);
            listview20Agroup(dbId, dbPw, dbIp);
            listview21Agroup(dbId, dbPw, dbIp);
            listview22Agroup(dbId, dbPw, dbIp);

            GetBgroup(dbId, dbPw, dbIp);

        }

        private void listview1Agroup(string dbId, string dbPw, string dbIp)
        {
            string strConn = "Server=" + dbIp + ";database=Intranet;" + "uid=" + dbId + ";pwd=" + dbPw + ";";
            using (SqlConnection conn = new SqlConnection(strConn))
            {
            string aGN = aList[0][0];
            string aGC = aList[0][1].ToString();
            string aGCode = aList[0][2].ToString();
            string SQL = "";

            ColumnHeader columnHeader_check = new System.Windows.Forms.ColumnHeader();
            ColumnHeader columnHeader_1 = new System.Windows.Forms.ColumnHeader();
            ColumnHeader columnHeader_2 = new System.Windows.Forms.ColumnHeader();
            columnHeader_1.Text = aGN;
            columnHeader_2.Text = aGC;
            columnHeader_2.TextAlign = HorizontalAlignment.Center;

            listView1.DrawColumnHeader += new DrawListViewColumnHeaderEventHandler(drawListColumnHeader);
            listView1.DrawItem += new DrawListViewItemEventHandler(lv_DrawItem);
            listView1.DrawSubItem += new DrawListViewSubItemEventHandler(lv_DrawSubItem);
            listView1.ColumnClick += new ColumnClickEventHandler(lv1_ColumnClick);

            listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { columnHeader_check, columnHeader_1, columnHeader_2 });
            listView1.Columns[0].Width = 22;
            listView1.Columns[1].Width = 150;


            SQL = "select bgroup as bgc, Format(count(bgroup), '#,#') as bgroupCount, (select description from CommCode with(nolock) where BGroup = code) as bgroupName ";
            SQL = SQL + " from clv2data(nolock) where agroup=@agroupCode group by bgroup order by bgroupCount desc";

            conn.Open();
            SqlCommand dbcmd = new SqlCommand(SQL, conn);

            SqlParameter paramBgroupCode = new SqlParameter("@agroupCode", SqlDbType.NVarChar, 15);
            paramBgroupCode.Value = aGCode;
            dbcmd.Parameters.Add(paramBgroupCode);

            SqlDataReader reader = dbcmd.ExecuteReader();

            while (reader.Read())
            {
                bgroupName = reader["bgroupName"].ToString();
                bgroupCnt = reader["bgroupCount"].ToString();
                bgroup = reader["bgc"].ToString();

                Clv = new ListViewItem();
                Clv.Name = bgroupName;
                Clv.SubItems.Add(bgroupName);
                Clv.SubItems.Add(bgroupCnt);
                Clv.SubItems.Add(bgroup);
                listView1.Items.Add(Clv);
            }
            reader.Close();
            }
        }

        private void listview2Agroup(string dbId, string dbPw, string dbIp)
        {
            string strConn = "Server=" + dbIp + ";database=Intranet;" + "uid=" + dbId + ";pwd=" + dbPw + ";";
            using (SqlConnection conn = new SqlConnection(strConn))
            {
            string aGN = aList[1][0];
            string aGC = aList[1][1].ToString();
            string aGCode = aList[1][2].ToString();
            string SQL = "";

            ColumnHeader columnHeader_check = new System.Windows.Forms.ColumnHeader();
            ColumnHeader columnHeader_1 = new System.Windows.Forms.ColumnHeader();
            ColumnHeader columnHeader_2 = new System.Windows.Forms.ColumnHeader();
            columnHeader_1.Text = aGN;
            columnHeader_2.Text = aGC;
            columnHeader_2.TextAlign = HorizontalAlignment.Center;

            listView2.DrawColumnHeader += new DrawListViewColumnHeaderEventHandler(drawListColumnHeader);
            listView2.DrawItem += new DrawListViewItemEventHandler(lv_DrawItem);
            listView2.DrawSubItem += new DrawListViewSubItemEventHandler(lv_DrawSubItem);
            listView2.ColumnClick += new ColumnClickEventHandler(lv2_ColumnClick);

            listView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { columnHeader_check, columnHeader_1, columnHeader_2 });
            listView2.Columns[0].Width = 22;
            listView2.Columns[1].Width = 150;

            SQL = "select bgroup as bgc, Format(count(bgroup), '#,#') as bgroupCount, (select description from CommCode with(nolock) where BGroup = code) as bgroupName ";
            SQL = SQL + " from clv2data(nolock) where agroup=@agroupCode group by bgroup order by bgroupCount desc";

            conn.Open();
            SqlCommand dbcmd = new SqlCommand(SQL, conn);

            SqlParameter paramBgroupCode = new SqlParameter("@agroupCode", SqlDbType.NVarChar, 15);
            paramBgroupCode.Value = aGCode;
            dbcmd.Parameters.Add(paramBgroupCode);

            SqlDataReader reader = dbcmd.ExecuteReader();

            while (reader.Read())
            {
                bgroupName = reader["bgroupName"].ToString();
                bgroupCnt = reader["bgroupCount"].ToString();
                bgroup = reader["bgc"].ToString();

                Clv = new ListViewItem();
                Clv.Name = bgroupName;
                Clv.SubItems.Add(bgroupName);
                Clv.SubItems.Add(bgroupCnt);
                Clv.SubItems.Add(bgroup);
                listView2.Items.Add(Clv);
            }
            reader.Close();

            }
        }

        private void listview3Agroup(string dbId, string dbPw, string dbIp)
        {
            string strConn = "Server=" + dbIp + ";database=Intranet;" + "uid=" + dbId + ";pwd=" + dbPw + ";";
            using (SqlConnection conn = new SqlConnection(strConn))
            {
            string aGN = aList[2][0];
            string aGC = aList[2][1].ToString();
            string aGCode = aList[2][2].ToString();
            string SQL = "";

            ColumnHeader columnHeader_check = new System.Windows.Forms.ColumnHeader();
            ColumnHeader columnHeader_1 = new System.Windows.Forms.ColumnHeader();
            ColumnHeader columnHeader_2 = new System.Windows.Forms.ColumnHeader();
            columnHeader_1.Text = aGN;
            columnHeader_2.Text = aGC;
            columnHeader_2.TextAlign = HorizontalAlignment.Center;

            listView3.DrawColumnHeader += new DrawListViewColumnHeaderEventHandler(drawListColumnHeader);
            listView3.DrawItem += new DrawListViewItemEventHandler(lv_DrawItem);
            listView3.DrawSubItem += new DrawListViewSubItemEventHandler(lv_DrawSubItem);
            listView3.ColumnClick += new ColumnClickEventHandler(lv3_ColumnClick);

            listView3.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { columnHeader_check, columnHeader_1, columnHeader_2 });
            listView3.Columns[0].Width = 22;
            listView3.Columns[1].Width = 150;

            SQL = "select bgroup as bgc, Format(count(bgroup), '#,#') as bgroupCount, (select description from CommCode with(nolock) where BGroup = code) as bgroupName ";
            SQL = SQL + " from clv2data(nolock) where agroup=@agroupCode group by bgroup order by bgroupCount desc";

            conn.Open();
            SqlCommand dbcmd = new SqlCommand(SQL, conn);

            SqlParameter paramBgroupCode = new SqlParameter("@agroupCode", SqlDbType.NVarChar, 15);
            paramBgroupCode.Value = aGCode;
            dbcmd.Parameters.Add(paramBgroupCode);

            SqlDataReader reader = dbcmd.ExecuteReader();

            while (reader.Read())
            {
                bgroupName = reader["bgroupName"].ToString();
                bgroupCnt = reader["bgroupCount"].ToString();
                bgroup = reader["bgc"].ToString();

                Clv = new ListViewItem();
                Clv.Name = bgroupName;
                Clv.SubItems.Add(bgroupName);
                Clv.SubItems.Add(bgroupCnt);
                Clv.SubItems.Add(bgroup);
                listView3.Items.Add(Clv);
            }
            reader.Close();

            }
        }

        private void listview4Agroup(string dbId, string dbPw, string dbIp)
        {
            string strConn = "Server=" + dbIp + ";database=Intranet;" + "uid=" + dbId + ";pwd=" + dbPw + ";";
            using (SqlConnection conn = new SqlConnection(strConn))
            {
            string aGN = aList[3][0];
            string aGC = aList[3][1].ToString();
            string aGCode = aList[3][2].ToString();
            string SQL = "";

            ColumnHeader columnHeader_check = new System.Windows.Forms.ColumnHeader();
            ColumnHeader columnHeader_1 = new System.Windows.Forms.ColumnHeader();
            ColumnHeader columnHeader_2 = new System.Windows.Forms.ColumnHeader();
            columnHeader_1.Text = aGN;
            columnHeader_2.Text = aGC;
            columnHeader_2.TextAlign = HorizontalAlignment.Center;

            listView4.DrawColumnHeader += new DrawListViewColumnHeaderEventHandler(drawListColumnHeader);
            listView4.DrawItem += new DrawListViewItemEventHandler(lv_DrawItem);
            listView4.DrawSubItem += new DrawListViewSubItemEventHandler(lv_DrawSubItem);
            listView4.ColumnClick += new ColumnClickEventHandler(lv4_ColumnClick);

            listView4.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { columnHeader_check, columnHeader_1, columnHeader_2 });
            listView4.Columns[0].Width = 22;
            listView4.Columns[1].Width = 150;

            SQL = "select bgroup as bgc, Format(count(bgroup), '#,#') as bgroupCount, (select description from CommCode with(nolock) where BGroup = code) as bgroupName ";
            SQL = SQL + " from clv2data(nolock) where agroup=@agroupCode group by bgroup order by bgroupCount desc";

            conn.Open();
            SqlCommand dbcmd = new SqlCommand(SQL, conn);

            SqlParameter paramBgroupCode = new SqlParameter("@agroupCode", SqlDbType.NVarChar, 15);
            paramBgroupCode.Value = aGCode;
            dbcmd.Parameters.Add(paramBgroupCode);

            SqlDataReader reader = dbcmd.ExecuteReader();

            while (reader.Read())
            {
                bgroupName = reader["bgroupName"].ToString();
                bgroupCnt = reader["bgroupCount"].ToString();
                bgroup = reader["bgc"].ToString();

                Clv = new ListViewItem();
                Clv.Name = bgroupName;
                Clv.SubItems.Add(bgroupName);
                Clv.SubItems.Add(bgroupCnt);
                Clv.SubItems.Add(bgroup);
                listView4.Items.Add(Clv);
            }
            reader.Close();

            }
        }

        private void listview5Agroup(string dbId, string dbPw, string dbIp)
        {
            string strConn = "Server=" + dbIp + ";database=Intranet;" + "uid=" + dbId + ";pwd=" + dbPw + ";";
            using (SqlConnection conn = new SqlConnection(strConn))
            {
            string aGN = aList[4][0];
            string aGC = aList[4][1].ToString();
            string aGCode = aList[4][2].ToString();
            string SQL = "";

            ColumnHeader columnHeader_check = new System.Windows.Forms.ColumnHeader();
            ColumnHeader columnHeader_1 = new System.Windows.Forms.ColumnHeader();
            ColumnHeader columnHeader_2 = new System.Windows.Forms.ColumnHeader();
            columnHeader_1.Text = aGN;
            columnHeader_2.Text = aGC;
            columnHeader_2.TextAlign = HorizontalAlignment.Center;

            listView5.DrawColumnHeader += new DrawListViewColumnHeaderEventHandler(drawListColumnHeader);
            listView5.DrawItem += new DrawListViewItemEventHandler(lv_DrawItem);
            listView5.DrawSubItem += new DrawListViewSubItemEventHandler(lv_DrawSubItem);
            listView5.ColumnClick += new ColumnClickEventHandler(lv5_ColumnClick);

            listView5.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { columnHeader_check, columnHeader_1, columnHeader_2 });
            listView5.Columns[0].Width = 22;
            listView5.Columns[1].Width = 150;

            SQL = "select bgroup as bgc, Format(count(bgroup), '#,#') as bgroupCount, (select description from CommCode with(nolock) where BGroup = code) as bgroupName ";
            SQL = SQL + " from clv2data(nolock) where agroup=@agroupCode group by bgroup order by bgroupCount desc";

            conn.Open();
            SqlCommand dbcmd = new SqlCommand(SQL, conn);

            SqlParameter paramBgroupCode = new SqlParameter("@agroupCode", SqlDbType.NVarChar, 15);
            paramBgroupCode.Value = aGCode;
            dbcmd.Parameters.Add(paramBgroupCode);

            SqlDataReader reader = dbcmd.ExecuteReader();

            while (reader.Read())
            {
                bgroupName = reader["bgroupName"].ToString();
                bgroupCnt = reader["bgroupCount"].ToString();
                bgroup = reader["bgc"].ToString();

                Clv = new ListViewItem();
                Clv.Name = bgroupName;
                Clv.SubItems.Add(bgroupName);
                Clv.SubItems.Add(bgroupCnt);
                Clv.SubItems.Add(bgroup);
                listView5.Items.Add(Clv);
            }
            reader.Close();

            }
        }

        private void listview6Agroup(string dbId, string dbPw, string dbIp)
        {
            string strConn = "Server=" + dbIp + ";database=Intranet;" + "uid=" + dbId + ";pwd=" + dbPw + ";";
            using (SqlConnection conn = new SqlConnection(strConn))
            {
            string aGN = aList[5][0];
            string aGC = aList[5][1].ToString();
            string aGCode = aList[5][2].ToString();
            string SQL = "";

            ColumnHeader columnHeader_check = new System.Windows.Forms.ColumnHeader();
            ColumnHeader columnHeader_1 = new System.Windows.Forms.ColumnHeader();
            ColumnHeader columnHeader_2 = new System.Windows.Forms.ColumnHeader();
            columnHeader_1.Text = aGN;
            columnHeader_2.Text = aGC;
            columnHeader_2.TextAlign = HorizontalAlignment.Center;

            listView6.DrawColumnHeader += new DrawListViewColumnHeaderEventHandler(drawListColumnHeader);
            listView6.DrawItem += new DrawListViewItemEventHandler(lv_DrawItem);
            listView6.DrawSubItem += new DrawListViewSubItemEventHandler(lv_DrawSubItem);
            listView6.ColumnClick += new ColumnClickEventHandler(lv6_ColumnClick);

            listView6.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { columnHeader_check, columnHeader_1, columnHeader_2 });
            listView6.Columns[0].Width = 22;
            listView6.Columns[1].Width = 150;

            SQL = "select bgroup as bgc,Format(count(bgroup), '#,#') as bgroupCount, (select description from CommCode with(nolock) where BGroup = code) as bgroupName ";
            SQL = SQL + " from clv2data(nolock) where agroup=@agroupCode group by bgroup order by bgroupCount desc";

            conn.Open();
            SqlCommand dbcmd = new SqlCommand(SQL, conn);

            SqlParameter paramBgroupCode = new SqlParameter("@agroupCode", SqlDbType.NVarChar, 15);
            paramBgroupCode.Value = aGCode;
            dbcmd.Parameters.Add(paramBgroupCode);

            SqlDataReader reader = dbcmd.ExecuteReader();

            while (reader.Read())
            {
                bgroupName = reader["bgroupName"].ToString();
                bgroupCnt = reader["bgroupCount"].ToString();
                bgroup = reader["bgc"].ToString();

                Clv = new ListViewItem();
                Clv.Name = bgroupName;
                Clv.SubItems.Add(bgroupName);
                Clv.SubItems.Add(bgroupCnt);
                Clv.SubItems.Add(bgroup);
                listView6.Items.Add(Clv);
            }
            reader.Close();

            }
        }

        private void listview7Agroup(string dbId, string dbPw, string dbIp)
        {
            string strConn = "Server=" + dbIp + ";database=Intranet;" + "uid=" + dbId + ";pwd=" + dbPw + ";";
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                string aGN = aList[6][0];
            string aGC = aList[6][1].ToString();
            string aGCode = aList[6][2].ToString();
            string SQL = "";

            ColumnHeader columnHeader_check = new System.Windows.Forms.ColumnHeader();
            ColumnHeader columnHeader_1 = new System.Windows.Forms.ColumnHeader();
            ColumnHeader columnHeader_2 = new System.Windows.Forms.ColumnHeader();
            columnHeader_1.Text = aGN;
            columnHeader_2.Text = aGC;
            columnHeader_2.TextAlign = HorizontalAlignment.Center;

            listView7.DrawColumnHeader += new DrawListViewColumnHeaderEventHandler(drawListColumnHeader);
            listView7.DrawItem += new DrawListViewItemEventHandler(lv_DrawItem);
            listView7.DrawSubItem += new DrawListViewSubItemEventHandler(lv_DrawSubItem);
            listView7.ColumnClick += new ColumnClickEventHandler(lv7_ColumnClick);

            listView7.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { columnHeader_check, columnHeader_1, columnHeader_2 });
            listView7.Columns[0].Width = 22;
            listView7.Columns[1].Width = 150;

            SQL = "select bgroup as bgc, Format(count(bgroup), '#,#') as bgroupCount, (select description from CommCode with(nolock) where BGroup = code) as bgroupName ";
            SQL = SQL + " from clv2data(nolock) where agroup=@agroupCode group by bgroup order by bgroupCount desc";

            conn.Open();
            SqlCommand dbcmd = new SqlCommand(SQL, conn);

            SqlParameter paramBgroupCode = new SqlParameter("@agroupCode", SqlDbType.NVarChar, 15);
            paramBgroupCode.Value = aGCode;
            dbcmd.Parameters.Add(paramBgroupCode);

            SqlDataReader reader = dbcmd.ExecuteReader();

            while (reader.Read())
            {
                bgroupName = reader["bgroupName"].ToString();
                bgroupCnt = reader["bgroupCount"].ToString();
                bgroup = reader["bgc"].ToString();

                Clv = new ListViewItem();
                Clv.Name = bgroupName;
                Clv.SubItems.Add(bgroupName);
                Clv.SubItems.Add(bgroupCnt);
                Clv.SubItems.Add(bgroup);
                listView7.Items.Add(Clv);
            }
            reader.Close();

            }
        }

        private void listview8Agroup(string dbId, string dbPw, string dbIp)
        {
            string strConn = "Server=" + dbIp + ";database=Intranet;" + "uid=" + dbId + ";pwd=" + dbPw + ";";
            using (SqlConnection conn = new SqlConnection(strConn))
            {
            string aGN = aList[7][0];
            string aGC = aList[7][1].ToString();
            string aGCode = aList[7][2].ToString();
            string SQL = "";

            ColumnHeader columnHeader_check = new System.Windows.Forms.ColumnHeader();
            ColumnHeader columnHeader_1 = new System.Windows.Forms.ColumnHeader();
            ColumnHeader columnHeader_2 = new System.Windows.Forms.ColumnHeader();
            columnHeader_1.Text = aGN;
            columnHeader_2.Text = aGC;
            columnHeader_2.TextAlign = HorizontalAlignment.Center;

            listView8.DrawColumnHeader += new DrawListViewColumnHeaderEventHandler(drawListColumnHeader);
            listView8.DrawItem += new DrawListViewItemEventHandler(lv_DrawItem);
            listView8.DrawSubItem += new DrawListViewSubItemEventHandler(lv_DrawSubItem);
            listView8.ColumnClick += new ColumnClickEventHandler(lv8_ColumnClick);

            listView8.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { columnHeader_check, columnHeader_1, columnHeader_2 });
            listView8.Columns[0].Width = 22;
            listView8.Columns[1].Width = 150;

            SQL = "select bgroup as bgc, Format(count(bgroup), '#,#') as bgroupCount, (select description from CommCode with(nolock) where BGroup = code) as bgroupName ";
            SQL = SQL + " from clv2data(nolock) where agroup=@agroupCode group by bgroup order by bgroupCount desc";

            conn.Open();
            SqlCommand dbcmd = new SqlCommand(SQL, conn);

            SqlParameter paramBgroupCode = new SqlParameter("@agroupCode", SqlDbType.NVarChar, 15);
            paramBgroupCode.Value = aGCode;
            dbcmd.Parameters.Add(paramBgroupCode);

            SqlDataReader reader = dbcmd.ExecuteReader();

            while (reader.Read())
            {
                bgroupName = reader["bgroupName"].ToString();
                bgroupCnt = reader["bgroupCount"].ToString();
                bgroup = reader["bgc"].ToString();

                Clv = new ListViewItem();
                Clv.Name = bgroupName;
                Clv.SubItems.Add(bgroupName);
                Clv.SubItems.Add(bgroupCnt);
                Clv.SubItems.Add(bgroup);
                listView8.Items.Add(Clv);
            }
            reader.Close();

            }
        }

        private void listview9Agroup(string dbId, string dbPw, string dbIp)
        {
            string strConn = "Server=" + dbIp + ";database=Intranet;" + "uid=" + dbId + ";pwd=" + dbPw + ";";
            using (SqlConnection conn = new SqlConnection(strConn))
            {
            string aGN = aList[8][0];
            string aGC = aList[8][1].ToString();
            string aGCode = aList[8][2].ToString();
            string SQL = "";

            ColumnHeader columnHeader_check = new System.Windows.Forms.ColumnHeader();
            ColumnHeader columnHeader_1 = new System.Windows.Forms.ColumnHeader();
            ColumnHeader columnHeader_2 = new System.Windows.Forms.ColumnHeader();
            columnHeader_1.Text = aGN;
            columnHeader_2.Text = aGC;
            columnHeader_2.TextAlign = HorizontalAlignment.Center;

            listView9.DrawColumnHeader += new DrawListViewColumnHeaderEventHandler(drawListColumnHeader);
            listView9.DrawItem += new DrawListViewItemEventHandler(lv_DrawItem);
            listView9.DrawSubItem += new DrawListViewSubItemEventHandler(lv_DrawSubItem);
            listView9.ColumnClick += new ColumnClickEventHandler(lv9_ColumnClick);

            listView9.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { columnHeader_check, columnHeader_1, columnHeader_2 });
            listView9.Columns[0].Width = 22;
            listView9.Columns[1].Width = 150;

            SQL = "select bgroup as bgc, Format(count(bgroup), '#,#') as bgroupCount, (select description from CommCode with(nolock) where BGroup = code) as bgroupName ";
            SQL = SQL + " from clv2data(nolock) where agroup=@agroupCode group by bgroup order by bgroupCount desc";

            conn.Open();
            SqlCommand dbcmd = new SqlCommand(SQL, conn);

            SqlParameter paramBgroupCode = new SqlParameter("@agroupCode", SqlDbType.NVarChar, 15);
            paramBgroupCode.Value = aGCode;
            dbcmd.Parameters.Add(paramBgroupCode);

            SqlDataReader reader = dbcmd.ExecuteReader();

            while (reader.Read())
            {
                bgroupName = reader["bgroupName"].ToString();
                bgroupCnt = reader["bgroupCount"].ToString();
                bgroup = reader["bgc"].ToString();

                Clv = new ListViewItem();
                Clv.Name = bgroupName;
                Clv.SubItems.Add(bgroupName);
                Clv.SubItems.Add(bgroupCnt);
                Clv.SubItems.Add(bgroup);
                listView9.Items.Add(Clv);
            }
            reader.Close();

            }
        }

        private void listview10Agroup(string dbId, string dbPw, string dbIp)
        {
            string strConn = "Server=" + dbIp + ";database=Intranet;" + "uid=" + dbId + ";pwd=" + dbPw + ";";
            using (SqlConnection conn = new SqlConnection(strConn))
            {
            string aGN = aList[9][0];
            string aGC = aList[9][1].ToString();
            string aGCode = aList[9][2].ToString();
            string SQL = "";

            ColumnHeader columnHeader_check = new System.Windows.Forms.ColumnHeader();
            ColumnHeader columnHeader_1 = new System.Windows.Forms.ColumnHeader();
            ColumnHeader columnHeader_2 = new System.Windows.Forms.ColumnHeader();
            columnHeader_1.Text = aGN;
            columnHeader_2.Text = aGC;
            columnHeader_2.TextAlign = HorizontalAlignment.Center;

            listView10.DrawColumnHeader += new DrawListViewColumnHeaderEventHandler(drawListColumnHeader);
            listView10.DrawItem += new DrawListViewItemEventHandler(lv_DrawItem);
            listView10.DrawSubItem += new DrawListViewSubItemEventHandler(lv_DrawSubItem);
            listView10.ColumnClick += new ColumnClickEventHandler(lv10_ColumnClick);

            listView10.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { columnHeader_check, columnHeader_1, columnHeader_2 });
            listView10.Columns[0].Width = 22;
            listView10.Columns[1].Width = 150;

            SQL = "select bgroup as bgc, Format(count(bgroup), '#,#') as bgroupCount, (select description from CommCode with(nolock) where BGroup = code) as bgroupName ";
            SQL = SQL + " from clv2data(nolock) where agroup=@agroupCode group by bgroup order by bgroupCount desc";

            conn.Open();
            SqlCommand dbcmd = new SqlCommand(SQL, conn);

            SqlParameter paramBgroupCode = new SqlParameter("@agroupCode", SqlDbType.NVarChar, 15);
            paramBgroupCode.Value = aGCode;
            dbcmd.Parameters.Add(paramBgroupCode);

            SqlDataReader reader = dbcmd.ExecuteReader();

            while (reader.Read())
            {
                bgroupName = reader["bgroupName"].ToString();
                bgroupCnt = reader["bgroupCount"].ToString();
                bgroup = reader["bgc"].ToString();

                Clv = new ListViewItem();
                Clv.Name = bgroupName;
                Clv.SubItems.Add(bgroupName);
                Clv.SubItems.Add(bgroupCnt);
                Clv.SubItems.Add(bgroup);
                listView10.Items.Add(Clv);
            }
            reader.Close();

            }
        }

        private void listview11Agroup(string dbId, string dbPw, string dbIp)
        {
            string strConn = "Server=" + dbIp + ";database=Intranet;" + "uid=" + dbId + ";pwd=" + dbPw + ";";
            using (SqlConnection conn = new SqlConnection(strConn))
            {
            string aGN = aList[10][0];
            string aGC = aList[10][1].ToString();
            string aGCode = aList[10][2].ToString();
            string SQL = "";

            ColumnHeader columnHeader_check = new System.Windows.Forms.ColumnHeader();
            ColumnHeader columnHeader_1 = new System.Windows.Forms.ColumnHeader();
            ColumnHeader columnHeader_2 = new System.Windows.Forms.ColumnHeader();
            columnHeader_1.Text = aGN;
            columnHeader_2.Text = aGC;
            columnHeader_2.TextAlign = HorizontalAlignment.Center;

            listView11.DrawColumnHeader += new DrawListViewColumnHeaderEventHandler(drawListColumnHeader);
            listView11.DrawItem += new DrawListViewItemEventHandler(lv_DrawItem);
            listView11.DrawSubItem += new DrawListViewSubItemEventHandler(lv_DrawSubItem);
            listView11.ColumnClick += new ColumnClickEventHandler(lv11_ColumnClick);

            listView11.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { columnHeader_check, columnHeader_1, columnHeader_2 });
            listView11.Columns[0].Width = 22;
            listView11.Columns[1].Width = 150;

            SQL = "select bgroup as bgc, Format(count(bgroup), '#,#') as bgroupCount, (select description from CommCode with(nolock) where BGroup = code) as bgroupName ";
            SQL = SQL + " from clv2data(nolock) where agroup=@agroupCode group by bgroup order by bgroupCount desc";

            conn.Open();
            SqlCommand dbcmd = new SqlCommand(SQL, conn);

            SqlParameter paramBgroupCode = new SqlParameter("@agroupCode", SqlDbType.NVarChar, 15);
            paramBgroupCode.Value = aGCode;
            dbcmd.Parameters.Add(paramBgroupCode);

            SqlDataReader reader = dbcmd.ExecuteReader();

            while (reader.Read())
            {
                bgroupName = reader["bgroupName"].ToString();
                bgroupCnt = reader["bgroupCount"].ToString();
                bgroup = reader["bgc"].ToString();

                Clv = new ListViewItem();
                Clv.Name = bgroupName;
                Clv.SubItems.Add(bgroupName);
                Clv.SubItems.Add(bgroupCnt);
                Clv.SubItems.Add(bgroup);
                listView11.Items.Add(Clv);
            }
            reader.Close();

            }
        }

        private void listview12Agroup(string dbId, string dbPw, string dbIp)
        {
            string strConn = "Server=" + dbIp + ";database=Intranet;" + "uid=" + dbId + ";pwd=" + dbPw + ";";
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                string aGN = aList[11][0];
                string aGC = aList[11][1].ToString();
                string aGCode = aList[11][2].ToString();
                string SQL = "";

                ColumnHeader columnHeader_check = new System.Windows.Forms.ColumnHeader();
                ColumnHeader columnHeader_1 = new System.Windows.Forms.ColumnHeader();
                ColumnHeader columnHeader_2 = new System.Windows.Forms.ColumnHeader();
                columnHeader_1.Text = aGN;
                columnHeader_2.Text = aGC;
                columnHeader_2.TextAlign = HorizontalAlignment.Center;

                listView12.DrawColumnHeader += new DrawListViewColumnHeaderEventHandler(drawListColumnHeader);
                listView12.DrawItem += new DrawListViewItemEventHandler(lv_DrawItem);
                listView12.DrawSubItem += new DrawListViewSubItemEventHandler(lv_DrawSubItem);
                listView12.ColumnClick += new ColumnClickEventHandler(lv12_ColumnClick);

                listView12.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { columnHeader_check, columnHeader_1, columnHeader_2 });
                listView12.Columns[0].Width = 22;
                listView12.Columns[1].Width = 150;

                SQL = "select bgroup as bgc, Format(count(bgroup), '#,#') as bgroupCount, (select description from CommCode with(nolock) where BGroup = code) as bgroupName ";
                SQL = SQL + " from clv2data(nolock) where agroup=@agroupCode group by bgroup order by bgroupCount desc";

                conn.Open();
                SqlCommand dbcmd = new SqlCommand(SQL, conn);

                SqlParameter paramBgroupCode = new SqlParameter("@agroupCode", SqlDbType.NVarChar, 15);
                paramBgroupCode.Value = aGCode;
                dbcmd.Parameters.Add(paramBgroupCode);

                SqlDataReader reader = dbcmd.ExecuteReader();

                while (reader.Read())
                {
                    bgroupName = reader["bgroupName"].ToString();
                    bgroupCnt = reader["bgroupCount"].ToString();
                    bgroup = reader["bgc"].ToString();

                    Clv = new ListViewItem();
                    Clv.Name = bgroupName;
                    Clv.SubItems.Add(bgroupName);
                    Clv.SubItems.Add(bgroupCnt);
                    Clv.SubItems.Add(bgroup);
                    listView12.Items.Add(Clv);
                }
                reader.Close();
            }
        }

        private void listview13Agroup(string dbId, string dbPw, string dbIp)
        {
            string strConn = "Server=" + dbIp + ";database=Intranet;" + "uid=" + dbId + ";pwd=" + dbPw + ";";
            using (SqlConnection conn = new SqlConnection(strConn))
            {
            string aGN = aList[12][0];
            string aGC = aList[12][1].ToString();
            string aGCode = aList[12][2].ToString();
            string SQL = "";

            ColumnHeader columnHeader_check = new System.Windows.Forms.ColumnHeader();
            ColumnHeader columnHeader_1 = new System.Windows.Forms.ColumnHeader();
            ColumnHeader columnHeader_2 = new System.Windows.Forms.ColumnHeader();
            columnHeader_1.Text = aGN;
            columnHeader_2.Text = aGC;
            columnHeader_2.TextAlign = HorizontalAlignment.Center;

            listView13.DrawColumnHeader += new DrawListViewColumnHeaderEventHandler(drawListColumnHeader);
            listView13.DrawItem += new DrawListViewItemEventHandler(lv_DrawItem);
            listView13.DrawSubItem += new DrawListViewSubItemEventHandler(lv_DrawSubItem);
            listView13.ColumnClick += new ColumnClickEventHandler(lv13_ColumnClick);

            listView13.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { columnHeader_check, columnHeader_1, columnHeader_2 });
            listView13.Columns[0].Width = 22;
            listView13.Columns[1].Width = 150;

            SQL = "select bgroup as bgc, Format(count(bgroup), '#,#') as bgroupCount, (select description from CommCode with(nolock) where BGroup = code) as bgroupName ";
            SQL = SQL + " from clv2data(nolock) where agroup=@agroupCode group by bgroup order by bgroupCount desc";

            conn.Open();
            SqlCommand dbcmd = new SqlCommand(SQL, conn);

            SqlParameter paramBgroupCode = new SqlParameter("@agroupCode", SqlDbType.NVarChar, 15);
            paramBgroupCode.Value = aGCode;
            dbcmd.Parameters.Add(paramBgroupCode);

            SqlDataReader reader = dbcmd.ExecuteReader();

            while (reader.Read())
            {
                bgroupName = reader["bgroupName"].ToString();
                bgroupCnt = reader["bgroupCount"].ToString();
                bgroup = reader["bgc"].ToString();

                Clv = new ListViewItem();
                Clv.Name = bgroupName;
                Clv.SubItems.Add(bgroupName);
                Clv.SubItems.Add(bgroupCnt);
                Clv.SubItems.Add(bgroup);
                listView13.Items.Add(Clv);
            }
            reader.Close();

            }
        }

        private void listview14Agroup(string dbId, string dbPw, string dbIp)
        {
            string strConn = "Server=" + dbIp + ";database=Intranet;" + "uid=" + dbId + ";pwd=" + dbPw + ";";
            using (SqlConnection conn = new SqlConnection(strConn))
            {
            string aGN = aList[13][0];
            string aGC = aList[13][1].ToString();
            string aGCode = aList[13][2].ToString();
            string SQL = "";

            ColumnHeader columnHeader_check = new System.Windows.Forms.ColumnHeader();
            ColumnHeader columnHeader_1 = new System.Windows.Forms.ColumnHeader();
            ColumnHeader columnHeader_2 = new System.Windows.Forms.ColumnHeader();
            columnHeader_1.Text = aGN;
            columnHeader_2.Text = aGC;
            columnHeader_2.TextAlign = HorizontalAlignment.Center;

            listView14.DrawColumnHeader += new DrawListViewColumnHeaderEventHandler(drawListColumnHeader);
            listView14.DrawItem += new DrawListViewItemEventHandler(lv_DrawItem);
            listView14.DrawSubItem += new DrawListViewSubItemEventHandler(lv_DrawSubItem);
            listView14.ColumnClick += new ColumnClickEventHandler(lv14_ColumnClick);

            listView14.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { columnHeader_check, columnHeader_1, columnHeader_2 });
            listView14.Columns[0].Width = 22;
            listView14.Columns[1].Width = 150;

            SQL = "select bgroup as bgc, Format(count(bgroup), '#,#') as bgroupCount, (select description from CommCode with(nolock) where BGroup = code) as bgroupName ";
            SQL = SQL + " from clv2data(nolock) where agroup=@agroupCode group by bgroup order by bgroupCount desc";

            conn.Open();
            SqlCommand dbcmd = new SqlCommand(SQL, conn);

            SqlParameter paramBgroupCode = new SqlParameter("@agroupCode", SqlDbType.NVarChar, 15);
            paramBgroupCode.Value = aGCode;
            dbcmd.Parameters.Add(paramBgroupCode);

            SqlDataReader reader = dbcmd.ExecuteReader();

            while (reader.Read())
            {
                bgroupName = reader["bgroupName"].ToString();
                bgroupCnt = reader["bgroupCount"].ToString();
                bgroup = reader["bgc"].ToString();

                Clv = new ListViewItem();
                Clv.Name = bgroupName;
                Clv.SubItems.Add(bgroupName);
                Clv.SubItems.Add(bgroupCnt);
                Clv.SubItems.Add(bgroup);
                listView14.Items.Add(Clv);
            }
            reader.Close();

            }
        }

        private void listview15Agroup(string dbId, string dbPw, string dbIp)
        {
            string strConn = "Server=" + dbIp + ";database=Intranet;" + "uid=" + dbId + ";pwd=" + dbPw + ";";
            using (SqlConnection conn = new SqlConnection(strConn))
            {
            string aGN = aList[14][0];
            string aGC = aList[14][1].ToString();
            string aGCode = aList[14][2].ToString();
            string SQL = "";

            ColumnHeader columnHeader_check = new System.Windows.Forms.ColumnHeader();
            ColumnHeader columnHeader_1 = new System.Windows.Forms.ColumnHeader();
            ColumnHeader columnHeader_2 = new System.Windows.Forms.ColumnHeader();
            columnHeader_1.Text = aGN;
            columnHeader_2.Text = aGC;
            columnHeader_2.TextAlign = HorizontalAlignment.Center;

            listView15.DrawColumnHeader += new DrawListViewColumnHeaderEventHandler(drawListColumnHeader);
            listView15.DrawItem += new DrawListViewItemEventHandler(lv_DrawItem);
            listView15.DrawSubItem += new DrawListViewSubItemEventHandler(lv_DrawSubItem);
            listView15.ColumnClick += new ColumnClickEventHandler(lv15_ColumnClick);

            listView15.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { columnHeader_check, columnHeader_1, columnHeader_2 });
            listView15.Columns[0].Width = 22;
            listView15.Columns[1].Width = 150;

            SQL = "select bgroup as bgc, Format(count(bgroup), '#,#') as bgroupCount, (select description from CommCode with(nolock) where BGroup = code) as bgroupName ";
            SQL = SQL + " from clv2data(nolock) where agroup=@agroupCode group by bgroup order by bgroupCount desc";

            conn.Open();
            SqlCommand dbcmd = new SqlCommand(SQL, conn);

            SqlParameter paramBgroupCode = new SqlParameter("@agroupCode", SqlDbType.NVarChar, 15);
            paramBgroupCode.Value = aGCode;
            dbcmd.Parameters.Add(paramBgroupCode);

            SqlDataReader reader = dbcmd.ExecuteReader();

            while (reader.Read())
            {
                bgroupName = reader["bgroupName"].ToString();
                bgroupCnt = reader["bgroupCount"].ToString();
                bgroup = reader["bgc"].ToString();

                Clv = new ListViewItem();
                Clv.Name = bgroupName;
                Clv.SubItems.Add(bgroupName);
                Clv.SubItems.Add(bgroupCnt);
                Clv.SubItems.Add(bgroup);
                listView15.Items.Add(Clv);
            }
            reader.Close();

            }
        }

        private void listview16Agroup(string dbId, string dbPw, string dbIp)
        {
            string strConn = "Server=" + dbIp + ";database=Intranet;" + "uid=" + dbId + ";pwd=" + dbPw + ";";
            using (SqlConnection conn = new SqlConnection(strConn))
            {
            string aGN = aList[15][0];
            string aGC = aList[15][1].ToString();
            string aGCode = aList[15][2].ToString();
            string SQL = "";

            ColumnHeader columnHeader_check = new System.Windows.Forms.ColumnHeader();
            ColumnHeader columnHeader_1 = new System.Windows.Forms.ColumnHeader();
            ColumnHeader columnHeader_2 = new System.Windows.Forms.ColumnHeader();
            columnHeader_1.Text = aGN;
            columnHeader_2.Text = aGC;
            columnHeader_2.TextAlign = HorizontalAlignment.Center;

            listView16.DrawColumnHeader += new DrawListViewColumnHeaderEventHandler(drawListColumnHeader);
            listView16.DrawItem += new DrawListViewItemEventHandler(lv_DrawItem);
            listView16.DrawSubItem += new DrawListViewSubItemEventHandler(lv_DrawSubItem);
            listView16.ColumnClick += new ColumnClickEventHandler(lv16_ColumnClick);

            listView16.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { columnHeader_check, columnHeader_1, columnHeader_2 });
            listView16.Columns[0].Width = 22;
            listView16.Columns[1].Width = 150;

            SQL = "select bgroup as bgc, Format(count(bgroup), '#,#') as bgroupCount, (select description from CommCode with(nolock) where BGroup = code) as bgroupName ";
            SQL = SQL + " from clv2data(nolock) where agroup=@agroupCode group by bgroup order by bgroupCount desc";

            conn.Open();
            SqlCommand dbcmd = new SqlCommand(SQL, conn);

            SqlParameter paramBgroupCode = new SqlParameter("@agroupCode", SqlDbType.NVarChar, 15);
            paramBgroupCode.Value = aGCode;
            dbcmd.Parameters.Add(paramBgroupCode);

            SqlDataReader reader = dbcmd.ExecuteReader();

            while (reader.Read())
            {
                bgroupName = reader["bgroupName"].ToString();
                bgroupCnt = reader["bgroupCount"].ToString();
                bgroup = reader["bgc"].ToString();

                Clv = new ListViewItem();
                Clv.Name = bgroupName;
                Clv.SubItems.Add(bgroupName);
                Clv.SubItems.Add(bgroupCnt);
                Clv.SubItems.Add(bgroup);
                listView16.Items.Add(Clv);
            }
            reader.Close();

            }
        }

        private void listview17Agroup(string dbId, string dbPw, string dbIp)
        {
            string strConn = "Server=" + dbIp + ";database=Intranet;" + "uid=" + dbId + ";pwd=" + dbPw + ";";
            using (SqlConnection conn = new SqlConnection(strConn))
            {
            string aGN = aList[16][0];
            string aGC = aList[16][1].ToString();
            string aGCode = aList[16][2].ToString();
            string SQL = "";

            ColumnHeader columnHeader_check = new System.Windows.Forms.ColumnHeader();
            ColumnHeader columnHeader_1 = new System.Windows.Forms.ColumnHeader();
            ColumnHeader columnHeader_2 = new System.Windows.Forms.ColumnHeader();
            columnHeader_1.Text = aGN;
            columnHeader_2.Text = aGC;
            columnHeader_2.TextAlign = HorizontalAlignment.Center;

            listView17.DrawColumnHeader += new DrawListViewColumnHeaderEventHandler(drawListColumnHeader);
            listView17.DrawItem += new DrawListViewItemEventHandler(lv_DrawItem);
            listView17.DrawSubItem += new DrawListViewSubItemEventHandler(lv_DrawSubItem);
            listView17.ColumnClick += new ColumnClickEventHandler(lv17_ColumnClick);

            listView17.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { columnHeader_check, columnHeader_1, columnHeader_2 });
            listView17.Columns[0].Width = 22;
            listView17.Columns[1].Width = 150;

            SQL = "select bgroup as bgc, Format(count(bgroup), '#,#') as bgroupCount, (select description from CommCode with(nolock) where BGroup = code) as bgroupName ";
            SQL = SQL + " from clv2data(nolock) where agroup=@agroupCode group by bgroup order by bgroupCount desc";

            conn.Open();
            SqlCommand dbcmd = new SqlCommand(SQL, conn);

            SqlParameter paramBgroupCode = new SqlParameter("@agroupCode", SqlDbType.NVarChar, 15);
            paramBgroupCode.Value = aGCode;
            dbcmd.Parameters.Add(paramBgroupCode);

            SqlDataReader reader = dbcmd.ExecuteReader();

            while (reader.Read())
            {
                bgroupName = reader["bgroupName"].ToString();
                bgroupCnt = reader["bgroupCount"].ToString();
                bgroup = reader["bgc"].ToString();

                Clv = new ListViewItem();
                Clv.Name = bgroupName;
                Clv.SubItems.Add(bgroupName);
                Clv.SubItems.Add(bgroupCnt);
                Clv.SubItems.Add(bgroup);
                listView17.Items.Add(Clv);
            }
            reader.Close();

            }
        }

        private void listview18Agroup(string dbId, string dbPw, string dbIp)
        {
            string strConn = "Server=" + dbIp + ";database=Intranet;" + "uid=" + dbId + ";pwd=" + dbPw + ";";
            using (SqlConnection conn = new SqlConnection(strConn))
            {
            string aGN = aList[17][0];
            string aGC = aList[17][1].ToString();
            string aGCode = aList[17][2].ToString();
            string SQL = "";

            ColumnHeader columnHeader_check = new System.Windows.Forms.ColumnHeader();
            ColumnHeader columnHeader_1 = new System.Windows.Forms.ColumnHeader();
            ColumnHeader columnHeader_2 = new System.Windows.Forms.ColumnHeader();
            //ColumnHeader columnHeader_3 = new System.Windows.Forms.ColumnHeader();
            columnHeader_1.Text = aGN;
            columnHeader_2.Text = aGC;
            //columnHeader_3.Text = "코드";
            columnHeader_2.TextAlign = HorizontalAlignment.Center;

            listView18.DrawColumnHeader += new DrawListViewColumnHeaderEventHandler(drawListColumnHeader);
            listView18.DrawItem += new DrawListViewItemEventHandler(lv_DrawItem);
            listView18.DrawSubItem += new DrawListViewSubItemEventHandler(lv_DrawSubItem);
            listView18.ColumnClick += new ColumnClickEventHandler(lv18_ColumnClick);

            listView18.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { columnHeader_check, columnHeader_1, columnHeader_2 });
            listView18.Columns[0].Width = 22;
            listView18.Columns[1].Width = 150;

            SQL = "select bgroup as bgc, Format(count(bgroup), '#,#') as bgroupCount, (select description from CommCode with(nolock) where BGroup = code) as bgroupName ";
            SQL = SQL + " from clv2data(nolock) where agroup=@agroupCode group by bgroup order by bgc asc";

            conn.Open();
            SqlCommand dbcmd = new SqlCommand(SQL, conn);

            SqlParameter paramBgroupCode = new SqlParameter("@agroupCode", SqlDbType.NVarChar, 15);
            paramBgroupCode.Value = aGCode;
            dbcmd.Parameters.Add(paramBgroupCode);

            SqlDataReader reader = dbcmd.ExecuteReader();

            while (reader.Read())
            {
                bgroupName = reader["bgroupName"].ToString();
                bgroupCnt = reader["bgroupCount"].ToString();
                bgroup = reader["bgc"].ToString();

                Clv = new ListViewItem();
                Clv.Name = bgroupName;
                Clv.SubItems.Add(bgroupName);
                Clv.SubItems.Add(bgroupCnt);
                Clv.SubItems.Add(bgroup);
                listView18.Items.Add(Clv);
            }
            reader.Close();

            }
        }

        private void listview19Agroup(string dbId, string dbPw, string dbIp)
        {
            string strConn = "Server=" + dbIp + ";database=Intranet;" + "uid=" + dbId + ";pwd=" + dbPw + ";";
            using (SqlConnection conn = new SqlConnection(strConn))
            {
            string aGN = aList[18][0];
            string aGC = aList[18][1].ToString();
            string aGCode = aList[18][2].ToString();
            string SQL = "";

            ColumnHeader columnHeader_check = new System.Windows.Forms.ColumnHeader();
            ColumnHeader columnHeader_1 = new System.Windows.Forms.ColumnHeader();
            ColumnHeader columnHeader_2 = new System.Windows.Forms.ColumnHeader();
            columnHeader_1.Text = aGN;
            columnHeader_2.Text = aGC;
            columnHeader_2.TextAlign = HorizontalAlignment.Center;

            listView19.DrawColumnHeader += new DrawListViewColumnHeaderEventHandler(drawListColumnHeader);
            listView19.DrawItem += new DrawListViewItemEventHandler(lv_DrawItem);
            listView19.DrawSubItem += new DrawListViewSubItemEventHandler(lv_DrawSubItem);
            listView19.ColumnClick += new ColumnClickEventHandler(lv19_ColumnClick);

            listView19.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { columnHeader_check, columnHeader_1, columnHeader_2 });
            listView19.Columns[0].Width = 22;
            listView19.Columns[1].Width = 150;

            SQL = "select bgroup as bgc, Format(count(bgroup), '#,#') as bgroupCount, (select description from CommCode with(nolock) where BGroup = code) as bgroupName ";
            SQL = SQL + " from clv2data(nolock) where agroup=@agroupCode group by bgroup order by bgroupCount desc";

            conn.Open();
            SqlCommand dbcmd = new SqlCommand(SQL, conn);

            SqlParameter paramBgroupCode = new SqlParameter("@agroupCode", SqlDbType.NVarChar, 15);
            paramBgroupCode.Value = aGCode;
            dbcmd.Parameters.Add(paramBgroupCode);

            SqlDataReader reader = dbcmd.ExecuteReader();

            while (reader.Read())
            {
                bgroupName = reader["bgroupName"].ToString();
                bgroupCnt = reader["bgroupCount"].ToString();
                bgroup = reader["bgc"].ToString();

                Clv = new ListViewItem();
                Clv.Name = bgroupName;
                Clv.SubItems.Add(bgroupName);
                Clv.SubItems.Add(bgroupCnt);
                Clv.SubItems.Add(bgroup);
                listView19.Items.Add(Clv);
            }
            reader.Close();

            }
        }

        private void listview20Agroup(string dbId, string dbPw, string dbIp)
        {
            string strConn = "Server=" + dbIp + ";database=Intranet;" + "uid=" + dbId + ";pwd=" + dbPw + ";";
            using (SqlConnection conn = new SqlConnection(strConn))
            {
            string aGN = aList[19][0];
            string aGC = aList[19][1].ToString();
            string aGCode = aList[19][2].ToString();
            string SQL = "";

            ColumnHeader columnHeader_check = new System.Windows.Forms.ColumnHeader();
            ColumnHeader columnHeader_1 = new System.Windows.Forms.ColumnHeader();
            ColumnHeader columnHeader_2 = new System.Windows.Forms.ColumnHeader();
            columnHeader_1.Text = aGN;
            columnHeader_2.Text = aGC;
            columnHeader_2.TextAlign = HorizontalAlignment.Center;

            listView20.DrawColumnHeader += new DrawListViewColumnHeaderEventHandler(drawListColumnHeader);
            listView20.DrawItem += new DrawListViewItemEventHandler(lv_DrawItem);
            listView20.DrawSubItem += new DrawListViewSubItemEventHandler(lv_DrawSubItem);
            listView20.ColumnClick += new ColumnClickEventHandler(lv20_ColumnClick);

            listView20.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { columnHeader_check, columnHeader_1, columnHeader_2 });
            listView20.Columns[0].Width = 22;
            listView20.Columns[1].Width = 150;

            SQL = "select bgroup as bgc, Format(count(bgroup), '#,#') as bgroupCount, (select description from CommCode with(nolock) where BGroup = code) as bgroupName ";
            SQL = SQL + " from clv2data(nolock) where agroup=@agroupCode group by bgroup order by bgroupCount desc";

            conn.Open();
            SqlCommand dbcmd = new SqlCommand(SQL, conn);

            SqlParameter paramBgroupCode = new SqlParameter("@agroupCode", SqlDbType.NVarChar, 15);
            paramBgroupCode.Value = aGCode;
            dbcmd.Parameters.Add(paramBgroupCode);

            SqlDataReader reader = dbcmd.ExecuteReader();

            while (reader.Read())
            {
                bgroupName = reader["bgroupName"].ToString();
                bgroupCnt = reader["bgroupCount"].ToString();
                bgroup = reader["bgc"].ToString();

                Clv = new ListViewItem();
                Clv.Name = bgroupName;
                Clv.SubItems.Add(bgroupName);
                Clv.SubItems.Add(bgroupCnt);
                Clv.SubItems.Add(bgroup);
                listView20.Items.Add(Clv);
            }
            reader.Close();

            }
        }

        private void listview21Agroup(string dbId, string dbPw, string dbIp)
        {
            string strConn = "Server=" + dbIp + ";database=Intranet;" + "uid=" + dbId + ";pwd=" + dbPw + ";";
            using (SqlConnection conn = new SqlConnection(strConn))
            {
            string aGN = aList[20][0];
            string aGC = aList[20][1].ToString();
            string aGCode = aList[20][2].ToString();
            string SQL = "";

            ColumnHeader columnHeader_check = new System.Windows.Forms.ColumnHeader();
            ColumnHeader columnHeader_1 = new System.Windows.Forms.ColumnHeader();
            ColumnHeader columnHeader_2 = new System.Windows.Forms.ColumnHeader();
            columnHeader_1.Text = aGN;
            columnHeader_2.Text = aGC;
            columnHeader_2.TextAlign = HorizontalAlignment.Center;

            listView21.DrawColumnHeader += new DrawListViewColumnHeaderEventHandler(drawListColumnHeader);
            listView21.DrawItem += new DrawListViewItemEventHandler(lv_DrawItem);
            listView21.DrawSubItem += new DrawListViewSubItemEventHandler(lv_DrawSubItem);
            listView21.ColumnClick += new ColumnClickEventHandler(lv21_ColumnClick);

            listView21.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { columnHeader_check, columnHeader_1, columnHeader_2 });
            listView21.Columns[0].Width = 22;
            listView21.Columns[1].Width = 150;

            //string strConn = "Server=" + dbIp + ";database=Intranet;" + "uid=" + dbId + ";pwd=" + dbPw + ";";

            SQL = "select bgroup as bgc,Format(count(bgroup), '#,#') as bgroupCount, (select description from CommCode with(nolock) where BGroup = code) as bgroupName ";
            SQL = SQL + " from clv2data(nolock) where agroup=@agroupCode group by bgroup order by bgroupCount desc";

            //SqlConnection conn = new SqlConnection(strConn);
            conn.Open();
            SqlCommand dbcmd = new SqlCommand(SQL, conn);

            SqlParameter paramBgroupCode = new SqlParameter("@agroupCode", SqlDbType.NVarChar, 15);
            paramBgroupCode.Value = aGCode;
            dbcmd.Parameters.Add(paramBgroupCode);

            SqlDataReader reader = dbcmd.ExecuteReader();

            while (reader.Read())
            {
                bgroupName = reader["bgroupName"].ToString();
                bgroupCnt = reader["bgroupCount"].ToString();
                bgroup = reader["bgc"].ToString();

                Clv = new ListViewItem();
                Clv.Name = bgroupName;
                Clv.SubItems.Add(bgroupName);
                Clv.SubItems.Add(bgroupCnt);
                Clv.SubItems.Add(bgroup);
                listView21.Items.Add(Clv);
            }
            reader.Close();

            }
        }

        private void listview22Agroup(string dbId, string dbPw, string dbIp)
        {
            string strConn = "Server=" + dbIp + ";database=Intranet;" + "uid=" + dbId + ";pwd=" + dbPw + ";";
            using (SqlConnection conn = new SqlConnection(strConn))
            {
            string aGN = aList[21][0];
            string aGC = aList[21][1].ToString();
            string aGCode = aList[21][2].ToString();
            string SQL = "";

            ColumnHeader columnHeader_check = new System.Windows.Forms.ColumnHeader();
            ColumnHeader columnHeader_1 = new System.Windows.Forms.ColumnHeader();
            ColumnHeader columnHeader_2 = new System.Windows.Forms.ColumnHeader();
            columnHeader_1.Text = aGN;
            columnHeader_2.Text = aGC;
            columnHeader_2.TextAlign = HorizontalAlignment.Center;

            listView22.DrawColumnHeader += new DrawListViewColumnHeaderEventHandler(drawListColumnHeader);
            listView22.DrawItem += new DrawListViewItemEventHandler(lv_DrawItem);
            listView22.DrawSubItem += new DrawListViewSubItemEventHandler(lv_DrawSubItem);
            listView22.ColumnClick += new ColumnClickEventHandler(lv22_ColumnClick);

            listView22.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { columnHeader_check, columnHeader_1, columnHeader_2 });
            listView22.Columns[0].Width = 22;
            listView22.Columns[1].Width = 150;

            //string strConn = "Server=" + dbIp + ";database=Intranet;" + "uid=" + dbId + ";pwd=" + dbPw + ";";

            SQL = "select bgroup as bgc, Format(count(bgroup), '#,#') as bgroupCount, (select description from CommCode with(nolock) where BGroup = code) as bgroupName ";
            SQL = SQL + " from clv2data(nolock) where agroup=@agroupCode group by bgroup order by bgroupCount desc";

            //SqlConnection conn = new SqlConnection(strConn);
            conn.Open();
            SqlCommand dbcmd = new SqlCommand(SQL, conn);

            SqlParameter paramBgroupCode = new SqlParameter("@agroupCode", SqlDbType.NVarChar, 15);
            paramBgroupCode.Value = aGCode;
            dbcmd.Parameters.Add(paramBgroupCode);

            SqlDataReader reader = dbcmd.ExecuteReader();

            while (reader.Read())
            {
                bgroupName = reader["bgroupName"].ToString();
                bgroupCnt = reader["bgroupCount"].ToString();
                bgroup = reader["bgc"].ToString();

                Clv = new ListViewItem();
                Clv.Name = bgroupName;
                Clv.SubItems.Add(bgroupName);
                Clv.SubItems.Add(bgroupCnt);
                Clv.SubItems.Add(bgroup);
                listView22.Items.Add(Clv);        
            }
            reader.Close();

            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {                 
            if (listViewSmall.CheckedItems.Count > 0)
            {
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.EnableResizing;
       
                dataGridView1.DataSource = await GetSearch();
                setRowNumber(dataGridView1);
                int rowcnt = dataGridView1.RowCount;
                label3.Text = rowcnt + "개 조회 완료!!";               
            }
            else
            {
                return;
            }   
        }

        private async void setRowNumber(DataGridView dgv)
        {
            await Task.Run(() =>
            {
                foreach(DataGridViewRow row in dgv.Rows)
                {
                    row.HeaderCell.Value = String.Format("{0}", row.Index + 1);
                }
               // dgv.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);
            });    
        }
    
        public async Task<DataTable> GetSearch()
        {
            string strConn = "Server=" + dbIp + ";database=Intranet;" + "uid=" + dbId + ";pwd=" + dbPw + ";";
            string paramName = "";
            string strAppend = "";
            string ScalaSql = "";
            int index = 1;
            int ind = 1;
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                foreach(ListViewItem item in listViewSmall.CheckedItems)
                {
                    paramName = "@code" + index;
                    strAppend += paramName + ",";
                    index += 1;
                }
                    strAppend = strAppend.ToString().Remove(strAppend.LastIndexOf(","), 1);
                    ScalaSql = "Select nSeq, sFromInfo, AGroup, BGroup, CGroup, sComName, sOwner, sZipCode, sAddrs, ";
                    ScalaSql = ScalaSql + "sTypeOfIndustry, sTelNum, sFaxPrefix, sFaxNum, nNumOfMen, nCapital, dtRegDate from Clv2Data(nolock) where cgroup in (" + strAppend + ")";
                    SqlDataAdapter adapter = new SqlDataAdapter(ScalaSql, conn);

                foreach(ListViewItem i in listViewSmall.CheckedItems)
                {               
                    adapter.SelectCommand.Parameters.Add("@code" + ind, SqlDbType.NVarChar, 2000).Value = i.SubItems[3].Text;
                    ind += 1;
                }
                    DataTable ds = new DataTable();
                    await Task.Run(() => {
                        adapter.Fill(ds);                            
                    });
                    return ds;
            }
        }

        private void listView18_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
    }

    public static class ExtensionMethods   
    {
        public static void DoubleBuffered(this DataGridView dgv, bool setting)
        {
            Type dgvType = dgv.GetType();
            PropertyInfo pi = dgvType.GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.SetProperty);
            pi.SetValue(dgv, setting, null);
        }
    }

}
