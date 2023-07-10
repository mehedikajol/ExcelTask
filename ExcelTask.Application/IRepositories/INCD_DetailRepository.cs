using ExcelTask.Core.Entities;

namespace ExcelTask.Application.IRepositories;

public interface INCD_DetailRepository : IGenericRepository<NCD_Detail>
{
    Task<IEnumerable<NCD_Detail>> GetEntitiesByPatientIdAsync(int patientId);
    Task<NCD_Detail> GetEntityByPatientIdAndNcdIdAsync(int patientId, int ncdId);
}
