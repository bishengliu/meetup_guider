using MeetupGuilder.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeetupGuider.API.Extensions
{
    public static class MeetupGuidereServiceExtension
    {
        public static void RegisterMeetupGuidereServices(this IServiceCollection services)
        {
            services.AddTransient<IGuiderService, GuiderService>();
        }
    }
}
