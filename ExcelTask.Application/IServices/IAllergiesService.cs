using ExcelTask.Application.DTOs;

namespace ExcelTask.Application.IServices;

public interface IAllergiesService
{
    Task<IEnumerable<AllergiesViewDto>> GetAllAllergiesAsync();
    Task<AllergiesViewDto> GetAllergiesByIdAsync(int id);

    Task AddAllergiesAsync(AllergiesCreateDto allergies);
    Task UpdateAllergies(AllergiesUpdateDto allergies);
    Task DeleteAllergiesAsync(int id);
}
