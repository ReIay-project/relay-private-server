using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using ServerCore;
using ServerCore.Server;

namespace ServerApp
{
    [DependsOn(
        typeof(ServerCoreModule),
        typeof(AbpAutoMapperModule))]
    public class ServerAppModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<RelayAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(ServerAppModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}