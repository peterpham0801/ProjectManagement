using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectManagement
{
    public partial class frmDashboard : Form
    {
        MySqlConnection con = new MySqlConnection("server=127.0.0.1;user id=root;password = Studyinaussie123!;persistsecurityinfo=True;database=projectmanagement");
        public frmDashboard()
        {
            InitializeComponent();
        }
        public frmDashboard(string a)
        {
            InitializeComponent();
            btn1.Enabled = false;
        }
        public DataTable GetDataTableLayout()
        {
            DataTable table = new DataTable();

            using (MySqlConnection connection = new MySqlConnection("server=127.0.0.1;user id=root;password = Studyinaussie123!;persistsecurityinfo=True;database=projectmanagement"))
            {
                connection.Open();
                // Select * is not a good thing, but in this cases is is very usefull to make the code dynamic/reusable 
                // We get the tabel layout for our DataTable
                string query = "SELECT * FROM users order by ID";
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection))
                {
                    adapter.Fill(table);
                };
            }

            return table;
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {


        }

        private void button1_Click(object sender, EventArgs e)
        {
            tlp1.Controls.Clear();
            frmUserManagement frm = new frmUserManagement();
            frm.MdiParent = this;
            frm.Show();
            tlp1.Controls.Add(frm);

            //tlp1.Controls.Clear();
            //frmProjectManagement frm = new frmProjectManagement();
            //frm.MdiParent = this;
            //frm.Show();
            //tlp1.Controls.Add(frm);
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn2_Click(object sender, EventArgs e)
        {
            tlp1.Controls.Clear();
            frmProjectManagement frm = new frmProjectManagement();
            frm.MdiParent = this;
            frm.Show();
            tlp1.Controls.Add(frm);
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            tlp1.Controls.Clear();
            frmIssueManagement frm = new frmIssueManagement();
            frm.MdiParent = this;
            frm.Show();
            tlp1.Controls.Add(frm);
        }

        private void lbl1_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void frmDashboard_Load(object sender, EventArgs e)
        {

        }
    }
}
