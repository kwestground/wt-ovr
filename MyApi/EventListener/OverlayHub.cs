using Microsoft.AspNetCore.SignalR;

public class OverlayHub : Hub
{
    public async Task SendMessage(string user, string message)
    {
        await Clients.All.SendAsync("ReceiveMessage", user, message);
    }
    
    public Task JoinGroup(string groupName)
    {
        return Groups.AddToGroupAsync(Context.ConnectionId, groupName);
    }
}