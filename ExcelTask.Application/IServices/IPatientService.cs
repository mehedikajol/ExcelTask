using ExcelTask.Application.DTOs;

namespace ExcelTask.Application.IServices;

public interface IPatientService
{
    Task<IEnumerable<PatientViewDto>> GetAllPatientsAsync();
    Task AddPatientAsync(PatientCreateDto patient);
}
