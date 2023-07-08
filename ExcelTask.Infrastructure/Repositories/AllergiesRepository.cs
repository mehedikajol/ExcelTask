using ExcelTask.Application.IRepositories;
using ExcelTask.Core.Entities;
using ExcelTask.Infrastructure.Contexts;

namespace ExcelTask.Infrastructure.Repositories;

public class AllergiesRepository : GenericRepository<Allergies>, IAllergiesRepository
{
    public AllergiesRepository(ExcelTaskDbContext context)
        : base(context)
    {
    }
}
