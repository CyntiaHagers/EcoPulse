using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace EcoPulse.Api.Models
{
    [BsonIgnoreExtraElements] // ⭐ ESSA LINHA RESOLVE
    public class Device
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public string Id { get; set; } = null!;

        [BsonElement("type")]
        public string Type { get; set; } = null!;

        [BsonElement("model")]
        public string Model { get; set; } = null!;
    }
}