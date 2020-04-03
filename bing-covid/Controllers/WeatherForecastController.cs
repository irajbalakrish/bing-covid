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
            var countryCodes =
                JsonConvert.DeserializeObject<CountryCodes[]>(
                    await System.IO.File.ReadAllTextAsync(@"country-code.json"));
            var resultContent = await _client.GetAsync("https://api.coronastatistics.live/countries?sort=cases");
            var covidResult = JsonConvert.DeserializeObject<Covid[]>(await resultContent.Content.ReadAsStringAsync());
            foreach (var item in covidResult)
                item.CountryCode =
                    countryCodes.FirstOrDefault(x => x.Name
                            .Equals(item.Country, StringComparison.OrdinalIgnoreCase))
                        ?.Code;
            return covidResult;
        }
    }

    public class Covid
    {
        [JsonProperty("country")] public string Country { get; set; }

        [JsonProperty("cases")] public long Cases { get; set; }

        [JsonProperty("todayCases")] public long TodayCases { get; set; }

        [JsonProperty("deaths")] public long Deaths { get; set; }

        [JsonProperty("todayDeaths")] public long TodayDeaths { get; set; }

        [JsonProperty("recovered")] public long Recovered { get; set; }

        [JsonProperty("active")] public long Active { get; set; }

        [JsonProperty("critical")] public long Critical { get; set; }

        [JsonProperty("casesPerOneMillion")] public double CasesPerOneMillion { get; set; }

        [JsonProperty("deathsPerOneMillion")] public double DeathsPerOneMillion { get; set; }

        [JsonProperty("countryCode")] public string CountryCode { get; set; } = "Unknown";
    }

    public class CountryCodes
    {
        [JsonProperty("name")] public string Name { get; set; }

        [JsonProperty("code")] public string Code { get; set; }
    }
}