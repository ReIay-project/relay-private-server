using Microsoft.EntityFrameworkCore;
using Relay.DBUtility;
using Relay.DBUtility;
using Relay.DBUtility.Models;
using Serilog;

namespace Relay.Server.Services;

public class UserUtilities(DbServer context)
{
    public async Task Connect(int id, string userName)
    {
        if (IsUserExists(userName).Result)
        {
            Log.Information("User {user} already exists.", userName);
            return;
        }
        context.Users.Add(new User(id, userName)
        {
            Id = id,
            Name = userName
        });
        await context.SaveChangesAsync();
        Log.Information("User {user} connected.", userName);
    }

    public async Task<bool> IsUserExists(string userName) =>
        await context.FindAsync<string>(userName) == null;

    public async Task<int> GetNewUserId()
    {
        return await context.Users.CountAsync();
    }
}