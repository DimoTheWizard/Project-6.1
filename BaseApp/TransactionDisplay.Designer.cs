﻿namespace Sports_Accounting.BaseApp
{
    partial class TransactionDisplay
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
            this.label1 = new System.Windows.Forms.Label();
            this.XMLTransactions = new System.Data.DataSet();
            this.listView1 = new System.Windows.Forms.ListView();
            this.Account = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ClosingBalance = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TransactionReference = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.databaseSave = new System.Windows.Forms.Button();
            this.messageBox = new System.Windows.Forms.Label();
            this.searchBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.XMLTransactions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Circular Std Black", 10F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(18, 80);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Transactions";
            // 
            // XMLTransactions
            // 
            this.XMLTransactions.DataSetName = "XMLTransactions";
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Account,
            this.ClosingBalance,
            this.TransactionReference});
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(18, 112);
            this.listView1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(598, 539);
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listView1_ItemSelectionChanged);
            // 
            // Account
            // 
            this.Account.Text = "Account";
            this.Account.Width = 150;
            // 
            // ClosingBalance
            // 
            this.ClosingBalance.Text = "ClosingBalance";
            this.ClosingBalance.Width = 110;
            // 
            // TransactionReference
            // 
            this.TransactionReference.Text = "Transaction Reference";
            this.TransactionReference.Width = 125;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Circular Std Black", 10F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(636, 80);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(194, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Transaction Details";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(642, 112);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(506, 540);
            this.dataGridView1.TabIndex = 4;
            // 
            // databaseSave
            // 
            this.databaseSave.Font = new System.Drawing.Font("Circular Std Black", 10F, System.Drawing.FontStyle.Bold);
            this.databaseSave.Location = new System.Drawing.Point(1176, 112);
            this.databaseSave.Name = "databaseSave";
            this.databaseSave.Size = new System.Drawing.Size(303, 69);
            this.databaseSave.TabIndex = 5;
            this.databaseSave.Text = "Save all to databasee";
            this.databaseSave.UseVisualStyleBackColor = true;
            this.databaseSave.Visible = false;
            this.databaseSave.Click += new System.EventHandler(this.databaseSave_Click);
            // 
            // messageBox
            // 
            this.messageBox.AutoSize = true;
            this.messageBox.Font = new System.Drawing.Font("Circular Std Black", 10F, System.Drawing.FontStyle.Bold);
            this.messageBox.Location = new System.Drawing.Point(1172, 200);
            this.messageBox.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.messageBox.Name = "messageBox";
            this.messageBox.Size = new System.Drawing.Size(0, 25);
            this.messageBox.TabIndex = 6;
            // 
            // searchBox
            // 
            this.searchBox.Location = new System.Drawing.Point(1177, 291);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(303, 26);
            this.searchBox.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(1184, 247);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(224, 25);
            this.label3.TabIndex = 8;
            this.label3.Text = "Search for transaction";
            // 
            // TransactionDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1504, 686);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.searchBox);
            this.Controls.Add(this.messageBox);
            this.Controls.Add(this.databaseSave);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "TransactionDisplay";
            this.Text = "TransactionDisplay";
            this.Load += new System.EventHandler(this.TransactionDisplay_Load);
            ((System.ComponentModel.ISupportInitialize)(this.XMLTransactions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Data.DataSet XMLTransactions;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader Account;
        private System.Windows.Forms.ColumnHeader ClosingBalance;
        private System.Windows.Forms.ColumnHeader TransactionReference;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button databaseSave;
        private System.Windows.Forms.Label messageBox;
        private System.Windows.Forms.TextBox searchBox;
        private System.Windows.Forms.Label label3;
    }
}