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
    public partial class frmIssueManagement : Form
    {
        MySqlConnection con = new MySqlConnection("server=127.0.0.1;user id=root;password = Studyinaussie123!;persistsecurityinfo=True;database=projectmanagement");
        
        public frmIssueManagement()
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
                string query = "SELECT * FROM projects";
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection))
                {
                    adapter.Fill(table);
                };
            }

            return table;
        }
        public DataTable GetDataTableLayout1()
        {
            DataTable table = new DataTable();

            using (MySqlConnection connection = new MySqlConnection("server=127.0.0.1;user id=root;password = Studyinaussie123!;persistsecurityinfo=True;database=projectmanagement"))
            {
                connection.Open();
                // Select * is not a good thing, but in this cases is is very usefull to make the code dynamic/reusable 
                // We get the tabel layout for our DataTable
                string query = $"select issues.ID, issues.IssueName, issues.IssueDescription, projects.ProjectName\r\nfrom Projects\r\ninner join issues\r\non projects.ID = issues.Project_ID;";
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

        private void frmIssueManagement_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = GetDataTableLayout1();
            cbbProjectName.DataSource= GetDataTableLayout();
            cbbProjectName.DisplayMember = "ProjectName";
            cbbProjectName.ValueMember = "ID";
            foreach (DataGridViewColumn column in dataGridView1.Columns)
               
            this.Width = dataGridView1.Width;

        }

        public void addIssue(string name, string description, string project_id)
        {
            con.Open();
            string query = string.Format("insert into Issues(IssueName, IssueDescription, Project_ID) values ('{0}','{1}','{2}')", name, description, project_id);
            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            addIssue(txt1.Text, txt2.Text, cbbProjectName.SelectedValue.ToString());
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = GetDataTableLayout1();
        }
        public void editIssue(string id, string name, string description, string project_id)
        {
            con.Open();
            string query = string.Format("update Issues set IssueName = '{1}', IssueDescription = '{2}', Project_ID = '{3}' where ID = '{0}'", id, name, description, project_id);
            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            editIssue(dataGridView1.CurrentRow.Cells[0].Value.ToString(),txt1.Text, txt2.Text, cbbProjectName.SelectedValue.ToString());
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = GetDataTableLayout1();
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            
        }
        public void deleteIssue(string id)
        {
            con.Open();
            string query = string.Format("delete from issues where ID = {0}", id);
            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            deleteIssue(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = GetDataTableLayout1();
            cbbProjectName.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
        }

        private void dataGridView1_Click_1(object sender, EventArgs e)
        {
            txt1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txt2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            cbbProjectName.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
        }
    }
}
