using System.Windows.Forms;

namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button3 = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.textBox17 = new System.Windows.Forms.TextBox();
            this.richTextBox5 = new System.Windows.Forms.RichTextBox();
            this.richTextBox4 = new System.Windows.Forms.RichTextBox();
            this.textBox16 = new System.Windows.Forms.TextBox();
            this.textBox15 = new System.Windows.Forms.TextBox();
            this.textBox14 = new System.Windows.Forms.TextBox();
            this.textBox13 = new System.Windows.Forms.TextBox();
            this.textBox12 = new System.Windows.Forms.TextBox();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.richTextBox3 = new System.Windows.Forms.RichTextBox();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.MonthlySummary = new System.Windows.Forms.TextBox();
            this.Summary = new System.Windows.Forms.RichTextBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button6 = new System.Windows.Forms.Button();
            this.transactionsPage1 = new WindowsFormsApp1.TransactionsPage();
            this.listView1 = new System.Windows.Forms.ListView();
            this.Id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Content = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.View = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(12, 198);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(53, 23);
            this.button3.TabIndex = 30;
            this.button3.Text = "Home";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button1
            // 
            this.button1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.button1.Location = new System.Drawing.Point(983, 387);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(108, 23);
            this.button1.TabIndex = 61;
            this.button1.Text = "Check all";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 174);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(53, 277);
            this.pictureBox1.TabIndex = 60;
            this.pictureBox1.TabStop = false;
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.ForeColor = System.Drawing.Color.Gray;
            this.button2.Location = new System.Drawing.Point(983, 535);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(112, 34);
            this.button2.TabIndex = 59;
            this.button2.Text = "Settings";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.DarkBlue;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button5.ForeColor = System.Drawing.Color.White;
            this.button5.Location = new System.Drawing.Point(773, 535);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(183, 34);
            this.button5.TabIndex = 58;
            this.button5.Text = "New transaction";
            this.button5.UseVisualStyleBackColor = false;
            // 
            // textBox17
            // 
            this.textBox17.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.textBox17.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox17.Font = new System.Drawing.Font("Circular Std Black", 10F, System.Drawing.FontStyle.Bold);
            this.textBox17.ForeColor = System.Drawing.Color.DarkGray;
            this.textBox17.Location = new System.Drawing.Point(773, 390);
            this.textBox17.Name = "textBox17";
            this.textBox17.Size = new System.Drawing.Size(199, 16);
            this.textBox17.TabIndex = 57;
            this.textBox17.Text = "Latest transaction";
            // 
            // richTextBox5
            // 
            this.richTextBox5.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.richTextBox5.Location = new System.Drawing.Point(757, 376);
            this.richTextBox5.Name = "richTextBox5";
            this.richTextBox5.Size = new System.Drawing.Size(357, 214);
            this.richTextBox5.TabIndex = 56;
            this.richTextBox5.Text = "";
            // 
            // richTextBox4
            // 
            this.richTextBox4.AccessibleRole = System.Windows.Forms.AccessibleRole.ListItem;
            this.richTextBox4.BackColor = System.Drawing.SystemColors.Window;
            this.richTextBox4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox4.ForeColor = System.Drawing.Color.DarkGray;
            this.richTextBox4.Location = new System.Drawing.Point(1000, 109);
            this.richTextBox4.Name = "richTextBox4";
            this.richTextBox4.Size = new System.Drawing.Size(150, 30);
            this.richTextBox4.TabIndex = 55;
            this.richTextBox4.Text = "Last month";
            // 
            // textBox16
            // 
            this.textBox16.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox16.Font = new System.Drawing.Font("Circular Std Black", 11F, System.Drawing.FontStyle.Bold);
            this.textBox16.ForeColor = System.Drawing.Color.DarkGray;
            this.textBox16.Location = new System.Drawing.Point(329, 36);
            this.textBox16.Name = "textBox16";
            this.textBox16.Size = new System.Drawing.Size(207, 18);
            this.textBox16.TabIndex = 54;
            this.textBox16.Text = "Welcom back, Rob!";
            // 
            // textBox15
            // 
            this.textBox15.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.textBox15.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox15.Font = new System.Drawing.Font("Circular Std Black", 7.999999F, System.Drawing.FontStyle.Bold);
            this.textBox15.ForeColor = System.Drawing.SystemColors.Window;
            this.textBox15.Location = new System.Drawing.Point(1085, 42);
            this.textBox15.Name = "textBox15";
            this.textBox15.Size = new System.Drawing.Size(29, 13);
            this.textBox15.TabIndex = 53;
            this.textBox15.Text = "A";
            // 
            // textBox14
            // 
            this.textBox14.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox14.Font = new System.Drawing.Font("Circular Std Black", 7.999999F, System.Drawing.FontStyle.Bold);
            this.textBox14.ForeColor = System.Drawing.Color.DarkBlue;
            this.textBox14.Location = new System.Drawing.Point(790, 174);
            this.textBox14.Name = "textBox14";
            this.textBox14.Size = new System.Drawing.Size(166, 13);
            this.textBox14.TabIndex = 52;
            this.textBox14.Text = "**** **** ** 6666";
            // 
            // textBox13
            // 
            this.textBox13.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox13.Font = new System.Drawing.Font("Circular Std Black", 11F, System.Drawing.FontStyle.Bold);
            this.textBox13.ForeColor = System.Drawing.Color.DarkBlue;
            this.textBox13.Location = new System.Drawing.Point(790, 141);
            this.textBox13.Name = "textBox13";
            this.textBox13.Size = new System.Drawing.Size(163, 18);
            this.textBox13.TabIndex = 51;
            this.textBox13.Text = "$ 6 666 666.00";
            // 
            // textBox12
            // 
            this.textBox12.BackColor = System.Drawing.SystemColors.Window;
            this.textBox12.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox12.ForeColor = System.Drawing.Color.Red;
            this.textBox12.Location = new System.Drawing.Point(960, 269);
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new System.Drawing.Size(135, 15);
            this.textBox12.TabIndex = 50;
            this.textBox12.Text = "- $ 222.00";
            // 
            // textBox11
            // 
            this.textBox11.BackColor = System.Drawing.SystemColors.Window;
            this.textBox11.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox11.Font = new System.Drawing.Font("Circular Std Black", 7.999999F, System.Drawing.FontStyle.Bold);
            this.textBox11.ForeColor = System.Drawing.Color.DarkGray;
            this.textBox11.Location = new System.Drawing.Point(982, 229);
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new System.Drawing.Size(92, 13);
            this.textBox11.TabIndex = 49;
            this.textBox11.Text = "Expense";
            // 
            // textBox10
            // 
            this.textBox10.BackColor = System.Drawing.SystemColors.Window;
            this.textBox10.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox10.ForeColor = System.Drawing.Color.LimeGreen;
            this.textBox10.Location = new System.Drawing.Point(761, 269);
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(135, 15);
            this.textBox10.TabIndex = 48;
            this.textBox10.Text = "+ $ 555 555.00";
            // 
            // textBox9
            // 
            this.textBox9.BackColor = System.Drawing.SystemColors.Window;
            this.textBox9.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox9.Font = new System.Drawing.Font("Circular Std Black", 7.999999F, System.Drawing.FontStyle.Bold);
            this.textBox9.ForeColor = System.Drawing.Color.DarkGray;
            this.textBox9.Location = new System.Drawing.Point(790, 229);
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(74, 13);
            this.textBox9.TabIndex = 47;
            this.textBox9.Text = "Income";
            // 
            // textBox8
            // 
            this.textBox8.BackColor = System.Drawing.SystemColors.Window;
            this.textBox8.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox8.Font = new System.Drawing.Font("Circular Std Black", 10F, System.Drawing.FontStyle.Bold);
            this.textBox8.ForeColor = System.Drawing.Color.DarkGray;
            this.textBox8.Location = new System.Drawing.Point(790, 100);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(106, 16);
            this.textBox8.TabIndex = 46;
            this.textBox8.Text = "Balance";
            // 
            // richTextBox3
            // 
            this.richTextBox3.BackColor = System.Drawing.Color.DarkGray;
            this.richTextBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox3.Location = new System.Drawing.Point(480, 141);
            this.richTextBox3.Name = "richTextBox3";
            this.richTextBox3.Size = new System.Drawing.Size(208, 135);
            this.richTextBox3.TabIndex = 45;
            this.richTextBox3.Text = "";
            // 
            // richTextBox2
            // 
            this.richTextBox2.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.richTextBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox2.Location = new System.Drawing.Point(239, 141);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(210, 135);
            this.richTextBox2.TabIndex = 44;
            this.richTextBox2.Text = "";
            // 
            // textBox7
            // 
            this.textBox7.BackColor = System.Drawing.SystemColors.Window;
            this.textBox7.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox7.Font = new System.Drawing.Font("Circular Std Black", 10F, System.Drawing.FontStyle.Bold);
            this.textBox7.ForeColor = System.Drawing.Color.DarkGray;
            this.textBox7.Location = new System.Drawing.Point(146, 100);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(106, 16);
            this.textBox7.TabIndex = 43;
            this.textBox7.Text = "My cards";
            // 
            // textBox6
            // 
            this.textBox6.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox6.Font = new System.Drawing.Font("Circular Std Black", 11F, System.Drawing.FontStyle.Bold);
            this.textBox6.ForeColor = System.Drawing.Color.DarkBlue;
            this.textBox6.Location = new System.Drawing.Point(146, 35);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(150, 18);
            this.textBox6.TabIndex = 42;
            this.textBox6.Text = "Dashboard";
            // 
            // textBox5
            // 
            this.textBox5.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.textBox5.ForeColor = System.Drawing.Color.Red;
            this.textBox5.Location = new System.Drawing.Point(97, 535);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(135, 22);
            this.textBox5.TabIndex = 41;
            this.textBox5.Text = "- $ 222 22.00";
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.textBox4.ForeColor = System.Drawing.Color.LimeGreen;
            this.textBox4.Location = new System.Drawing.Point(97, 458);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(135, 22);
            this.textBox4.TabIndex = 40;
            this.textBox4.Text = "+ $ 555 555.00";
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox3.Font = new System.Drawing.Font("Circular Std Black", 7.999999F, System.Drawing.FontStyle.Bold);
            this.textBox3.ForeColor = System.Drawing.Color.DarkGray;
            this.textBox3.Location = new System.Drawing.Point(97, 509);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(92, 13);
            this.textBox3.TabIndex = 39;
            this.textBox3.Text = "Expenses";
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Font = new System.Drawing.Font("Circular Std Black", 7.999999F, System.Drawing.FontStyle.Bold);
            this.textBox2.ForeColor = System.Drawing.Color.DarkGray;
            this.textBox2.Location = new System.Drawing.Point(97, 432);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(74, 13);
            this.textBox2.TabIndex = 38;
            this.textBox2.Text = "Income";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Circular Std Black", 7.999999F, System.Drawing.FontStyle.Bold);
            this.textBox1.ForeColor = System.Drawing.Color.DarkBlue;
            this.textBox1.Location = new System.Drawing.Point(331, 394);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(148, 13);
            this.textBox1.TabIndex = 37;
            this.textBox1.Text = "Generate report";
            // 
            // MonthlySummary
            // 
            this.MonthlySummary.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.MonthlySummary.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.MonthlySummary.Font = new System.Drawing.Font("Circular Std Black", 10F, System.Drawing.FontStyle.Bold);
            this.MonthlySummary.ForeColor = System.Drawing.Color.DarkGray;
            this.MonthlySummary.Location = new System.Drawing.Point(97, 390);
            this.MonthlySummary.Name = "MonthlySummary";
            this.MonthlySummary.Size = new System.Drawing.Size(199, 16);
            this.MonthlySummary.TabIndex = 36;
            this.MonthlySummary.Text = "Monthly Summary";
            // 
            // Summary
            // 
            this.Summary.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Summary.Location = new System.Drawing.Point(79, 378);
            this.Summary.Name = "Summary";
            this.Summary.Size = new System.Drawing.Size(400, 214);
            this.Summary.TabIndex = 35;
            this.Summary.Text = "";
            // 
            // richTextBox1
            // 
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Location = new System.Drawing.Point(79, -2);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(1100, 328);
            this.richTextBox1.TabIndex = 34;
            this.richTextBox1.Text = "";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(12, 198);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(61, 23);
            this.button4.TabIndex = 63;
            this.button4.Text = "Home";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Circular Std Black", 20F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(25, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(248, 34);
            this.label2.TabIndex = 67;
            this.label2.Text = "Transactions page";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.Location = new System.Drawing.Point(773, 416);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(322, 113);
            this.dataGridView1.TabIndex = 0;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(1010, 12);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(154, 23);
            this.button6.TabIndex = 68;
            this.button6.Text = "Add Transaction";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // transactionsPage1
            // 
            this.transactionsPage1.Location = new System.Drawing.Point(3, -2);
            this.transactionsPage1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.transactionsPage1.Name = "transactionsPage1";
            this.transactionsPage1.Size = new System.Drawing.Size(1176, 627);
            this.transactionsPage1.TabIndex = 64;
            this.transactionsPage1.Load += new System.EventHandler(this.transactionsPage1_Load);
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Id,
            this.Content,
            this.View});
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(79, 42);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(1085, 537);
            this.listView1.TabIndex = 69;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // Id
            // 
            this.Id.Text = "Id";
            this.Id.Width = 200;
            // 
            // Content
            // 
            this.Content.Text = "Content";
            this.Content.Width = 727;
            // 
            // View
            // 
            this.View.Text = "View";
            this.View.Width = 158;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(1176, 621);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.transactionsPage1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.textBox17);
            this.Controls.Add(this.richTextBox5);
            this.Controls.Add(this.richTextBox4);
            this.Controls.Add(this.textBox16);
            this.Controls.Add(this.textBox15);
            this.Controls.Add(this.textBox14);
            this.Controls.Add(this.textBox13);
            this.Controls.Add(this.textBox12);
            this.Controls.Add(this.textBox11);
            this.Controls.Add(this.textBox10);
            this.Controls.Add(this.textBox9);
            this.Controls.Add(this.textBox8);
            this.Controls.Add(this.richTextBox3);
            this.Controls.Add(this.richTextBox2);
            this.Controls.Add(this.textBox7);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.MonthlySummary);
            this.Controls.Add(this.Summary);
            this.Controls.Add(this.richTextBox1);
            this.Font = new System.Drawing.Font("Circular Std Black", 8.999999F, System.Drawing.FontStyle.Bold);
            this.ForeColor = System.Drawing.Color.LimeGreen;
            this.Name = "Form1";
            this.Text = "+ $ 555 555.00";
            this.Load += new System.EventHandler(this.Form1_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Button button3;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Button button1;
        private PictureBox pictureBox1;
        private Button button2;
        private Button button5;
        private TextBox textBox17;
        private RichTextBox richTextBox5;
        private RichTextBox richTextBox4;
        private TextBox textBox16;
        private TextBox textBox15;
        private TextBox textBox14;
        private TextBox textBox13;
        private TextBox textBox12;
        private TextBox textBox11;
        private TextBox textBox10;
        private TextBox textBox9;
        private TextBox textBox8;
        private RichTextBox richTextBox3;
        private RichTextBox richTextBox2;
        private TextBox textBox7;
        private TextBox textBox6;
        private TextBox textBox5;
        private TextBox textBox4;
        private TextBox textBox3;
        private TextBox textBox2;
        private TextBox textBox1;
        private TextBox MonthlySummary;
        private RichTextBox Summary;
        private RichTextBox richTextBox1;
        private Button button4;
        private TransactionsPage transactionsPage1;
        private Label label2;
        private DataGridView dataGridView1;
        private Button button6;
        private ListView listView1;
        private ColumnHeader Id;
        private ColumnHeader Content;
        private ColumnHeader View;
    }
}
