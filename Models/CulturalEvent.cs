using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace cp5.Models;

public class CulturalEvent
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; } = "";
    
    [BsonElement("title")]
    public required string Title { get; set; }
    
    [BsonElement("description")]
    public required string Description { get; set; }
    
    [BsonElement("date")]
    public required DateTime Date { get; set; }
    
    [BsonElement("location")]
    public required string Location { get; set; }
    
    [BsonElement("category")]
    public required string Category { get; set; }
    
    [BsonElement("max_capacity")]
    public required int MaxCapacity { get; set; }
    
    [BsonElement("created_at")]
    public required DateTime CreatedAt { get; set; }
}