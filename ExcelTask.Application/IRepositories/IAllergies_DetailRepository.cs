using ExcelTask.Core.Entities;

namespace ExcelTask.Application.IRepositories;

public interface IAllergies_DetailRepository : IGenericRepository<Allergies_Detail>
{
    Task<IEnumerable<Allergies_Detail>> GetEntitiesByPatientIdAsync(int patientId);
}
