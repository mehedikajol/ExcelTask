using ExcelTask.Application.IRepositories;
using ExcelTask.Core.Entities;
using ExcelTask.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace ExcelTask.Infrastructure.Repositories;

public class NCD_DetailRepository : GenericRepository<NCD_Detail>, INCD_DetailRepository
{
    public NCD_DetailRepository(ExcelTaskDbContext context) 
        : base(context)
    {
    }

    public async Task<IEnumerable<NCD_Detail>> GetEntitiesByPatientIdAsync(int patientId)
    {
        return await _dbSet.Where(nd => nd.PatientId == patientId).ToListAsync();
    }

    public async Task<NCD_Detail> GetEntityByPatientIdAndNcdIdAsync(int patientId, int ncdId)
    {
        return await _dbSet.Where(nd => nd.PatientId == patientId && nd.NCDId == ncdId).FirstOrDefaultAsync();
    }
}
