using ExcelTask.Application.DTOs;

namespace ExcelTask.Application.IServices;

public interface INCD_DetailService
{
    Task<IEnumerable<Ncd_DetailUPdateDto>> GetAllNcdDetailsAsync();
    Task<Ncd_DetailUPdateDto> GetNcdDetailByIdAsync(int id);

    Task AddNcdDetailAsync(Ncd_DetailCreateDto ncdDetail);
    Task UpdateDetailNcd(Ncd_DetailUPdateDto ncdDetail);
    Task DeleteNcdDetailAsync(int id);
}
