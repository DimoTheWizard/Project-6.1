﻿using System;
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
            //dataGridView1.Hide();
            label2.Hide();
            //this.JsonApiCall();
            //this.XMLApiCall();
            //ValidateJSON();
            //ValidateXML();

            //DataSet ds = new DataSet();
            //ds.ReadXml("C:\\Users\\Gebruiker\\source\\repos\\WindowsFormsApp1\\WindowsFormsApp1\\get.xml");
            //dataGridView1.DataSource = ds.Tables[0];

            ValidateJSON();
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
            label2.Hide();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            
            transactionsPage1.BringToFront();
            transactionsPage1.Show();
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
        
        private void JsonApiCall()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var address = new Uri("https://v2.jokeapi.dev/joke/Any?blacklistFlags=nsfw,religious,political,racist,sexist,explicit&type=single&amount=10");
                    var result = client.GetAsync(address).Result;
                    var joke = result.Content.ReadAsAsync<Transactions>().Result;

                    label2.Text = "Joke 1 "+ joke.Jokes[0].Joke + " Joke 2 " + joke.Jokes[1].Joke;
                    //System.Console.WriteLine(joke.Error);
                    //System.Console.WriteLine(joke.Amount);
                    //System.Console.WriteLine(joke.Jokes[0].Joke);
                }
            }
            catch (AggregateException)
            {
            }
        }

        //Validates JSON using schema provided
        private async void ValidateJSON()
        {
            string filepath = "C:\\Users\\Gebruiker\\source\\repos\\WindowsFormsApp1\\WindowsFormsApp1\\get.json";

            var bsonValue = await getValue();
            var settings = new JsonWriterSettings { Indent = true };
            var jsonOutput = bsonValue.ToJson(settings);
            var jsonOutputString = jsonOutput.ToString();
            String bracketL = "{";
            String bracketR = "}";

            string output = String.Format("{0} \"transaction\": {1} {2} ",bracketL, jsonOutputString,bracketR);

            
            output = output.Replace("_", string.Empty);
            output = output.Replace("ObjectId(", string.Empty);
            output = output.Replace("STARTUMSE", string.Empty);

            output = output.Replace("),", ",");


            File.WriteAllText(filepath, output);

            //System.Console.WriteLine(output);

            JSchema schema = JSchema.Parse(System.IO.File.ReadAllText("C:\\Users\\Gebruiker\\source\\repos\\WindowsFormsApp1\\WindowsFormsApp1\\schemaValidation.json"));
            JObject jsonObject = JObject.Parse(System.IO.File.ReadAllText("C:\\Users\\Gebruiker\\source\\repos\\WindowsFormsApp1\\WindowsFormsApp1\\get.json"));
            if (jsonObject.IsValid(schema))
            {
                System.Console.WriteLine(jsonObject.IsValid(schema));
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
        }

        private void transactionsPage1_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

    }
}
