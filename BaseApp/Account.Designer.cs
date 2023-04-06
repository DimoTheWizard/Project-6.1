﻿namespace Sports_Accounting.BaseApp
{
    partial class Account
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
            this.useridDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usernameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.levelDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.databaseDataSet = new Sports_Accounting.DatabaseDataSet();
            this.userTableAdapter = new Sports_Accounting.DatabaseDataSetTableAdapters.UserTableAdapter();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.usernameBox = new System.Windows.Forms.TextBox();
            this.passwordBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.accessListBox = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.addMessageBox = new System.Windows.Forms.Label();
<<<<<<< HEAD
<<<<<<< HEAD
            this.button4 = new System.Windows.Forms.Button();
=======
>>>>>>> added proper login functionality and 80 percent of the user panel
=======
            this.button4 = new System.Windows.Forms.Button();
>>>>>>> can add transactions to database, fixed login, fixed parsing
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.databaseDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.useridDataGridViewTextBoxColumn,
            this.usernameDataGridViewTextBoxColumn,
            this.levelDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.userBindingSource;
<<<<<<< HEAD
<<<<<<< HEAD
            this.dataGridView1.Location = new System.Drawing.Point(12, 68);
=======
            this.dataGridView1.Location = new System.Drawing.Point(12, 55);
>>>>>>> added proper login functionality and 80 percent of the user panel
=======
            this.dataGridView1.Location = new System.Drawing.Point(12, 68);
>>>>>>> can add transactions to database, fixed login, fixed parsing
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(344, 367);
            this.dataGridView1.TabIndex = 0;
            // 
            // useridDataGridViewTextBoxColumn
            // 
            this.useridDataGridViewTextBoxColumn.DataPropertyName = "user_id";
            this.useridDataGridViewTextBoxColumn.HeaderText = "user_id";
            this.useridDataGridViewTextBoxColumn.Name = "useridDataGridViewTextBoxColumn";
            this.useridDataGridViewTextBoxColumn.ReadOnly = true;
            this.useridDataGridViewTextBoxColumn.Width = 80;
            // 
            // usernameDataGridViewTextBoxColumn
            // 
            this.usernameDataGridViewTextBoxColumn.DataPropertyName = "username";
            this.usernameDataGridViewTextBoxColumn.HeaderText = "username";
            this.usernameDataGridViewTextBoxColumn.Name = "usernameDataGridViewTextBoxColumn";
            this.usernameDataGridViewTextBoxColumn.ReadOnly = true;
            this.usernameDataGridViewTextBoxColumn.Width = 120;
            // 
            // levelDataGridViewTextBoxColumn
            // 
            this.levelDataGridViewTextBoxColumn.DataPropertyName = "level";
            this.levelDataGridViewTextBoxColumn.HeaderText = "level";
            this.levelDataGridViewTextBoxColumn.Name = "levelDataGridViewTextBoxColumn";
            this.levelDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // userBindingSource
            // 
            this.userBindingSource.DataMember = "User";
            this.userBindingSource.DataSource = this.databaseDataSet;
            // 
            // databaseDataSet
            // 
            this.databaseDataSet.DataSetName = "DatabaseDataSet";
            this.databaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // userTableAdapter
            // 
            this.userTableAdapter.ClearBeforeFill = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Circular Std Black", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
<<<<<<< HEAD
<<<<<<< HEAD
            this.label1.Location = new System.Drawing.Point(11, 35);
=======
            this.label1.Location = new System.Drawing.Point(11, 22);
>>>>>>> added proper login functionality and 80 percent of the user panel
=======
            this.label1.Location = new System.Drawing.Point(11, 35);
>>>>>>> can add transactions to database, fixed login, fixed parsing
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 30);
            this.label1.TabIndex = 10;
            this.label1.Text = "Users";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Circular Std Black", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
<<<<<<< HEAD
<<<<<<< HEAD
            this.label2.Location = new System.Drawing.Point(389, 68);
