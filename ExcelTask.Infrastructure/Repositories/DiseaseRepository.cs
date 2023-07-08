using ExcelTask.Application.IRepositories;
using ExcelTask.Core.Entities;
using ExcelTask.Infrastructure.Contexts;

namespace ExcelTask.Infrastructure.Repositories;

public class DiseaseRepository : GenericRepository<Disease>, IDiseaseRepository
{
    public DiseaseRepository(ExcelTaskDbContext context) 
        : base(context)
    {
    }
}
