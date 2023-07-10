namespace ExcelTask.Application.DTOs;

public class PatientUpdateDto
{
    public int Id { get; set; }
    public string? Name { get; set; }

    public int DiseaseId { get; set; }
    public int Epilepsy { get; set; }

    public List<Ncd_DetailUpdateDto>? NCDs { get; set; }
    public List<Allergies_DetailUpdateDto>? Allergies { get; set; }
}
