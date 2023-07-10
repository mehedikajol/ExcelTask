namespace ExcelTask.Application.DTOs;

public class Allergies_DetailViewDto
{
    public int Id { get; set; }
    public int AllergiesId { get; set; }
    public string? AllergiesName { get; set; }
    public int PatientId { get; set; }
}
