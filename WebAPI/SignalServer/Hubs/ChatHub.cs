using Microsoft.AspNetCore.SignalR;

namespace SignalServer.Hubs
{
    public class ChatHub: Hub
    {
        public async Task SendMessageToAll(string user,string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
      
    }
  
}
