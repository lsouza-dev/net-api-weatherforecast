namespace ModelsHelper.Models.WeatherForecast
{
    public class Condition
    {
        public string text { get; set; }
        public string icon { get; set; }
        public int code { get; set; }


        public override string ToString()
        {
            return $"Condition: {text}, Icon: {icon}, Code: {code}";
        }

    }
}
