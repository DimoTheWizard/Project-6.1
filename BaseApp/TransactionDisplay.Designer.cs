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
            this.databaseSave = new System.Windows.Forms.Button();
            this.messageBox = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.editDescriptionButton = new System.Windows.Forms.Button();
            this.editDescriptionField = new System.Windows.Forms.TextBox();
            this.editDescriptionText = new System.Windows.Forms.Label();
            this.editDescriptionMessage = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.XMLTransactions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Circular Std Black", 10F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(9, 142);
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
            this.listView1.Location = new System.Drawing.Point(12, 176);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(400, 144);
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listViewDetailed);
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
            this.label2.Location = new System.Drawing.Point(425, 142);
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
            this.dataGridView1.Location = new System.Drawing.Point(428, 176);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(337, 143);
            this.dataGridView1.TabIndex = 4;
            // 
            // databaseSave
            // 
            this.databaseSave.Font = new System.Drawing.Font("Circular Std Black", 10F, System.Drawing.FontStyle.Bold);
            this.databaseSave.Location = new System.Drawing.Point(790, 274);
            this.databaseSave.Margin = new System.Windows.Forms.Padding(2);
            this.databaseSave.Name = "databaseSave";
            this.databaseSave.Size = new System.Drawing.Size(202, 45);
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
            this.messageBox.Location = new System.Drawing.Point(781, 130);
            this.messageBox.Name = "messageBox";
            this.messageBox.Size = new System.Drawing.Size(0, 18);
            this.messageBox.TabIndex = 6;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(11, 65);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(2);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(401, 20);
            this.txtSearch.TabIndex = 7;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(11, 25);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(170, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "Search for transaction";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Pin",
            "Card"});
            this.comboBox1.Location = new System.Drawing.Point(790, 212);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(160, 21);
            this.comboBox1.TabIndex = 9;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(787, 186);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Select Cost Center";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // editDescriptionButton
            // 
            this.editDescriptionButton.Font = new System.Drawing.Font("Circular Std Black", 10F, System.Drawing.FontStyle.Bold);
            this.editDescriptionButton.Location = new System.Drawing.Point(682, 347);
            this.editDescriptionButton.Margin = new System.Windows.Forms.Padding(1);
            this.editDescriptionButton.Name = "editDescriptionButton";
            this.editDescriptionButton.Size = new System.Drawing.Size(62, 26);
            this.editDescriptionButton.TabIndex = 24;
            this.editDescriptionButton.Text = "Edit";
            this.editDescriptionButton.UseVisualStyleBackColor = true;
            this.editDescriptionButton.Visible = false;
            this.editDescriptionButton.Click += new System.EventHandler(this.editDescription);
            // 
            // editDescriptionField
            // 
            this.editDescriptionField.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.editDescriptionField.Font = new System.Drawing.Font("Circular Std Light", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editDescriptionField.Location = new System.Drawing.Point(428, 347);
            this.editDescriptionField.Margin = new System.Windows.Forms.Padding(1);
            this.editDescriptionField.Name = "editDescriptionField";
            this.editDescriptionField.Size = new System.Drawing.Size(240, 26);
            this.editDescriptionField.TabIndex = 23;
            this.editDescriptionField.Visible = false;
            // 
            // editDescriptionText
            // 
            this.editDescriptionText.AutoSize = true;
            this.editDescriptionText.Font = new System.Drawing.Font("Circular Std Black", 10F, System.Drawing.FontStyle.Bold);
            this.editDescriptionText.Location = new System.Drawing.Point(425, 328);
            this.editDescriptionText.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.editDescriptionText.Name = "editDescriptionText";
            this.editDescriptionText.Size = new System.Drawing.Size(114, 18);
            this.editDescriptionText.TabIndex = 22;
            this.editDescriptionText.Text = "Edit Description";
            this.editDescriptionText.Visible = false;
            // 
            // editDescriptionMessage
            // 
            this.editDescriptionMessage.AutoSize = true;
            this.editDescriptionMessage.Font = new System.Drawing.Font("Circular Std Black", 10F, System.Drawing.FontStyle.Bold);
            this.editDescriptionMessage.Location = new System.Drawing.Point(425, 386);
            this.editDescriptionMessage.Name = "editDescriptionMessage";
            this.editDescriptionMessage.Size = new System.Drawing.Size(0, 18);
            this.editDescriptionMessage.TabIndex = 25;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.SlateBlue;
            this.button4.Font = new System.Drawing.Font("Circular Std Black", 11.95F, System.Drawing.FontStyle.Bold);
            this.button4.ForeColor = System.Drawing.Color.White;
            this.button4.Location = new System.Drawing.Point(896, 12);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(95, 34);
            this.button4.TabIndex = 38;
            this.button4.Text = "Go Back";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.GoBackButton);
            // 
            // TransactionDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1003, 446);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.editDescriptionMessage);
            this.Controls.Add(this.editDescriptionButton);
            this.Controls.Add(this.editDescriptionField);
            this.Controls.Add(this.editDescriptionText);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.messageBox);
            this.Controls.Add(this.databaseSave);
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
        private System.Windows.Forms.Button databaseSave;
        private System.Windows.Forms.Label messageBox;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button editDescriptionButton;
        private System.Windows.Forms.TextBox editDescriptionField;
        private System.Windows.Forms.Label editDescriptionText;
        private System.Windows.Forms.Label editDescriptionMessage;
        private System.Windows.Forms.Button button4;
    }
}
