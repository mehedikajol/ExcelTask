using ExcelTask.Application;
using ExcelTask.Application.DTOs;
using ExcelTask.Application.IServices;
using ExcelTask.Core.Entities;

namespace ExcelTask.Infrastructure.Services;

public class AllergiesService : IAllergiesService
{
    private readonly IUnitOfWork _unitOfWork;

    public AllergiesService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<AllergiesViewDto>> GetAllAllergiesAsync()
    {
        var entities = await _unitOfWork.Allergies.GetAllEntitiesAsync();
        var allergies = new List<AllergiesViewDto>();
        foreach (var entity in entities)
        {
            allergies.Add(new AllergiesViewDto
            {
                Id = entity.Id,
                Name = entity.Name,
            });
        }
        return allergies.ToList();
    }

    public async Task<AllergiesViewDto> GetAllergiesByIdAsync(int id)
    {
        var entity = await _unitOfWork.Allergies.GetEntityByIdAsync(id);
        return new AllergiesViewDto
        {
            Id = entity.Id,
            Name = entity.Name,
        };
    }

    public async Task AddAllergiesAsync(AllergiesCreateDto allergies)
    {
        await _unitOfWork.Allergies.AddEntityAsync(new Allergies { Name = allergies.Name, });
        await _unitOfWork.CompleteAsync();
    }

    public async Task UpdateAllergies(AllergiesUpdateDto allergies)
    {
        await _unitOfWork.Allergies.UpdateEntity(new Allergies { Id = allergies.Id, Name = allergies.Name });
        await _unitOfWork.CompleteAsync();
    }

    public async Task DeleteAllergiesAsync(int id)
    {
        await _unitOfWork.Allergies.DeleteEntityByIdAsync(id);
        await _unitOfWork.CompleteAsync();
    }
}
