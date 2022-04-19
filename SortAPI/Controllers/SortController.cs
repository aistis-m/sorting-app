using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

namespace SortAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class SortController : ControllerBase
{

    private readonly ILogger<SortController> _logger;

    public SortController(ILogger<SortController> logger)
    {
        _logger = logger;
    }

    [HttpPost(Name = "sort")]
    public async IAsyncEnumerable<SortResponse> SaveNewValue([FromBody] string value)
    {
        int[] intArray;

        try
        {
            intArray = value.Split(new[] { ' ' },
                       StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        }
        catch
        {
            yield break;
        }

        Sorter sorter = new Sorter(intArray);

        // Run multiple sorts on separate threads
        Task<SortResult> bubble = sorter.RunAlgorithm(new BubbleSort());
        Task<SortResult> insertion = sorter.RunAlgorithm(new InsertionSort());

        var results = await Task.WhenAll(bubble, insertion);

        // await is NOT used intentionally - sends back the response while file I/O opperation 
        // is being performed
        var response = new SortResponse(value, results);

        System.IO.File.WriteAllTextAsync("result.txt", JsonSerializer.Serialize(response));

        
        yield return response;

    }

}

