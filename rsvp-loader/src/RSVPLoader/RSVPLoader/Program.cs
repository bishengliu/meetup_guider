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
            //prepare DI
            var configuration = StandaloneConfigurationBuilder
                .CreateConfigurationBuilder()
                .Build();

            string connectionString = "server=.;database=meetup_guider;User ID=app;password=app;";

            var serviceProvider = new ServiceCollection()
                .AddScoped<RSVPHelper>()
                .AddDbContext<MeetupGuiderDbContext>(o =>
                    o.UseLazyLoadingProxies()
                    .UseSqlServer(connectionString))
                .BuildServiceProvider();

            // load services
            using var scope = 
                serviceProvider
                .CreateScope();

            using var repoContext = 
                scope.ServiceProvider
                .GetRequiredService<MeetupGuiderDbContext>();

            var rsvpHelper = 
                scope
                .ServiceProvider
                .GetService<RSVPHelper>();

            //retrieve and save rsvps
            _ = rsvpHelper.RetrieveRSVPs(repoContext);

        }
    }
}
