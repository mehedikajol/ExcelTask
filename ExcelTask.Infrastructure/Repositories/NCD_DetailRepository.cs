using ExcelTask.Application.IRepositories;
using ExcelTask.Core.Entities;
using ExcelTask.Infrastructure.Contexts;

namespace ExcelTask.Infrastructure.Repositories;

public class NCD_DetailRepository : GenericRepository<NCD_Detail>, INCD_DetailRepository
{
    public NCD_DetailRepository(ExcelTaskDbContext context) 
        : base(context)
    {
    }
}
