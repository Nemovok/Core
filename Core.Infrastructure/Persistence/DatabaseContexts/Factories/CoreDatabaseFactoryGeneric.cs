using System;
using System.IO;

using Core.Domain.Enums;
using Core.Infrastructure.Persistence.DatabaseContexts.Interfaces;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Core.Infrastructure.Persistence.DatabaseContexts.Factories
{
    public abstract class CoreDatabaseFactoryGeneric<TDatabaseContext> : IDesignTimeDbContextFactory<TDatabaseContext>
        where TDatabaseContext : DbContext, ICoreDatabaseContext
    {
        protected IConfiguration Configuration { get; } = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        public virtual TDatabaseContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<TDatabaseContext>();

            optionsBuilder.UseNpgsql(
                Configuration.GetConnectionString(CoreConnectionStrings.DefaultConnection.ToString()),
                x => x.MigrationsAssembly(typeof(TDatabaseContext).Assembly.FullName));

            return (TDatabaseContext)Activator.CreateInstance(typeof(TDatabaseContext), optionsBuilder.Options);
        }
    }
}
