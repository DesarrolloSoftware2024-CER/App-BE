using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Watchly.EntityFrameworkCore;

/* This class is needed for EF Core console commands
 * (like Add-Migration and Update-Database commands) */
public class WatchlyDbContextFactory : IDesignTimeDbContextFactory<WatchlyDbContext>
{
    public WatchlyDbContext CreateDbContext(string[] args)
    {
        var configuration = BuildConfiguration();
        
        WatchlyEfCoreEntityExtensionMappings.Configure();

        var builder = new DbContextOptionsBuilder<WatchlyDbContext>()
            .UseSqlServer(configuration.GetConnectionString("Default"));
        
        return new WatchlyDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../Watchly.DbMigrator/"))
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
