using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace bing_covid.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly HttpClient _client = new HttpClient();

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<Covid[]> Get()
        { 
            var resultContent = await _client.GetAsync("https://api.coronatracker.com/v3/stats/worldometer/topCountry");
            var covidResult = JsonConvert.DeserializeObject<Covid[]>(await resultContent.Content.ReadAsStringAsync());
            return covidResult;
        }
    }

    public class Covid
    {
        [JsonProperty("countryCode")]
        public string CountryCode { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("lat")]
        public double? Lat { get; set; }

        [JsonProperty("lng")]
        public double? Lng { get; set; }

        [JsonProperty("totalConfirmed")]
        public long TotalConfirmed { get; set; }

        [JsonProperty("totalDeaths")]
        public long TotalDeaths { get; set; }

        [JsonProperty("totalRecovered")]
        public long TotalRecovered { get; set; }

        [JsonProperty("dailyConfirmed")]
        public long DailyConfirmed { get; set; }

        [JsonProperty("dailyDeaths")]
        public long DailyDeaths { get; set; }

        [JsonProperty("activeCases")]
        public long ActiveCases { get; set; }

        [JsonProperty("totalCritical")]
        public long TotalCritical { get; set; }

        [JsonProperty("totalConfirmedPerMillionPopulation")]
        public long TotalConfirmedPerMillionPopulation { get; set; }

        [JsonProperty("totalDeathsPerMillionPopulation")]
        public long? TotalDeathsPerMillionPopulation { get; set; }

        [JsonProperty("FR")]
        public string Fr { get; set; }

        [JsonProperty("PR")]
        public string Pr { get; set; }

        [JsonProperty("lastUpdated")]
        public DateTimeOffset LastUpdated { get; set; }
    }

}