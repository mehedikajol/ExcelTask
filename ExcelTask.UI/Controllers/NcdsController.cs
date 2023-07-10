using ExcelTask.Application.DTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace ExcelTask.UI.Controllers;

public class NcdsController : BaseController
{
    string url = "Ncds/";

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        List<NcdViewDto> ncds = new List<NcdViewDto>();
        HttpResponseMessage response = await _client.GetAsync(_client.BaseAddress + url);

        if (response.IsSuccessStatusCode)
        {
            string data = await response.Content.ReadAsStringAsync();
            ncds = JsonConvert.DeserializeObject<List<NcdViewDto>>(data);
        }
        return View(ncds);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(NcdCreateDto ncd)
    {
        if (ModelState.IsValid)
        {
            try
            {
                var data = JsonConvert.SerializeObject(ncd);
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
        NcdViewDto ncd = new NcdViewDto();
        HttpResponseMessage response = await _client.GetAsync(_client.BaseAddress + url + id);

        if (response.IsSuccessStatusCode)
        {
            string data = await response.Content.ReadAsStringAsync();
            ncd = JsonConvert.DeserializeObject<NcdViewDto>(data);
        }
        return View(ncd);
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        NcdUpdateDto ncd = new NcdUpdateDto();
        HttpResponseMessage response = await _client.GetAsync(_client.BaseAddress + url + id);

        if (response.IsSuccessStatusCode)
        {
            string data = await response.Content.ReadAsStringAsync();
            ncd = JsonConvert.DeserializeObject<NcdUpdateDto>(data);
        }
        return View(ncd);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(NcdUpdateDto ncd)
    {
        if (ModelState.IsValid)
        {
            try
            {
                var data = JsonConvert.SerializeObject(ncd);
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
        NcdViewDto ncd = new NcdViewDto();
        HttpResponseMessage response = await _client.GetAsync(_client.BaseAddress + url + id);

        if (response.IsSuccessStatusCode)
        {
            string data = await response.Content.ReadAsStringAsync();
            ncd = JsonConvert.DeserializeObject<NcdViewDto>(data);
        }
        return View(ncd);
    }

    [HttpPost]
    public async Task<IActionResult> Delete(NcdViewDto ncd)
    {
        HttpResponseMessage response = await _client.DeleteAsync(_client.BaseAddress + url + ncd.Id);

        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction(nameof(Index));
        }
        return View(ncd);
    }
}
