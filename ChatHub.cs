using Microsoft.AspNetCore.SignalR;

namespace SignalRDemo
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            //await Clients.All.SendAsync("ReceiveMessage", $"connection id: {Context.GetHttpContext().Session.ConnectionId}");

            var connectionId = Context.ConnectionId;
            var httpContext = Context.GetHttpContext();
        }
    }
}
