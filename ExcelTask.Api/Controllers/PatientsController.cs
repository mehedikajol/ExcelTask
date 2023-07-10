using ExcelTask.Application.DTOs;
using ExcelTask.Application.IServices;
using ExcelTask.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace ExcelTask.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PatientsController : ControllerBase
{
    private readonly IPatientService _patientService;

    public PatientsController(IPatientService patientService)
    {
        _patientService = patientService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var patient = await _patientService.GetAllPatientsAsync();
        return Ok(patient);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var allergies = await _patientService.GetPatientByIdAsync(id);
        return Ok(allergies);
    }

    [HttpPost]
    public async Task<IActionResult> Post(PatientCreateDto patient)
    {
        await _patientService.AddPatientAsync(patient);
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> Put(PatientUpdateDto patient)
    {
        await _patientService.UpdatePatient(patient);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _patientService.DeletePatientAsync(id);
        return Ok();
    }
}
