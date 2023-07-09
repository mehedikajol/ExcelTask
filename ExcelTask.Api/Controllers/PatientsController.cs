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
        var patients = await _patientService.GetAllPatientsAsync();
        return Ok(patients);
    }

    [HttpPost]
    public async Task<IActionResult> Post(PatientCreateDto patient)
    {
        await _patientService.AddPatientAsync(patient);
        return Ok();
    }
}
