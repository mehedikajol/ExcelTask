namespace ExcelTask.Application.DTOs;

public class PatientViewDto
{
    public int Id { get; set; }
    public string? Name { get; set; }

    public int DiseaseId { get; set; }
    public string? DiseaseName { get; set; }
    public int Epilepsy { get; set; }
    public string? EpilepsyName { get; set; }

    public List<Ncd_DetailViewDto>? NCDs { get; set; }
    public List<Allergies_DetailViewDto>? Allergies { get; set; }
}
