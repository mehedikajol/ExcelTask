using ExcelTask.Application.DTOs;

namespace ExcelTask.Application.IServices;

public interface IDiseaseService
{
    Task<IEnumerable<DiseaseViewDto>> GetAllDiseasesAsync();
    Task<DiseaseViewDto> GetDiseaseByIdAsync(int id);

    Task AddDiseaseAsync(DiseaseCreateDto disease);
    Task UpdateDiease(DiseaseUpdateDto disease);
    Task DeleteDiseaseAsync(int id);
}
