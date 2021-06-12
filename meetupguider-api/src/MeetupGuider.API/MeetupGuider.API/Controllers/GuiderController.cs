using MeetupGuilder.Entities.Models;
using MeetupGuilder.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace MeetupGuider.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class GuiderController : ControllerBase
    {
        private readonly ILogger<GuiderController> _logger;
        private readonly IGuiderService _guiderService;

        private static readonly JsonSerializerOptions JsonSerializerOptions = new JsonSerializerOptions
        {
            IgnoreNullValues = true,
            PropertyNameCaseInsensitive = true
        };

        public GuiderController(IGuiderService guiderService
            , ILogger<GuiderController> logger)
        {
            _guiderService = guiderService;
            _logger = logger;
        }

        /// <summary>
        /// get rsvps by city overview
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<RSVPCity> GetRSVPCityOverview() => _guiderService.GetRSVPCities();

        /// <summary>
        /// get topics of a country
        /// </summary>
        /// <returns></returns>
        [HttpGet("{country}")]
        public IEnumerable<CountryTopic> GetCountryTopicByCountry(string country) => _guiderService.GetCountryTopicByCountry(country);
    }
}