=======
            this.label2.Location = new System.Drawing.Point(404, 22);
>>>>>>> added proper login functionality and 80 percent of the user panel
=======
            this.label2.Location = new System.Drawing.Point(389, 68);
>>>>>>> can add transactions to database, fixed login, fixed parsing
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 30);
            this.label2.TabIndex = 11;
            this.label2.Text = "Add User";
            // 
            // usernameBox
            // 
<<<<<<< HEAD
<<<<<<< HEAD
            this.usernameBox.Location = new System.Drawing.Point(394, 141);
=======
            this.usernameBox.Location = new System.Drawing.Point(409, 95);
>>>>>>> added proper login functionality and 80 percent of the user panel
=======
            this.usernameBox.Location = new System.Drawing.Point(394, 141);
>>>>>>> can add transactions to database, fixed login, fixed parsing
            this.usernameBox.Name = "usernameBox";
            this.usernameBox.Size = new System.Drawing.Size(129, 20);
            this.usernameBox.TabIndex = 12;
            // 
            // passwordBox
            // 
<<<<<<< HEAD
<<<<<<< HEAD
            this.passwordBox.Location = new System.Drawing.Point(394, 190);
=======
            this.passwordBox.Location = new System.Drawing.Point(409, 144);
>>>>>>> added proper login functionality and 80 percent of the user panel
=======
            this.passwordBox.Location = new System.Drawing.Point(394, 190);
>>>>>>> can add transactions to database, fixed login, fixed parsing
            this.passwordBox.Name = "passwordBox";
            this.passwordBox.Size = new System.Drawing.Size(129, 20);
            this.passwordBox.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Circular Std Black", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
<<<<<<< HEAD
<<<<<<< HEAD
            this.label3.Location = new System.Drawing.Point(390, 114);
=======
            this.label3.Location = new System.Drawing.Point(405, 68);
>>>>>>> added proper login functionality and 80 percent of the user panel
=======
            this.label3.Location = new System.Drawing.Point(390, 114);
>>>>>>> can add transactions to database, fixed login, fixed parsing
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 24);
            this.label3.TabIndex = 14;
            this.label3.Text = "Username";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Circular Std Black", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
<<<<<<< HEAD
<<<<<<< HEAD
            this.label4.Location = new System.Drawing.Point(390, 164);
=======
            this.label4.Location = new System.Drawing.Point(405, 118);
>>>>>>> added proper login functionality and 80 percent of the user panel
=======
            this.label4.Location = new System.Drawing.Point(390, 164);
