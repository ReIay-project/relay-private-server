using Relay.DBUtility;

namespace Relay.Server.Models;

internal class User(int id, string userName)
{
    public required int Id { get; set; } = id;

    public required string Name { get; set; } = userName;
}