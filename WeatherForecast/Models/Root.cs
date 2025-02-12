namespace WeatherForecast.Models
{
    public class Root
    {
        public Location location { get; set; }
        public Current current { get; set; }
        public Forecast forecast { get; set; }

        public Root() { }

        public Root(Root? weatherResponse)
        {
            this.location = weatherResponse.location;
            this.current = weatherResponse.current;
            this.forecast = weatherResponse.forecast;
        }

    }
}
