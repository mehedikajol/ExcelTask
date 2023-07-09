using ExcelTask.Application.DTOs;
using ExcelTask.Application.IServices;
using Microsoft.AspNetCore.Mvc;

namespace ExcelTask.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AllergiesController : ControllerBase
{
    private readonly IAllergiesService _allergiesService;

    public AllergiesController(IAllergiesService allergiesService)
    {
        _allergiesService = allergiesService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var allergies = await _allergiesService.GetAllAllergiesAsync();
        return Ok(allergies);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var allergies = await _allergiesService.GetAllergiesByIdAsync(id);
        return Ok(allergies);
    }

    [HttpPost]
    public async Task<IActionResult> Post(AllergiesCreateDto allergies)
    {
        await _allergiesService.AddAllergiesAsync(allergies);
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> Put(AllergiesUpdateDto allergies)
    {
        await _allergiesService.UpdateAllergies(allergies);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _allergiesService.DeleteAllergiesAsync(id);
        return Ok();
    }
}
