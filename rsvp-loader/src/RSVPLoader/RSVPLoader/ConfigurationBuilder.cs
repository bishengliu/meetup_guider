using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace RSVPLoader
{
    public static class StandaloneConfigurationBuilder
    {
        public static IConfigurationBuilder CreateConfigurationBuilder()
        {
            return new ConfigurationBuilder()
                          .AddJsonFile("appsettings.json", true);
        }
    }
}
