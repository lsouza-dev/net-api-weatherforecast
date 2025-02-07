using System.Threading.Tasks;
using Xunit;
using System.Net.Http;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using Teste.Services;

public class WeatherServiceTests
{
    [Fact]
    public async Task GetWeatherData_ReturnsData()
    {
        var httpClient = new HttpClient();
        var config = new ConfigurationBuilder()
        .AddInMemoryCollection(new Dictionary<string, string>
        {
            {"WeatherApi:BaseUrl", "https://mockapi.com"},
            {"WeatherApi:ApiKey", "mock_api_key"}
        })
        .Build();
        var service = new WeatherService(httpClient, config);
        var result = await service.GetWeatherData("São Paulo");
        Assert.NotNull(result);
    }

    [Fact]
    public async Task GetWeatherData_InvalidCity_ReturnsNull()
    {
        var httpClient = new HttpClient();
        var config = new ConfigurationBuilder()
        .AddInMemoryCollection(new Dictionary<string, string>
        {
            {"WeatherApi:BaseUrl", "https://mockapi.com"},
            {"WeatherApi:ApiKey", "mock_api_key"}
        })
        .Build();
        var service = new WeatherService(httpClient, config);
        var result = await service.GetWeatherData("InvalidCity");
        Assert.Null(result);
    }

    [Fact]
    public async Task GetWeatherData_EmptyCity_ThrowsArgumentException()
    {
        var httpClient = new HttpClient();
        var config = new ConfigurationBuilder()
        .AddInMemoryCollection(new Dictionary<string, string>
        {
            {"WeatherApi:BaseUrl", "https://mockapi.com"},
            {"WeatherApi:ApiKey", "mock_api_key"}
        })
        .Build();
        var service = new WeatherService(httpClient, config);
        await Assert.ThrowsAsync<ArgumentException>(() => service.GetWeatherData(string.Empty));
    }
}
