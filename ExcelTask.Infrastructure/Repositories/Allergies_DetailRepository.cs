using ExcelTask.Application.IRepositories;
using ExcelTask.Core.Entities;
using ExcelTask.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace ExcelTask.Infrastructure.Repositories;

public class Allergies_DetailRepository : GenericRepository<Allergies_Detail>, IAllergies_DetailRepository
{
    public Allergies_DetailRepository(ExcelTaskDbContext context)
        : base(context)
    {
    }

    public async Task<IEnumerable<Allergies_Detail>> GetEntitiesByPatientIdAsync(int patientId)
    {
        return await _dbSet.Where(ad => ad.PatientId == patientId).ToListAsync();
    }

    public async Task<Allergies_Detail> GetEntityByPatientIdAndAllergiesIdAsync(int patientId, int allergiesId)
    {
        return await _dbSet.Where(ad => ad.PatientId == patientId && ad.AllergiesId == allergiesId).FirstOrDefaultAsync();
    }
}
