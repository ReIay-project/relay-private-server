using Abp.Modules;
using Abp.Reflection.Extensions;
using ServerWebCore;
using ServerWebCore.Configuration;

namespace ServerWeb.Startup
{
    [DependsOn(
        typeof(ServerWebCoreModule))]
    public class ServerWebModule : AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public ServerWebModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(ServerWebModule).GetAssembly());
        }
    }
}