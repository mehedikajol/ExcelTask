using ExcelTask.Application;
using ExcelTask.Application.DTOs;
using ExcelTask.Application.IServices;
using ExcelTask.Core.Entities;
using ExcelTask.Core.Enums;

namespace ExcelTask.Infrastructure.Services;

public class PatientService : IPatientService
{
    private readonly IUnitOfWork _unitOfWork;

    public PatientService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<PatientViewDto>> GetAllPatientsAsync()
    {
        var entities = await _unitOfWork.Patients.GetAllEntitiesAsync();
        var patients = new List<PatientViewDto>();

        foreach(var entity in entities)
        {
            patients.Add(new PatientViewDto
            {
                Id = entity.Id,
                Name = entity.Name,
                DiseaseId = entity.DiseaseId,
                Epilepsy = entity.Epilepsy.GetHashCode()
            });
        }
        return patients;
    }

    public async Task AddPatientAsync(PatientCreateDto patient)
    {
        var patientEntity = new Patient
        {
            Name = patient.Name,
            DiseaseId = patient.DiseaseId,
            Epilepsy = (Epilepsy)patient.Epilepsy,
        };
        await _unitOfWork.Patients.AddEntityAsync(patientEntity);
        await _unitOfWork.CompleteAsync();

        if (patient?.NCDs?.Count() > 0)
        {
            foreach (var ncd in patient.NCDs)
            {
                await _unitOfWork.NCD_Details.AddEntityAsync(new NCD_Detail
                {
                    PatientId = patientEntity.Id,
                    NCDId = ncd.NCDId
                });
            }
        }

        if (patient?.Allergies?.Count() > 0)
        {
            foreach (var allergies in patient.Allergies)
            {
                await _unitOfWork.Allergies_Details.AddEntityAsync(new Allergies_Detail
                {
                    PatientId = patientEntity.Id,
                    AllergiesId = allergies.AllergiesId
                });
            }
        }
        await _unitOfWork.CompleteAsync();
    }
}
