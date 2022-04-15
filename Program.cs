using System.Text.Json;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";
var url = $"http://0.0.0.0:{port}";
var target = Environment.GetEnvironmentVariable("TARGET") ?? "World";

var app = builder.Build();
var datafile = "result.txt";

app.MapPost("/sort", async (HttpContext context) =>
{

    StreamReader reader = new StreamReader(context.Request.Body, Encoding.UTF8);
    string numbers = await reader.ReadToEndAsync();


    try
    {
        int[] intArray = numbers.Split(new[] {' '},
                        StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

        Sorter sorter = new Sorter(intArray);

        // Run multiple sorts on separate threads
        Task<SortResult> bubble = sorter.RunAlgorithm(new BubbleSort());
        Task<SortResult> insertion = sorter.RunAlgorithm(new InsertionSort());

        var results = await Task.WhenAll(bubble, insertion);

        var response = new Response(numbers, results);

        // await is NOT used intentionally - sends back the response while file I/O opperation 
        // is being performed
        File.WriteAllTextAsync(datafile, results.First().sorted);

        return JsonSerializer.Serialize(response, new JsonSerializerOptions
        {
            WriteIndented = true
        });

    }
    catch
    {
        return "Invalid or empty request body";
    }

});

app.MapGet("/result", async () =>
{
    return await File.ReadAllTextAsync(datafile);
});


app.Run(url);