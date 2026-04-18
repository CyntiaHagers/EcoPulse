using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace EcoPulse.Api.Models
{
    [BsonIgnoreExtraElements]
    public class Device
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }   // ✅ opcional (Mongo gera)

        [BsonElement("type")]
        public string Type { get; set; } = string.Empty;  // ✅ evita erro

        [BsonElement("model")]
        public string Model { get; set; } = string.Empty; // ✅ evita erro
    }
}