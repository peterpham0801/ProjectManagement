using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;

namespace ProjectManagement
{
    public partial class frmProjectManagement : Form
    {
        MySqlConnection con = new MySqlConnection("server=127.0.0.1;user id=root;password = Studyinaussie123!;persistsecurityinfo=True;database=projectmanagement");
        public frmProjectManagement()
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
                string query = $"select projects.ID, projects.ProjectName, projects.StartDate, projects.EndDate, projects.StartDate2, projects.EndDate2, users.FullName\r\nfrom users\r\ninner join projects\r\non projects.manager_id = users.ID;";
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
        public DataTable GetDataTableLayout1()
        {
            DataTable table = new DataTable();

            using (MySqlConnection connection = new MySqlConnection("server=127.0.0.1;user id=root;password = Studyinaussie123!;persistsecurityinfo=True;database=projectmanagement"))
            {
                connection.Open();
                // Select * is not a good thing, but in this cases is is very usefull to make the code dynamic/reusable 
                // We get the tabel layout for our DataTable
                string query = "select * from users;";
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection))
                {
                    adapter.Fill(table);
                };
            }

            return table;
        }

        private void frmProjectManagement_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = GetDataTableLayout();
            int count  = dataGridView1.Rows.Count;
            cbbManagerId.DataSource = GetDataTableLayout1();
            cbbManagerId.DisplayMember = "FullName";
            cbbManagerId.ValueMember = "ID";
        }
        public void addProject(string projectname, string startdate, string enddate, string startdate2, string enddate2, string manager_id)
        {
            con.Open();  
            string query = string.Format("insert into Projects(ProjectName, StartDate, EndDate, StartDate2, EndDate2, manager_id) values ('{0}','{1}','{2}','{3}','{4}','{5}')", projectname, startdate, enddate, startdate2, enddate2, manager_id);
            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void editProject(string id, string projectname, string startdate, string enddate, string startdate2, string enddate2, string manager_id)
        {
            con.Open();
            string query = string.Format("update Projects set ProjectName = '{1}', StartDate = '{2}', EndDate = '{3}', StartDate2 = '{4}', EndDate = '{5}', manager_id = '{6}' where ID = '{0}'", id, projectname, startdate, enddate, startdate2, enddate2, manager_id);
            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void deleteUser(string id)
        {
            try
            {
                con.Open();
                string query = string.Format("delete from projects where ID = {0}", id);
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (SystemException ex)
            {
                MessageBox.Show("ProjectName still exist in Issues tab. Those projects need to be deleted or change manager in order to delete this row!");
            }
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string msqld1 = dtp1.Value.ToString("yyyy-MM-dd HH:mm:ss");
            string msqld2 = dtp2.Value.ToString("yyyy-MM-dd HH:mm:ss");
            string msqld3 = dtp3.Value.ToString("yyyy-MM-dd HH:mm:ss");
            string msqld4 = dtp4.Value.ToString("yyyy-MM-dd HH:mm:ss");
            if (txtName.Text == string.Empty)
            {
                MessageBox.Show("You need to insert all the values!");

            }
            else
                addProject(txtName.Text, msqld1, msqld2, msqld3, msqld4, cbbManagerId.SelectedValue.ToString());

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = GetDataTableLayout();
            txtName.Text = string.Empty;


        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            txtName.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            dtp1.Value = DateTime.Parse(dataGridView1.CurrentRow.Cells[2].Value.ToString());
            dtp2.Value = DateTime.Parse(dataGridView1.CurrentRow.Cells[3].Value.ToString());
            dtp3.Value = DateTime.Parse(dataGridView1.CurrentRow.Cells[4].Value.ToString());
            dtp4.Value = DateTime.Parse(dataGridView1.CurrentRow.Cells[5].Value.ToString());
            cbbManagerId.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (txtName.Text == string.Empty)
            {
                MessageBox.Show("This field must not be empty!");
            }
            else
            {
                if (dataGridView1.CurrentRow.Cells[1].Value.ToString() == txtName.Text && DateTime.Parse(dataGridView1.CurrentRow.Cells[2].Value.ToString()) == dtp1.Value && DateTime.Parse(dataGridView1.CurrentRow.Cells[3].Value.ToString()) == dtp2.Value && DateTime.Parse(dataGridView1.CurrentRow.Cells[4].Value.ToString()) == dtp3.Value && DateTime.Parse(dataGridView1.CurrentRow.Cells[5].Value.ToString()) == dtp4.Value && dataGridView1.CurrentRow.Cells[6].Value.ToString() == cbbManagerId.Text)
                {
                    MessageBox.Show("The value changes need to be different from the previous values!");
                }
                else
                    editProject(dataGridView1.CurrentRow.Cells[0].Value.ToString(), txtName.Text, dtp1.Value.ToString("yyyy-MM-dd HH:mm:ss"), dtp2.Value.ToString("yyyy-MM-dd HH:mm:ss"), dtp3.Value.ToString("yyyy-MM-dd HH:mm:ss"), dtp4.Value.ToString("yyyy-MM-dd HH:mm:ss"), cbbManagerId.SelectedValue.ToString());
            }
            
            
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = GetDataTableLayout();
            txtName.Text = string.Empty;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            deleteUser(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = GetDataTableLayout();
            txtName.Text = string.Empty;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
