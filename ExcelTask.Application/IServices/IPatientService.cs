using ExcelTask.Application.DTOs;

namespace ExcelTask.Application.IServices;

public interface IPatientService
{
    Task AddPatientAsync(PatientCreateDto patient);
}
