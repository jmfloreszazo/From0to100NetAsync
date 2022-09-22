using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

namespace ApiWithAsyncSyncBenchmark.Controllers;

[ApiController]
[Route("[controller]")]
public class BitcoinController : ControllerBase
{
    
    private readonly ILogger<BitcoinController> _logger;
    private readonly IHttpClientFactory _httpClientFactory;

    public BitcoinController(ILogger<BitcoinController> logger, IHttpClientFactory httpClientFactory)
    {
        _logger = logger;
        _httpClientFactory = httpClientFactory;
    }

    [HttpGet("GetCurrentPriceSync")]
    public ActionResult<string> GetSync()
    {
        var client = _httpClientFactory.CreateClient();
        var response = client.GetStringAsync($"https://api.coindesk.com/v1/bpi/currentprice.json").Result; // Very Bad!
        dynamic obj = Newtonsoft.Json.JsonConvert.DeserializeObject(response) ?? throw new InvalidOperationException();
        var currentPrice = obj.bpi.EUR.rate.Value;
        return currentPrice?.ToString();
    }

    [HttpGet("GetCurrentPriceAsync")]
    public async Task<ActionResult<string>> GetAsync()
    {
        var client = _httpClientFactory.CreateClient();
        var response =await client.GetAsync($"https://api.coindesk.com/v1/bpi/currentprice.json");
        if (!response.IsSuccessStatusCode) return NoContent();
        var contentStream = await response.Content.ReadAsStringAsync();
        dynamic obj = Newtonsoft.Json.JsonConvert.DeserializeObject(contentStream) ?? throw new InvalidOperationException();
        var currentPrice = obj.bpi.EUR.rate.Value;
        return currentPrice?.ToString();
    }
}