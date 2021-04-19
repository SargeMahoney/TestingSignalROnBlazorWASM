using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestingState.Server.Hub
{
    public class NotificationHub : Hub<INotificationHub>
    {
        public async Task ShowInfoNotification(string message, string title = "Information")
        {
            await Clients.All.ShowInfoNotification(message,title);
        }
    }
}
