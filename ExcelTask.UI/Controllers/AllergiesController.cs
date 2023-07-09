using ExcelTask.Application.DTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace ExcelTask.UI.Controllers;

public class AllergiesController : BaseController
{
    string url = "Allergies/";

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        List<AllergiesViewDto> allergies = new List<AllergiesViewDto>();
        HttpResponseMessage response = await _client.GetAsync(_client.BaseAddress + url);

        if (response.IsSuccessStatusCode)
        {
            string data = await response.Content.ReadAsStringAsync();
            allergies = JsonConvert.DeserializeObject<List<AllergiesViewDto>>(data);
        }
        return View(allergies);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(AllergiesCreateDto allergies)
    {
        try
        {
            var data = JsonConvert.SerializeObject(allergies);
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
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> View(int id)
    {
        AllergiesViewDto allergies = new AllergiesViewDto();
        HttpResponseMessage response = await _client.GetAsync(_client.BaseAddress + url + id);

        if (response.IsSuccessStatusCode)
        {
            string data = await response.Content.ReadAsStringAsync();
            allergies = JsonConvert.DeserializeObject<AllergiesViewDto>(data);
        }
        return View(allergies);
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        AllergiesUpdateDto allergies = new AllergiesUpdateDto();
        HttpResponseMessage response = await _client.GetAsync(_client.BaseAddress + url + id);

        if (response.IsSuccessStatusCode)
        {
            string data = await response.Content.ReadAsStringAsync();
            allergies = JsonConvert.DeserializeObject<AllergiesUpdateDto>(data);
        }
        return View(allergies);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(AllergiesUpdateDto allergies)
    {
        try
        {
            var data = JsonConvert.SerializeObject(allergies);
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
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        AllergiesViewDto allergies = new AllergiesViewDto();
        HttpResponseMessage response = await _client.GetAsync(_client.BaseAddress + url + id);

        if (response.IsSuccessStatusCode)
        {
            string data = await response.Content.ReadAsStringAsync();
            allergies = JsonConvert.DeserializeObject<AllergiesViewDto>(data);
        }
        return View(allergies);
    }

    [HttpPost]
    public async Task<IActionResult> Delete(AllergiesViewDto allergies)
    {
        HttpResponseMessage response = await _client.DeleteAsync(_client.BaseAddress + url + allergies.Id);

        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction(nameof(Index));
        }
        return View(allergies);
    }
}
