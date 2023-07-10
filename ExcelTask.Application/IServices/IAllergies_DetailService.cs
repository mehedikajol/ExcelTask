using ExcelTask.Application.DTOs;

namespace ExcelTask.Application.IServices;

public interface IAllergies_DetailService
{
    Task<IEnumerable<Allergies_DetailViewDto>> GetAllAllergiesDetailsAsync();
    Task<Allergies_DetailViewDto> GetAllergiesDetailByIdAsync(int id);

    Task AddAllergiesDetailAsync(Allergies_DetailCreateDto allergiesDetail);
    Task UpdateAllergiesDetail(Allergies_DetailUpdateDto allergiesDetail);
    Task DeleteAllergiesDetailAsync(int id);

    Task<IEnumerable<Allergies_DetailViewDto>> GetAllergiesDetailsByPatientIdAsync(int patientId);
}
