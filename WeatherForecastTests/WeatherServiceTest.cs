using System;
using System.Collections.Generic;
using System.Text.Json;
using Xunit;
using Xunit.Abstractions;
using ModelsHelper.Models.Repository;
using ModelsHelper.Models.Repository.DTOS.Exibicao;
using ModelsHelper.Models.WeatherForecast;
using System.Dynamic;
using NuGet.Frameworks;
using System.Globalization;

public class WeatherServiceTests
{

    private readonly ITestOutputHelper _output;

    public WeatherServiceTests(ITestOutputHelper output)
    {
        _output = output;
    }

    [Fact]
    public void Deve_Criar_WeatherForecast_Com_Dados_Corretos_E_Converter_Para_DTO()
    {

        var hour1 = new Hour
        {
            time = "2025-03-10 14:00",
            temp_c = 9,
            temp_f = 85.1,
            condition = new Condition { text = "Parcialmente nublado" },
            wind_mph = 10.5,
            wind_kph = 16.9,
            wind_degree = 200,
            wind_dir = "S",
            precip_mm = 0.0,
            precip_in = 0.0,
            snow_cm = 0.0,
            humidity = 55,
            cloud = 40,
            feelslike_c = 31.0,
            feelslike_f = 87.8,
            windchill_c = 29.5,
            windchill_f = 85.1,
            heatindex_c = 30.0,
            heatindex_f = 86.0,
            will_it_rain = 0,
            chance_of_rain = 10,
            will_it_snow = 0,
            chance_of_snow = 0,
            uv = 7.5
        };

        var hour2 = new Hour
        {
            time = "2025-03-11 14:00",
            temp_c = 22.0,
            temp_f = 71.6,
            condition = new Condition { text = "Chuvoso" },
            wind_mph = 8.2,
            wind_kph = 13.2,
            wind_degree = 180,
            wind_dir = "SE",
            precip_mm = 12.5,
            precip_in = 0.49,
            snow_cm = 0.0,
            humidity = 80,
            cloud = 90,
            feelslike_c = 21.5,
            feelslike_f = 70.7,
            windchill_c = 22.0,
            windchill_f = 71.6,
            heatindex_c = 22.0,
            heatindex_f = 71.6,
            will_it_rain = 1,
            chance_of_rain = 90,
            will_it_snow = 0,
            chance_of_snow = 0,
            uv = 3.2
        };

        var day1 = new Day
        {
            maxtemp_c = 30.0,
            maxtemp_f = 86.0,
            mintemp_c = 18.0,
            mintemp_f = 64.4,
            avgtemp_c = 24.5,
            avgtemp_f = 76.1,
            maxwind_mph = 12.0,
            maxwind_kph = 19.3,
            totalprecip_mm = 2.5,
            totalprecip_in = 0.1,
            totalsnow_cm = 0.0,
            avgvis_km = 10.0,
            avgvis_miles = 6.2,
            avghumidity = 60,
            daily_will_it_rain = 1,
            daily_chance_of_rain = 50,
            daily_will_it_snow = 0,
            daily_chance_of_snow = 0,
            condition = new Condition { text = "Parcialmente nublado" },
            uv = 8.0
        };

        var day2 = new Day
        {
            maxtemp_c = 9.0,
            maxtemp_f = 77.0,
            mintemp_c = 17.0,
            mintemp_f = 62.6,
            avgtemp_c = 21.0,
            avgtemp_f = 69.8,
            maxwind_mph = 9.5,
            maxwind_kph = 15.3,
            totalprecip_mm = 15.0,
            totalprecip_in = 0.59,
            totalsnow_cm = 0.0,
            avgvis_km = 8.0,
            avgvis_miles = 5.0,
            avghumidity = 75,
            daily_will_it_rain = 1,
            daily_chance_of_rain = 80,
            daily_will_it_snow = 0,
            daily_chance_of_snow = 0,
            condition = new Condition { text = "Chuvoso" },
            uv = 5.0
        };


        var forecastDayDTOs = new List<ForecastDayDTO>
        {
            new ForecastDayDTO("2025-03-10", hour1, day1),
            new ForecastDayDTO("2025-03-11", hour2, day2)

        };

        var weatherForecastDTO = new WeatherForecastDTO(
            "São Paulo",
            "SP",
            "Brasil",
            new DateTime(2025, 3, 10, 14, 0, 0),
            new DateTime(2025, 3, 10, 13, 50, 0),
            28.5, 83.3, 30.2, 86.4,
            60,
            new TimeOnly(6, 15),
            new TimeOnly(18, 30),
            new TimeOnly(20, 45),
            new TimeOnly(6, 0),
            "Crescente",
            1, 0,
            "Ensolarado",
            "sunny.png",
            forecastDayDTOs
        );

        // Act - Criando a Model a partir do DTO de Criação
        var weatherForecast = new WeatherForecast(weatherForecastDTO);

        var mensagensTemperatura = new List<String>();

        foreach (var f in weatherForecast.Forecasts)
        {
            if (f.TempC > 30 || f.TempC < 10) mensagensTemperatura.Add("Alerta");
            _output.WriteLine($"Temperatura do dia {f.Data} :  {f.TempC}");
        }

        // Assert Entidade
        Assert.NotNull(weatherForecast);
        Assert.Equal("São Paulo", weatherForecast.Cidade);
        Assert.Equal("SP", weatherForecast.Estado);
        Assert.Equal("Brasil", weatherForecast.Pais);
        Assert.Equal(28.5, weatherForecast.TempC);
        Assert.NotNull(weatherForecast.Forecasts);
        Assert.Equal(2, weatherForecast.Forecasts.Count);

        // Act - Conversão para DTO de Exibição
        var dtoExibicao = new WeatherForecastExibicaoDTO(weatherForecast);

        // Assert DTO de Exibição
        Assert.NotNull(dtoExibicao);
        Assert.Equal("São Paulo", dtoExibicao.Cidade);
        Assert.Equal("SP", dtoExibicao.Estado);
        Assert.Equal("Brasil", dtoExibicao.Pais);
        Assert.Equal(28.5, dtoExibicao.TempC);
        Assert.NotNull(dtoExibicao.Forecasts);
        Assert.Equal(2, dtoExibicao.Forecasts.Count);
        Assert.Equal("Parcialmente nublado", dtoExibicao.Forecasts[0].CondicaoCeu);
        Assert.Equal("Chuvoso", dtoExibicao.Forecasts[1].CondicaoCeu);
        Assert.Equal(1, mensagensTemperatura.Count);

       
    }
}
