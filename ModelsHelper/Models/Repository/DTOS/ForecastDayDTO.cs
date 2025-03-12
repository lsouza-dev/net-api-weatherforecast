using System.Globalization;
using ModelsHelper.Models;
using ModelsHelper.Models.WeatherForecast;
public class ForecastDayDTO
{
    public string Date { get; set; }
    public Hour Hour { get; set; }
    public Day Day { get; set; }

    public ForecastDayDTO(string date, Hour hour, Day day)
    {
        Date = date;
        Hour = hour;
        Day = day;
    }
}


