using Amazon.Auth.AccessControlPolicy;
using MongoDB.Bson;
using MongoDB.Driver;
using Raptorious.SharpMt940Lib;
using Sports_Accounting;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;

namespace api
{
    public class JsonAPI
    {
        MongoClient dbClient = null;
        MongoDB.Driver.IMongoDatabase database = null;
        MongoDB.Driver.IMongoCollection<MongoDB.Bson.BsonDocument> collection = null;

        public JsonAPI()
        {
            //connect the mongoDB client to the db through the connection string
            MongoClient dbClient = new MongoClient(@"mongodb+srv://GroupA:flzld6fOoWLDdTnD@project6-1.hoeec74.mongodb.net/?retryWrites=true&w=majority");

            //get the database and the collection we want to use
            database = dbClient.GetDatabase("SportsAccounting");
            collection = database.GetCollection<BsonDocument>("transactions");
        }

        public BsonDocument FileToBson(string path)
        {
            //read the content of the file
            var mt940Text = File.ReadAllText(path);

            //add the trailer
            mt940Text += "-";

            Console.WriteLine(mt940Text);

            //Create a valid JSON string
            var jsonFile = "{ \"mt940_content\": \"" + mt940Text.Replace("\"", "\\\"") + "\" }";

            //Parse the JSON string into a BsonDocument
            var document = BsonDocument.Parse(jsonFile);

            return document;
        }

        public bool checkMT940(BsonDocument BsonDoc)
        {
            var header = new Raptorious.SharpMt940Lib.Mt940Format.Separator("STARTUMSE");
            var trailer = new Raptorious.SharpMt940Lib.Mt940Format.Separator("-");
            var genericFomat = new Raptorious.SharpMt940Lib.Mt940Format.GenericFormat(header, trailer);
            try
            {
                //if it successfully runs all tests return true
                var parsed = Raptorious.SharpMt940Lib.Mt940Parser.ParseData(genericFomat, BsonDoc.GetElement("mt940_content").ToString(), CultureInfo.CurrentCulture);
                XmlAPI xmlAPI = new XmlAPI();
                List<BsonDocument> document = new List<BsonDocument>();
                document.Add(BsonDoc);
                if (xmlAPI.XMLConverter(document) == null)
                {
                    return false;
                }
                return true;
            } catch
            {
                //if it fails catch and throw false
                return false;
            }
        }

        //Put a single document into the MongoDB database
        public void Post(BsonDocument document)
        {
            try
            {
                collection.InsertOne(document);
                System.Console.WriteLine("inserted document into MongoDB");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error inserting document into MongoDB: " + ex.Message);
            }
        }

        public async Task<List<BsonDocument>> Get(BsonDocument criteria)
        {
            try
            {
                // retrieve BSON documents from MongoDB based on the criteria
                var cursor = await collection.FindAsync(criteria);

                var documents = new List<BsonDocument>();
                while (await cursor.MoveNextAsync())
                {
                    // loops through all found documents
                    var batch = cursor.Current;
                    foreach (var document in batch)
                    {
                        // Add the BSON document to the list
                        documents.Add(document);
                    }
                }
                return documents;
            }
            catch (Exception ex)
            {
                // handle any exceptions thrown during get request
                System.Console.WriteLine("An error occurred retrieving documents from MongoDB: " + ex.Message);
                return null;
            }
        }

        public async Task<List<BsonDocument>> GetAll()
        {
            try
            {
                //retrieve all BSON documents from MongoDB
                var cursor = await collection.FindAsync(new BsonDocument());

                var documents = new List<BsonDocument>();
                while (await cursor.MoveNextAsync())
                {
                    //loops through all found documents
                    var batch = cursor.Current;
                    foreach (var document in batch)
                    {
                        //Add the BSON document to the list
                        documents.Add(document);
                    }
                }
                return documents;
            }
            catch (Exception ex)
            {
                //handle exceptions given during get request
                System.Console.WriteLine("An error occurred retrieving documents from MongoDB: " + ex.Message);
                return null;
            }
        }

        //Updates all similar to the filter according to update
        public async Task<bool> Put(BsonDocument original, BsonDocument updated)
        {
            try
            {
                //make a filter based on id
                var filter = Builders<BsonDocument>.Filter.Eq("_id", original["_id"]);
                //make the updated bson document
                var update = Builders<BsonDocument>.Update.Set("mt940_content", updated["mt940_content"]);
                //update the single adjusted document
                var result = await collection.UpdateOneAsync(filter, update);

                //return true if the document was updated.
                return result.ModifiedCount > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while updating the document: " + ex.Message);
                return false;
            }
        }

        public async Task<bool> Delete(BsonDocument original)
        {
            //Delete the document that matches the filter
            var result = await collection.DeleteOneAsync(original);

            //True if deleted, else false
            return result.IsAcknowledged && result.DeletedCount > 0;
        }
    }
}