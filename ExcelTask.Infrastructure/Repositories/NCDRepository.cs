using ExcelTask.Application.IRepositories;
using ExcelTask.Core.Entities;
using ExcelTask.Infrastructure.Contexts;

namespace ExcelTask.Infrastructure.Repositories;

internal class NCDRepository : GenericRepository<NCD>, INCDRepository
{
    public NCDRepository(ExcelTaskDbContext context) 
        : base(context)
    {
    }
}
