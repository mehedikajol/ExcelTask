using Microsoft.AspNetCore.Mvc;

namespace ExcelTask.UI.Controllers;

public class BaseController : Controller
{
    Uri baseAddress = new Uri("https://localhost:7282/api/");
    protected readonly HttpClient _client;

    public BaseController()
    {
        _client = new HttpClient();
        _client.BaseAddress = baseAddress;
    }
}
