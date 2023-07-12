
using Microsoft.AspNetCore.SignalR;

namespace Notification_Using_signalR
{
    public class ChatHub : Hub                                             
    {
        public Task SendMessage1(string user, string message,DateTime date)              
        {
            return Clients.All.SendAsync("ReceiveOne", user, message,date = DateTime.Now);   
            
        }
    }
}

