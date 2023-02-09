using API.Models;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using System.IO;
using System.Text.Json;

namespace API.Services
{
    public class MongoDBService
    {
        private readonly IMongoCollection<Transaction> _transactionCollection;
        public MongoDBService(IOptions<MongoDBSettings> mongoDBSettings)
        {
            MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
            IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
            _transactionCollection = database.GetCollection<Transaction>(mongoDBSettings.Value.CollectionName);
        }

        public async Task CreateAsync(Transaction transaction)
        {
            await _transactionCollection.InsertOneAsync(transaction);
            return;
        }

        public async Task<List<Transaction>> GetAsync()
        {
            return await _transactionCollection.Find(new BsonDocument()).ToListAsync();
        }
    }
}