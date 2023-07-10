using System.ComponentModel.DataAnnotations;

namespace ExcelTask.Application.DTOs;

public class NcdCreateDto
{
    [Required]
    public string? Name { get; set; }
}
