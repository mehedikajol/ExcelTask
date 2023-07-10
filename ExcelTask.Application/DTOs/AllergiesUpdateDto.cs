using System.ComponentModel.DataAnnotations;

namespace ExcelTask.Application.DTOs;

public class AllergiesUpdateDto
{
    public int Id { get; set; }

    [Required]
    public string? Name { get; set; }
}
