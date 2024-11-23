using System.Reflection;
using Abp.AspNetCore;
using Abp.AspNetCore.Mvc.Antiforgery;
using Abp.AspNetCore.SignalR.Hubs;
using Abp.PlugIns;
using Castle.Facilities.Logging;
using Jason.Abp.Castle.Serilog.Castle.Logging.Serilog;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.WebSockets;
using Microsoft.OpenApi;
using NSwag;
using NSwag.Generation.Processors.Security;
using Serilog;
using Serilog.Core;
using Serilog.Events;
using ServerCore.DirectoryHelper;
using ServerCore.Identity;
using ServerWebCore.Configuration;
using ILoggerFactory = Castle.Core.Logging.ILoggerFactory;

namespace ServerWeb.Startup;

public class Startup
{
    private const string AllowAnyOrigins = "AllowAnyOrigins"; //ToDo разобраться с CORS

    private const string _apiVersion = "v1";

    private readonly IConfigurationRoot _appConfiguration;
    private readonly IWebHostEnvironment _hostingEnvironment;

    public Startup(IWebHostEnvironment env)
    {
        _hostingEnvironment = env;
        _appConfiguration = env.GetAppConfiguration();
    }

    public void ConfigureServices(IServiceCollection services)
    {
        //MVC
        services.AddControllersWithViews(options =>
        {
            options.Filters.Add(new AbpAutoValidateAntiforgeryTokenAttribute());
        });

        IdentityRegistrar.Register(services);
        AuthConfigurer.Configure(services, _appConfiguration);

        // Swagger - Enable this line and the related lines in Configure method to enable swagger UI
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        ConfigureSwagger(services);

        services.AddSerilog(configuration => configuration.ReadFrom.Configuration(_appConfiguration));
        // Configure Abp and Dependency Injection
        services.AddAbpWithoutCreatingServiceProvider<ServerWebModule>(
            options =>
            {
                options.IocManager.IocContainer.AddFacility<LoggingFacility>(f =>
                    f.UseAbpSerilog(configuration => configuration.ReadFrom.Configuration(_appConfiguration)));
                
                options.PlugInSources.Add(new FolderPlugInSource(
                    Path.Combine(WebContentDirectoryFinder.CalculateContentRootFolder() + "/Plugins/")));
                
                options.IocManager.ResolveAll<AbpCommonHub>("/chats");
            });
        services.AddWebSockets(options =>
        {
            //options.AllowedOrigins.Add("http://localhost:1420/");
            //options.KeepAliveInterval = TimeSpan.FromMinutes(5);
        });
        services.AddCors(options =>
        {
            options.AddPolicy(AllowAnyOrigins,
                builder => builder
                    .AllowAnyOrigin()
                    .SetIsOriginAllowedToAllowWildcardSubdomains()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
        });
        services.AddSignalR(options =>
        {
            //options.SupportedProtocols.Add("websoket");
        });
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
    {
        app.UseAbp(options => options.UseAbpRequestLocalization = false); // Initializes ABP framework.

        app.UseStaticFiles();
        app.UseCors(AllowAnyOrigins); // Enable CORS!
        app.UseAuthentication();
        app.UseRouting();
        app.UseAuthorization();
        app.UseWebSockets();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapHub<AbpCommonHub>("/signalr");
            endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
            endpoints.MapControllerRoute("defaultWithArea", "{area}/{controller=Home}/{action=Index}/{id?}");
        });
        app.UseOpenApi();
        //app.UseSwagger();
        app.UseSwaggerUI(options =>
        {
            options.IndexStream = () => Assembly.GetExecutingAssembly()
                .GetManifestResourceStream("ServerWeb.wwwroot.swagger.ui.index.html");
        });
        app.UseReDoc(options =>
        {
            options.Path = "/redoc";
        });
    }

    private void ConfigureSwagger(IServiceCollection services)
    {
        services.AddSwaggerGen();
        services.ConfigureSwaggerGen(options => { options.AddSignalRSwaggerGen(); });
        
        services.AddOpenApiDocument(settings =>
        {
            settings.PostProcess = document =>
            {
                document.Info = new OpenApiInfo
                {
                    Version = _apiVersion,
                    Title = "Relay API",
                    Description = "<p style=\"color:red\";>Апи ещё в разработке.</p>",
                    Contact = new OpenApiContact
                    {
                        Name = "Relay",
                        Url = "https://github.com/ReIay-project/relay-private-server"
                    },
                    License = new OpenApiLicense
                    {
                        Name = "MIT License",
                        Url = "https://github.com/ReIay-project/relay-private-server?tab=MIT-1-ov-file"
                    }
                };
            };

            settings.AddSecurity("JwtBearer", Enumerable.Empty<string>(), new OpenApiSecurityScheme
            {
                Type = OpenApiSecuritySchemeType.Http,
                Scheme = JwtBearerDefaults.AuthenticationScheme,
                BearerFormat = "JWT",
                Description = "Type into the textbox: {your JWT token}."
            });

            settings.OperationProcessors.Add(new AspNetCoreOperationSecurityScopeProcessor("JwtBearer"));
        });
    }
}