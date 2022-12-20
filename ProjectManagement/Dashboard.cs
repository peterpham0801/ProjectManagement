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
        bool NotAdmin = false;
        MySqlConnection con = new MySqlConnection("server=127.0.0.1;user id=root;password=Studyinaussie123!;persistsecurityinfo=True;database=projectmanagement");
        public frmDashboard()
        {
            InitializeComponent();
            
        }
        void Connect()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
        }
        void Disconnect()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }

        public frmDashboard(string a)
        {
            InitializeComponent();
            frmUserManagement frm = new frmUserManagement();
            NotAdmin = true;
            ttNoAdmin.SetToolTip(btn1, "You need to be the admin to access this tab");
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (NotAdmin) { }
            else
            {
                tlp1.Controls.Clear();
                frmUserManagement frm = new frmUserManagement();
                frm.MdiParent = this;
                frm.Show();
                tlp1.Controls.Add(frm);
                Connect();
                lblCat.Text = string.Format("USERS: {0}", frm.CountDG().ToString());
                string query = string.Format("select count(ID) from Users");
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.ExecuteNonQuery();
                Disconnect();
            }
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            tlp1.Controls.Clear();
            frmProjectManagement frm = new frmProjectManagement();
            frm.MdiParent = this;
            frm.Show();
            tlp1.Controls.Add(frm);
            lblCat.Text = string.Format("PROJECTS: {0}", frm.CountDG().ToString());
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            tlp1.Controls.Clear();
            frmIssueManagement frm = new frmIssueManagement();
            frm.MdiParent = this;
            frm.Show();
            tlp1.Controls.Add(frm);
            lblCat.Text = string.Format("ISSUES: {0}", frm.CountDG().ToString());

        }

        private void frmDashboard_Load(object sender, EventArgs e)
        {
            tlp1.Controls.Clear();
            frmProjectManagement frm = new frmProjectManagement();
            frm.MdiParent = this;
            frm.Show();
            tlp1.Controls.Add(frm);
            lblCat.Text = string.Format("PROJECTS: {0}", frm.CountDG().ToString());
        }
    }
}
