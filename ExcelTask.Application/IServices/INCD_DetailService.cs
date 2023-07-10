using ExcelTask.Application.DTOs;

namespace ExcelTask.Application.IServices;

public interface INCD_DetailService
{
    Task<IEnumerable<Ncd_DetailViewDto>> GetAllNcdDetailsAsync();
    Task<Ncd_DetailViewDto> GetNcdDetailByIdAsync(int id);

    Task AddNcdDetailAsync(Ncd_DetailCreateDto ncdDetail);
    Task UpdateDetailNcd(Ncd_DetailUpdateDto ncdDetail);
    Task DeleteNcdDetailAsync(int id);

    Task<IEnumerable<Ncd_DetailViewDto>> GetNcdDetailsByPatientIdAsync(int patientId);
}
