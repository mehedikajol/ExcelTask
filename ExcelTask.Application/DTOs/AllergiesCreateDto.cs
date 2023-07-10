using System.ComponentModel.DataAnnotations;

namespace ExcelTask.Application.DTOs;

public class AllergiesCreateDto
{
    [Required]
    public string? Name { get; set; }
}
