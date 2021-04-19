using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingState.Application.Contracts;
using TestingState.Shared;

namespace Testing.Persistance.Internal
{
    public class WeatherForecastRepository : IWeatherRepository
    {
        private static readonly string[] Summaries = new[]
      {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private List<WeatherForecast> _weathers { get; set; }
        public WeatherForecastRepository()
        {
            var rng = new Random();
            _weathers = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToList();
        }
        public async Task<WeatherForecast> AddWeather(WeatherForecast weather)
        {
            var rng = new Random();

            var x = new WeatherForecast
            {
                Date = DateTime.Now.AddDays(rng.Next(1, 5)),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            };
            _weathers.Add(x);

            return x;
        }

        public async Task<IEnumerable<WeatherForecast>> GetWeathers()
        {
            return _weathers;
        }

        public async Task<WeatherForecast> RemoveWeather(WeatherForecast weather)
        {
            _weathers.Remove(weather);
            return weather;
        }
    }
}
