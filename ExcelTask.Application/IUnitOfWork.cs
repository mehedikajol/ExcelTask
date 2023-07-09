using ExcelTask.Application.IRepositories;

namespace ExcelTask.Application;

public interface IUnitOfWork
{

    IPatientRepository Patients { get; }
    IDiseaseRepository Diseases { get; }
    IAllergiesRepository Allergies { get; }
    IAllergies_DetailRepository Allergies_Details { get; }
    INCDRepository NCDs { get; }
    INCD_DetailRepository NCD_Details { get; }

    Task CompleteAsync();
}
