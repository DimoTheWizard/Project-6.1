using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography;


namespace Sports_Accounting
{
    public partial class LogIn : Form
    {
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Gebruiker\Documents\GitHub\Project-6.1\Database.mdf;Integrated Security=True";
        public LogIn()
        {
            InitializeComponent();
        }

        private void buttonLogIn_Click(object sender, EventArgs e)
        {
            
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            string username = firstinput.Text.Trim();
            string password = textBox1.Text;

            if (TryLogIn(username, password))
            {
                //do nothing
            }
            else
            {
                //give error and stop running method
                MessageBox.Show("Invalid username or password.");
                return;
            }

            //make the user level the userLevel

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                //checks if the username exists
                string query = "SELECT level FROM [User] WHERE username=@username";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@username", username);

                SqlDataReader reader = command.ExecuteReader();

                //check if a password was found for the given username
                if (reader.HasRows && reader.Read())
                {
                    //retrieve the level from the database
                    string level = reader.GetString(0);

                    //sets the user level to the respective level of the user
                    switch (level)
                    {
                        case "[superuser]":
                            User.Level = userLevel.SUPERUSER;
                            break;
                        case "[admin]":
                            User.Level = userLevel.ADMIN;
                            break;
                        case "[guest]":
                            User.Level = userLevel.GUEST;
                            break;
                        default:
                            User.Level = userLevel.GUEST;
                            break;
                    }
                }
            }
            
            //Set the user username to the filled in username
            User.UserName = username;

            //make a home form and hide the login form
            Home form2 = new Home();
            form2.Show();
            this.Hide();
        }

        //makes a connection with the database and check whether the username and password match
        //an existing user
        private Boolean TryLogIn(string username, string password)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                //checks if the username exists
                string query = "SELECT COUNT(*) FROM [User] WHERE username = @username";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@username", username);

                int count = (int)command.ExecuteScalar();

                if (count <= 0)
                {
                    connection.Close();
                    return false;
                }

                //username exists in the table
                //check to see if the password matches after hash
                string checkPasswordQuery = "SELECT password FROM [User] WHERE username=@username";

                using (SqlCommand checkPasswordCommand = new SqlCommand(checkPasswordQuery, connection))
                {
                    checkPasswordCommand.Parameters.AddWithValue("@username", username);

                    SqlDataReader reader = checkPasswordCommand.ExecuteReader();

                    //check if a password was found for the given username
                    if (reader.HasRows && reader.Read())
                    {
                        //retrieve the hashed password from the database
                        string hashedPasswordFromDatabase = reader.GetString(0);

                        // compare the hashed password with the password entered by the user
                        if (hashedPasswordFromDatabase == HashString(password))
                        {
                            //passwords match
                            connection.Close();
                            return true;
                        }
                        else
                        {
                            //passwords doesnt match
                            connection.Close();
                            return false;
                        }
                    }
                    else
                    {
                        //no password found for the given username
                        connection.Close();
                        return false;
                    }
                }
            }
        }

        //hashes a string and returns the hashed string
        //uses SHA256
        public static string HashString(string input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = sha256.ComputeHash(inputBytes);
                return Convert.ToBase64String(hashBytes);
            }
        }
    }
}


