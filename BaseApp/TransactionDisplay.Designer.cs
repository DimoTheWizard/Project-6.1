namespace Sports_Accounting.BaseApp
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
            ((System.ComponentModel.ISupportInitialize)(this.XMLTransactions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Circular Std Black", 10F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(12, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 18);
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
            this.listView1.Location = new System.Drawing.Point(12, 73);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(400, 352);
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
            this.label2.Location = new System.Drawing.Point(453, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 18);
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
            this.dataGridView1.Location = new System.Drawing.Point(456, 73);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(337, 352);
            this.dataGridView1.TabIndex = 4;
            // 
            // TransactionDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(835, 435);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.label1);
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
    }
}