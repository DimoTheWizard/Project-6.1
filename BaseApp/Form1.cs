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
using System.IO;
using MongoDB.Driver.Core.Configuration;
using System.Text.RegularExpressions;
using Amazon.Auth.AccessControlPolicy;

namespace Sports_Accounting
{
    public partial class LogIn : Form
    {

        //private string databasePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Database.mdf");

        private string connectionString;

        //checking whether we should make a user first or just allow login
        private Boolean isUsersEmpty = true;

        public LogIn() 
        {
            HttpApi httpApi = new HttpApi();
            InitializeComponent();
            connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True";

            string query = $"SELECT COUNT(*) FROM [User]";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    int rowCount = (int)command.ExecuteScalar();

                    if (rowCount == 0)
                    {
                        label1.Text = "Please make the first user, this user will automatically be a super user!";
                        buttonLogIn.Text = "Register";
                        isUsersEmpty = true;
                    }
                    else
                    {
                        isUsersEmpty = false;
                    }
                }
            }
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            string username = firstinput.Text.Trim();
            string password = textBox1.Text.Trim();
            if (isUsersEmpty)
            {
                //create a new user of superuser level with the given name and password
                tryCreateUser();
            } else
            {
                //check users and login if valid user

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
                    string query = "SELECT level, user_id FROM [User] WHERE username=@username";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@username", username);

                    SqlDataReader reader = command.ExecuteReader();

                    //check if a password was found for the given username
                    if (reader.HasRows && reader.Read())
                    {
                        //retrieve the level from the database
                        string level = reader.GetString(0);

                        User.userID = reader.GetInt32(1);

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

        private void tryCreateUser()
        {
            //check if all fields are valid
            //checks if username is not empty
            if (firstinput.Text == null || firstinput.Text == "")
            {
                addMessageBox.Text = "Username must not be empty";
                return;
            }

            //checks if username isnt longer than 50 characters
            if (firstinput.Text.Length > 50)
            {
                addMessageBox.Text = "Username must not be over 50 characters long";
                return;
            }

            //checks if no special characters are used in username
            Regex regex = new Regex("[^a-zA-Z0-9]");

            if (regex.IsMatch(firstinput.Text))
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
                command.Parameters.AddWithValue("@username", firstinput.Text);

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

            string username = firstinput.Text;

            //check to see if password is valid
            //checks if password is not empty
            if (textBox1.Text == null || textBox1.Text == "")
            {
                addMessageBox.Text = "password must not be empty";
                return;
            }

            //checks if password isnt longer than 12 characters
            if (textBox1.Text.Length > 12)
            {
                addMessageBox.Text = "password must not be over 50 characters long";
                return;
            }

            //checks if no special characters are used in password
            if (regex.IsMatch(textBox1.Text))
            {
                addMessageBox.Text = "password must not contain special characters or spaces";
                return;
            }

            string password = HashString(textBox1.Text);

            //add the new user to the database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                //runs the query adding new user
                SqlCommand command = new SqlCommand("INSERT INTO [User] (username, password, level) VALUES (@username, @password, @level)", connection);
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@password", password);
                command.Parameters.AddWithValue("@level", "[superuser]");
                command.ExecuteNonQuery();

                //gives notification of successful addition
                addMessageBox.Text = "Successfully added!";
                connection.Close();
            }

            //refresh page with new login page
            LogIn login = new LogIn();
            login.Show();
            this.Hide();
        }

    }
}


