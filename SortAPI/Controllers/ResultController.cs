using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

namespace SortAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ResultController : ControllerBase
{

    private readonly ILogger<ResultController> _logger;

    public ResultController(ILogger<ResultController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "result")]
    public IEnumerable<SortResponse> Get()
    {

        string file = System.IO.File.ReadAllText("result.txt");
        var response = JsonSerializer.Deserialize<SortResponse>(file);
        yield return response;
    }

}


