﻿namespace Sports_Accounting
{
    partial class LogIn
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogIn));
            this.buttonLogIn = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.welcome = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.iban = new System.Windows.Forms.Label();
            this.passwordinput = new System.Windows.Forms.Label();
            this.firstinput = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonLogIn
            // 
            this.buttonLogIn.BackColor = System.Drawing.Color.DarkBlue;
            this.buttonLogIn.Font = new System.Drawing.Font("Circular Std Black", 7.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLogIn.ForeColor = System.Drawing.Color.White;
            this.buttonLogIn.Location = new System.Drawing.Point(272, 406);
<<<<<<< HEAD
            this.buttonLogIn.Margin = new System.Windows.Forms.Padding(2);
=======
            this.buttonLogIn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
>>>>>>> added proper login functionality and 80 percent of the user panel
            this.buttonLogIn.Name = "buttonLogIn";
            this.buttonLogIn.Size = new System.Drawing.Size(190, 27);
            this.buttonLogIn.TabIndex = 5;
            this.buttonLogIn.Text = "Log in";
            this.buttonLogIn.UseVisualStyleBackColor = false;
            this.buttonLogIn.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(693, 84);
<<<<<<< HEAD
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
=======
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
>>>>>>> added proper login functionality and 80 percent of the user panel
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(292, 335);
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // welcome
            // 
            this.welcome.AutoSize = true;
            this.welcome.BackColor = System.Drawing.SystemColors.Control;
            this.welcome.Font = new System.Drawing.Font("Circular Std Black", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.welcome.ForeColor = System.Drawing.Color.DarkBlue;
            this.welcome.Location = new System.Drawing.Point(183, 124);
            this.welcome.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.welcome.Name = "welcome";
            this.welcome.Size = new System.Drawing.Size(364, 30);
            this.welcome.TabIndex = 9;
            this.welcome.Text = "Welcome back to Sport\'s Club!";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Circular Std Black", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkGray;
            this.label1.Location = new System.Drawing.Point(243, 161);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(245, 15);
            this.label1.TabIndex = 10;
            this.label1.Text = "Welcome back, please enter your details!";
            // 
            // iban
            // 
            this.iban.AutoSize = true;
            this.iban.Font = new System.Drawing.Font("Circular Std Black", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iban.ForeColor = System.Drawing.Color.Gray;
            this.iban.Location = new System.Drawing.Point(185, 222);
            this.iban.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.iban.Name = "iban";
            this.iban.Size = new System.Drawing.Size(76, 18);
            this.iban.TabIndex = 11;
            this.iban.Text = "Username";
            // 
            // passwordinput
            // 
            this.passwordinput.AutoSize = true;
            this.passwordinput.BackColor = System.Drawing.SystemColors.Control;
            this.passwordinput.Font = new System.Drawing.Font("Circular Std Black", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordinput.ForeColor = System.Drawing.Color.Gray;
            this.passwordinput.Location = new System.Drawing.Point(185, 308);
            this.passwordinput.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.passwordinput.Name = "passwordinput";
            this.passwordinput.Size = new System.Drawing.Size(74, 18);
            this.passwordinput.TabIndex = 12;
            this.passwordinput.Text = "Password";
            // 
            // firstinput
            // 
            this.firstinput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.firstinput.Font = new System.Drawing.Font("Circular Std Light", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.firstinput.Location = new System.Drawing.Point(188, 250);
<<<<<<< HEAD
            this.firstinput.Margin = new System.Windows.Forms.Padding(2);
=======
            this.firstinput.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
>>>>>>> added proper login functionality and 80 percent of the user panel
            this.firstinput.Name = "firstinput";
            this.firstinput.Size = new System.Drawing.Size(359, 26);
            this.firstinput.TabIndex = 13;
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Font = new System.Drawing.Font("Circular Std Light", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(188, 336);
<<<<<<< HEAD
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.Name = "textBox1";
            this.textBox1.PasswordChar = '*';
=======
            this.textBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox1.Name = "textBox1";
>>>>>>> added proper login functionality and 80 percent of the user panel
            this.textBox1.Size = new System.Drawing.Size(359, 26);
            this.textBox1.TabIndex = 14;
            // 
            // LogIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1052, 549);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.firstinput);
            this.Controls.Add(this.passwordinput);
            this.Controls.Add(this.iban);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.welcome);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.buttonLogIn);
<<<<<<< HEAD
            this.Margin = new System.Windows.Forms.Padding(2);
=======
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
>>>>>>> added proper login functionality and 80 percent of the user panel
            this.Name = "LogIn";
            this.Text = "Login";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonLogIn;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label welcome;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label iban;
        private System.Windows.Forms.Label passwordinput;
        private System.Windows.Forms.TextBox firstinput;
        private System.Windows.Forms.TextBox textBox1;
    }
}

