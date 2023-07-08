namespace ExcelTask.Core.Entities;

public class NCD_Detail : BaseEntity
{
    public int PatientId { get; set; }
    public Patient Patient { get; set; }

    public int NCDId { get; set; }
    public NCD NCD { get; set; }
}
