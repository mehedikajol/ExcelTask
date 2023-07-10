using ExcelTask.Application.DTOs;

namespace ExcelTask.Application.IServices;

public interface IPatientService
{
    Task<IEnumerable<PatientViewDto>> GetAllPatientsAsync();
    Task<PatientViewDto> GetPatientByIdAsync(int id);
    Task AddPatientAsync(PatientCreateDto patient);
    Task DeletePatientAsync(int id);
    Task UpdatePatient(PatientUpdateDto patient);
}
