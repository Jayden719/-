using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class DataSelect : Form
    {


        public DataSelect()
        {
            InitializeComponent();
            this.textBox1.KeyDown += tb_KeyDown;
            this.textBox2.KeyDown += tb_KeyDown;
            this.textBox3.KeyDown += tb_KeyDown;
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
        string dbId = "";
        string dbPw = "";
        string dbIp = "";
        string comName = "";
        string addr = "";
        string faxNum = "";
        string SearchSql = "";
        string DefaultSql = "";

        private void tb_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                button2_Click(sender, e);
            }
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }

        private void DataSelect_Load(object sender, EventArgs e)
        {
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.MultiSelect = true;
            dataGridView1.ReadOnly = true;
            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersVisible = true;
            DoubleBuffered = true;      
        }
    

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            comName = textBox1.Text.Replace(" ", "");
            addr = textBox2.Text.Replace(" ", "");
            faxNum = textBox3.Text.Replace(" ", "");
            faxNum = faxNum.Replace("-", "");

            if (comName!="" && comName.Length < 2 )
            {
                MessageBox.Show("두글자 이상 적어주세요");
                return;
            }
            else if (addr!="" && addr.Length < 2)
            {
                MessageBox.Show("두글자 이상 적어주세요");
                return;
            }
            else if (faxNum!="" && faxNum.Length < 2)
            {
                MessageBox.Show("두글자 이상 적어주세요");
                return;
            }
            else
            {
                SearchSql = "select sfrominfo,";
                SearchSql = SearchSql + "(select description from CommCode with(nolock) where AGroup = code) as agroup,";
                SearchSql = SearchSql + "(select description from CommCode with(nolock) where BGroup = code) as bgroup,";
                SearchSql = SearchSql + "(select description from CommCode with(nolock) where CGroup = code) as cgroup,";
                SearchSql = SearchSql + "scomname, sowner, saddrs, szipcode, stypeofindustry, stelnum, sfaxprefix, sfaxnum, nnumofmen, ncapital, dtregdate";
                SearchSql = SearchSql + " from CLV2Data_MK2020_ADD with(nolock) where ";

                DefaultSql = "select sfrominfo,";
                DefaultSql = DefaultSql + "(select description from CommCode with(nolock) where AGroup = code) as agroup,";
                DefaultSql = DefaultSql + "(select description from CommCode with(nolock) where BGroup = code) as bgroup,";
                DefaultSql = DefaultSql + "(select description from CommCode with(nolock) where CGroup = code) as cgroup,";
                DefaultSql = DefaultSql + "scomname, sowner, saddrs, szipcode, stypeofindustry, stelnum, sfaxprefix, sfaxnum, nnumofmen, ncapital, dtregdate";
                DefaultSql = DefaultSql + " from CLV2Data_MK2020_ADD with(nolock)";


                if (comName == "" && addr == "" && faxNum == "")
                {
                    DataSet dfs = GetSearch(DefaultSql);
                    dataGridView1.DataSource = dfs.Tables[0];

                    int DrowNumber = 1;
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (row.IsNewRow) continue;
                        row.HeaderCell.Value = string.Format("{0}", DrowNumber);
                        DrowNumber++;
                    }
                    dataGridView1.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);
                    MessageBox.Show("작업이 완료되었습니다");
                    return;
                }
                else if (comName != "")
                {
                    if (addr == "" && faxNum == "")
                    {
                        SearchSql = SearchSql + "sComName like '%" + comName + "%'";

                    }
                    else if (addr != "" && faxNum == "")
                    {
                        SearchSql = SearchSql + "sComName like '%" + comName + "%' and saddrs like '%" + addr + "%'";

                    }
                    else if (addr == "" && faxNum != "")
                    {
                        SearchSql = SearchSql + "sComName like '%" + comName + "%' and sfaxNum like '%" + faxNum + "%'";
                    }
                    else
                    {
                        SearchSql = SearchSql + "sComName like '%" + comName + "%' and saddrs like '%" + addr + "%' and sfaxNum like '%" + faxNum + "%'";
                    }
                }
                else if (addr != "")
                {
                    if (faxNum == "")
                    {
                        SearchSql = SearchSql + "saddrs like '%" + addr + "%'";
                    }
                    else
                    {
                        SearchSql = SearchSql + "saddrs like '%" + addr + "%' and sfaxNum like '%" + faxNum + "%'";
                    }
                }
                else
                {
                    SearchSql = SearchSql + "sfaxNum like '%" + faxNum + "%'";
                }

                DataSet ds = GetSearch(SearchSql);
                dataGridView1.DataSource = ds.Tables[0];

                int rowNumber = 1;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.IsNewRow) continue;
                    row.HeaderCell.Value = string.Format("{0}", rowNumber);                 
                    rowNumber++;
                }
                dataGridView1.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);
                MessageBox.Show("작업이 완료되었습니다");
            }
        }

        public DataSet GetSearch(string sql)
        {
            dbId = INI_READ("ClvMk", "DbId");
            dbPw = INI_READ("ClvMk", "DbPw");
            dbIp = INI_READ("ClvMk", "DbIp");
            string strConn = "Server=" + dbIp + ";database=Intranet;" + "uid=" + dbId + ";pwd=" + dbPw + ";";

            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();

            SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
            DataSet ds = new DataSet();
            adapter.Fill(ds);

            conn.Close();
            return ds;
        }
    }
}
