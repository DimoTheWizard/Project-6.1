using System.Data.SQLite;
using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace project6._1Api.Entities
{
    public class sqlitedb
    {
        private static string connectionString = @"Data Source=C:\Users\Gebruiker\source\repos\project6.1Api\bin\Files\database.db;";

        public static void InitializeDatabase()
        {
            if (!File.Exists(@"..\..\Files\database.db"))
            {
                SQLiteConnection.CreateFile(@"..\..\Files\database.db");

                using (var connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    string createTransactionTableQuery = @"
                    CREATE TABLE IF NOT EXISTS transactions (
                    id INTEGER PRIMARY KEY AUTOINCREMENT,
                    account TEXT,
                    closingAvailableBalance TEXT,
                    closingBalance TEXT,
                    description TEXT,
                    forwardAvailableBalance TEXT,
                    openingBalance TEXT,
                    relatedMessage TEXT,
                    sequenceNumber TEXT,
                    statementNumber TEXT,
                    transactionReference TEXT,
                    transactionType TEXT,
                    transactionDate TEXT
                    );";

                    using (var command = new SQLiteCommand(connection))
                    {
                        command.CommandText = createTransactionTableQuery;
                        command.ExecuteNonQuery();

                    }
                }
            }
        }
       

        //getAll faker for testing
        public static void TransactionFaker()
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                using (SQLiteCommand command = new SQLiteCommand(connection))
                {
                    command.CommandText = @"
            INSERT INTO transactions (account, closingAvailableBalance, closingBalance, description, forwardAvailableBalance, openingBalance, relatedMessage, sequenceNumber, statementNumber, transactionReference, transactionType, transactionDate)
            VALUES (@Account, @ClosingAvailableBalance, @ClosingBalance, @Description, @ForwardAvailableBalance, @OpeningBalance, @RelatedMessage, @SequenceNumber, @StatementNumber, @TransactionReference, @TransactionType, @TransactionDate);";   
                    Random random = new Random();
                    string account = "ACCT-" + random.Next(1000, 9999);
                    string closingAvailableBalance = random.NextDouble().ToString();
                    string closingBalance = random.NextDouble().ToString();
                    string description = "Description";
                    string forwardAvailableBalance = random.NextDouble().ToString();
                    string openingBalance = random.NextDouble().ToString();
                    string relatedMessage = "Related Message";
                    string sequenceNumber = random.Next(1, 100).ToString();
                    string statementNumber = random.Next(1, 10).ToString();
                    string transactionReference = "TXN-" + random.Next(1000, 9999);
                    string transactionType = "Type";
                    string transactionDate = DateTime.Now.ToString("yyyyMMdd");

              
                    command.Parameters.AddWithValue("@Account", account);
                    command.Parameters.AddWithValue("@ClosingAvailableBalance", closingAvailableBalance);
                    command.Parameters.AddWithValue("@ClosingBalance", closingBalance);
                    command.Parameters.AddWithValue("@Description", description);
                    command.Parameters.AddWithValue("@ForwardAvailableBalance", forwardAvailableBalance);
                    command.Parameters.AddWithValue("@OpeningBalance", openingBalance);
                    command.Parameters.AddWithValue("@RelatedMessage", relatedMessage);
                    command.Parameters.AddWithValue("@SequenceNumber", sequenceNumber);
                    command.Parameters.AddWithValue("@StatementNumber", statementNumber);
                    command.Parameters.AddWithValue("@TransactionReference", transactionReference);
                    command.Parameters.AddWithValue("@TransactionType", transactionType);
                    command.Parameters.AddWithValue("@TransactionDate", transactionDate);

                    command.ExecuteNonQuery();
                }
            }
        }


        public static string[] GetTransactionXml()
        {
            XDocument xmlDocument = new XDocument();

            XElement xmlElement = new XElement("Transactions");

            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string selectEntriesQuery = "SELECT * FROM transactions;";

                using (var command = new SQLiteCommand(selectEntriesQuery, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32(0);
                            string account = reader.GetString(1);
                            string closingAvailableBalance = reader.GetString(2);
                            string closingBalance = reader.GetString(3);
                            string description = reader.GetString(4);
                            string forwardAvailableBalance = reader.GetString(5);
                            string openingBalance = reader.GetString(6);
                            string relatedMessage = reader.GetString(7);
                            string sequenceNumber = reader.GetString(8);
                            string statementNumber = reader.GetString(9);
                            string transactionReference = reader.GetString(10);
                            string transactionType = reader.GetString(11);
                            string transactionDate = reader.GetString(12);

                            XElement transactionElement = new XElement("Transaction",
                                new XElement("Id", id),
                                new XElement("Account", account),
                                new XElement("ClosingAvailableBalance", closingAvailableBalance),
                                new XElement("ClosingBalance", closingBalance),
                                new XElement("Description", description),
                                new XElement("ForwardAvailableBalance", forwardAvailableBalance),
                                new XElement("OpeningBalance", openingBalance),
                                new XElement("RelatedMessage", relatedMessage),
                                new XElement("SequenceNumber", sequenceNumber),
                                new XElement("StatementNumber", statementNumber),
                                new XElement("TransactionReference", transactionReference),
                                new XElement("TransactionType", transactionType),
                                new XElement("TransactionDate", transactionDate)
                            );

                            xmlElement.Add(transactionElement);
                        }
                    }
                }
            }

            xmlDocument.Add(xmlElement);

            return new string[] { xmlDocument.ToString() };
        }

        public static String GetTransactionCount()
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string counttransaction = "SELECT COUNT(*) FROM transactions;";

                using (var command = new SQLiteCommand(counttransaction, connection))
                {
                    int count = Convert.ToInt32(command.ExecuteScalar());
                    return count.ToString();
                }
            }
        }
    }
}
