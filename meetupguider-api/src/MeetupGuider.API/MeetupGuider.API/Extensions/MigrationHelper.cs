using MeetupGuilder.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeetupGuider.API.Extensions
{
    public static class MigrationHelper
    {
        public static IHost MigrateDatabase(this IHost host)
        {
            // create product stock view
            string script =
                @"IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'meetup_guider')
                BEGIN
                  CREATE DATABASE MyTestDataBase;
                END;
                GO;";

            using (var scope = host.Services.CreateScope())
            {
                IConfiguration configureation = scope.ServiceProvider.GetRequiredService<IConfiguration>();
                bool migrateOnStart = configureation.GetValue<bool>("DBMigration:OnStart");
                if (migrateOnStart)
                {
                    using var repoContext = scope.ServiceProvider.GetRequiredService<MeetupGuiderDbContext>();
                    try
                    {
                        repoContext.Database.Migrate();
                        // create a view for product stock
                        repoContext.Database.ExecuteSqlRawAsync(script);
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
            return host;
        }
    }
}
