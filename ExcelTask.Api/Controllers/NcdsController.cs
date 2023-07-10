using ExcelTask.Application.DTOs;
using ExcelTask.Application.IServices;
using Microsoft.AspNetCore.Mvc;

namespace ExcelTask.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class NcdsController : ControllerBase
{
    private readonly INCDService _ndcService;

    public NcdsController(INCDService ndcService)
    {
        _ndcService = ndcService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var ncds = await _ndcService.GetAllNcdsAsync();
        return Ok(ncds);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var ncd = await _ndcService.GetNcdByIdAsync(id);
        return Ok(ncd);
    }

    [HttpPost]
    public async Task<IActionResult> Post(NcdCreateDto ncd)
    {
        await _ndcService.AddNcdAsync(ncd);
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> Put(NcdUpdateDto ncd)
    {
        await _ndcService.UpdateNcd(ncd);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _ndcService.DeleteNcdAsync(id);
        return Ok();
    }
}
