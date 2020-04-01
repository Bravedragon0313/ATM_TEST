using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace ATM.Server.Hubs
{
    public class FileWatcherHub : Hub
    {
        public Task NotifyConnection()
        {
            return Clients.All.SendAsync("TestBrodcasting", $"Testing a Basic HUB at {DateTime.Now.ToLocalTime()}");
        }
        public async Task SendMessage(string message)
        {
            await Clients.All.SendAsync("newMessage", Context.User.Identity.Name, message);
        }
    }
}
