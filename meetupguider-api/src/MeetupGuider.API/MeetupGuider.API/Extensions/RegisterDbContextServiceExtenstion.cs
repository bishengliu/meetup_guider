using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MeetupGuilder.Entities;

namespace MeetupGuider.API.Extensions
{
    public static class RegisterDbCOntextServiceExtenstion
    {
        public static void RegisterDbContext(this IServiceCollection services, IConfiguration configureation)
        {
            string connectionString = configureation.GetValue<string>("MeetupGuiderDb:ConnectionString");

            services.AddDbContext<MeetupGuiderDbContext>(o =>
                // lazy loading
                o.UseLazyLoadingProxies()
                .UseSqlServer(connectionString, options => options.MigrationsAssembly("MeetupGuilder.Entities")));

        }
    }
}
