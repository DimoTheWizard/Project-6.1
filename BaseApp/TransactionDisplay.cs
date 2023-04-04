using Amazon.Auth.AccessControlPolicy;
using MongoDB.Driver.Core.Events;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Data.SqlClient;
<<<<<<< HEAD
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;
=======
>>>>>>> added proper login functionality and 80 percent of the user panel

namespace Sports_Accounting.BaseApp
{
    public partial class TransactionDisplay : Form
    {
        XmlAPI xmlAPI = new XmlAPI();
        XDocument XMLData = new XDocument();

        private class StatementData
        {
            public StatementData() { }
            public string id { get; set; }
            public string account { get; set; }
            public string closingAvailableBalance { get; set;}
            public string closingBalance { get; set;}
            public string description { get; set;}
            public string forwardAvailableBalance { get; set;}
            public string openingBalance { get; set; }
            public string relatedMessage { get; set; }
            public string sequenceNumber { get; set; }
            public string statementNumber { get; set; }
            public string transactionReference { get; set; }
            public string transactionType { get; set; } 
<<<<<<< HEAD
            public string transactionDate { get; set; }
=======
>>>>>>> added proper login functionality and 80 percent of the user panel

        }

        public TransactionDisplay()
        {
            InitializeComponent();

            //if the user is an admin or superuser allow them to view the add to database button
            if (User.Level == userLevel.SUPERUSER || User.Level == userLevel.ADMIN)
            {
                databaseSave.Visible = true;
            }
        }

        //On page load
        private async void TransactionDisplay_Load(object sender, EventArgs e)
        {
            XmlDocument data = await xmlAPI.GetAll();
            XMLData = XDocument.Parse(data.OuterXml);

            //add xml to create list items
            foreach (var statement in XMLData.Descendants("Statement"))
            {
                string account = statement.Element("Account").Value;
                string closingBalance = "";
                string transactionReference = statement.Element("TransactionReference").Value;

                //gets the balance from the closing balance part of XML
                foreach(var balance in statement.Descendants("ClosingBalance"))
                {
                    closingBalance = balance.Element("Balance").Value;
                }
                ListViewItem item = new ListViewItem(new string[]
                {
                    account,
                    closingBalance,
                    transactionReference
                });
                listView1.Items.Add(item);
            }
            listView1.View = View.Details;
        }

        private void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if(e.IsSelected)
            {
                //create index number to loop to correct index with
                int index = 0;

                //add xml to create list items
                foreach (var statement in XMLData.Descendants("Statement"))
                {
                    if(index == e.ItemIndex)
                    {
                        string account = statement.Element("Account").Value;
                        string closingAvailableBalance = statement.Element("ClosingAvailableBalance").Value;
                        string closingBalance = "";
                        string description = statement.Element("Description").Value;
                        string forwardAvailableBalance = statement.Element("ForwardAvailableBalance").Value;
                        string openingBalance = "";
                        string relatedMessage = statement.Element("RelatedMessage").Value;
                        string sequenceNumber = statement.Element("SequenceNumber").Value;
                        string statementNumber = statement.Element("StatementNumber").Value;
                        string transactionReference = statement.Element("TransactionReference").Value;
                        string transactionDate = "";

                        //gets the balance from the closing balance part of XML
                        foreach (var balance in statement.Descendants("ClosingBalance"))
                        {
                            closingBalance = balance.Element("Balance").Value;
                            transactionDate = balance.Element("EntryDate").Value;
                        }

                        //gets the balance from the opening balance part of XML
                        foreach (var balance in statement.Descendants("OpeningBalance"))
                        {
                            openingBalance = balance.Element("Balance").Value;
                        }

                        //Create dataset
                        DataSet set = new DataSet();
                        DataTable table = new DataTable();
                        table.TableName = "Statements";

                        table.Columns.Add("Account", typeof(string));
                        table.Columns.Add("Closing Available Balance", typeof(string));
                        table.Columns.Add("Closing Balance", typeof(string));
                        table.Columns.Add("Description", typeof(string));
                        table.Columns.Add("Forward Available Balance", typeof(string));
                        table.Columns.Add("Opening Balance", typeof(string));
                        table.Columns.Add("Related Message", typeof(string));
                        table.Columns.Add("Sequence Number", typeof(string));
                        table.Columns.Add("Statement Number", typeof(string));
                        table.Columns.Add("Transaction Reference", typeof(string));
                        table.Columns.Add("Transaction Date", typeof(string));

                        table.Rows.Add(new object[] { 
                            account, 
                            closingAvailableBalance,
                            closingBalance,
                            description,
                            forwardAvailableBalance,
                            openingBalance,
                            relatedMessage,
                            sequenceNumber,
                            statementNumber,
                            transactionReference,
                            transactionDate
                        });
                        
                        table.AcceptChanges();

                        set.Tables.Add(table);

                        // Flip the DataSet
                        DataSet flippedDataSet = FlipDataSet(set);
                        DataView my_DataView = flippedDataSet.Tables[0].DefaultView;
                        dataGridView1.DataSource = my_DataView;
                        //makes the headers more descriptive
                        dataGridView1.Columns[0].HeaderText = "Description";
                        dataGridView1.Columns[1].HeaderText = "Value";
                    }                    
                    index++;
                }
            }
        }

