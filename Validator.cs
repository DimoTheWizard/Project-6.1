using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using Newtonsoft.Json.Schema;
using Newtonsoft.Json.Linq; 
using api;
using MongoDB.Bson.IO;
using MongoDB.Bson;
using Newtonsoft.Json;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using System.Data.SqlTypes;

namespace Sports_Accounting
{
    public class Validator
    {
        private string JsonSchemapath = AppDomain.CurrentDomain.BaseDirectory + "schemaValidation.json";
        public Validator(){}

        //gets all from the json api
        private async Task<List<BsonDocument>> getValue()
        {
            JsonAPI jsonAPI = new JsonAPI();
            var xmlDocs = await jsonAPI.GetAll();
            return xmlDocs;
        }

        //Validates JSON using schema provided
        public bool validateJson(BsonDocument BsonDoc)
        {
            JSchema schema = JSchema.Parse(System.IO.File.ReadAllText(JsonSchemapath));
            XmlAPI xml = new XmlAPI();
            List<BsonDocument> bsonDocs = new List<BsonDocument>();
            bsonDocs.Add(BsonDoc);
            XmlDocument xmlDocs = xml.XMLConverter(bsonDocs);
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xmlDocs.OuterXml);

            string json = Newtonsoft.Json.JsonConvert.SerializeXmlNode(doc);

            //if validation passes display to page
            if (JObject.Parse(json).IsValid(schema))
            {
                return true;
            }
            else
            {
                return false;
            };
        }

        //Validates XML using Schema
        public bool validateXml(string xml)
        {
            try
            {
                //Create the XmlSchemaSet with XSD string
                XmlSchemaSet schemaSet = new XmlSchemaSet();

                schemaSet.Add(null, AppDomain.CurrentDomain.BaseDirectory + "xmlValidator.xsd");

                //Make reader settings with validation schema
                XmlReaderSettings settings = new XmlReaderSettings();
                settings.ValidationType = ValidationType.Schema;
                settings.Schemas = schemaSet;
                settings.ValidationEventHandler += ValidationEventHandler;

                //Make the reader with xml string
                XmlReader reader = XmlReader.Create(new StringReader(xml), settings);

                //Reads the xml until its false AKA invalid
                while (reader.Read()) { }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        static void ValidationEventHandler(object sender, System.Xml.Schema.ValidationEventArgs e)
        {
            if (e.Severity == XmlSeverityType.Error)
                Console.WriteLine("Error: " + e.Message);
            else
                Console.WriteLine("Warning: " + e.Message);
        }
    }
}
