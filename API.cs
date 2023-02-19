using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections;

namespace api
{
    public class API
    {
        MongoClient dbClient = null;
        MongoDB.Driver.IMongoDatabase database = null;
        MongoDB.Driver.IMongoCollection<MongoDB.Bson.BsonDocument> collection = null;

        public API()
        {
            //we have to connect the mongoDB client to the db through the connection string
            MongoClient dbClient = new MongoClient(@"mongodb+srv://GroupA:flzld6fOoWLDdTnD@project6-1.hoeec74.mongodb.net/?retryWrites=true&w=majority");

            //get the database and the collection we want to use
            database = dbClient.GetDatabase("SportsAccounting");
            collection = database.GetCollection<BsonDocument>("transactions");
        }

        public void postToDB(string[] mt940FileLocation)
        {
            ArrayList mt940Data = new ArrayList();
            ArrayList mt940Bson = new ArrayList();

            Console.WriteLine("Reading File using File.ReadAllText()");

            for (int i = 0; i < mt940FileLocation.Length; i++)
            {
                // To read the entire file at once
                if (File.Exists(mt940FileLocation[i]))
                {
                    // Read all the content in one string
                    // and display the string
                    mt940Data.Add(File.ReadAllText(mt940FileLocation[i]));
                }
                Console.WriteLine();
            }

            //Converts the data into bson documents
            for (int i = 0; i < mt940Data.Count; i++)
            {
                mt940Bson.Add(BsonDocument.Parse("{\"mt940_content\":\" " + mt940Data[i] + " \"}"));
            }

            //adds arrayList to database in atlas
            for (int i = 0; i < mt940Bson.Count; i++)
            {
                collection.InsertOne((BsonDocument)mt940Bson.ToArray().GetValue(i));
            }

            System.Console.WriteLine("Done sending files");
        }

        public List<MongoDB.Bson.BsonDocument> readDB()
        {
            return collection.Find(new BsonDocument()).ToList();
        }
    }
