using Abp.Dependency;
using Abp.Runtime.Session;
using Castle.LoggingFacility.MsLogging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalRSwaggerGen.Attributes;
using Swashbuckle.AspNetCore.Annotations;
using ILogger = Castle.Core.Logging.ILogger;

namespace ServerWeb;

[SignalRHub]
[Route("/ws")]
public class HostAdminChat : Hub, ITransientDependency
{
    [SwaggerIgnore] private IAbpSession AbpSession { get; set; }
    [SwaggerIgnore] private ILogger Logger { get; set; }

    [SignalRHidden]
    public override async Task OnConnectedAsync()
    {
        Logger.Log(LogLevel.Critical, "A client connected to AdminChat: " + Context.ConnectionId);
        await base.OnConnectedAsync();
    }

    [SignalRMethod]
    public async Task SendMessage(string user, string message) =>
        await Clients.All.SendAsync("ReceiveMessage", user, $"{message}");

    [SignalRMethod]
    public async Task SendMessageToCaller(string user, string message) =>
        await Clients.Caller.SendAsync("ReceiveMessage", $"System: {message}");

    [SignalRMethod]
    public async Task SendMessageToGroup(string user, string message, string groupName) =>
        await Clients.Group(groupName).SendAsync("ReceiveMessage", $"User {AbpSession.UserId}: {message}");
}