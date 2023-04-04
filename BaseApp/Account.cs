using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using MongoDB.Driver.Core.Configuration;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Data.SqlClient;
using System.Xml.Linq;

namespace Sports_Accounting.BaseApp
{
    public partial class Account : Form
    {
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\dimit\source\repos\Project-6.1\Database.mdf;Integrated Security=True";

        public Account()
        {
            InitializeComponent();
        }

        private void Account_Load(object sender, EventArgs e)
        {
            this.userTableAdapter.Fill(this.databaseDataSet.User);
        }

<<<<<<< HEAD
        private void AddUserButton(object sender, EventArgs e)
=======
        private void button1_Click(object sender, EventArgs e)
>>>>>>> added proper login functionality and 80 percent of the user panel
        {
            string username;
            string password;
            string level = "guest";

            //check if all fields are valid
            //checks if username is not empty
            if (usernameBox.Text == null || usernameBox.Text == "")
            {
                addMessageBox.Text = "Username must not be empty";
                return;
            }

            //checks if username isnt longer than 50 characters
            if (usernameBox.Text.Length > 50)
            {
                addMessageBox.Text = "Username must not be over 50 characters long";
                return;
            }

            //checks if no special characters are used in username
            Regex regex = new Regex("[^a-zA-Z0-9]");

            if (regex.IsMatch(usernameBox.Text))
            {
                addMessageBox.Text = "Username must not contain special characters or spaces";
                return;
            }

            //checks if username exists already or not
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                //checks if the username exists
                string query = "SELECT COUNT(*) FROM [User] WHERE username = @username";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@username", usernameBox.Text);

                int count = (int)command.ExecuteScalar();
                //if there are more than 1 usernames
                if (count > 0)
                {
                    addMessageBox.Text = "Username already used, try another one";
                    connection.Close();
                    return;
                }
                connection.Close();
            }

            username = usernameBox.Text;

            //check to see if password is valid
            //checks if password is not empty
            if (passwordBox.Text == null || passwordBox.Text == "")
            {
                addMessageBox.Text = "password must not be empty";
                return;
            }

            //checks if password isnt longer than 12 characters
            if (passwordBox.Text.Length > 12)
            {
                addMessageBox.Text = "password must not be over 50 characters long";
                return;
            }

            //checks if no special characters are used in password
            if (regex.IsMatch(passwordBox.Text))
            {
                addMessageBox.Text = "password must not contain special characters or spaces";
                return;
            }
            
            password = LogIn.HashString(passwordBox.Text);

            switch(accessListBox.SelectedIndex)
            {
                case 0:
                    level = "guest";
                    break;
                case 1:
                    level = "admin";
                    break;
                case 2:
                    level = "superuser";
                    break;
            }

            //add the new user to the database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                //runs the query adding new user
                SqlCommand command = new SqlCommand("INSERT INTO [User] (username, password, level) VALUES (@username, @password, @level)", connection);
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@password", password);
                command.Parameters.AddWithValue("@level", "[" + level + "]");
                command.ExecuteNonQuery();
                

                //gives notification of successful addition
                addMessageBox.Text = "Successfully added!";

                //refresh the datagridview
                SqlDataAdapter dataAdapter = new SqlDataAdapter();
                dataAdapter.SelectCommand = new SqlCommand("SELECT user_id, username, level FROM [User]", connection);

                // Create a new instance of the DataTable
                DataTable myTable = new DataTable("User");

                // Fill the DataTable with the initial data
                dataAdapter.Fill(myTable);

                // Set the DataGridView's DataSource property to the User table in the DataSet
                dataGridView1.DataSource = myTable;

                // Refresh the DataGridView to display the initial data
                dataGridView1.Refresh();
                connection.Close();
            }
        }
<<<<<<< HEAD

        private void GoBackButton(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }
=======
>>>>>>> added proper login functionality and 80 percent of the user panel
    }
}
