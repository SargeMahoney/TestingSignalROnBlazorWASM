using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestingState.Server.Hub
{
    public class WeatherHub : Hub<IWeatherHub>
    {
        public async Task RefreshWeathers()
        {
            await Clients.All.RefreshWeathers();
        }
    }
}
