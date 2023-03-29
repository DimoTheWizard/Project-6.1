using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.Xml;
using Newtonsoft.Json.Schema;
using Newtonsoft.Json.Linq;
using System.Xml.Schema;
using System.Xml.Linq;
using api;
using MongoDB.Bson.IO;
using MongoDB.Bson;
using Newtonsoft.Json;
using Sports_Accounting;
using System.Data.SqlTypes;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();


        }

        private async void Form1_Load_1(object sender, EventArgs e)
        {


            //Refresh the load itself, call function itself
            //Refresh();

            transactionsPage1.Hide();
            button4.Hide();
            label2.Hide();
            listView1.Hide();
            callJson();
            callXml();
        }

        public async Task<List<BsonDocument>> getJsonValue()
        {
            JsonAPI jsonAPI = new JsonAPI();
            var jsonDocs = await jsonAPI.GetAll();
            return jsonDocs;
        }

        public async Task<XmlDocument> getXmlValue()
        {
            XmlAPI xmlApi = new XmlAPI();
            var xmlDocs = await xmlApi.GetAll();
            return xmlDocs;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            transactionsPage1.Hide();
            button4.Hide();
            //dataGridView1.Hide();
            listView1.Hide();
            label2.Hide();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            transactionsPage1.BringToFront();
            transactionsPage1.Show();
            listView1.Show();
            listView1.BringToFront();
            button4.Show();
            button4.BringToFront();
            //dataGridView1.Show();
            //dataGridView1.BringToFront();
            label2.Show();
            label2.BringToFront();
        }

        private void transactionsPage2_Load(object sender, EventArgs e)
        {

        }

        //Validates JSON using schema provided, populate table 
        //TODO: store in Database
        private async void callJson()
        {
            string filepath = "C:\\Users\\Gebruiker\\source\\repos\\WindowsFormsApp1\\WindowsFormsApp1\\get.json";

            //JsonAPI call to save as string
            var bsonValue = await getJsonValue();
            var settings = new JsonWriterSettings { Indent = true };
            var jsonOutput = bsonValue.ToJson(settings);
            var jsonOutputString = jsonOutput.ToString();
            
            String bracketL = "{";
            String bracketR = "}";

            string output = String.Format("{0} \"transaction\": {1} {2} ", bracketL, jsonOutputString, bracketR);


            output = output.Replace("_", string.Empty);
            output = output.Replace("ObjectId(", string.Empty);
            output = output.Replace("STARTUMSE", string.Empty);

            output = output.Replace("),", ",");

            //Save file 
            File.WriteAllText(filepath, output);

            //Validate File using draft 07
            JSchema schema = JSchema.Parse(System.IO.File.ReadAllText("C:\\Users\\Gebruiker\\source\\repos\\WindowsFormsApp1\\WindowsFormsApp1\\schemaValidation.json"));
            JObject jsonObject = JObject.Parse(System.IO.File.ReadAllText("C:\\Users\\Gebruiker\\source\\repos\\WindowsFormsApp1\\WindowsFormsApp1\\get.json"));

            //if validation passes display to page
            if (jsonObject.IsValid(schema))
            {
                System.Console.WriteLine(jsonObject.IsValid(schema));
                var serialisedString = output;
                var transactions = Newtonsoft.Json.JsonConvert.DeserializeObject<Transactions>(output, new JsonSerializerSettings());


                //Loop through result to display columns in the Table
                foreach (var trans in transactions.Transaction)
                {
                    //Here we can push each the transaction id to the mssql if it doesn't exist
                    
                    //Check WhatsApp Dms on how to simplify ERD
                    String[] row = { trans.ID, trans.Mt940content};
                    var listItem = new ListViewItem(row);
                    listView1.Items.Add(listItem);
                }
            }
            else
            {
                System.Console.WriteLine(false);
            };
        }


        //Validates xml using schema provided, populate first page
        private async void callXml()
        {
            //Uncomment to pull from APi
            string filepath = "C:\\Users\\Gebruiker\\source\\repos\\WindowsFormsApp1\\WindowsFormsApp1\\get.xml";
            //var xmlValue = await getXmlValue();
            //var xmlOutput = xmlValue.OuterXml;
            //var output = xmlOutput.ToString();

            //File.WriteAllText(filepath, output);


            XmlSchemaSet schema = new XmlSchemaSet();
            schema.Add("", @"C:\\Users\\Gebruiker\\source\\repos\\WindowsFormsApp1\\WindowsFormsApp1\\xmlValidator.xsd");

            XDocument doc = XDocument.Load(filepath);
            bool status = false;

            doc.Validate(schema, (s, e) =>
            {

                System.Console.WriteLine(e.Message);
                status = true;
            });

            if (status)
            {
                System.Console.WriteLine("Failed");
            }
            //WriteState code to populate page here
            else
            {
                System.Console.WriteLine("Passed");
            }

            //System.Console.WriteLine(output);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            transactionsPage1.Hide();
            button4.Hide();
            //dataGridView1.Hide();
            label2.Hide();
            listView1.Hide();
        }

        private void transactionsPage1_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void listView1_Load()
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}