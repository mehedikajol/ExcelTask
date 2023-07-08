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
}
