using ExcelTask.Application.DTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace ExcelTask.UI.Controllers;

public class DiseasesController : BaseController
{
    string url = "Diseases/";

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        List<DiseaseViewDto> diseases = new List<DiseaseViewDto>();
        HttpResponseMessage response = await _client.GetAsync(_client.BaseAddress + url);

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
        if (ModelState.IsValid)
        {
            try
            {
                var data = JsonConvert.SerializeObject(disease);
                var content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await _client.PostAsync(_client.BaseAddress + url, content);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> View(int id)
    {
        DiseaseViewDto disease = new DiseaseViewDto();
        HttpResponseMessage response = await _client.GetAsync(_client.BaseAddress + url + id);

        if (response.IsSuccessStatusCode)
        {
            string data = await response.Content.ReadAsStringAsync();
            disease = JsonConvert.DeserializeObject<DiseaseViewDto>(data);
        }
        return View(disease);
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        DiseaseUpdateDto disease = new DiseaseUpdateDto();
        HttpResponseMessage response = await _client.GetAsync(_client.BaseAddress + url + id);

        if (response.IsSuccessStatusCode)
        {
            string data = await response.Content.ReadAsStringAsync();
            disease = JsonConvert.DeserializeObject<DiseaseUpdateDto>(data);
        }
        return View(disease);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(DiseaseUpdateDto disease)
    {
        if (ModelState.IsValid)
        {
            try
            {
                var data = JsonConvert.SerializeObject(disease);
                var content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await _client.PutAsync(_client.BaseAddress + url, content);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        DiseaseViewDto disease = new DiseaseViewDto();
        HttpResponseMessage response = await _client.GetAsync(_client.BaseAddress + url + id);

        if (response.IsSuccessStatusCode)
        {
            string data = await response.Content.ReadAsStringAsync();
            disease = JsonConvert.DeserializeObject<DiseaseViewDto>(data);
        }
        return View(disease);
    }

    [HttpPost]
    public async Task<IActionResult> Delete(DiseaseViewDto disease)
    {
        HttpResponseMessage response = await _client.DeleteAsync(_client.BaseAddress + url + disease.Id);

        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction(nameof(Index));
        }
        return View(disease);
    }
}
