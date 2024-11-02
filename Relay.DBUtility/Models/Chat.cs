using Microsoft.EntityFrameworkCore;

namespace Relay.DBUtility.Models;

public class Chat(string name, int id) : DbContext
{
    public int Id { get; set; } = id;

    public required string Name { get; set; } = name;

    public IEnumerable<Message>? Messages { get; set; }
    
    public IEnumerable<User>? Users { get; set; }

    public static string TableName { get; } = "chats";
}