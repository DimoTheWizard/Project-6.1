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

namespace Sports_Accounting
{
    public class Validator
    {
        public Validator(){}

        //gets all from the json api
        private async Task<List<BsonDocument>> getValue()
        {
            JsonAPI jsonAPI = new JsonAPI();
            var xmlDocs = await jsonAPI.GetAll();
            return xmlDocs;
        }

        //Validates JSON using schema provided, populate table 
        //TODO: store in Database
        public async void callJson()
        {
            string filepath = "C:\\Users\\dimit\\Source\\Repos\\Project-6.1\\get.json";

            //JsonAPI call to save as string
            var bsonValue = await getValue();
            var settings = new JsonWriterSettings { Indent = true };
            var jsonOutput = bsonValue.ToJson(settings);
            var jsonOutputString = jsonOutput.ToString();
            Console.WriteLine(jsonOutputString);
            
           //Hardcode change  the api request to fit format of draft 07 for validation
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
            JSchema schema = JSchema.Parse(System.IO.File.ReadAllText(@"C:\Users\dimit\Source\Repos\Project-6.1\schemaValidation.json"));
            JObject jsonObject = JObject.Parse(System.IO.File.ReadAllText(@"C:\\Users\\dimit\\Source\\Repos\\Project-6.1\\get.json"));

            //if validation passes display to page
            if (jsonObject.IsValid(schema))
            {
                System.Console.WriteLine(jsonObject.IsValid(schema));
                var serialisedString = output;
                var transactions = Newtonsoft.Json.JsonConvert.DeserializeObject<Transactions>(output, new JsonSerializerSettings());
            }
            else
            {
                System.Console.WriteLine(false);
            };
        }

        ////Validates xml using schema provided
        //private void ValidateXML()
        //{
        //    string filepath = "C:\\Users\\Gebruiker\\source\\repos\\WindowsFormsApp1\\WindowsFormsApp1\\get.xml";

        //    try
        //    {
        //        using (HttpClient cli = new HttpClient())
        //        {
        //            var url = new Uri("https://v2.jokeapi.dev/joke/Any?blacklistFlags=nsfw,religious,political,racist,sexist,explicit&format=xml&type=single&amount=10");
        //            var response = cli.GetAsync(url).Result;
        //            var joke = response.Content.ReadAsStringAsync().Result;

        //            File.WriteAllText(filepath, joke);
        //            XmlSchemaSet schema = new XmlSchemaSet();
        //            schema.Add("", @"C:\\Users\\Gebruiker\\source\\repos\\WindowsFormsApp1\\WindowsFormsApp1\\xmlValidator.xsd");

        //            XDocument doc = XDocument.Load(filepath);
        //            bool status = false;

        //            doc.Validate(schema, (s, e) =>
        //            {

        //                System.Console.WriteLine(e.Message);
        //                status = true;
        //            });
        //            if (status)
        //            {
        //                System.Console.WriteLine("Failed");
        //            }
        //            //WriteState code to populate page here
        //            else
        //            {
        //                System.Console.WriteLine("Passed");
        //            }
        //        }
        //    }
        //    catch (AggregateException)
        //    {
        //    }
        //}

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
    }
}