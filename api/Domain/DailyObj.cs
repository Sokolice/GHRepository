using API;
using Newtonsoft.Json;

namespace API.Model
{
    public class DailyObj
    {
        [JsonProperty("temp")]
        public Temp Temp { get; set; }

        [JsonProperty("weather")]
        public List<Weather> Weather { get; set; }

        [JsonProperty("pop")]
        public double Pop {  get; set; }
    }

    public class Temp
    {
        [JsonProperty("min")]
        public double Min { get;set;}
        [JsonProperty("max")]
        public double Max { get;set;}   

    }

    public class Weather
    {
        [JsonProperty("id")]
        public string Id { get; set; }
    }
}
