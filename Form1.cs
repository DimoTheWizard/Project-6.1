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
        }

        public async Task<List<BsonDocument>> getValue()
        {
            JsonAPI jsonAPI = new JsonAPI();
            var xmlDocs = await jsonAPI.GetAll();
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

        //Validates JSON using schema provided
        private async void callJson()
        {
            string filepath = "C:\\Users\\Gebruiker\\source\\repos\\WindowsFormsApp1\\WindowsFormsApp1\\get.json";

            var bsonValue = await getValue();
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


            File.WriteAllText(filepath, output);

            //System.Console.WriteLine(output);

            JSchema schema = JSchema.Parse(System.IO.File.ReadAllText("C:\\Users\\Gebruiker\\source\\repos\\WindowsFormsApp1\\WindowsFormsApp1\\schemaValidation.json"));
            JObject jsonObject = JObject.Parse(System.IO.File.ReadAllText("C:\\Users\\Gebruiker\\source\\repos\\WindowsFormsApp1\\WindowsFormsApp1\\get.json"));

            //DisplayNameAttribute to Screen
            //Validation ofApi call

            if (jsonObject.IsValid(schema))
            {
                System.Console.WriteLine(jsonObject.IsValid(schema));
                var serialisedString = output;
                var transactions = Newtonsoft.Json.JsonConvert.DeserializeObject<Transactions>(output, new JsonSerializerSettings());
                //IEnumerable<Transactions> transactionsArray = (IEnumerable<Transactions>) transactions;

                DataSet ds = new DataSet();
                dataGridView1.DataSource = transactions;

                string[] headers;

                foreach (var trans in transactions.Transaction)
                {
                    String[] row = { trans.ID, trans.Mt940content};
                    var listItem = new ListViewItem(row);
                    listView1.Items.Add(listItem);
                }
                //System.Console.WriteLine(transactions.Transaction[0].ID); ;
            }
            else
            {
                System.Console.WriteLine(false);
            };


        }

        //Validates xml using schema provided
        private void ValidateXML()
        {
            string filepath = "C:\\Users\\Gebruiker\\source\\repos\\WindowsFormsApp1\\WindowsFormsApp1\\get.xml";

            try
            {
                using (HttpClient cli = new HttpClient())
                {
                    var url = new Uri("https://v2.jokeapi.dev/joke/Any?blacklistFlags=nsfw,religious,political,racist,sexist,explicit&format=xml&type=single&amount=10");
                    var response = cli.GetAsync(url).Result;
                    var joke = response.Content.ReadAsStringAsync().Result;

                    File.WriteAllText(filepath, joke);
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
                }
            }
            catch (AggregateException)
            {
            }
        }

        private void XMLApiCall()
        {
            string filepath = "C:\\Users\\Gebruiker\\source\\repos\\WindowsFormsApp1\\WindowsFormsApp1\\get.xml";
            try
            {
                using (HttpClient cli = new HttpClient())
                {
                    var url = new Uri("https://v2.jokeapi.dev/joke/Any?blacklistFlags=nsfw,religious,political,racist,sexist,explicit&format=xml&type=single&amount=10");
                    var response = cli.GetAsync(url).Result;
                    var joke = response.Content.ReadAsStringAsync().Result;

                    File.WriteAllText(filepath, joke);

                    //System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(joke.GetType());
                    //Serize ti file to read
                    //x.Serialize(Console.Out, joke);

                    //WriteToXmlFile(filepath, joke);

                    //label2.Text = joke.Jokes[0].Joke;
                    //System.Console.WriteLine(joke);
                }
            }
            catch (AggregateException)
            {
            }
        }

        public static void WriteToXmlFile(string filePath, string objectToWrite, bool append = false)
        {
            TextWriter writer = null;
            try
            {
                var serializer = new XmlSerializer(objectToWrite.GetType());
                writer = new StreamWriter(filePath, append);
                serializer.Serialize(writer, objectToWrite);
            }
            finally
            {
                if (writer != null)
                    writer.Close();
            }
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