using System.Net.WebSockets;
using Microsoft.AspNetCore.SignalR;
using Relay.DBUtility;
using Relay.DBUtility;
using Relay.DBUtility.Models;
using Relay.Server.Models;
using Serilog;

namespace Relay.Server.Services;

public class WebSocketUtilities() : Hub
{
    //private DbServer db = dbServer;

    [HubMethodName("SendMessage")]
    [EndpointName("WebSocketUtilities")]
    public async Task SendMessage(string user, string message)
    {
        await Clients.All.SendAsync("ReceiveMessage", user, message);
    }

    public async Task SendMessageToCaller(string user, string message)
        => await Clients.Caller.SendAsync("ReceiveMessage", user, message);

    public async Task SendMessageToGroup(string user, string message, string groupName)
        => await Clients.Group(groupName).SendAsync("ReceiveMessage", user, message);
    /*
    public override async Task OnConnectedAsync()
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, "SignalR Users");
        var users = new UserUtilities(db);
        var isNewUser = users.IsUserExists(Context?.User?.Identity?.Name?? string.Empty).Result;
        if (isNewUser)
        {
            var id = users.GetNewUserId().Id;
            if (Context?.User?.Identity?.Name is null)
            {
                Log.Error("User is null");
                return;
            }
            var name = Context.User.Identity.Name;
            await users.Connect(id, name);
        }
        Log.Information(Context.User.Identity.Name + " connected");
        await base.OnConnectedAsync();
    }*/
}