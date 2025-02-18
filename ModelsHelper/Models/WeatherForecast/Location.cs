namespace ModelsHelper.Models.WeatherForecast
{
    public class Location
    {
        public string name { get; set; }
        public string region { get; set; }
        public string country { get; set; }
        public string tz_id { get; set; }
        public string localtime { get; set; }

        public override string ToString()
        {
            return $"Name: {name}, Region: {region}, Country: {country}, Timezone: {tz_id}, Localtime: {localtime}";
        }
    }
}
