using System.Globalization;
using ModelsHelper.Models;
using ModelsHelper.Models.WeatherForecast;
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
    public ForecastDayDTO(string date, dynamic hour, dynamic day) : this(
       DateOnly.ParseExact(date, "yyyy-MM-dd", CultureInfo.InvariantCulture), // Data
       DateTime.Parse((string)hour.time).ToShortTimeString(), // Horario
       (double)hour.temp_c, // TempC
       (double)hour.temp_f, // TempF
       (string)hour.condition.text, // CondicaoCeu
       (string)hour.condition.icon, // Icon
       (double)day.totalprecip_mm, // PrevisaoMm
       (double)day.totalsnow_cm, // NeveCm
       (int)hour.humidity, // Umidade
       (int)hour.cloud, // Nebulosidade
       (double)hour.feelslike_c, // SensacaoTermicaC
       (double)hour.feelslike_f, // SensacaoTermicaF
       (int)day.daily_will_it_rain, // VaiChover
       (int)day.daily_chance_of_rain, // ChanceChuva
       (int)day.daily_will_it_snow, // VaiNevar
       (int)day.daily_chance_of_snow // ChanceNeve
    )
    { }
}
