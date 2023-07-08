using ExcelTask.Application;
using ExcelTask.Application.DTOs;
using ExcelTask.Application.IServices;
using ExcelTask.Core.Entities;

namespace ExcelTask.Infrastructure.Services;

public class NCDService : INCDService
{
    private readonly IUnitOfWork _unitOfWork;

    public NCDService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<NcdVIewDto>> GetAllNcdsAsync()
    {
        var entities = await _unitOfWork.NCDs.GetAllEntitiesAsync();
        var ncds = new List<NcdVIewDto>();
        foreach (var entity in entities)
        {
            ncds.Add(new NcdVIewDto
            {
                Id = entity.Id,
                Name = entity.Name,
            });
        }
        return ncds;
    }

    public async Task<NcdVIewDto> GetNcdByIdAsync(int id)
    {
        var entity = await _unitOfWork.NCDs.GetEntityByIdAsync(id);
        return new NcdVIewDto
        {
            Id = entity.Id,
            Name = entity.Name,
        };
    }

    public async Task AddNcdAsync(NcdCreateDto ncd)
    {
        await _unitOfWork.NCDs.AddEntityAsync(new NCD { Name = ncd.Name, });
        await _unitOfWork.CompleteAsync();
    }

    public async Task UpdateNcd(NcdUpdateDto ncd)
    {
        await _unitOfWork.NCDs.UpdateEntity(new NCD { Id = ncd.Id, Name = ncd.Name });
        await _unitOfWork.CompleteAsync();
    }

    public async Task DeleteNcdAsync(int id)
    {
        await _unitOfWork.NCDs.DeleteEntityByIdAsync(id);
        await _unitOfWork.CompleteAsync();
    }
}
