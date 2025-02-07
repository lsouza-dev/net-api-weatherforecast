using System.Threading.Tasks;
using Xunit;
using System.Net.Http;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
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
}
