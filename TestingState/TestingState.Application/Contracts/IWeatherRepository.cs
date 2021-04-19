using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingState.Shared;

namespace TestingState.Application.Contracts
{
    public interface IWeatherRepository
    {

        Task<WeatherForecast> AddWeather(WeatherForecast weather);
        Task<WeatherForecast> RemoveWeather(WeatherForecast weather);
        Task<IEnumerable<WeatherForecast>> GetWeathers();

    }
}
