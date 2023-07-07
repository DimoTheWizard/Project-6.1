using Sports_Accounting.BaseApp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using api;
using MongoDB.Driver.Core.Configuration;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace Sports_Accounting
{
    public partial class Home : Form
    {
        private string databasePath;

        private string connectionString;
        
        public Home()
        {
            InitializeComponent();
            connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True";

            //if the user is a superuser allow them to view the users panel
            if (User.Level == userLevel.SUPERUSER)
            {
                button1.Visible = true;
            }

            //set welcome to display username
            welcomeText.Text += " " + User.UserName + "!";

            //calculate total income
            var total = getTotalExpense();
            totalIncome.Text = total.Item1.ToString() + " EUR";
            totalExpense.Text = total.Item2.ToString() + " EUR";

            //calculate monthly income
            var monthly = getMonthlyExpense();
            monthlyIncome.Text = monthly.Item1.ToString() + " EUR";
            monthlyExpense.Text = monthly.Item2.ToString() + " EUR";
        }

        private void showTransactionButton(object sender, EventArgs e)
        {
            TransactionDisplay transactionDisplay = new TransactionDisplay();
            transactionDisplay.Show();
            this.Hide();
        }

        [STAThread]
        private void buttonTransaction_Click(object sender, EventArgs e)
            {
            //need to run method on a seperate thread
            Thread t = new Thread((ThreadStart)(() => {
                OpenFileDialog dialog = new OpenFileDialog();
                //allowed file types
                dialog.Filter = "Text files | *.txt";
                dialog.Multiselect = true; // allow/deny user to upload more than one file at a time
                if (dialog.ShowDialog() == DialogResult.OK) // if user clicked OK
                {
                    //MAKES SURE TO FIRST CHECK ALL FILES AND THEN UPLOAD TO MONGODB
                    JsonAPI jsonAPI = new JsonAPI();
                    Validator val = new Validator();
                    bool invalidFile = false;
                    foreach(var filePath in dialog.FileNames)
                    {
                        var bsonFile = jsonAPI.FileToBson(filePath);

                        //checks if its valid mt940 and valid json file format
                        try
                        {
                            if (jsonAPI.checkMT940(bsonFile) && !val.validateJson(bsonFile))
                            {
                                invalidFile = true;
                                //if invalid file is found stop checking and report error
                                break;
                            }
                        } catch
                        {
                            invalidFile = true;
                        }  
                    }
                    if(invalidFile)
                    {
                        MessageBox.Show("File is not valid mt940 document, No files have been uploaded to the database.", "ERROR");
                    } else
                    {
                        //upload documents to mongoDB
                        foreach (var filePath in dialog.FileNames)
                        {
                            jsonAPI.Post(jsonAPI.FileToBson(filePath));
                        }
                    }
                }
            }));

            //un your code from a thread that joins the STA Thread
            t.SetApartmentState(ApartmentState.STA);
            t.Start();
            t.Join();
            
        }

        private void showAccountButton(object sender, EventArgs e)
        {
            Account account = new Account();
            account.Show();
            this.Hide();
        }

        private void LogOutButton(object sender, EventArgs e)
        {
            //go back to log in page and reset the users data
            LogIn logIn = new LogIn();
            logIn.Show();
            User.UserName = string.Empty;
            User.Level = userLevel.GUEST;
            this.Hide();
        }

        //gets the total income and expenses from the database or give nothing if not there
        public (int, int) getTotalExpense()
        {
            //query to select the opening_balance and closing_balance fields from the Transaction table
            string query = "SELECT opening_balance, closing_balance FROM [Transaction]";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        //create a new DataTable object
                        DataTable dataTable = new DataTable();

                        //fill the DataTable with the results of the query
                        adapter.Fill(dataTable);

                        //calculate the sum of the opening_balance and the sum of the closing_balance
                        int incomeSum = 0;
                        int expenseSum = 0;

                        foreach (DataRow row in dataTable.Rows)
                        {
                            //extract the numeric part of the balance with regex
                            string openingBalanceString = Regex.Match((string)row["opening_balance"], @"\d+").Value;
                            string closingBalanceString = Regex.Match((string)row["closing_balance"], @"\d+").Value;

                            //convert the balance values to integers
                            int openingBalance = int.Parse(openingBalanceString);
                            int closingBalance = int.Parse(closingBalanceString);

                            //loss
                            if(openingBalance > closingBalance) 
                            {
                                expenseSum += openingBalance - closingBalance;
                            }
                            //profit
                            else if(openingBalance < closingBalance)
                            {
                                incomeSum += closingBalance - openingBalance;
                            }
                        }

                        //return a tuple containing the sums of the income and expenses
                        return (incomeSum, expenseSum);
                    }
                }
            }
        }

        //gets the monthly income and expenses from the database or give nothing if not there
        public (int, int) getMonthlyExpense()
        {
            //calculate the start and end dates of the month
            DateTime currentDate = DateTime.Now;
            DateTime startDate = new DateTime(currentDate.Year, currentDate.Month, 1);
            DateTime endDate = startDate.AddMonths(1).AddDays(-1);

            //gets the opening and closing balance from DB only from those within this month's range
            string query = $"SELECT opening_balance, closing_balance, CAST(transaction_date AS DATETIME) as transaction_date FROM [Transaction] WHERE CAST(transaction_date AS DATETIME) BETWEEN '{startDate.ToString("yyyy-MM-dd")}' AND '{endDate.ToString("yyyy-MM-dd")}'";

            int incomeSum = 0;
            int expenseSum = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            //extract the opening_balance and closing_balance values from row
                            int openingBalance = int.Parse(Regex.Match(reader["opening_balance"].ToString(), @"\d+").Value);
                            int closingBalance = int.Parse(Regex.Match(reader["closing_balance"].ToString(), @"\d+").Value);

                            //calculate the monthly income and expenses based on the opening and closing balances
                            if (openingBalance > closingBalance)
                            {
                                expenseSum += openingBalance - closingBalance;
                            }
                            else if (openingBalance < closingBalance)
                            {
                                incomeSum += closingBalance - openingBalance;
                            }
                        }
                    }
                }
            }

            //return a tuple containing monthly income and expense
            return (incomeSum, expenseSum);
        }

    }
}
