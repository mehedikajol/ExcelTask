using ExcelTask.Application.IRepositories;

namespace ExcelTask.Application;

public interface IUnitOfWork
{

    IPatientRepository Patients { get; }
    IDiseaseRepository Diseases { get; }
    IAllergiesRepository Allergies { get; }
    INCDRepository NCDs { get; }

    Task CompleteAsync();
}
