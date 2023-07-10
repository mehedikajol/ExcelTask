using ExcelTask.Application;
using ExcelTask.Application.DTOs;
using ExcelTask.Application.IServices;
using ExcelTask.Core.Entities;

namespace ExcelTask.Infrastructure.Services;

public class NCD_DetailService : INCD_DetailService
{
    private readonly IUnitOfWork _unitOfWork;

    public NCD_DetailService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Ncd_DetailViewDto>> GetAllNcdDetailsAsync()
    {
        var entities = await _unitOfWork.NCD_Details.GetAllEntitiesAsync();
        var ncdDetails = new List<Ncd_DetailViewDto>();
        foreach (var entity in entities)
        {
            ncdDetails.Add(new Ncd_DetailViewDto
            {
                Id = entity.Id,
                PatientId = entity.PatientId,
                NCDId = entity.NCDId
            });
        }
        return ncdDetails;
    }

    public async Task<Ncd_DetailViewDto> GetNcdDetailByIdAsync(int id)
    {
        var entity = await _unitOfWork.NCD_Details.GetEntityByIdAsync(id);
        return new Ncd_DetailViewDto
        {
            Id = entity.Id,
            PatientId = entity.PatientId,
            NCDId = entity.NCDId
        };
    }

    public async Task AddNcdDetailAsync(Ncd_DetailCreateDto ncdDetail)
    {
        await _unitOfWork.NCD_Details.AddEntityAsync(new NCD_Detail
        {
            PatientId = ncdDetail.PatientId,
            NCDId = ncdDetail.NCDId
        });
        await _unitOfWork.CompleteAsync();
    }

    public async Task UpdateDetailNcd(Ncd_DetailUpdateDto ncdDetail)
    {
        await _unitOfWork.NCD_Details.UpdateEntity(new NCD_Detail
        {
            Id = ncdDetail.Id,
            PatientId = ncdDetail.PatientId,
            NCDId = ncdDetail.NCDId
        });
        await _unitOfWork.CompleteAsync();
    }

    public async Task DeleteNcdDetailAsync(int id)
    {
        await _unitOfWork.NCD_Details.DeleteEntityByIdAsync(id);
        await _unitOfWork.CompleteAsync();
    }

    public async Task<IEnumerable<Ncd_DetailViewDto>> GetNcdDetailsByPatientIdAsync(int patientId)
    {
        var entities = await _unitOfWork.NCD_Details.GetEntitiesByPatientIdAsync(patientId);
        var ncdDetails = new List<Ncd_DetailViewDto>();
        foreach (var entity in entities)
        {
            ncdDetails.Add(new Ncd_DetailViewDto
            {
                Id = entity.Id,
                PatientId = entity.PatientId,
                NCDId = entity.NCDId
            });
        }
        return ncdDetails;
    }
}
