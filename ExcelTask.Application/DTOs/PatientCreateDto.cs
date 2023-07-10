using System.ComponentModel.DataAnnotations;

namespace ExcelTask.Application.DTOs;

public class PatientCreateDto
{
    [Required]
    public string? Name { get; set; }

    [Required]
    public int DiseaseId { get; set; }
    public int Epilepsy { get; set; }

    public List<Ncd_DetailCreateDto>? NCDs { get; set; }
    public List<Allergies_DetailCreateDto>? Allergies { get; set; }
}