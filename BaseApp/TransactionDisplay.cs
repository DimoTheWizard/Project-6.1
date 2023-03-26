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

namespace Sports_Accounting.BaseApp
{
    public partial class TransactionDisplay : Form
    {
        XmlAPI xmlAPI = new XmlAPI();
        XDocument XMLData = new XDocument();
        public TransactionDisplay()
        {
            InitializeComponent();
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

                        //gets the balance from the closing balance part of XML
                        foreach (var balance in statement.Descendants("ClosingBalance"))
                        {
                            closingBalance = balance.Element("Balance").Value;
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
                        table.Columns.Add("Statemen tNumber", typeof(string));
                        table.Columns.Add("Transaction Reference", typeof(string));

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
                            transactionReference
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
    }
}
