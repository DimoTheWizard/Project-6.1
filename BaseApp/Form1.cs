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
            Validator val = new Validator();
            val.callJson();
        }

        private void buttonLogIn_Click(object sender, EventArgs e)
        {
            Home form2 = new Home();
            form2.Show();
            this.Hide();
        }

        /*private void LoginButton_Click(object sender, EventArgs e)
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
            
            string connectionString = "Data Source=(local);Initial Catalog=MyDatabase;Integrated Security=True";
            string query = "SELECT PasswordHash, Salt, Iterations FROM Users WHERE Username = @Username";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Username", username);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
            
                        byte[] salt = (byte[])reader["Salt"];
                        byte[] expectedHash = (byte[])reader["PasswordHash"];
                        int iterations = (int)reader["Iterations"];

                        byte[] passwordHash = HashPassword(password, salt, iterations);

                        if (ByteArrayCompare(passwordHash, expectedHash))
                        {
                            return true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error connecting to database: " + ex.Message);
                }
            }

            return false;
        }

        private byte[] HashPassword(string password, byte[] salt, int iterations)
        {
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
        }*/
    }
}


 