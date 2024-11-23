using Abp.Dependency;
using Abp.Runtime.Session;
using Castle.LoggingFacility.MsLogging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using ILogger = Castle.Core.Logging.ILogger;

namespace ServerWeb;

[Route("/ws")]
public class AdminChat : Hub, ITransientDependency
{
    [SwaggerIgnore] private IAbpSession AbpSession { get; set; }
    [SwaggerIgnore] private ILogger Logger { get; set; }

    public override async Task OnConnectedAsync()
    {
        Logger.Log(LogLevel.Critical, "A client connected to AdminChat: " + Context.ConnectionId);
        await base.OnConnectedAsync();
    }
    //адресс:порт/chats/{version}/{serverId}/{chatId}/{method}/{userId}/{content?}
    public async Task SendMessage(string user, string message) =>
        await Clients.All.SendAsync("ReceiveMessage", user, $"{message}");

    public async Task SendMessageToCaller(string user, string message) =>
        await Clients.Caller.SendAsync("ReceiveMessage", $"System: {message}");

    public async Task SendMessageToGroup(string user, string message, string groupName) =>
        await Clients.Group(groupName).SendAsync("ReceiveMessage", $"User {AbpSession.UserId}: {message}");
}