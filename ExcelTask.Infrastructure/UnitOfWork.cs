using ExcelTask.Application;
using ExcelTask.Application.IRepositories;
using ExcelTask.Infrastructure.Contexts;
using ExcelTask.Infrastructure.Repositories;

namespace ExcelTask.Infrastructure;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly ExcelTaskDbContext _context;

    public UnitOfWork(ExcelTaskDbContext context)
    {
        _context = context;

        Patients = new PatientRepository(_context);
        Diseases = new DiseaseRepository(_context);
    }

    public IPatientRepository Patients { get; private set; }

    public IDiseaseRepository Diseases { get; private set; }

    public async Task CompleteAsync()
    {
        await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
