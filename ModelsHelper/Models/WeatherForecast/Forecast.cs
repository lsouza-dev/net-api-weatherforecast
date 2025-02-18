namespace ModelsHelper.Models.WeatherForecast
{
    public class Forecast
    {
        public List<Forecastday> forecastday { get; set; }

        public override string ToString()
        {
            if (forecastday == null || forecastday.Count == 0)
                return "No forecast data available";

            return string.Join("\n", forecastday.Select(f => f.ToString()));
        }
    }
}
