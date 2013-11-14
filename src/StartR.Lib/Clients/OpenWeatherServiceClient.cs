using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.ServiceClient.Web;

namespace StartR.Lib.Clients
{
    public class OpenWeatherServiceClient
    {

        private string _url;
        private const string BaseUrl = "http://api.openweathermap.org/data/2.5/weather?q={0},{1}";
        
        private readonly string _city;
        private readonly string _state;

        public async Task<WeatherResult> GetWeather()
        {
            HttpClient client = new HttpClient();
            var response = await client.GetAsync(_url);
            var x = response.Content;
            return new WeatherResult() { CurrentCondition = "Partly with chance of meatballs", Temp = 85 };
        }

        public OpenWeatherServiceClient(string city, string state)
        {
            _state = state;
            _city = city;
            _url = String.Format(BaseUrl, _city, _state);
        }

        public class Coord
        {
            public double lon { get; set; }
            public double lat { get; set; }
        }

        public class Sys
        {
            public string country { get; set; }
            public int sunrise { get; set; }
            public int sunset { get; set; }
        }

        public class Weather
        {
            public int id { get; set; }
            public string main { get; set; }
            public string description { get; set; }
            public string icon { get; set; }
        }

        public class Main
        {
            public double temp { get; set; }
            public int pressure { get; set; }
            public int humidity { get; set; }
            public double temp_min { get; set; }
            public double temp_max { get; set; }
        }

        public class Wind
        {
            public double speed { get; set; }
            public int deg { get; set; }
            public double gust { get; set; }
        }

        public class Rain
        {
            public int __invalid_name__3h { get; set; }
        }

        public class Clouds
        {
            public int all { get; set; }
        }

        public class RootObject
        {
            public Coord coord { get; set; }
            public Sys sys { get; set; }
            public List<Weather> weather { get; set; }
            public string @base { get; set; }
            public Main main { get; set; }
            public Wind wind { get; set; }
            public Rain rain { get; set; }
            public Clouds clouds { get; set; }
            public int dt { get; set; }
            public int id { get; set; }
            public string name { get; set; }
            public int cod { get; set; }
        }
    }
}
