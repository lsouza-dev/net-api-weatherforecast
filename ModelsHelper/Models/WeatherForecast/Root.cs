namespace ModelsHelper.Models.WeatherForecast
{
    public class Root
    {
        public Location location { get; set; }
        public Current current { get; set; }
        public Forecast forecast { get; set; }

        public Root() { }

        public override string ToString()
        {
            string locationString = location != null ? location.ToString() : "No location data available";
            string currentString = current != null ? current.ToString() : "No current weather data available";
            string forecastString = forecast != null ? forecast.ToString() : "No forecast data available";

            return $"Weather Data:\nLocation:\n{locationString}\n\nCurrent Weather:\n{currentString}\n\nForecast:\n{forecastString}";
        }

    }
}
