using System.Globalization;
using ModelsHelper.Models.WeatherForecast;

public record WeatherForecastDTO(
    string Cidade,
    string Estado,
    string Pais,
    DateTime DataLocal,
    DateTime UltimaAtualizacao,
    double TempC,
    double TempF,
    double SensacaoTermicaC,
    double SensacaoTermicaF,
    int Umidade,
    TimeOnly NascerDoSol,
    TimeOnly PorDoSol,
    TimeOnly NascerDaLua,
    TimeOnly PorDaLua,
    string FaseDaLua,
    int EstaDeDia,
    int EstaDeNoite,
    string CondicaoCeu,
    string Icon,
    List<ForecastDayDTO> Forecasts
)
{
    public WeatherForecastDTO(Root root) : this(
        root.location.name,
        root.location.region,
        root.location.country,
        DateTime.ParseExact(root.location.localtime, "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
        DateTime.ParseExact(root.current.last_updated, "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
        root.current.temp_c,
        root.current.temp_f,
        root.current.feelslike_c,
        root.current.feelslike_f,
        root.current.humidity,
        TimeOnly.ParseExact(root.forecast.forecastday.First().astro.sunrise, "hh:mm tt", CultureInfo.InvariantCulture),
        TimeOnly.ParseExact(root.forecast.forecastday.First().astro.sunset, "hh:mm tt", CultureInfo.InvariantCulture),
        TimeOnly.ParseExact(root.forecast.forecastday.First().astro.moonrise, "hh:mm tt", CultureInfo.InvariantCulture),
        TimeOnly.ParseExact(root.forecast.forecastday.First().astro.moonset, "hh:mm tt", CultureInfo.InvariantCulture),
        root.forecast.forecastday.First().astro.moon_phase,
        root.forecast.forecastday
            .FirstOrDefault(f => f.hour
                .Any(fh => DateTime.ParseExact(fh.time, "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture).Hour == DateTime.Now.Hour))
            ?.astro.is_sun_up ?? 0,
        root.forecast.forecastday
            .FirstOrDefault(f => f.hour
                .Any(fh => DateTime.ParseExact(fh.time, "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture).Hour == DateTime.Now.Hour))
            ?.astro.is_moon_up ?? 0,
        root.current.condition.text,
        root.forecast.forecastday
            .FirstOrDefault(f => f.hour
                .Any(fh => DateTime.ParseExact(fh.time, "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture).Hour == DateTime.Now.Hour))
            ?.day.condition.icon ?? "",
        root.forecast.forecastday.SelectMany(fd => fd.hour.Select(h => new ForecastDayDTO(fd.date, h, fd.day))).ToList()
    )
    { }
}