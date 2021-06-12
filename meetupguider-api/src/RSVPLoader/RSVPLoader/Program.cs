using MeetupGuilder.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.IO;

namespace RSVPLoader
{
    class Program
    {
        static void Main(string[] args)
        {
            // create serice provider
            var serviceProvider = ConfigureServiceProvider();

            //create scope
            using var scope = serviceProvider.CreateScope();

            // db context
            using var repoContext = scope.ServiceProvider.GetRequiredService<MeetupGuiderDbContext>();

            // rsvp loader
            var rsvpService = scope.ServiceProvider.GetService<RSVPService>();

            //retrieve and save rsvps
            _ = rsvpService.RetrieveRSVPs(repoContext);

        }

        private static ServiceProvider ConfigureServiceProvider()
        {
            // create service collection
            var serviceCollection = new ServiceCollection();
            // add services
            ConfigureServices(serviceCollection);
            // create serice provider
            var serviceProvider = serviceCollection.BuildServiceProvider();
            return serviceProvider;
        }

        // configure services
        private static void ConfigureServices(IServiceCollection serviceCollection)
        {
            // build configuration
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
                .AddJsonFile("appsettings.json", false)
                .AddEnvironmentVariables()
                .Build();

            // Add access to generic IConfigurationRoot
            serviceCollection.AddSingleton<IConfigurationRoot>(configuration);

            // connect db
            string connectionString = configuration.GetValue<string>("MeetupGuiderDb:ConnectionString");

            Console.WriteLine(connectionString);

            // inject services
            serviceCollection
                .AddScoped<RSVPService>()
                .AddDbContext<MeetupGuiderDbContext>(o =>
                    o.UseLazyLoadingProxies()
                    .UseSqlServer(connectionString));

        }
    }
}
