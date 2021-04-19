using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestingState.Server.Hub
{
    public interface INotificationHub
    {
        Task ShowInfoNotification(string message, string title = "Information");
    }
}
