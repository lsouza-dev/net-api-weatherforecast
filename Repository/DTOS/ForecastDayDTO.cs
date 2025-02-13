using System.Globalization;
using Repository.Models;
using WeatherForecast.Models;

public record ForecastDayDTO(
    DateOnly Data,
    string Horario,
    double TempC,
    double TempF,
    string CondicaoCeu,
    string Icon,
    double PrevisaoMm,
    double NeveCm,
    int Umidade,
    int Nebulosidade,
    double SensacaoTermicaC,
    double SensacaoTermicaF,
    int VaiChover,
    int ChanceChuva,
    int VaiNevar,
    int ChanceNeve
)
{
    public ForecastDayDTO(WeatherForecast.Models.Forecastday forecastDay) : this(
        DateOnly.ParseExact(forecastDay.date, "yyyy/MM/dd", CultureInfo.InvariantCulture),// date
        forecastDay.hour.FirstOrDefault()?.time ?? string.Empty, // hour
        forecastDay.hour.FirstOrDefault().temp_c, // TempC (utilizando a média de temperatura no 'day')
        forecastDay.hour.FirstOrDefault().temp_f, // TempF
        forecastDay.day.condition?.text ?? string.Empty, // CondicaoCeu (usando o texto do condition)
        forecastDay.day.condition?.icon ?? string.Empty, // Icon
        forecastDay.day.totalprecip_mm, // PrevisaoMm
        forecastDay.day.totalsnow_cm, // NeveCm
        forecastDay.day.avghumidity, // Umidade
        forecastDay.hour.FirstOrDefault()?.humidity ?? 0, // Nebulosidade (ajustado, pois o atributo original pode ser diferente)
        forecastDay.hour.FirstOrDefault()?.feelslike_c ?? 0,  // SensacaoTermicaC
        forecastDay.hour.FirstOrDefault()?.feelslike_f ?? 0,  // SensacaoTermicaF
        forecastDay.day.daily_will_it_rain, // VaiChover
        forecastDay.day.daily_chance_of_rain, // ChanceChuva
        forecastDay.day.daily_will_it_snow, // VaiNevar
        forecastDay.day.daily_chance_of_snow // ChanceNeve
    )
    { }
}
