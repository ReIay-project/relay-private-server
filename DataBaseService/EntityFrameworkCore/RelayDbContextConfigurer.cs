using System.Data.Common;
using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace DataBaseService.EntityFrameworkCore
{
    public static class RelayDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<RelayDbContext> builder, string connectionString)
        {
            builder.UseNpgsql(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<RelayDbContext> builder, DbConnection connection)
        {
            builder.UseNpgsql(connection);
        }
    }
}