using Microsoft.AspNetCore.Mvc;
using Relay.DBUtility;
using Relay.DBUtility.Models;
using Relay.DBUtility;
using Relay.DBUtility.Models;

namespace Relay.Server.Models;

internal class Chat
{
    public required int Id { get; set; }

    public required string Name { get; set; }

    public IEnumerable<Message>? Messages { get; set; }

    public IEnumerable<User>? Users { get; set; }
}