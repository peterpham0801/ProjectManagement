using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;

namespace ProjectManagement
{
    public partial class frmIssueManagement : Form
    {
        MySqlConnection con = new MySqlConnection("server=127.0.0.1;user id=root;password = Studyinaussie123!;persistsecurityinfo=True;database=" +
            "projectmanagement");
        
        public frmIssueManagement()
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
        public DataTable GetDataTableLayout()
        {
            DataTable table = new DataTable();

            using (MySqlConnection connection = new MySqlConnection("server=127.0.0.1;user id=root;password = Studyinaussie123!;persistsecurityinfo=" +
                "True;" +
                "database=projectmanagement"))
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

            using (MySqlConnection connection = new MySqlConnection("server=127.0.0.1;user id=root;password = Studyinaussie123!;persistsecurityinfo=" +
                "True;database=projectmanagement"))
            {
                connection.Open();
                string query = $"select issues.Id, issues.IssueName, projects.ProjectName\r\nfrom Projects\r\ninner join issues\r\non projects.ID = " +
                    $"issues.Project_ID;";
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection))
                {
                    adapter.Fill(table);
                };
            }

            return table;
        }
         public string GetDescriptionString(string id)
        {
            string description;
            Connect();
            string query = string.Format("select issues.IssueDescription from Issues where id = {0}", id);
            MySqlCommand cmd = new MySqlCommand(query, con);
            description = cmd.ExecuteScalar().ToString();
            Disconnect();
            return description;
        }
        
        public int CountDG()
        {
            return dataGridView1.RowCount;
        }
       
        private void frmIssueManagement_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = GetDataTableLayout1();
            cbbProjectName.DataSource= GetDataTableLayout();
            cbbProjectName.DisplayMember = "ProjectName";
            cbbProjectName.ValueMember = "ID";
            foreach (DataGridViewColumn column in dataGridView1.Columns)
               this.Width = dataGridView1.Width;

            dataGridView1.Columns[0].Width = 50;

        }

        public void addIssue(string name, string description, string project_id)
        {
            Connect();
            string query = string.Format("insert into Issues(IssueName, IssueDescription, Project_ID) values ('{0}','{1}','{2}')", name, description,
                project_id);
            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.ExecuteNonQuery();
            txt1.ForeColor = Color.Black;
            txt2.ForeColor = Color.Black;
            lblAsterisk1.Visible = false;
            lblAsterisk2.Visible = false;
            lblAsterisk3.Visible = false;
            Disconnect();
        }

        public void editIssue(string id, string name, string description, string project_id)
        {
            Connect();
            string query = string.Format("update Issues set IssueName = '{1}', IssueDescription = '{2}', Project_ID = '{3}' where ID = '{0}'", id, name,
                description, project_id);
            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.ExecuteNonQuery();
            txt1.ForeColor = Color.Black;
            txt2.ForeColor = Color.Black;
            lblAsterisk1.Visible = false;
            lblAsterisk2.Visible = false;
            lblAsterisk3.Visible = false;
            Disconnect();
        }
        public void deleteIssue(string id)
        {
            Connect();
            string query = string.Format("delete from issues where ID = {0}", id);
            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.ExecuteNonQuery();
            txt1.ForeColor = Color.Black;
            txt2.ForeColor = Color.Black;
            lblAsterisk1.Visible = false;
            lblAsterisk2.Visible = false;
            lblAsterisk3.Visible = false;
            Disconnect();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txt1.Text == string.Empty || txt2.Text == string.Empty)
            {
                lblAsterisk1.Visible = true;
                lblAsterisk2.Visible = true;
                lblAsterisk3.Visible = true;
                txt1.ForeColor = Color.Red;
                txt2.ForeColor = Color.Red;
                ttWarning.SetToolTip(lblAsterisk1, "You need to fill in this field");
                ttWarning.SetToolTip(lblAsterisk2, "You need to fill in this field");
            }
            else
                addIssue(txt1.Text, txt2.Text, cbbProjectName.SelectedValue.ToString());

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = GetDataTableLayout1();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (txt1.Text == string.Empty || txt2.Text == string.Empty || cbbProjectName.Text == string.Empty)
            {
                lblAsterisk1.Visible = true;
                lblAsterisk2.Visible = true;
                lblAsterisk3.Visible = true;
                txt1.ForeColor = Color.Red;
                txt2.ForeColor = Color.Red;
                ttWarning.SetToolTip(lblAsterisk1, "You need to fill in this field");
                ttWarning.SetToolTip(lblAsterisk2, "You need to fill in this field");
                ttWarning.SetToolTip(lblAsterisk3, "You need to fill in this field");
            }
            else
            {
                if (dataGridView1.CurrentRow.Cells[1].Value.ToString() == txt1.Text && dataGridView1.CurrentRow.Cells[2].Value.ToString() == txt2.Text &&
                dataGridView1.CurrentRow.Cells[3].Value.ToString() == cbbProjectName.Text)
                {
                    lblAsterisk1.Visible = true;
                    lblAsterisk2.Visible = true;
                    lblAsterisk3.Visible = true;
                    txt1.ForeColor = Color.Red;
                    txt2.ForeColor = Color.Red;
                    ttWarning.SetToolTip(lblAsterisk1, "This field needs to be different!");
                    ttWarning.SetToolTip(lblAsterisk2, "This field needs to be different!");
                    ttWarning.SetToolTip(lblAsterisk3, "this field needs to be different!");
                }
                else
                    editIssue(dataGridView1.CurrentRow.Cells[0].Value.ToString(), txt1.Text, txt2.Text, cbbProjectName.SelectedValue.ToString());
            }
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = GetDataTableLayout1();
            txt1.Text = txt2.Text = string.Empty;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            deleteIssue(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = GetDataTableLayout1();
        }

        private void dataGridView1_Click_1(object sender, EventArgs e)
        {
            txt1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            cbbProjectName.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txt2.Text = GetDescriptionString(dataGridView1.CurrentRow.Cells[0].Value.ToString());
        }

        private void btnItalic_Click(object sender, EventArgs e)
        {
            if (!txt2.SelectionFont.Italic)
            {
                txt2.SelectionFont = new Font(txt2.SelectionFont, FontStyle.Italic);
            }
            else
            {
                txt2.SelectionFont = new Font(txt2.SelectionFont, FontStyle.Regular);
            }
            
        }

        private void btnBold_Click(object sender, EventArgs e)
        {
            if (!txt2.SelectionFont.Bold)
            {
                txt2.SelectionFont = new Font(txt2.SelectionFont, FontStyle.Bold);
            }
            else
            {
                txt2.SelectionFont = new Font(txt2.SelectionFont, FontStyle.Bold);
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            txt1.Text = string.Empty;
            txt2.Text = string.Empty;
            txt1.ForeColor = Color.Black;
            txt2.ForeColor = Color.Black;
            lblAsterisk1.Visible = false;
            lblAsterisk2.Visible = false;
            lblAsterisk3.Visible = false;
        }
    }
}