>>>>>>> can add transactions to database, fixed login, fixed parsing
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 24);
            this.label4.TabIndex = 15;
            this.label4.Text = "Password";
            // 
            // accessListBox
            // 
            this.accessListBox.Font = new System.Drawing.Font("Circular Std Black", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.accessListBox.FormattingEnabled = true;
            this.accessListBox.ItemHeight = 16;
            this.accessListBox.Items.AddRange(new object[] {
            "Guest",
            "Admin",
            "Superuser"});
<<<<<<< HEAD
<<<<<<< HEAD
            this.accessListBox.Location = new System.Drawing.Point(394, 243);
=======
            this.accessListBox.Location = new System.Drawing.Point(409, 197);
>>>>>>> added proper login functionality and 80 percent of the user panel
=======
            this.accessListBox.Location = new System.Drawing.Point(394, 243);
>>>>>>> can add transactions to database, fixed login, fixed parsing
            this.accessListBox.Name = "accessListBox";
            this.accessListBox.Size = new System.Drawing.Size(80, 52);
            this.accessListBox.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Circular Std Black", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
<<<<<<< HEAD
<<<<<<< HEAD
            this.label5.Location = new System.Drawing.Point(390, 216);
=======
            this.label5.Location = new System.Drawing.Point(405, 170);
>>>>>>> added proper login functionality and 80 percent of the user panel
=======
            this.label5.Location = new System.Drawing.Point(390, 216);
>>>>>>> can add transactions to database, fixed login, fixed parsing
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(125, 24);
            this.label5.TabIndex = 17;
            this.label5.Text = "Access Type";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Circular Std Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
<<<<<<< HEAD
<<<<<<< HEAD
            this.button1.Location = new System.Drawing.Point(394, 314);
=======
            this.button1.Location = new System.Drawing.Point(409, 268);
>>>>>>> added proper login functionality and 80 percent of the user panel
=======
            this.button1.Location = new System.Drawing.Point(394, 314);
>>>>>>> can add transactions to database, fixed login, fixed parsing
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(96, 29);
            this.button1.TabIndex = 18;
            this.button1.Text = "Add User";
            this.button1.UseVisualStyleBackColor = true;
<<<<<<< HEAD
<<<<<<< HEAD
            this.button1.Click += new System.EventHandler(this.AddUserButton);
=======
            this.button1.Click += new System.EventHandler(this.button1_Click);
>>>>>>> added proper login functionality and 80 percent of the user panel
=======
            this.button1.Click += new System.EventHandler(this.AddUserButton);
>>>>>>> can add transactions to database, fixed login, fixed parsing
            // 
            // addMessageBox
            // 
            this.addMessageBox.AutoSize = true;
            this.addMessageBox.Font = new System.Drawing.Font("Circular Std Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addMessageBox.ForeColor = System.Drawing.Color.Black;
<<<<<<< HEAD
<<<<<<< HEAD
            this.addMessageBox.Location = new System.Drawing.Point(398, 355);
=======
            this.addMessageBox.Location = new System.Drawing.Point(413, 309);
>>>>>>> added proper login functionality and 80 percent of the user panel
=======
            this.addMessageBox.Location = new System.Drawing.Point(398, 355);
>>>>>>> can add transactions to database, fixed login, fixed parsing
            this.addMessageBox.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.addMessageBox.Name = "addMessageBox";
            this.addMessageBox.Size = new System.Drawing.Size(0, 20);
            this.addMessageBox.TabIndex = 19;
            // 
<<<<<<< HEAD
<<<<<<< HEAD
=======
>>>>>>> can add transactions to database, fixed login, fixed parsing
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.SlateBlue;
            this.button4.Font = new System.Drawing.Font("Circular Std Black", 11.95F, System.Drawing.FontStyle.Bold);
            this.button4.ForeColor = System.Drawing.Color.White;
            this.button4.Location = new System.Drawing.Point(693, 12);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(95, 34);
            this.button4.TabIndex = 37;
            this.button4.Text = "Go Back";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.GoBackButton);
            // 
<<<<<<< HEAD
=======
>>>>>>> added proper login functionality and 80 percent of the user panel
=======
>>>>>>> can add transactions to database, fixed login, fixed parsing
            // Account
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
<<<<<<< HEAD
<<<<<<< HEAD
            this.Controls.Add(this.button4);
=======
>>>>>>> added proper login functionality and 80 percent of the user panel
=======
            this.Controls.Add(this.button4);
>>>>>>> can add transactions to database, fixed login, fixed parsing
            this.Controls.Add(this.addMessageBox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.accessListBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.passwordBox);
            this.Controls.Add(this.usernameBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Account";
            this.Text = "Account";
            this.Load += new System.EventHandler(this.Account_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.databaseDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private DatabaseDataSet databaseDataSet;
        private System.Windows.Forms.BindingSource userBindingSource;
        private DatabaseDataSetTableAdapters.UserTableAdapter userTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn useridDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usernameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn levelDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox usernameBox;
        private System.Windows.Forms.TextBox passwordBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox accessListBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label addMessageBox;
<<<<<<< HEAD
<<<<<<< HEAD
        private System.Windows.Forms.Button button4;
=======
>>>>>>> added proper login functionality and 80 percent of the user panel
=======
        private System.Windows.Forms.Button button4;
>>>>>>> can add transactions to database, fixed login, fixed parsing
    }
}