
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
            this.components = new System.ComponentModel.Container();
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
            this.lblAsterisk1 = new System.Windows.Forms.Label();
            this.lblAsterisk2 = new System.Windows.Forms.Label();
            this.lblAsterisk6 = new System.Windows.Forms.Label();
            this.lblAsterisk5 = new System.Windows.Forms.Label();
            this.lblAsterisk4 = new System.Windows.Forms.Label();
            this.lblAsterisk3 = new System.Windows.Forms.Label();
            this.ttWarning = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 11);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(533, 427);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.Click += new System.EventHandler(this.dataGridView1_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Red;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(560, 376);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(209, 48);
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
            this.btnEdit.Location = new System.Drawing.Point(560, 322);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(209, 48);
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
            this.btnAdd.Location = new System.Drawing.Point(560, 268);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(209, 48);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lbl2
            // 
            this.lbl2.AutoSize = true;
            this.lbl2.Location = new System.Drawing.Point(560, 11);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(68, 13);
            this.lbl2.TabIndex = 7;
            this.lbl2.Text = "ProjectName";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(560, 27);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(209, 20);
            this.txtName.TabIndex = 6;
            // 
            // lbl3
            // 
            this.lbl3.AutoSize = true;
            this.lbl3.Location = new System.Drawing.Point(560, 50);
            this.lbl3.Name = "lbl3";
            this.lbl3.Size = new System.Drawing.Size(52, 13);
            this.lbl3.TabIndex = 11;
            this.lbl3.Text = "StartDate";
            // 
            // lbl4
            // 
            this.lbl4.AutoSize = true;
            this.lbl4.Location = new System.Drawing.Point(560, 128);
            this.lbl4.Name = "lbl4";
            this.lbl4.Size = new System.Drawing.Size(49, 13);
            this.lbl4.TabIndex = 9;
            this.lbl4.Text = "EndDate";
            // 
            // lbl5
            // 
            this.lbl5.AutoSize = true;
            this.lbl5.Location = new System.Drawing.Point(560, 89);
            this.lbl5.Name = "lbl5";
            this.lbl5.Size = new System.Drawing.Size(97, 13);
            this.lbl5.TabIndex = 15;
            this.lbl5.Text = "ExpectedStartDate";
            // 
            // lbl6
            // 
            this.lbl6.AutoSize = true;
            this.lbl6.Location = new System.Drawing.Point(560, 167);
            this.lbl6.Name = "lbl6";
            this.lbl6.Size = new System.Drawing.Size(55, 13);
            this.lbl6.TabIndex = 13;
            this.lbl6.Text = "EndDate2";
            // 
            // dtp1
            // 
            this.dtp1.Location = new System.Drawing.Point(560, 66);
            this.dtp1.Name = "dtp1";
            this.dtp1.Size = new System.Drawing.Size(209, 20);
            this.dtp1.TabIndex = 16;
            // 
            // dtp2
            // 
            this.dtp2.Location = new System.Drawing.Point(560, 105);
            this.dtp2.Name = "dtp2";
            this.dtp2.Size = new System.Drawing.Size(209, 20);
            this.dtp2.TabIndex = 17;
            // 
            // dtp3
            // 
            this.dtp3.Location = new System.Drawing.Point(560, 144);
            this.dtp3.Name = "dtp3";
            this.dtp3.Size = new System.Drawing.Size(209, 20);
            this.dtp3.TabIndex = 18;
            // 
            // dtp4
            // 
            this.dtp4.Location = new System.Drawing.Point(560, 183);
            this.dtp4.Name = "dtp4";
            this.dtp4.Size = new System.Drawing.Size(209, 20);
            this.dtp4.TabIndex = 19;
            // 
            // lbl7
            // 
            this.lbl7.AutoSize = true;
            this.lbl7.Location = new System.Drawing.Point(560, 205);
            this.lbl7.Name = "lbl7";
            this.lbl7.Size = new System.Drawing.Size(52, 13);
            this.lbl7.TabIndex = 21;
            this.lbl7.Text = "Manager ";
            // 
            // cbbManagerId
            // 
            this.cbbManagerId.FormattingEnabled = true;
            this.cbbManagerId.Location = new System.Drawing.Point(560, 221);
            this.cbbManagerId.Name = "cbbManagerId";
            this.cbbManagerId.Size = new System.Drawing.Size(209, 21);
            this.cbbManagerId.TabIndex = 23;
            // 
            // lblAsterisk1
            // 
            this.lblAsterisk1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAsterisk1.ForeColor = System.Drawing.Color.Red;
            this.lblAsterisk1.Location = new System.Drawing.Point(775, 27);
            this.lblAsterisk1.Name = "lblAsterisk1";
            this.lblAsterisk1.Size = new System.Drawing.Size(18, 20);
            this.lblAsterisk1.TabIndex = 38;
            this.lblAsterisk1.Text = "*";
            this.lblAsterisk1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblAsterisk1.Visible = false;
            // 
            // lblAsterisk2
            // 
            this.lblAsterisk2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAsterisk2.ForeColor = System.Drawing.Color.Red;
            this.lblAsterisk2.Location = new System.Drawing.Point(775, 66);
            this.lblAsterisk2.Name = "lblAsterisk2";
            this.lblAsterisk2.Size = new System.Drawing.Size(18, 20);
            this.lblAsterisk2.TabIndex = 39;
            this.lblAsterisk2.Text = "*";
            this.lblAsterisk2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblAsterisk2.Visible = false;
            // 
            // lblAsterisk6
            // 
            this.lblAsterisk6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAsterisk6.ForeColor = System.Drawing.Color.Red;
            this.lblAsterisk6.Location = new System.Drawing.Point(775, 222);
            this.lblAsterisk6.Name = "lblAsterisk6";
            this.lblAsterisk6.Size = new System.Drawing.Size(18, 20);
            this.lblAsterisk6.TabIndex = 45;
            this.lblAsterisk6.Text = "*";
            this.lblAsterisk6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblAsterisk6.Visible = false;
            // 
            // lblAsterisk5
            // 
            this.lblAsterisk5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAsterisk5.ForeColor = System.Drawing.Color.Red;
            this.lblAsterisk5.Location = new System.Drawing.Point(775, 183);
            this.lblAsterisk5.Name = "lblAsterisk5";
            this.lblAsterisk5.Size = new System.Drawing.Size(18, 20);
            this.lblAsterisk5.TabIndex = 44;
            this.lblAsterisk5.Text = "*";
            this.lblAsterisk5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblAsterisk5.Visible = false;
            // 
            // lblAsterisk4
            // 
            this.lblAsterisk4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAsterisk4.ForeColor = System.Drawing.Color.Red;
            this.lblAsterisk4.Location = new System.Drawing.Point(775, 144);
            this.lblAsterisk4.Name = "lblAsterisk4";
            this.lblAsterisk4.Size = new System.Drawing.Size(18, 20);
            this.lblAsterisk4.TabIndex = 43;
            this.lblAsterisk4.Text = "*";
            this.lblAsterisk4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblAsterisk4.Visible = false;
            // 
            // lblAsterisk3
            // 
            this.lblAsterisk3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAsterisk3.ForeColor = System.Drawing.Color.Red;
            this.lblAsterisk3.Location = new System.Drawing.Point(775, 105);
            this.lblAsterisk3.Name = "lblAsterisk3";
            this.lblAsterisk3.Size = new System.Drawing.Size(18, 20);
            this.lblAsterisk3.TabIndex = 42;
            this.lblAsterisk3.Text = "*";
            this.lblAsterisk3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblAsterisk3.Visible = false;
            // 
            // frmProjectManagement
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblAsterisk6);
            this.Controls.Add(this.lblAsterisk5);
            this.Controls.Add(this.lblAsterisk4);
            this.Controls.Add(this.lblAsterisk3);
            this.Controls.Add(this.lblAsterisk2);
            this.Controls.Add(this.lblAsterisk1);
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
        private System.Windows.Forms.Label lblAsterisk1;
        private System.Windows.Forms.Label lblAsterisk2;
        private System.Windows.Forms.Label lblAsterisk6;
        private System.Windows.Forms.Label lblAsterisk5;
        private System.Windows.Forms.Label lblAsterisk4;
        private System.Windows.Forms.Label lblAsterisk3;
        private System.Windows.Forms.ToolTip ttWarning;
    }
}