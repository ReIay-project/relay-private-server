using Abp.AspNetCore;
using Abp.AspNetCore.SignalR;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Zero.Configuration;
using DataBaseService.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using ServerCore.Server.Roles;
using ServerWebCore.Authentication.External;
using ServerWebCore.Configuration;

namespace ServerWeb;

[DependsOn(
    typeof(DataBaseServiceModule),
    typeof(AbpAspNetCoreModule),
    typeof(AbpAspNetCoreSignalRModule)
)]
public class RelayHubModule : AbpModule
{
    private readonly IWebHostEnvironment _env;
    private readonly IConfigurationRoot _appConfiguration;
        
    public RelayHubModule(IWebHostEnvironment env)
    {
        _env = env;
        _appConfiguration = env.GetAppConfiguration();
    }

    public override void PreInitialize()
    {
        Configuration.Modules.Zero().UserManagement.ExternalAuthenticationSources.Add<ExternalAuthManager>();
    }

    public override void Initialize()
    {
        IocManager.RegisterAssemblyByConvention(typeof(RelayHubModule).GetAssembly());
    }

    public override void PostInitialize()
    {
        IocManager.Resolve<ApplicationPartManager>()
            .AddApplicationPartsIfNotAddedBefore(typeof(RelayHubModule).Assembly);
    }
}