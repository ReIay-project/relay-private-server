using Abp.EntityFrameworkCore.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Zero.EntityFrameworkCore;
using DataBaseService.EntityFrameworkCore.Seed;
using Microsoft.EntityFrameworkCore;
using ServerCore;

namespace DataBaseService.EntityFrameworkCore
{
    [DependsOn(
        typeof(ServerCoreModule),
        typeof(AbpZeroCoreEntityFrameworkCoreModule))]
    public class DataBaseServiceModule : AbpModule
    {
        public bool SkipDbSeed { get; set; }

        public override void PreInitialize()
        {
            Configuration.Modules.AbpEfCore().AddDbContext<RelayDbContext>(options =>
            {
                if (options.ExistingConnection != null)
                {
                    RelayDbContextConfigurer.Configure(options.DbContextOptions, options.ExistingConnection);
                }
                else
                {
                    var connectionString = Configuration.DefaultNameOrConnectionString;
                    Console.WriteLine($"Connection String in PreInitialize: {connectionString}");
                    RelayDbContextConfigurer.Configure(options.DbContextOptions, connectionString);
                }
            });
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(DataBaseServiceModule).GetAssembly());
        }

        public override void PostInitialize()
        {
            if (!SkipDbSeed)
            {
                SeedHelper.SeedHostDb(IocManager);
            }
        }
    }
}