using ExcelTask.Application.IRepositories;
using ExcelTask.Core.Entities;
using ExcelTask.Infrastructure.Contexts;

namespace ExcelTask.Infrastructure.Repositories;

public class Allergies_DetailRepository : GenericRepository<Allergies_Detail>, IAllergies_DetailRepository
{
    public Allergies_DetailRepository(ExcelTaskDbContext context) 
        : base(context)
    {
    }
}
