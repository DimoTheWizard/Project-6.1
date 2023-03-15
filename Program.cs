using api;
using MongoDB.Bson;
using Parser;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sports_Accounting
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            //This is needed to allow await functions to wait instead of causing errors,
            //Have to turn main into an async task aswell so that it functions properly
            Task.Run(async () => await MainAsync(args));

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LogIn());
        }
        static async Task MainAsync(string[] args)
        {
            /*
            MT940 mt940 = new MT940(@"C:\Users\dimit\Source\Repos\Project-6.1\samplemt940.txt");
            ParserAPI parser = new ParserAPI(mt940);
            Console.WriteLine(parser.parseMT940_TO_JSON());
            Console.WriteLine(parser.getJSON());
            Console.ReadKey();
            */

            //define the API class
            JsonAPI jsonAPI = new JsonAPI();

            //Get a MT940 file ready
            MT940 mt940File = new MT940(@"C:\Users\dimit\source\repos\RestAPITesting\samplemt940.txt");

            //Read the file
            var mt940Text = File.ReadAllText(mt940File.getMT940());

            //Create a valid JSON string
            var jsonFile = "{ \"mt940_content\": \"" + mt940Text.Replace("\"", "\\\"") + "\" }";

            //Parse the JSON string into a BsonDocument
            var document = BsonDocument.Parse(jsonFile);

            //Post the BsonDocument to MongoDB
            jsonAPI.Post(document);

            //Retrieve the Document using Get
            var retrievedDocs = await jsonAPI.Get(document);
            Console.WriteLine("RETRIEVED DOCUMENTS");
            foreach (var doc in retrievedDocs)
            {
                Console.WriteLine(doc.ToJson());
            }

            //Get a MT940 file ready
            MT940 mt940AFileAdjusted = new MT940(@"C:\Users\dimit\source\repos\RestAPITesting\editedmt940.txt");

            //Read the file
            var mt940Adjusted = File.ReadAllText(mt940AFileAdjusted.getMT940());

            //Create a valid JSON string
            var jsonFileAdjusted = "{ \"mt940_content\": \"" + mt940Adjusted.Replace("\"", "\\\"") + "\" }";

            //Parse the JSON string into a BsonDocument
            var documentAdjusted = BsonDocument.Parse(jsonFileAdjusted);

            //Update the document
            await jsonAPI.Put(document, documentAdjusted);

            //Retrieve the Document using Get
            var retrievedDocsAdjusted = await jsonAPI.Get(documentAdjusted);
            Console.WriteLine("RETRIEVED ADJUSTED DOCUMENTS");
            foreach (var doc in retrievedDocsAdjusted)
            {
                Console.WriteLine(doc.ToJson());
            }

            //delete the document
            jsonAPI.Delete(documentAdjusted);
            Console.WriteLine("DELETED DOCUMENT");
        }
    }
}
