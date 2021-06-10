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
        /// get all the rsvps by city/location
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<RSVP> GetRSVPs() => _guiderService.GetRSVPs();

        /// <summary>
        /// get all the rsvps of a country the city located
        /// </summary>
        /// <returns></returns>
        [HttpGet("{city}")]
        public IEnumerable<RSVP> GetRSVPsByCity(string city) => _guiderService.GetRSVPsByCity(city);
    }
}
