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
        MySqlConnection con = new MySqlConnection("server=127.0.0.1;user id=root;password = Studyinaussie123!;persistsecurityinfo=True;database=projectmanagement");
     
        public frmUserManagement()
        {
            InitializeComponent();
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
        public int CountDG()
        {
            return dataGridView1.RowCount;
        }
        private void frmUserManagement_Load_1(object sender, EventArgs e)
        {
            dataGridView1.DataSource = GetDataTableLayout();

        }
        public void addUser(string username, string password,string fullname, string email, string phone,bool admin)
        {
            try
            {
                Connect();
                string query = string.Format("insert into Users( UserName, UPassword, FullName, EmailAddress, PhoneNumber, AdminAccount) values ('{0}','{1}','{2}','{3}','{4}',{5})", username, password, fullname, email, phone, admin);
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.ExecuteNonQuery();
                Close();
            }
            catch (SystemException ex)
            {
                MessageBox.Show("Your username is already used!");
            }
        }
        void Connect()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
        }
        void Close()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }
        public void editUser(string id, string username, string password, string fullname, string email, string phone, bool admin)
        {
            try
            {
                con.Open();
                string query = string.Format("update users set  UserName = '{1}', UPassword = '{2}', FullName = '{3}', EmailAddress = '{4}', PhoneNumber= '{5}', AdminAccount = {6} where ID = '{0}'", id, username, password, fullname, email, phone, admin);
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (SystemException ex)
            {
                MessageBox.Show("Your username is already used!");
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
                Close();
            }
            catch (SystemException ex)
            {
                MessageBox.Show("FullName still exist in Projects tab. Those projects need to be deleted or change manager in order to delete this row!");
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
                MessageBox.Show("You need to insert all the values!");

            }
            else
            {
                addUser(txt2.Text, txt3.Text, txt4.Text, txt5.Text, txt6.Text, value);
            }
                

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = GetDataTableLayout();
            txt2.Text = txt3.Text = txt4.Text = txt5.Text = txt6.Text = string.Empty;
            cb1.Checked = false;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (txt2.Text == string.Empty || txt3.Text == string.Empty || txt4.Text == string.Empty || txt5.Text == null || txt6.Text == string.Empty)
            {
                MessageBox.Show("All fields must be filled");

            }
            else
            {
                if (dataGridView1.CurrentRow.Cells[1].Value.ToString() == txt2.Text && dataGridView1.CurrentRow.Cells[2].Value.ToString() == txt3.Text &&
                dataGridView1.CurrentRow.Cells[3].Value.ToString() == txt4.Text && dataGridView1.CurrentRow.Cells[4].Value.ToString() == txt5.Text &&
                dataGridView1.CurrentRow.Cells[5].Value.ToString() == txt6.Text && dataGridView1.CurrentRow.Cells[6].Value.ToString() == cb1.Checked.ToString() )
                {
                    MessageBox.Show("The value changes need to be different from the previous values!");
                }
                else
                {
                    editUser(dataGridView1.CurrentRow.Cells[0].Value.ToString(), txt2.Text, txt3.Text, txt4.Text, txt5.Text, txt6.Text, cb1.Checked);
                }
            }

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = GetDataTableLayout();
            txt2.Text = txt3.Text = txt4.Text = txt5.Text = txt6.Text = string.Empty;
            cb1.Checked = false;
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            txt2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txt3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txt4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txt5.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txt6.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();

            if (dataGridView1.CurrentRow.Cells[6].Value.ToString() == "True")
            {
                cb1.Checked = true;
            }
            else { cb1.Checked = false; }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            deleteUser(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = GetDataTableLayout();
            txt2.Text = txt3.Text = txt4.Text = txt5.Text = txt6.Text = string.Empty;
        }

        private void txt4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }

        }

        private void cb1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void txt2_Validating(object sender, CancelEventArgs e)
        {
           
        }

        private void txt2_Leave(object sender, EventArgs e)
        {
            if (txt2.Text.Length <= 3)
            {
                MessageBox.Show("Your username need to have more than 3 characters");
                txt2.Focus();
            }
            
        }

        private void txt3_Leave(object sender, EventArgs e)
        {
            if (txt3.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Your password is not filled or there is only spaces found");
                txt3.Focus();
            }
        }

        private void txt5_Leave(object sender, EventArgs e)
        {
            try
            {
                new System.Net.Mail.MailAddress(txt5.Text);
                txt5.Focus();
            }
            catch (ArgumentException)
            {
                MessageBox.Show("You need to fill in your email!");
            }
            catch (FormatException)
            {
                MessageBox.Show("Your email is not valid!");
            }
        }

        private void txt6_Leave(object sender, EventArgs e)
        {
            if (txt6.Text.Length > 10 && txt6.Text.Length < 10)
            {
                MessageBox.Show("Your number cant be more or less than 10 characters");
                txt6.Focus();
            }
        }
    }
}
