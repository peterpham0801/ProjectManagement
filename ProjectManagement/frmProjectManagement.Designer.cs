
namespace ProjectManagement
{
    partial class frmProjectManagement
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lbl2 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lbl3 = new System.Windows.Forms.Label();
            this.lbl4 = new System.Windows.Forms.Label();
            this.lbl5 = new System.Windows.Forms.Label();
            this.lbl6 = new System.Windows.Forms.Label();
            this.dtp1 = new System.Windows.Forms.DateTimePicker();
            this.dtp2 = new System.Windows.Forms.DateTimePicker();
            this.dtp3 = new System.Windows.Forms.DateTimePicker();
            this.dtp4 = new System.Windows.Forms.DateTimePicker();
            this.lbl7 = new System.Windows.Forms.Label();
            this.cbbManagerId = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(533, 426);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.Click += new System.EventHandler(this.dataGridView1_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Red;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(551, 364);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(200, 45);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnEdit.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.ForeColor = System.Drawing.Color.White;
            this.btnEdit.Location = new System.Drawing.Point(551, 313);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(200, 45);
            this.btnEdit.TabIndex = 2;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.ForestGreen;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(551, 262);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(200, 45);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lbl2
            // 
            this.lbl2.AutoSize = true;
            this.lbl2.Location = new System.Drawing.Point(551, 11);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(68, 13);
            this.lbl2.TabIndex = 7;
            this.lbl2.Text = "ProjectName";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(551, 27);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(209, 20);
            this.txtName.TabIndex = 6;
            // 
            // lbl3
            // 
            this.lbl3.AutoSize = true;
            this.lbl3.Location = new System.Drawing.Point(551, 50);
            this.lbl3.Name = "lbl3";
            this.lbl3.Size = new System.Drawing.Size(52, 13);
            this.lbl3.TabIndex = 11;
            this.lbl3.Text = "StartDate";
            // 
            // lbl4
            // 
            this.lbl4.AutoSize = true;
            this.lbl4.Location = new System.Drawing.Point(551, 89);
            this.lbl4.Name = "lbl4";
            this.lbl4.Size = new System.Drawing.Size(49, 13);
            this.lbl4.TabIndex = 9;
            this.lbl4.Text = "EndDate";
            // 
            // lbl5
            // 
            this.lbl5.AutoSize = true;
            this.lbl5.Location = new System.Drawing.Point(551, 132);
            this.lbl5.Name = "lbl5";
            this.lbl5.Size = new System.Drawing.Size(58, 13);
            this.lbl5.TabIndex = 15;
            this.lbl5.Text = "StartDate2";
            // 
            // lbl6
            // 
            this.lbl6.AutoSize = true;
            this.lbl6.Location = new System.Drawing.Point(551, 171);
            this.lbl6.Name = "lbl6";
            this.lbl6.Size = new System.Drawing.Size(55, 13);
            this.lbl6.TabIndex = 13;
            this.lbl6.Text = "EndDate2";
            // 
            // dtp1
            // 
            this.dtp1.Location = new System.Drawing.Point(551, 66);
            this.dtp1.Name = "dtp1";
            this.dtp1.Size = new System.Drawing.Size(200, 20);
            this.dtp1.TabIndex = 16;
            // 
            // dtp2
            // 
            this.dtp2.Location = new System.Drawing.Point(551, 109);
            this.dtp2.Name = "dtp2";
            this.dtp2.Size = new System.Drawing.Size(200, 20);
            this.dtp2.TabIndex = 17;
            // 
            // dtp3
            // 
            this.dtp3.Location = new System.Drawing.Point(551, 148);
            this.dtp3.Name = "dtp3";
            this.dtp3.Size = new System.Drawing.Size(200, 20);
            this.dtp3.TabIndex = 18;
            // 
            // dtp4
            // 
            this.dtp4.Location = new System.Drawing.Point(551, 187);
            this.dtp4.Name = "dtp4";
            this.dtp4.Size = new System.Drawing.Size(200, 20);
            this.dtp4.TabIndex = 19;
            // 
            // lbl7
            // 
            this.lbl7.AutoSize = true;
            this.lbl7.Location = new System.Drawing.Point(551, 207);
            this.lbl7.Name = "lbl7";
            this.lbl7.Size = new System.Drawing.Size(52, 13);
            this.lbl7.TabIndex = 21;
            this.lbl7.Text = "Manager ";
            // 
            // cbbManagerId
            // 
            this.cbbManagerId.FormattingEnabled = true;
            this.cbbManagerId.Location = new System.Drawing.Point(554, 221);
            this.cbbManagerId.Name = "cbbManagerId";
            this.cbbManagerId.Size = new System.Drawing.Size(197, 21);
            this.cbbManagerId.TabIndex = 23;
            this.cbbManagerId.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // frmProjectManagement
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cbbManagerId);
            this.Controls.Add(this.lbl7);
            this.Controls.Add(this.dtp4);
            this.Controls.Add(this.dtp3);
            this.Controls.Add(this.dtp2);
            this.Controls.Add(this.dtp1);
            this.Controls.Add(this.lbl5);
            this.Controls.Add(this.lbl6);
            this.Controls.Add(this.lbl3);
            this.Controls.Add(this.lbl4);
            this.Controls.Add(this.lbl2);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.HelpButton = true;
            this.Name = "frmProjectManagement";
            this.Load += new System.EventHandler(this.frmProjectManagement_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label lbl2;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lbl3;
        private System.Windows.Forms.Label lbl4;
        private System.Windows.Forms.Label lbl5;
        private System.Windows.Forms.Label lbl6;
        private System.Windows.Forms.DateTimePicker dtp1;
        private System.Windows.Forms.DateTimePicker dtp2;
        private System.Windows.Forms.DateTimePicker dtp3;
        private System.Windows.Forms.DateTimePicker dtp4;
        private System.Windows.Forms.Label lbl7;
        private System.Windows.Forms.ComboBox cbbManagerId;
    }
}