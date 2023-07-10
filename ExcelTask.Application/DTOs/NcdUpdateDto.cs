using System.ComponentModel.DataAnnotations;

namespace ExcelTask.Application.DTOs;

public class NcdUpdateDto
{
    public int Id { get; set; }

    [Required]
    public string? Name { get; set; }
}