        //makes it so that the rows become the collumns and vice versa, easier to view like this
        public DataSet FlipDataSet(DataSet my_DataSet)
        {
            DataSet ds = new DataSet();

            foreach (DataTable dt in my_DataSet.Tables)
            {
                DataTable table = new DataTable();

                for (int i = 0; i <= dt.Rows.Count; i++)
                { table.Columns.Add(Convert.ToString(i)); }

                DataRow r;
                for (int k = 0; k < dt.Columns.Count; k++)
                {
                    r = table.NewRow();
                    r[0] = dt.Columns[k].ToString();
                    for (int j = 1; j <= dt.Rows.Count; j++)
                    { r[j] = dt.Rows[j - 1][k]; }
                    table.Rows.Add(r);
                }
                ds.Tables.Add(table);
            }

            return ds;
        }

        private void databaseSave_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\dimit\\source\\repos\\Project-6.1\\Database.mdf;Integrated Security=True";

<<<<<<< HEAD
            string checkIfExistsQuery = "SELECT COUNT(*) FROM [Transaction] WHERE object_id = @Id";

            string query = @"INSERT INTO [Transaction] (account, closing_balance, opening_balance, statement_number, transaction_reference, original_description, transaction_date, object_id)
                             VALUES (@account, @closing_balance, @opening_balance, @statement_number, @transaction_reference, @original_description, @transaction_date, @object_id)";
=======
            string checkIfExistsQuery = "SELECT COUNT(*) FROM Transaction WHERE transaction_id = @Id";

            string query = @"INSERT INTO Transaction (transaction_id) VALUES (@transaction_id)";
>>>>>>> added proper login functionality and 80 percent of the user panel

            List<StatementData> data = new List<StatementData>();
            int index = 0;
            foreach (var statement in XMLData.Descendants("Statement"))
            {
                StatementData statementData = new StatementData();
                data.Add(statementData);
                data[index].id = statement.Element("ID").Value;
                data[index].account = statement.Element("Account").Value;
                data[index].closingAvailableBalance = statement.Element("ClosingAvailableBalance").Value;
                data[index].description = statement.Element("Description").Value;
                data[index].forwardAvailableBalance = statement.Element("ForwardAvailableBalance").Value;
                data[index].relatedMessage = statement.Element("RelatedMessage").Value;
                data[index].sequenceNumber = statement.Element("SequenceNumber").Value;
                data[index].statementNumber = statement.Element("StatementNumber").Value;
                data[index].transactionReference = statement.Element("TransactionReference").Value;

<<<<<<< HEAD
                //gets the balance and date from the closing balance part of XML
                foreach (var balance in statement.Descendants("ClosingBalance"))
                {
                    data[index].closingBalance = balance.Element("Balance").Value;
                    data[index].transactionDate = balance.Element("EntryDate").Value.ToString();
=======
                //gets the balance from the closing balance part of XML
                foreach (var balance in statement.Descendants("ClosingBalance"))
                {
                    data[index].closingBalance = balance.Element("Balance").Value;
>>>>>>> added proper login functionality and 80 percent of the user panel
                }

                //gets the balance from the opening balance part of XML
                foreach (var balance in statement.Descendants("OpeningBalance"))
                {
                    data[index].openingBalance = balance.Element("Balance").Value;
                }

                //gets the transaction type of the first transaction
                foreach (var transaction in statement.Descendants("Transactions"))
                {
                    foreach(var transactionData in transaction.Descendants("Transaction"))
                    {
                        data[index].transactionType = transactionData.Element("TransactionType").ToString();
                    }

                }

<<<<<<< HEAD
                //working with the database
=======
>>>>>>> added proper login functionality and 80 percent of the user panel
                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString)) // Create a new SQL connection
                    {
                        connection.Open();
                        //check if value with id exists
                        SqlCommand checkCommand = new SqlCommand(checkIfExistsQuery, connection);
                        checkCommand.Parameters.AddWithValue("@Id", data[index].id);
                        bool exists = ((int)checkCommand.ExecuteScalar() > 0);
<<<<<<< HEAD
                        //if the field doesnt exist
                        if (!exists)
                        {
                            SqlCommand command = new SqlCommand(query, connection); // Create a new SQL command
                            command.Parameters.AddWithValue("@account", data[index].account ?? (object)DBNull.Value);
                            command.Parameters.AddWithValue("@closing_balance", data[index].closingBalance ?? (object)DBNull.Value);
                            command.Parameters.AddWithValue("@opening_balance", data[index].openingBalance ?? (object)DBNull.Value);
                            command.Parameters.AddWithValue("@statement_number", data[index].statementNumber ?? (object)DBNull.Value);
                            command.Parameters.AddWithValue("@transaction_reference", data[index].transactionReference ?? (object)DBNull.Value);
                            command.Parameters.AddWithValue("@original_description", data[index].description ?? (object)DBNull.Value);
                            command.Parameters.AddWithValue("@transaction_date", data[index].transactionDate ?? (object)DBNull.Value);
                            command.Parameters.AddWithValue("@object_id", data[index].id);

                            int rowsAffected = command.ExecuteNonQuery();
=======
                        //if the thing doesnt exist
                        if (!exists)
                        {
                            SqlCommand command = new SqlCommand(query, connection); // Create a new SQL command
                            command.Parameters.AddWithValue("@transaction_id", data[index].id);
                            
                            int rowsAffected = command.ExecuteNonQuery();
                            Console.WriteLine(rowsAffected + " row(s) inserted.");
>>>>>>> added proper login functionality and 80 percent of the user panel
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error with database insertion " + ex.Message);
                }
            }
<<<<<<< HEAD
            messageBox.Text = "Added new transactions to \n local database";
=======
>>>>>>> added proper login functionality and 80 percent of the user panel
        }
    }
}
