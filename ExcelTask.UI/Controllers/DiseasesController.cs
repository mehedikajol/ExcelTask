using ExcelTask.Application.DTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
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
        HttpResponseMessage response = await _client.GetAsync(_client.BaseAddress + "/Diseases");

        if (response.IsSuccessStatusCode)
        {
            string data = await response.Content.ReadAsStringAsync();
            diseases = JsonConvert.DeserializeObject<List<DiseaseViewDto>>(data);
        }
        return View(diseases);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(DiseaseCreateDto disease)
    {
        try
        {
            var data = JsonConvert.SerializeObject(disease);
            var content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _client.PostAsync(_client.BaseAddress + "/Diseases", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
        }catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View();
        }
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> View(int id)
    {
        DiseaseViewDto disease = new DiseaseViewDto();
        HttpResponseMessage response = await _client.GetAsync(_client.BaseAddress + "/Diseases/" + id);

        if (response.IsSuccessStatusCode)
        {
            string data = await response.Content.ReadAsStringAsync();
            disease = JsonConvert.DeserializeObject<DiseaseViewDto>(data);
        }
        return View(disease);
    }
}
