using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.SignalR;

namespace SignalRDemo
{
    public class ConnectionHub : Hub
    {
        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            var connectionId = Context.ConnectionId;
            var httpContext = Context.GetHttpContext();
            var userSessionId = httpContext.Session.GetString("userSessionId");
        }
    }
}
