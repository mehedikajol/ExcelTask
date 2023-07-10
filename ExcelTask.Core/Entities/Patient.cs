using ExcelTask.Core.Enums;

namespace ExcelTask.Core.Entities;

public class Patient : BaseEntity
{
    public string? Name { get; set; }

    public int DiseaseId { get; set; }
    public Disease Disease { get; set; }

    public Epilepsy Epilepsy { get; set; }

    public ICollection<NCD_Detail>? NCDs { get; set; }
    public ICollection<Allergies_Detail>? Allergies { get; set;}
}
