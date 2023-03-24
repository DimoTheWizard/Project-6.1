using api;
using Newtonsoft.Json.Schema;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.Xml;
using Newtonsoft.Json.Schema;
using Newtonsoft.Json.Linq;
using System.Xml.Schema;
using System.Xml.Linq;
using MongoDB.Bson.IO;
using MongoDB.Bson;


namespace Sports_Accounting
{
    public partial class LogIn : Form
    {
        public LogIn()
        {
            InitializeComponent();
            ValidateJSON();
        }


        //Pull all from API
        public async Task<List<BsonDocument>> getValue()
        {
            JsonAPI jsonAPI = new JsonAPI();
            var xmlDocs = await jsonAPI.GetAll();
            return xmlDocs;
        }

        //Validates JSON using schema provided
        private async void ValidateJSON()
        {
            string filepath = "C:\\Users\\Gebruiker\\Documents\\GitHub\\Project-6.1\\get.json";

            //Uncomment with correct format
            //var bsonValue = await getValue();
            //var settings = new JsonWriterSettings { Indent = true };
            //var jsonOutput = bsonValue.ToJson(settings);

            //File.WriteAllText(filepath, jsonOutput);

            //System.Console.WriteLine(jsonOutput);

            JSchema schema = JSchema.Parse(System.IO.File.ReadAllText("C:\\Users\\Gebruiker\\Documents\\GitHub\\Project-6.1\\schemaValidation.json"));
            JObject jsonObject = JObject.Parse(System.IO.File.ReadAllText("C:\\Users\\Gebruiker\\Documents\\GitHub\\Project-6.1\\get.json"));
            if (jsonObject.IsValid(schema))
            {
                System.Console.WriteLine("Yes it passed Yes it passed Yes it passed Yes it passed Yes it passed Yes it passed Yes it passed Yes it passed Yes it passed Yes it passed Yes it passed Yes it passed Yes it passed Yes it passed");
            };


        }
    }
}
