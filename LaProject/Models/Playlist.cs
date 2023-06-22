using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace LaProject.Models
{
    public class Playlist
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string? Id { get; set; }
        
        public string username { get; set; } = null!;

        [BsonElement("items")]
        [JsonPropertyName("items")]
        public List<string> movieIds { get; set; } = null!;
    }
}
