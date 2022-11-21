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
    public partial class frmLogin : Form
    {
        MySqlConnection con = new MySqlConnection("server=127.0.0.1;user id=root;password = Studyinaussie123!;persistsecurityinfo=True;database=projectmanagement");
        MySqlDataAdapter adapter;
        List<Users> users = new List<Users>();

        public frmLogin()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Users users1= new Users();

           users = new List<Users>(users1.LoadListUser());
        }
        public DataTable loadDG()
        {
            DataTable dt = new DataTable("Users");
            string cmd = "SELECT * From Users";
            adapter = new MySqlDataAdapter(cmd, con);
            adapter.Fill(dt);

            return dt;

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var q = users.Where(t => t.UserName == txtLogin.Text && t.Password == txtPassword.Text).FirstOrDefault();
            if (q != null)
            {
                if (q.AdminAccount)
                {
                    frmDashboard frm = new frmDashboard();
                    frm.ShowDialog();
                }
                else
                {
                    frmDashboard frm = new frmDashboard("hihi");
                    frm.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Tai khoan sai");
            }
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter)) {
                var q = users.Where(t => t.UserName == txtLogin.Text && t.Password == txtPassword.Text).FirstOrDefault();
                if (q != null)
                {
                    if (q.AdminAccount)
                    {
                        frmDashboard frm = new frmDashboard();
                        frm.ShowDialog();
                    }
                    else
                    {
                        frmDashboard frm = new frmDashboard("hihi");
                        frm.ShowDialog();
                    }
                }
                else
                {
                    MessageBox.Show("Tai khoan sai");
                }
            }
        }
    }
}
