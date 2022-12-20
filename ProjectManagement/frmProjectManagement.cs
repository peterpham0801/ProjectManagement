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
using System.Xml.Linq;
using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;

namespace ProjectManagement
{
    public partial class frmProjectManagement : Form
    {
        MySqlConnection con = new MySqlConnection("server=127.0.0.1;user id=root;password = Studyinaussie123!;persistsecurityinfo=True;" +
            "database=projectmanagement");
        public frmProjectManagement()
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
                "True;database=projectmanagement"))
            {
                connection.Open();
                string query = $"select projects.ID, projects.ProjectName, projects.StartDate, projects.ExpectedStartDate, projects.EndDate, " +
                    $"projects.ExpectedEndDate, users.FullName\r\nfrom users\r\ninner join projects\r\non projects.manager_id = users.ID;";
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

            using (MySqlConnection connection = new MySqlConnection("server=127.0.0.1;user id=root;password = Studyinaussie123!;persistsecurityinfo=" +
                "True;database=projectmanagement"))
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
            int count = dataGridView1.Rows.Count;
            cbbManagerId.DataSource = GetDataTableLayout1();
            cbbManagerId.DisplayMember = "FullName";
            cbbManagerId.ValueMember = "ID";
            dataGridView1.Columns[0].Width = 60;
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
        public void addProject(string projectname, string startdate, string startdate2, string enddate, string enddate2, string manager_id)
        {
            try
            {
                Connect();
                string query = string.Format("insert into Projects(ProjectName, StartDate, ExpectedStartDate, EndDate, ExpectedEndDate, manager_id) " +
                    "values ('{0}','{1}','{2}','{3}','{4}','{5}')", projectname, startdate, startdate2, enddate, enddate2, manager_id);
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.ExecuteNonQuery();
                txtName.Text = string.Empty;
                txtName.ForeColor = Color.Black;
                lblAsterisk1.Visible = false;
                lblAsterisk2.Visible = false;
                lblAsterisk3.Visible = false;
                lblAsterisk4.Visible = false;
                lblAsterisk5.Visible = false;
                lblAsterisk6.Visible = false;
                Disconnect();
            }
            catch
            {
                txtName.ForeColor = Color.Red;
                lblAsterisk1.Visible = true;
                ttWarning.SetToolTip(lblAsterisk1, "The project already exists");
            }
        }
        public void editProject(string id, string projectname, string startdate, string startdate2, string enddate,  string enddate2, string manager_id)
        {
            try
            {
                Connect();
                string query = string.Format("update Projects set ProjectName = '{1}', StartDate = '{2}', ExpectedStartDate = '{3}', EndDate = '{4}'," +
                    " ExpectedEndDate = '{5}', manager_id = '{6}' where ID = '{0}'", id, projectname, startdate, startdate2, enddate, enddate2, manager_id);
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.ExecuteNonQuery();
                txtName.Text = string.Empty;
                txtName.ForeColor = Color.Black;
                lblAsterisk1.Visible = false;
                lblAsterisk2.Visible = false;
                lblAsterisk3.Visible = false;
                lblAsterisk4.Visible = false;
                lblAsterisk5.Visible = false;
                lblAsterisk6.Visible = false;
                Disconnect();
            }
            catch
            {
                txtName.ForeColor = Color.Red;
                lblAsterisk1.Visible = true;
                ttWarning.SetToolTip(lblAsterisk1, "The project already exists");
            }
        }
        public void deleteUser(string id)
        {
            try
            {
                Connect();
                string query = string.Format("delete from projects where ID = {0}", id);
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.ExecuteNonQuery();
                txtName.Text = string.Empty;
                txtName.ForeColor = Color.Black;
                lblAsterisk1.Visible = false;
                lblAsterisk2.Visible = false;
                lblAsterisk3.Visible = false;
                lblAsterisk4.Visible = false;
                lblAsterisk5.Visible = false;
                lblAsterisk6.Visible = false;
                Disconnect();
            }
            catch (SystemException)
            {
                txtName.ForeColor = Color.Red;
                lblAsterisk1.Visible = true;
                lblAsterisk2.Visible = true;
                lblAsterisk3.Visible = true;
                lblAsterisk4.Visible = true;
                lblAsterisk5.Visible = true;
                lblAsterisk6.Visible = true;
                ttWarning.SetToolTip(lblAsterisk1, "This project still exists in other tab");
                ttWarning.SetToolTip(lblAsterisk2, "This project still exists in other tab");
                ttWarning.SetToolTip(lblAsterisk3, "This project still exists in other tab");
                ttWarning.SetToolTip(lblAsterisk4, "This project still exists in other tab");
                ttWarning.SetToolTip(lblAsterisk5, "This project still exists in other tab");
                ttWarning.SetToolTip(lblAsterisk6, "This project still exists in other tab");
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string msqld1 = dtp1.Value.ToString("yyyy-MM-dd HH:mm:ss");
            string msqld2 = dtp2.Value.ToString("yyyy-MM-dd HH:mm:ss");
            string msqld3 = dtp3.Value.ToString("yyyy-MM-dd HH:mm:ss");
            string msqld4 = dtp4.Value.ToString("yyyy-MM-dd HH:mm:ss");
            if (txtName.Text == string.Empty)
            {
                txtName.ForeColor = Color.Red;
                lblAsterisk1.Visible = true;
                lblAsterisk2.Visible = true;
                lblAsterisk3.Visible = true;
                lblAsterisk4.Visible = true;
                lblAsterisk5.Visible = true;
                ttWarning.SetToolTip(lblAsterisk1, "Please fill in this field");
                ttWarning.SetToolTip(lblAsterisk2, "Please change this field");
                ttWarning.SetToolTip(lblAsterisk3, "Please change this field");
                ttWarning.SetToolTip(lblAsterisk4, "Please change this field");
                ttWarning.SetToolTip(lblAsterisk5, "Please change this field");
            }
            else
                addProject(txtName.Text, msqld1, msqld2, msqld3, msqld4, cbbManagerId.SelectedValue.ToString());

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = GetDataTableLayout();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (txtName.Text == string.Empty)
            {
                txtName.ForeColor = Color.Red;
                lblAsterisk1.Visible = true;
                lblAsterisk2.Visible = true;
                lblAsterisk3.Visible = true;
                lblAsterisk4.Visible = true;
                lblAsterisk5.Visible = true;
                ttWarning.SetToolTip(lblAsterisk1, "Please fill in this field");
                ttWarning.SetToolTip(lblAsterisk2, "Please change this field");
                ttWarning.SetToolTip(lblAsterisk3, "Please change this field");
                ttWarning.SetToolTip(lblAsterisk4, "Please change this field");
                ttWarning.SetToolTip(lblAsterisk5, "Please change this field");
            }
            else
            {
                if (dataGridView1.CurrentRow.Cells[1].Value.ToString() == txtName.Text && DateTime.Parse(dataGridView1.CurrentRow.Cells[2].Value.
                    ToString()) == dtp1.Value && DateTime.Parse(dataGridView1.CurrentRow.Cells[3].Value.ToString()) == dtp2.Value &&
                    DateTime.Parse(dataGridView1.CurrentRow.Cells[4].Value.ToString()) == dtp3.Value && DateTime.Parse(dataGridView1.CurrentRow.Cells[5].
                    Value.ToString()) == dtp4.Value && dataGridView1.CurrentRow.Cells[6].Value.ToString() == cbbManagerId.Text)
                {
                    txtName.ForeColor = Color.Red;
                    lblAsterisk1.Visible = true;
                    lblAsterisk2.Visible = true;
                    lblAsterisk3.Visible = true;
                    lblAsterisk4.Visible = true;
                    lblAsterisk5.Visible = true;
                    lblAsterisk6.Visible = true;
                    ttWarning.SetToolTip(lblAsterisk1, "Please change this field");
                    ttWarning.SetToolTip(lblAsterisk2, "Please change this field");
                    ttWarning.SetToolTip(lblAsterisk3, "Please change this field");
                    ttWarning.SetToolTip(lblAsterisk4, "Please change this field");
                    ttWarning.SetToolTip(lblAsterisk5, "Please change this field");
                    ttWarning.SetToolTip(lblAsterisk6, "Please change this field");
                }
                else
                    editProject(dataGridView1.CurrentRow.Cells[0].Value.ToString(), txtName.Text, dtp1.Value.ToString("yyyy-MM-dd HH:mm:ss"), dtp2.Value.
                        ToString("yyyy-MM-dd HH:mm:ss"), dtp3.Value.ToString("yyyy-MM-dd HH:mm:ss"), dtp4.Value.ToString("yyyy-MM-dd HH:mm:ss"), 
                        cbbManagerId.SelectedValue.ToString());
            }
            
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = GetDataTableLayout();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                deleteUser(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            }
            catch 
            {
                txtName.ForeColor = Color.Red;
                lblAsterisk1.Visible = true;
                lblAsterisk2.Visible = true;
                lblAsterisk3.Visible = true;
                lblAsterisk4.Visible = true;
                lblAsterisk5.Visible = true;
                lblAsterisk6.Visible = true;
                ttWarning.SetToolTip(lblAsterisk1, "Still exist in other tab");
                ttWarning.SetToolTip(lblAsterisk2, "Still exist in other tab");
                ttWarning.SetToolTip(lblAsterisk3, "Still exist in other tab");
                ttWarning.SetToolTip(lblAsterisk4, "Still exist in other tab");
                ttWarning.SetToolTip(lblAsterisk5, "Still exist in other tab");
                ttWarning.SetToolTip(lblAsterisk6, "Still exist in other tab");
            }
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = GetDataTableLayout();
        }
    }
}
