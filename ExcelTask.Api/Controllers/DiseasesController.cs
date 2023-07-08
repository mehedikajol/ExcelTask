using ExcelTask.Application.DTOs;
using ExcelTask.Application.IServices;
using Microsoft.AspNetCore.Mvc;

namespace ExcelTask.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DiseasesController : ControllerBase
{
    private readonly IDiseaseService _diseaseService;

    public DiseasesController(IDiseaseService diseaseService)
    {
        _diseaseService = diseaseService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var diseases = await _diseaseService.GetAllDiseasesAsync();
        return Ok(diseases);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var disease = await _diseaseService.GetDiseaseByIdAsync(id);
        return Ok(disease);
    }

    [HttpPost]
    public async Task<IActionResult> Post(DiseaseCreateDto disease)
    {
        await _diseaseService.AddDiseaseAsync(disease);
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> Put(DiseaseUpdateDto disease)
    {
        await _diseaseService.UpdateDiease(disease);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _diseaseService.DeleteDiseaseAsync(id);
        return Ok();
    }
}
