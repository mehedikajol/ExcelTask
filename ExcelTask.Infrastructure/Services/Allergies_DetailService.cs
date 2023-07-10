using ExcelTask.Application;
using ExcelTask.Application.DTOs;
using ExcelTask.Application.IServices;
using ExcelTask.Core.Entities;

namespace ExcelTask.Infrastructure.Services;

public class Allergies_DetailService : IAllergies_DetailService
{
    private readonly IUnitOfWork _unitOfWork;

    public Allergies_DetailService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Allergies_DetailViewDto>> GetAllAllergiesDetailsAsync()
    {
        var entities = await _unitOfWork.Allergies_Details.GetAllEntitiesAsync();
        var allergiesDetails = new List<Allergies_DetailViewDto>();
        foreach (var entity in entities)
        {
            allergiesDetails.Add(new Allergies_DetailViewDto
            {
                Id = entity.Id,
                PatientId = entity.PatientId,
                AllergiesId = entity.AllergiesId,
            });
        }
        return allergiesDetails;
    }

    public async Task<Allergies_DetailViewDto> GetAllergiesDetailByIdAsync(int id)
    {
        var entity = await _unitOfWork.Allergies_Details.GetEntityByIdAsync(id);
        return new Allergies_DetailViewDto
        {
            Id = entity.Id,
            PatientId = entity.PatientId,
            AllergiesId = entity.AllergiesId
        };
    }

    public async Task AddAllergiesDetailAsync(Allergies_DetailCreateDto allergiesDetail)
    {
        await _unitOfWork.Allergies_Details.AddEntityAsync(new Allergies_Detail
        {
            PatientId = allergiesDetail.PatientId,
            AllergiesId = allergiesDetail.AllergiesId
        });
        await _unitOfWork.CompleteAsync();
    }

    public async Task UpdateAllergiesDetail(Allergies_DetailUpdateDto allergiesDetail)
    {
        await _unitOfWork.Allergies_Details.UpdateEntity(new Allergies_Detail
        {
            Id = allergiesDetail.Id,
            PatientId = allergiesDetail.PatientId,
            AllergiesId = allergiesDetail.AllergiesId
        });
        await _unitOfWork.CompleteAsync();
    }

    public async Task DeleteAllergiesDetailAsync(int id)
    {
        await _unitOfWork.Allergies_Details.DeleteEntityByIdAsync(id);
        await _unitOfWork.CompleteAsync();
    }

    public async Task<IEnumerable<Allergies_DetailViewDto>> GetAllergiesDetailsByPatientIdAsync(int patientId)
    {
        var entities = await _unitOfWork.Allergies_Details.GetEntitiesByPatientIdAsync(patientId);
        var allergiesDetails = new List<Allergies_DetailViewDto>();
        foreach (var entity in entities)
        {
            allergiesDetails.Add(new Allergies_DetailViewDto
            {
                Id = entity.Id,
                PatientId = entity.PatientId,
                AllergiesId = entity.AllergiesId,
            });
        }
        return allergiesDetails;
    }

    public async Task<Allergies_DetailViewDto> GetAllergiesDetailByPatientIdAndAllergiesIdAsync(int patientId, int allergiesId)
    {
        var entity = await _unitOfWork.Allergies_Details.GetEntityByPatientIdAndAllergiesIdAsync(patientId, allergiesId);
        return new Allergies_DetailViewDto
        {
            Id = entity.Id,
            PatientId = entity.PatientId,
            AllergiesId = entity.AllergiesId
        };
    }
}
