using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ProjectManagement
{
    public partial class frmUserManagement : Form
    {
        MySqlConnection con = new MySqlConnection("server=127.0.0.1;user id=root;password = Studyinaussie123!;persistsecurityinfo=True;database=" +
            "projectmanagement");
     
        public frmUserManagement()
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
        void ConClose()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }

        public DataTable GetDataTableLayout()
        {
            DataTable table = new DataTable();

            using (MySqlConnection connection = new MySqlConnection("server=127.0.0.1;user id=root;password = Studyinaussie123!;persistsecurityinfo=" +
                "True;database=projectmanagement"))
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

        public int CountDG()
        {   
            return dataGridView1.RowCount;
        }
        private void frmUserManagement_Load_1(object sender, EventArgs e)
        {
            dataGridView1.DataSource = GetDataTableLayout();
            dataGridView1.Columns[0].Width = 60;
        }
        public void addUser(string username, string password,string fullname, string email, string phone,bool admin)
        {
            try
            {
                Connect();
                string query = string.Format("insert into Users( UserName, UPassword, FullName, EmailAddress, PhoneNumber, AdminAccount) values " +
                    "('{0}','{1}','{2}','{3}','{4}',{5})", username, password, fullname, email, phone, admin);
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.ExecuteNonQuery();
                txt2.ForeColor = Color.Black;
                txt3.ForeColor = Color.Black;
                txt4.ForeColor = Color.Black;
                txt5.ForeColor = Color.Black;
                txt6.ForeColor = Color.Black;
                cb1.Checked = false;
                lblAsterisk1.Visible = false;
                lblAsterisk2.Visible = false;
                lblAsterisk3.Visible = false;
                lblAsterisk4.Visible = false;
                lblAsterisk5.Visible = false;
                ConClose();
            }
            catch (SystemException)
            {
                txt2.ForeColor = Color.Red;
                lblAsterisk1.Visible = true;
                ttUsername.SetToolTip(lblAsterisk1, "Username already exists");
                txt2.Focus();
            }
        }

        public void editUser(string id, string username, string password, string fullname, string email, string phone, bool admin)
        {
            try
            {
                Connect();
                string query = string.Format("update users set  UserName = '{1}', UPassword = '{2}', FullName = '{3}', EmailAddress = '{4}', " +
                    "PhoneNumber= '{5}', AdminAccount = {6} where ID = '{0}'", id, username, password, fullname, email, phone, admin);
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.ExecuteNonQuery();
                txt2.Text = txt3.Text = txt4.Text = txt5.Text = txt6.Text = string.Empty;
                txt2.ForeColor = Color.Black;
                txt3.ForeColor = Color.Black;
                txt4.ForeColor = Color.Black;
                txt5.ForeColor = Color.Black;
                txt6.ForeColor = Color.Black;
                cb1.Checked = false;
                lblAsterisk1.Visible = false;
                lblAsterisk2.Visible = false;
                lblAsterisk3.Visible = false;
                lblAsterisk4.Visible = false;
                lblAsterisk5.Visible = false;
                ConClose();
            }
            catch (SystemException)
            {
                txt2.ForeColor = Color.Red;
                lblAsterisk1.Visible = true;
                ttUsername.SetToolTip(lblAsterisk1, "Username already exists");
                txt2.Focus();
            }
            
        }
        public void deleteUser(string id)
        {
            try
            {
                Connect();
                string query = string.Format("delete from users where ID = {0}", id);
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.ExecuteNonQuery();
                txt2.Text = txt3.Text = txt4.Text = txt5.Text = txt6.Text = string.Empty;
                txt2.ForeColor = Color.Black;
                cb1.Checked = false;
                lblAsterisk1.Visible = false;
                lblAsterisk2.Visible = false;
                lblAsterisk3.Visible = false;
                lblAsterisk4.Visible = false;
                lblAsterisk5.Visible = false;
                ConClose();
            }
            catch (SystemException)
            {
                txt2.ForeColor = Color.Red;
                txt3.ForeColor = Color.Red;
                txt4.ForeColor = Color.Red;
                txt5.ForeColor = Color.Red;
                txt6.ForeColor = Color.Red;
                lblAsterisk1.Visible = true;
                lblAsterisk2.Visible = true;
                lblAsterisk3.Visible = true;
                lblAsterisk4.Visible = true;
                lblAsterisk5.Visible = true;
                ttUsername.SetToolTip(lblAsterisk1, "Still exist in other tab");
                ttUsername.SetToolTip(lblAsterisk2, "Still exist in other tab");
                ttUsername.SetToolTip(lblAsterisk3, "Still exist in other tab");
                ttUsername.SetToolTip(lblAsterisk4, "Still exist in other tab");
                ttUsername.SetToolTip(lblAsterisk5, "Still exist in other tab");
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            bool value;
            if (cb1.Checked == true)
            {
                value = true;
            }
            else
            {
                value = false;
            }

            if (txt2.Text == string.Empty || txt3.Text == string.Empty || txt4.Text == string.Empty || txt5 == null || txt6.Text == string.Empty)
            {
                txt2.ForeColor = Color.Red;
                txt3.ForeColor = Color.Red;
                txt4.ForeColor = Color.Red;
                txt5.ForeColor = Color.Red;
                txt6.ForeColor = Color.Red;
                lblAsterisk1.Visible = true;
                lblAsterisk2.Visible = true;
                lblAsterisk3.Visible = true;
                lblAsterisk4.Visible = true;
                lblAsterisk5.Visible = true;
                ttUsername.SetToolTip(lblAsterisk1, "You need to fill in this field!");
                ttUsername.SetToolTip(lblAsterisk2, "You need to fill in this field!");
                ttUsername.SetToolTip(lblAsterisk3, "You need to fill in this field!");
                ttUsername.SetToolTip(lblAsterisk4, "You need to fill in this field!");
                ttUsername.SetToolTip(lblAsterisk5, "You need to fill in this field!");
            }
            else
            {
                addUser(txt2.Text, txt3.Text, txt4.Text, txt5.Text, txt6.Text, value);
            }
             
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = GetDataTableLayout();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (txt2.Text == string.Empty || txt3.Text == string.Empty || txt4.Text == string.Empty || txt5.Text == null || txt6.Text == string.Empty)
            {
                txt2.ForeColor = Color.Red;
                txt3.ForeColor = Color.Red;
                txt4.ForeColor = Color.Red;
                txt5.ForeColor = Color.Red;
                txt6.ForeColor = Color.Red;
                lblAsterisk1.Visible = true;
                lblAsterisk2.Visible = true;
                lblAsterisk3.Visible = true;
                lblAsterisk4.Visible = true;
                lblAsterisk5.Visible = true;
                ttUsername.SetToolTip(lblAsterisk1, "You need to fill in this field!");
                ttUsername.SetToolTip(lblAsterisk2, "You need to fill in this field!");
                ttUsername.SetToolTip(lblAsterisk3, "You need to fill in this field!");
                ttUsername.SetToolTip(lblAsterisk4, "You need to fill in this field!");
                ttUsername.SetToolTip(lblAsterisk5, "You need to fill in this field!");
            }
            else
            {
                if (dataGridView1.CurrentRow.Cells[1].Value.ToString() == txt2.Text && dataGridView1.CurrentRow.Cells[2].Value.ToString() == txt3.Text &&
                dataGridView1.CurrentRow.Cells[3].Value.ToString() == txt4.Text && dataGridView1.CurrentRow.Cells[4].Value.ToString() == txt5.Text &&
                dataGridView1.CurrentRow.Cells[5].Value.ToString() == txt6.Text && dataGridView1.CurrentRow.Cells[6].Value.ToString() == cb1.Checked.
                ToString())
                {
                    txt2.ForeColor = Color.Red;
                    txt3.ForeColor = Color.Red;
                    txt4.ForeColor = Color.Red;
                    txt5.ForeColor = Color.Red;
                    txt6.ForeColor = Color.Red;
                    lblAsterisk1.Visible = true;
                    lblAsterisk2.Visible = true;
                    lblAsterisk3.Visible = true;
                    lblAsterisk4.Visible = true;
                    lblAsterisk5.Visible = true;
                    ttUsername.SetToolTip(lblAsterisk1, "This needs to be different!");
                    ttUsername.SetToolTip(lblAsterisk2, "This needs to be different!");
                    ttUsername.SetToolTip(lblAsterisk3, "This needs to be different!");
                    ttUsername.SetToolTip(lblAsterisk4, "This needs to be different!");
                    ttUsername.SetToolTip(lblAsterisk5, "This needs to be different!");
                }
                else
                {
                    editUser(dataGridView1.CurrentRow.Cells[0].Value.ToString(), txt2.Text, txt3.Text, txt4.Text, txt5.Text, txt6.Text, cb1.Checked);
                }
            }

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = GetDataTableLayout();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            deleteUser(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = GetDataTableLayout();
            
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            txt2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txt3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txt4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txt5.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txt6.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            txt2.ForeColor = Color.Black;
            txt3.ForeColor = Color.Black;
            txt4.ForeColor = Color.Black;
            txt5.ForeColor = Color.Black;
            txt6.ForeColor = Color.Black;
            lblAsterisk1.Visible = false;
            lblAsterisk2.Visible = false;
            lblAsterisk3.Visible = false;
            lblAsterisk4.Visible = false;
            lblAsterisk5.Visible = false;

            if (dataGridView1.CurrentRow.Cells[6].Value.ToString() == "True")
            {
                cb1.Checked = true;
            }
            else { cb1.Checked = false; }
        }

        private void txt4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txt2_Leave(object sender, EventArgs e)
        {
            if (txt2.Text.Length <= 3)
            {
                txt2.ForeColor = Color.Red;
                lblAsterisk1.Visible = true;
                ttUsername.SetToolTip(lblAsterisk1, "Username needs to be more than 3 characters!");
                txt2.Focus();
            }
            else if (txt2.Text.Length > 3)
            {
                txt2.ForeColor = Color.Black;
                lblAsterisk1.Visible = false;
            }
            
        }

        private void txt3_Leave(object sender, EventArgs e)
        {
            if (txt3.Text.Trim() == string.Empty)
            {
                txt3.ForeColor = Color.Red;
                lblAsterisk2.Visible = true;
                ttUsername.SetToolTip(lblAsterisk2, "You need to fill in your password!");
                txt3.Focus();
            }
            else
            {
                txt3.ForeColor = Color.Black;
                lblAsterisk2.Visible = false;
            }
        }

        private void txt4_Leave(object sender, EventArgs e)
        {
            if (txt4.Text.Trim() == string.Empty)
            {
                txt4.ForeColor = Color.Red;
                lblAsterisk3.Visible = true;
                ttUsername.SetToolTip(lblAsterisk3, "You need to type in your full name!");
                txt3.Focus();
            }
            else
            {
                txt4.ForeColor = Color.Black;
                lblAsterisk3.Visible = false;
            }
        }

        private void txt5_Leave(object sender, EventArgs e)
        {
            try
            {
                new System.Net.Mail.MailAddress(txt5.Text);
                txt5.ForeColor = Color.Black;
                lblAsterisk4.Visible = false;
            }
            catch (ArgumentException)
            {
                txt5.ForeColor = Color.Red;
                lblAsterisk4.Visible = true;
                ttUsername.SetToolTip(lblAsterisk4, "You need to fill in your email!");
                txt5.Focus();
            }
            catch (FormatException)
            {
                txt5.ForeColor = Color.Red;
                lblAsterisk4.Visible = true;
                ttUsername.SetToolTip(lblAsterisk4, "Your email needs to be valid!");
                txt5.Focus();
            }
        }

        private void txt6_Leave(object sender, EventArgs e)
        {
            if (txt6.Text.Length > 10)
            {
                txt6.ForeColor = Color.Red;
                lblAsterisk5.Visible = true;
                ttUsername.SetToolTip(lblAsterisk5, "Your phone number is too long!");
                txt6.Focus();
            }
            else if (txt6.Text.Length < 10)
            {
                txt6.ForeColor = Color.Red;
                lblAsterisk5.Visible = true;
                ttUsername.SetToolTip(lblAsterisk5, "Your phone number is too short!");
                txt6.Focus();
            }
            else
            {
                txt6.ForeColor = Color.Black;
                lblAsterisk5.Visible = false;
            }
        }
    }
}
