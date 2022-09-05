using Microsoft.AspNetCore.SignalR;

namespace SignalRTest.Hubs
{
    public class SignalRHub:Hub
    {
        public async Task SendMessage(string username, string message)
        {
            await Clients.All.SendAsync("ReciveMessage",username,message);
        }
    }
}
