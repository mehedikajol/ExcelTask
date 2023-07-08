using ExcelTask.Application.IRepositories;
using ExcelTask.Core.Entities;
using ExcelTask.Infrastructure.Contexts;

namespace ExcelTask.Infrastructure.Repositories;

public class PatientRepository : GenericRepository<Patient>, IPatientRepository
{
    public PatientRepository(ExcelTaskDbContext context) 
        : base(context)
    {
    }
}
