using ExcelTask.Application.DTOs;
using ExcelTask.Core.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Security.Policy;
using System.Text;

namespace ExcelTask.UI.Controllers;

public class PatientsController : BaseController
{
    string url = "Patients/";
    public async Task<IActionResult> IndexAsync()
    {
        List<PatientViewDto> patients = new List<PatientViewDto>();
        HttpResponseMessage response = await _client.GetAsync(_client.BaseAddress + url);

        if (response.IsSuccessStatusCode)
        {
            string data = await response.Content.ReadAsStringAsync();
            patients = JsonConvert.DeserializeObject<List<PatientViewDto>>(data);
        }
        return View(patients);
    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        var diseases = await GetAllDiseases();
        var epilepsyies = GetAllEpilepsies();
        var allergies = await GetAllAllergies();
        var ncds = await GetAllNcds();
        ViewData["Diseases"] = new SelectList(diseases, "Id", "Name");
        ViewData["Epilepsyies"] = new SelectList(epilepsyies, "Id", "Name");
        ViewData["Allergies"] = new List<AllergiesViewDto>(allergies);
        ViewData["Ncds"] = new List<NcdViewDto>(ncds);

        return View(new PatientCreateDto());
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] PatientCreateDto patient)
    {
        try
        {
            var data = JsonConvert.SerializeObject(patient);
            var content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _client.PostAsync(_client.BaseAddress + url, content);
            if (response.IsSuccessStatusCode)
            {
                return new JsonResult(new
                {
                    Done = true,
                    Message = "Success"
                });
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
        PatientViewDto patient = new PatientViewDto();
        HttpResponseMessage response = await _client.GetAsync(_client.BaseAddress + url + id);

        if (response.IsSuccessStatusCode)
        {
            string data = await response.Content.ReadAsStringAsync();
            patient = JsonConvert.DeserializeObject<PatientViewDto>(data);
        }
        return View(patient);
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        PatientUpdateDto patient = new PatientUpdateDto();
        HttpResponseMessage response = await _client.GetAsync(_client.BaseAddress + url + id);

        if (response.IsSuccessStatusCode)
        {
            string data = await response.Content.ReadAsStringAsync();
            patient = JsonConvert.DeserializeObject<PatientUpdateDto>(data);
        }
        var patientNcds = patient?.NCDs?.Select(p => p.NCDId).ToList();
        var patientAllergies = patient?.Allergies?.Select(p => p.AllergiesId).ToList();

        var diseases = await GetAllDiseases();
        var epilepsyies = GetAllEpilepsies();
        var allergies = await GetAllAllergies();
        var ncds = await GetAllNcds();
        ViewData["Diseases"] = new SelectList(diseases, "Id", "Name");
        ViewData["Epilepsyies"] = new SelectList(epilepsyies, "Id", "Name");
        ViewData["Allergies"] = new List<AllergiesViewDto>(allergies);
        ViewData["PatientAllergies"] = patientAllergies;
        ViewData["Ncds"] = new List<NcdViewDto>(ncds);
        ViewData["PatientNcds"] = patientNcds;

        return View(patient);
    }

    [HttpPost]
    public async Task<IActionResult> Edit([FromBody] PatientUpdateDto patient)
    {
        try
        {
            var data = JsonConvert.SerializeObject(patient);
            var content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _client.PutAsync(_client.BaseAddress + url, content);
            if (response.IsSuccessStatusCode)
            {
                return new JsonResult(new
                {
                    Done = true,
                    Message = "Success"
                });
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
        PatientViewDto patient = new PatientViewDto();
        HttpResponseMessage response = await _client.GetAsync(_client.BaseAddress + url + id);

        if (response.IsSuccessStatusCode)
        {
            string data = await response.Content.ReadAsStringAsync();
            patient = JsonConvert.DeserializeObject<PatientViewDto>(data);
        }
        return View(patient);
    }

    [HttpPost]
    public async Task<IActionResult> Delete(PatientViewDto patient)
    {
        HttpResponseMessage response = await _client.DeleteAsync(_client.BaseAddress + url + patient.Id);

        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction(nameof(Index));
        }
        return View(patient);
    }


    private async Task<List<DiseaseViewDto>> GetAllDiseases()
    {
        List<DiseaseViewDto> diseases = new List<DiseaseViewDto>();
        HttpResponseMessage response = await _client.GetAsync(_client.BaseAddress + "Diseases/");

        if (response.IsSuccessStatusCode)
        {
            string data = await response.Content.ReadAsStringAsync();
            diseases = JsonConvert.DeserializeObject<List<DiseaseViewDto>>(data);
        }
        return diseases;
    }

    private IEnumerable<object> GetAllEpilepsies()
    {
        var mainCategories = from Epilepsy s in Enum.GetValues(typeof(Epilepsy))
                             select new { Id = s.GetHashCode(), Name = s.ToString() };
        return mainCategories;
    }

    private async Task<List<AllergiesViewDto>> GetAllAllergies()
    {
        List<AllergiesViewDto> allergies = new List<AllergiesViewDto>();
        HttpResponseMessage response = await _client.GetAsync(_client.BaseAddress + "Allergies/");

        if (response.IsSuccessStatusCode)
        {
            string data = await response.Content.ReadAsStringAsync();
            allergies = JsonConvert.DeserializeObject<List<AllergiesViewDto>>(data);
        }
        return allergies;
    }

    private async Task<List<NcdViewDto>> GetAllNcds()
    {
        List<NcdViewDto> ncds = new List<NcdViewDto>();
        HttpResponseMessage response = await _client.GetAsync(_client.BaseAddress + "Ncds/");

        if (response.IsSuccessStatusCode)
        {
            string data = await response.Content.ReadAsStringAsync();
            ncds = JsonConvert.DeserializeObject<List<NcdViewDto>>(data);
        }
        return ncds;
    }
}
