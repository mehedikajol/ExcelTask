using ExcelTask.Application;
using ExcelTask.Application.DTOs;
using ExcelTask.Application.IServices;
using ExcelTask.Core.Entities;

namespace ExcelTask.Infrastructure.Services;

public class DiseaseService : IDiseaseService
{
    private readonly IUnitOfWork _unitOfWork;

    public DiseaseService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<DiseaseViewDto>> GetAllDiseasesAsync()
    {
        var entities = await _unitOfWork.Diseases.GetAllEntitiesAsync();
        var diseases = new List<DiseaseViewDto>();
        foreach(var entity in entities)
        {
            diseases.Add(new DiseaseViewDto
            {
                Id = entity.Id,
                Name = entity.Name,
            });
        }
        return diseases;
    }

    public async Task<DiseaseViewDto> GetDiseaseByIdAsync(int id)
    {
        var entity = await _unitOfWork.Diseases.GetEntityByIdAsync(id);
        return new DiseaseViewDto
        {
            Id = entity.Id,
            Name = entity.Name,
        };
    }

    public async Task AddDiseaseAsync(DiseaseCreateDto disease)
    {
        await _unitOfWork.Diseases.AddEntityAsync(new Disease { Name = disease.Name, });
        await _unitOfWork.CompleteAsync();
    }

    public async Task UpdateDiease(DiseaseUpdateDto disease)
    {
        await _unitOfWork.Diseases.UpdateEntity(new Disease { Id = disease.Id, Name = disease.Name });
        await _unitOfWork.CompleteAsync();
    }

    public async Task DeleteDiseaseAsync(int id)
    {
        await _unitOfWork.Diseases.DeleteEntityByIdAsync(id);
        await _unitOfWork.CompleteAsync();
    }
}
