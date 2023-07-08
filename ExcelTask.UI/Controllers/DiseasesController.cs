using ExcelTask.Application.DTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ExcelTask.UI.Controllers;

public class DiseasesController : Controller
{
    Uri baseAddress = new Uri("https://localhost:7282/api");
    private readonly HttpClient _client;

    public DiseasesController()
    {
        _client = new HttpClient();
        _client.BaseAddress = baseAddress;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        List<DiseaseViewDto> diseases = new List<DiseaseViewDto>();
        HttpResponseMessage response = await _client.GetAsync(_client.BaseAddress + "/Diseases/Get");

        if (response.IsSuccessStatusCode)
        {
            string data = await response.Content.ReadAsStringAsync();
            diseases = JsonConvert.DeserializeObject<List<DiseaseViewDto>>(data);
        }

        return View(diseases);
    }
}
