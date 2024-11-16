using Abp.Localization;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Runtime.Security;
using Abp.Timing;
using Abp.Zero;
using Abp.Zero.Configuration;
using ServerCore.Localization;
using ServerCore.MultiTenancy;
using ServerCore.Server.Roles;
using ServerCore.Server.Users;
using ServerCore.Timing;

namespace ServerCore
{
    /// <inheritdoc />
    [DependsOn(typeof(AbpZeroCoreModule))]
    public class ServerCoreModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Auditing.IsEnabledForAnonymousUsers = false;

            // Declare entity types
            Configuration.Modules.Zero().EntityTypes.Tenant = typeof(Tenant);
            Configuration.Modules.Zero().EntityTypes.Role = typeof(Role);
            Configuration.Modules.Zero().EntityTypes.User = typeof(User);

            RelayLocalizationConfigurer.Configure(Configuration.Localization);

            // Enable this line to create a multi-tenant application.
            Configuration.MultiTenancy.IsEnabled = RelayConsts.MultiTenancyEnabled;

            // Configure roles
            AppRoleConfig.Configure(Configuration.Modules.Zero().RoleManagement);

            Configuration.Localization.Languages.Add(new LanguageInfo("es", "Spanish"));
            Configuration.Settings.SettingEncryptionConfiguration.DefaultPassPhrase = RelayConsts.DefaultPassPhrase;
            SimpleStringCipher.DefaultPassPhrase = RelayConsts.DefaultPassPhrase;
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(ServerCoreModule).GetAssembly());
        }

        public override void PostInitialize()
        {
            IocManager.Resolve<AppTimes>().StartupTime = Clock.Now;
        }
    }
}