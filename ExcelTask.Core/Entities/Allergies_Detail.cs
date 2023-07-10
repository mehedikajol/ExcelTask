namespace ExcelTask.Core.Entities;

public class Allergies_Detail : BaseEntity
{
    public int PatientId { get; set; }
    public Patient Patient { get; set; }

    public int AllergiesId { get; set; }
    public Allergies Allergies { get; set; }
}
