using System.Net;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Serilog;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics.Internal;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MySqlConnector;
using Relay.DBUtility;
using Relay.DBUtility;
using Relay.DBUtility.Models;
using Relay.Server.Services;
using Serilog.Core;
using Serilog.Events;
using ILogger = Serilog.ILogger;

namespace Relay.Server;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var address = builder.Configuration["ServerAddress"];
        var port = int.Parse(builder.Configuration["ServerPort"] ?? throw new InvalidOperationException());

        var levelSwitch = new LoggingLevelSwitch();
        levelSwitch.MinimumLevel = LogEventLevel.Debug;
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.ControlledBy(levelSwitch)
            .WriteTo.Console()
            .CreateLogger();

        var stringBuilder = new MySqlConnectionStringBuilder();
        stringBuilder.Server = builder.Configuration["Server"];
        stringBuilder.Port = uint.Parse(builder.Configuration["Port"]);
        stringBuilder.UserID = builder.Configuration["UserID"];
        stringBuilder.Password = builder.Configuration["Password"];
        stringBuilder.Database = builder.Configuration["Database"];


        builder.WebHost.UseUrls($"http://{address}:{port}");

        // Add services to the container.
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ??
                               throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

        builder.Services.AddSerilog();
        builder.Services.AddSignalR(options =>
        {
            options.EnableDetailedErrors = true;
        });

        Log.Information(nameof(stringBuilder) + ":" + stringBuilder);
        /*
        builder.Services.AddDbContext<DbServer>(optionsBuilder =>
        {
            optionsBuilder.UseMySql(stringBuilder.ConnectionString, ServerVersion.AutoDetect(stringBuilder.ConnectionString));
            Log.Information(optionsBuilder.IsConfigured.ToString());
        });*/

        var app = builder.Build();
        app.UseWebSockets();

        app.MapHub<WebSocketUtilities>("/WebSocketUtilities");

        Log.Information("Application starting...");
        await app.RunAsync();
    }
}