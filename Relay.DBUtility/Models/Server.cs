using Microsoft.EntityFrameworkCore;

namespace Relay.DBUtility.Models;

public class Server : DbContext
{
    public required int Id { get; set; }
    public required string Name { get; set; }
    public required string Address { get; set; }
    public int Port { get; set; }
    public string? Password { get; set; }
}