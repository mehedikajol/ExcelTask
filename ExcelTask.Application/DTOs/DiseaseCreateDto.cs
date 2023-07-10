using System.ComponentModel.DataAnnotations;

namespace ExcelTask.Application.DTOs;

public class DiseaseCreateDto
{
    [Required]
    public string? Name { get; set; }
}
