using System.ComponentModel.DataAnnotations;

namespace cp5.DTO.CulturalEvent;

public class CulturalEventDTO
{
    [Required(ErrorMessage = "O título do evento é obrigatório")]
    public string Title { get; set; }
    
    [Required(ErrorMessage = "A descrição do evento é obrigatória")]
    public string Description { get; set; }
    
    [Required(ErrorMessage = "A data do evento é obrigatória")]
    public DateTime Date { get; set; }
    
    [Required(ErrorMessage = "A localização do evento é obrigatória")]
    public string Location { get; set; }
    
    [Required(ErrorMessage = "A categoria do evento é obrigatória")]
    public string Category { get; set; }
    
    [Required(ErrorMessage = "A capacidade máxima do evento é obrigatória")]
    public int MaxCapacity { get; set; }
}