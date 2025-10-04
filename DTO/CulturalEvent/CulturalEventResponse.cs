using MongoDB.Bson;

namespace cp5.DTO.CulturalEvent;

public class CulturalEventResponse
{
    public string Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime Date { get; set; }
    public string Location { get; set; }
    public string Category { get; set; }
    public int MaxCapacity { get; set; }
    public DateTime CreatedAt { get; set; }
}