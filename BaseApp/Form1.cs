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
        public LogIn()
        {
            InitializeComponent();
        }

            private void LoginButton_Click(object sender, EventArgs e)
            {
                string username = firstinput.Text.Trim();
                string password = textBox1.Text;

                if (AuthenticateUser(username, password))
                {
                    MessageBox.Show("Login successful!");
                }
                else
                {
                    MessageBox.Show("Invalid username or password.");
                }
            }

            private bool AuthenticateUser(string username, string password)
            {
                // Define the connection string for your SQL Server database.
                string connectionString = "Data Source=(local);Initial Catalog=MyDatabase;Integrated Security=True";

                // Define the SQL query to retrieve the salt and password hash for the user.
                string query = "SELECT PasswordHash, Salt, Iterations FROM Users WHERE Username = @Username";

                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add a parameter for the user's username to the query to avoid SQL injection attacks.
                    command.Parameters.AddWithValue("@Username", username);

                    try
                    {
                        // Open the database connection and execute the query.
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            // Retrieve the salt, password hash, and number of iterations from the database.
                            byte[] salt = (byte[])reader["Salt"];
                            byte[] expectedHash = (byte[])reader["PasswordHash"];
                            int iterations = (int)reader["Iterations"];

                            // Compute the password hash using the same salt and number of iterations as when the password was hashed.
                            byte[] passwordHash = HashPassword(password, salt, iterations);

                            // Compare the computed password hash to the one stored in the database.
                            if (ByteArrayCompare(passwordHash, expectedHash))
                            {
                                return true;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        // Handle any errors that occur while connecting to or querying the database.
                        MessageBox.Show("Error connecting to database: " + ex.Message);
                    }
                }

                return false;
            }

            private byte[] HashPassword(string password, byte[] salt, int iterations)
            {
                // Use the Rfc2898DeriveBytes class to hash the password with a randomly generated salt.
                byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
                Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes(passwordBytes, salt, iterations);
                return pbkdf2.GetBytes(20);
            }

            private bool ByteArrayCompare(byte[] a1, byte[] a2)
            {
                // Compare two byte arrays for equality.
                if (a1.Length != a2.Length)
                {
                    return false;
                }

                for (int i = 0; i < a1.Length; i++)
                {
                    if (a1[i] != a2[i])
                    {
                        return false;
                    }
                }

                return true;
            }
    }
}


 