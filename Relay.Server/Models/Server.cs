namespace Relay.Server.Models;

internal class Server
{
    public required int Id { get; set; }
    public required string Name { get; set; }
    public required string Address { get; set; }
    public int Port { get; set; }
    public string? Password { get; set; }
}