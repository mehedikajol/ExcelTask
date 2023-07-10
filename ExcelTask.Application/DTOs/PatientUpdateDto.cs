using System.ComponentModel.DataAnnotations;

namespace ExcelTask.Application.DTOs;

public class PatientUpdateDto
{
    [Required]
    public int Id { get; set; }

    [Required]
    public string? Name { get; set; }

    [Required]
    public int DiseaseId { get; set; }
    public int Epilepsy { get; set; }

    public List<Ncd_DetailUpdateDto>? NCDs { get; set; }
    public List<Allergies_DetailUpdateDto>? Allergies { get; set; }
}
