using ExcelTask.Application.DTOs;

namespace ExcelTask.Application.IServices;

public interface INCDService
{
    Task<IEnumerable<NcdViewDto>> GetAllNcdsAsync();
    Task<NcdViewDto> GetNcdByIdAsync(int id);

    Task AddNcdAsync(NcdCreateDto ncd);
    Task UpdateNcd(NcdUpdateDto ncd);
    Task DeleteNcdAsync(int id);
}
