using ExcelTask.Application.DTOs;
using ExcelTask.Application.IServices;

namespace ExcelTask.Infrastructure.Services;

public class Allergies_DetailService : IAllergies_DetailService
{
    public Task<IEnumerable<Allergies_DetailViewDto>> GetAllAllergiesDetailsAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Allergies_DetailViewDto> GetAllergiesDetailByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task AddAllergiesDetailAsync(Allergies_DetailCreateDto allergiesDetail)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAllergiesDetail(Allergies_DetailUpdateDto allergiesDetail)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAllergiesDetailAsync(int id)
    {
        throw new NotImplementedException();
    }
}
