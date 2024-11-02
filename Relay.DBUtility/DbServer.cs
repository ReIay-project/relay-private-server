using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Relay.DBUtility.Models;
using Serilog;

namespace Relay.DBUtility;

public sealed class DbServer : DbContext
{
    public DbSet<User> Users { get; init; }
    //public DbSet<Chat> Chats { get; init; }
    //public DbSet<Message> Messages { get; init; }
    public DbServer(DbContextOptions<DbServer> options)
        : base(options)
    {
        Database.EnsureCreated();
        Log.Debug(Database.CanConnect().ToString());
        Log.Debug(Database.ProviderName);
    }
}