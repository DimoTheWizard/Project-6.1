using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace modules
{
    public static class AccountingModule
    {
        /*        private XDocument xml;
        */
        /*  AccountingModule(XDocument xml) {
              this.xml = xml;
          }

          public addCategory(Categories category) {
              this.xml.category = category;
          }

          public updateCategory() {
              // Push the xml to the database
          }*/

        public static void Test()
        {
            DataTable Table = new DataTable();

            // Define the connection string for your SQL Server database.
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\dimit\source\repos\Project-6.1\Database.mdf;Integrated Security=True;Connect Timeout=30";

            // Define the SQL query to retrieve the salt and password hash for the user.
            string query = "SELECT * FROM Beverage";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                // // Add a parameter for the user's username to the query to avoid SQL injection attacks.
                // command.Parameters.AddWithValue("@Username", username);

                try
                {
                    // Open the database connection and execute the query.
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        // // Retrieve the salt, password hash, and number of iterations from the database.
                        // byte[] salt = (byte[])reader["Salt"];
                        // byte[] expectedHash = (byte[])reader["PasswordHash"];
                        // int iterations = (int)reader["Iterations"];

                        // // Compute the password hash using the same salt and number of iterations as when the password was hashed.
                        // byte[] passwordHash = HashPassword(password, salt, iterations);

                        // // Compare the computed password hash to the one stored in the database.
                        // if (ByteArrayCompare(passwordHash, expectedHash))
                        // {
                        //     return true;
                        // }
                        int id = reader.GetInt32(0); // Assuming the first column is an integer ID
                        string test1 = reader.GetString(1); // Assuming the second column is a string name
                        int quantitty = reader.GetInt32(2); // Assuming the third column is an integer ID
                                                            // Output the data row to the console
                        Console.WriteLine("ID: " + id + ", Name: " + test1 + ", Quantity: " + quantitty);
                    }
                }
                catch (Exception ex)
                {
                    // Handle any errors that occur while connecting to or querying the database.
                    MessageBox.Show("Error connecting to database: " + ex.Message);
                }
            }
        }
    }
}