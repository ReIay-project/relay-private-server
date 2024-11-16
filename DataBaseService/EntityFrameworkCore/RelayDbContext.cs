using Abp.Zero.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using ServerCore.MultiTenancy;
using ServerCore.Server.Roles;
using ServerCore.Server.Users;

namespace DataBaseService.EntityFrameworkCore
{
    public class RelayDbContext : AbpZeroDbContext<Tenant, Role, User, RelayDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public RelayDbContext(DbContextOptions<RelayDbContext> options)
            : base(options)
        {
            new DbSetFinder().FindSets(options.ContextType);
        }
    }
}