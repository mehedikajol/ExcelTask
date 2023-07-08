using ExcelTask.Application.IRepositories;

namespace ExcelTask.Application;

public interface IUnitOfWork
{

    IPatientRepository Patients { get; }
    IDiseaseRepository Diseases { get; }

    Task CompleteAsync();
}
