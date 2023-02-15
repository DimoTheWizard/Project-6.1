using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace API.Models
{
    public class Transaction
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id;

        [BsonElement("transaction")]
        [JsonPropertyName("transaction")]
        public string transaction { get; set; } = null;
    }
}
