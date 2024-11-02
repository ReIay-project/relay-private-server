using Microsoft.EntityFrameworkCore;

namespace Relay.DBUtility.Models;

public class Message(string content) : DbContext
{
    public Guid Id { get; set; }
    
    public DateTime Timestamp { get; set; }
    
    public string Content { get; set; } = content;
}