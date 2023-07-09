namespace ExcelTask.Application.DTOs;

public class PatientViewDto
{
    public int Id { get; set; }
    public string? Name { get; set; }

    public int DiseaseId { get; set; }
    public int Epilepsy { get; set; }

    public List<Ncd_DetailCreateDto>? NCDs { get; set; }
    public List<Allergies_DetailCreateDto>? Allergies { get; set; }
}
