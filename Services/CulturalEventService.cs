using cp5.DTO.CulturalEvent;
using cp5.Exceptions;
using cp5.Models;
using MongoDB.Driver;

namespace cp5.Services;

public class CulturalEventService : IService<CulturalEventResponse, CulturalEventDTO>
{
    private readonly IMongoCollection<CulturalEvent> _culturalEvents;

    private readonly string NOT_FOUND_MESSAGE = "Evento não foi encontrado";
    
    public CulturalEventService(IMongoCollection<CulturalEvent> culturalEvents)
    {
        _culturalEvents = culturalEvents;
    }

    // Create
    public async Task<CulturalEventResponse> Save(CulturalEventDTO request)
    {
        var culturalEvent = new CulturalEvent
        {
            Title = request.Title,
            Description = request.Description,
            Date = request.Date,
            Location = request.Location,
            Category = request.Category,
            MaxCapacity = request.MaxCapacity,
            CreatedAt = DateTime.UtcNow,
        };
        
        await _culturalEvents.InsertOneAsync(culturalEvent);
        
        return new  CulturalEventResponse
        {
            Id = culturalEvent.Id,
            Title = culturalEvent.Title,
            Description = culturalEvent.Description,
            Date = culturalEvent.Date,
            Location = culturalEvent.Location,
            Category = culturalEvent.Category,
            MaxCapacity = culturalEvent.MaxCapacity,
            CreatedAt = culturalEvent.CreatedAt
        };
    }
    
    // Find All
    public async Task<IEnumerable<CulturalEventResponse>> FindAll()
    {
      var culturalEvents = await _culturalEvents.Find(x => true).ToListAsync();
      return culturalEvents.Select(culturalEvent => new CulturalEventResponse
      {
          Id = culturalEvent.Id,
          Title = culturalEvent.Title,
          Description = culturalEvent.Description,
          Date = culturalEvent.Date,
          Location = culturalEvent.Location,
          Category = culturalEvent.Category,
          MaxCapacity = culturalEvent.MaxCapacity,
          CreatedAt = culturalEvent.CreatedAt
      }).ToList();
    }
    
    // Find By ID
    public async Task<CulturalEventResponse> FindById(string id)
    {
        var culturalEvent = await _culturalEvents.Find(culturalEvent => culturalEvent.Id == id).FirstOrDefaultAsync();
        if (culturalEvent == null) throw new NotFoundException(NOT_FOUND_MESSAGE);

        return new CulturalEventResponse
        {
            Id = culturalEvent.Id,
            Title = culturalEvent.Title,
            Description = culturalEvent.Description,
            Date = culturalEvent.Date,
            Location = culturalEvent.Location,
            Category = culturalEvent.Category,
            MaxCapacity = culturalEvent.MaxCapacity,
            CreatedAt = culturalEvent.CreatedAt
        };
    }
    
    // Update
    public async Task<CulturalEventResponse> Update(string id, CulturalEventDTO culturalEvent)
    {
        var existingCulturalEvent = await _culturalEvents.Find(existingCulturalEvent => existingCulturalEvent.Id == id).FirstOrDefaultAsync();
        if (existingCulturalEvent == null) throw new NotFoundException(NOT_FOUND_MESSAGE);

        var replacingCulturalEvent = new CulturalEvent
        {
            Id = existingCulturalEvent.Id,
            Title = culturalEvent.Title,
            Description = culturalEvent.Description,
            Date = culturalEvent.Date,
            Location = culturalEvent.Location,
            Category = culturalEvent.Category,
            MaxCapacity = culturalEvent.MaxCapacity,
            CreatedAt = existingCulturalEvent.CreatedAt
        };
        
        await _culturalEvents.ReplaceOneAsync(b => b.Id == id, replacingCulturalEvent);
        
        return new CulturalEventResponse
        {
            Id = replacingCulturalEvent.Id,
            Title = culturalEvent.Title,
            Description = culturalEvent.Description,
            Date = culturalEvent.Date,
            Location = culturalEvent.Location,
            Category = culturalEvent.Category,
            MaxCapacity = culturalEvent.MaxCapacity,
            CreatedAt = replacingCulturalEvent.CreatedAt
        };
    }
    
    // Delete
    public async Task<CulturalEventResponse> Delete(string id)
    {
        var result = await _culturalEvents.DeleteOneAsync(b => b.Id == id);
        if (result.DeletedCount == 0) throw new NotFoundException(NOT_FOUND_MESSAGE);
        
        return new CulturalEventResponse();
    }
}