using Microsoft.AspNetCore.Mvc;

namespace Mahta.Utilities.ScalarRegistration.Sample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private static List<WeatherForecast> _forecasts = new List<WeatherForecast>();

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        // GET: /weatherforecast
        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return _forecasts.Any()
                ? _forecasts
                : Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                }).ToArray();
        }

        // GET: /weatherforecast/{id}
        [HttpGet("{id}", Name = "GetWeatherById")]
        public ActionResult<WeatherForecast> GetById(int id)
        {
            var forecast = _forecasts.FirstOrDefault(f => f.Date.DayOfYear == id);
            if (forecast == null)
                return NotFound();

            return Ok(forecast);
        }

        // POST: /weatherforecast
        [HttpPost(Name = "CreateWeatherForecast")]
        public ActionResult<WeatherForecast> Post([FromBody] WeatherForecast forecast)
        {
            // Simple validation: Check if the forecast already exists
            if (_forecasts.Any(f => f.Date == forecast.Date))
                return Conflict("Weather forecast for this date already exists.");

            _forecasts.Add(forecast);
            return CreatedAtRoute("GetWeatherById", new { id = forecast.Date.DayOfYear }, forecast);
        }

        // PUT: /weatherforecast/{id}
        [HttpPut("{id}", Name = "UpdateWeatherForecast")]
        public ActionResult Put(int id, [FromBody] WeatherForecast updatedForecast)
        {
            var forecast = _forecasts.FirstOrDefault(f => f.Date.DayOfYear == id);
            if (forecast == null)
                return NotFound();

            forecast.TemperatureC = updatedForecast.TemperatureC;
            forecast.Summary = updatedForecast.Summary;

            return NoContent(); // 204 No Content response after update
        }

        // DELETE: /weatherforecast/{id}
        [HttpDelete("{id}", Name = "DeleteWeatherForecast")]
        public ActionResult Delete(int id)
        {
            var forecast = _forecasts.FirstOrDefault(f => f.Date.DayOfYear == id);
            if (forecast == null)
                return NotFound();

            _forecasts.Remove(forecast);
            return NoContent(); // 204 No Content response after deletion
        }
    }
}
