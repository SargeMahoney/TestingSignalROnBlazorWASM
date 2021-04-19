using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestingState.Application.Contracts;
using TestingState.Server.Hub;
using TestingState.Shared;

namespace TestingState.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
     
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IWeatherRepository weatherRepository;
        private readonly IHubContext<WeatherHub, IWeatherHub> _weatherHub;
        private readonly IHubContext<NotificationHub, INotificationHub> _notificationHub;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherRepository weatherRepository, 
                                        IHubContext<WeatherHub, IWeatherHub> WeatherHub,
                                        IHubContext<NotificationHub,INotificationHub> notificationHub)
        {
            _logger = logger;
            this.weatherRepository = weatherRepository;
            this._weatherHub = WeatherHub;
            this._notificationHub = notificationHub;
        }

        [HttpGet]
        public async Task<IEnumerable<WeatherForecast>> Get()
        {
           return await weatherRepository.GetWeathers();
        }

        [HttpPost("Add")]
        public async Task<WeatherForecast> Add([FromBody] WeatherForecast weather )
        {
            var newWeatherForecast = await weatherRepository.AddWeather(weather);
            await _weatherHub.Clients.All.RefreshWeathers();
            await _notificationHub.Clients.All.ShowInfoNotification($"{newWeatherForecast.Date} - {newWeatherForecast.Summary}", "New Weather");
            return newWeatherForecast;
        }
    }
}
