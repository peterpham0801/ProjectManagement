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

        private void frmUserManagement_Load_1(object sender, EventArgs e)
        {
            dataGridView1.DataSource = GetDataTableLayout();

        }
        public void addUser(string fullname, string email, string phone, string username, string password, bool admin)
        {
            con.Open();
            string query = string.Format("insert into Users(FullName, EmailAddress, PhoneNumber, UserName, UPassword, AdminAccount) values ('{0}','{1}','{2}','{3}','{4}',{5})", fullname, email, phone, username, password, admin);
            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void editUser(string id, string fullname, string email, string phone, string username, string password, bool admin)
        {
            con.Open();
            string query = string.Format("update users set FullName = '{1}', EmailAddress = '{2}', PhoneNumber= '{3}', UserName = '{4}', UPassword = '{5}', AdminAccount = {6} where ID = '{0}'", id, fullname, email, phone, username, password, admin);
            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void deleteUser(string id)
        {

            try
            {
                con.Open();
                string query = string.Format("delete from users where ID = {0}", id);
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();
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
                addUser(txt2.Text, txt3.Text, txt4.Text, txt5.Text, txt6.Text, value);


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
                if (dataGridView1.CurrentRow.Cells[1].Value.ToString() == txt2.Text && dataGridView1.CurrentRow.Cells[2].ToString() == txt3.Text &&
                dataGridView1.CurrentRow.Cells[3].Value.ToString() == txt4.Text && dataGridView1.CurrentRow.Cells[4].Value.ToString() == txt5.Text &&
                dataGridView1.CurrentRow.Cells[5].Value.ToString() == txt6.Text)
                {
                    MessageBox.Show("The value changes need to be different from the previous values!");
                }
                else
                    editUser(dataGridView1.CurrentRow.Cells[0].Value.ToString(), txt2.Text, txt3.Text, txt4.Text, txt5.Text, txt6.Text, cb1.Checked);
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
    }
}
