using ExcelTask.Application.DTOs;
using ExcelTask.Application.IServices;

namespace ExcelTask.Infrastructure.Services;

public class NCD_DetailService : INCD_DetailService
{
    public Task<IEnumerable<Ncd_DetailUPdateDto>> GetAllNcdDetailsAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Ncd_DetailUPdateDto> GetNcdDetailByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task AddNcdDetailAsync(Ncd_DetailCreateDto ncdDetail)
    {
        throw new NotImplementedException();
    }

    public Task UpdateDetailNcd(Ncd_DetailUPdateDto ncdDetail)
    {
        throw new NotImplementedException();
    }

    public Task DeleteNcdDetailAsync(int id)
    {
        throw new NotImplementedException();
    }
}
