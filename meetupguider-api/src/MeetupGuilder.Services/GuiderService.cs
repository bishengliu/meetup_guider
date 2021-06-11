using MeetupGuilder.Entities;
using MeetupGuilder.Entities.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeetupGuilder.Services
{
    public class GuiderService : IGuiderService
    {
        private readonly MeetupGuiderDbContext _repoContext;
        private readonly ILogger<GuiderService> _logger;

        public GuiderService(MeetupGuiderDbContext reposContext, ILogger<GuiderService> logger)
        {
            _repoContext = reposContext;
            _logger = logger;
        }

        public IEnumerable<CountryTopic> GetCountryTopicByCountry(string country) =>
            _repoContext.CountryTopics.Where(c => c.Country.ToLower() == country.ToLower());

        public IEnumerable<RSVPCity> GetRSVPCities() =>
            _repoContext.RSVPCities;
    }
}
