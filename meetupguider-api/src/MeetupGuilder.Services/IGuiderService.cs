using MeetupGuilder.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MeetupGuilder.Services
{
    public interface IGuiderService
    {
        /// <summary>
        /// get all topics of a contry
        /// </summary>
        /// <param name="country"></param>
        /// <returns></returns>
        IEnumerable<CountryTopic> GetCountryTopicByCountry(string country);

        /// <summary>
        /// get rsvps city overviews
        /// </summary>
        /// <returns></returns>
        IEnumerable<RSVPCity> GetRSVPCities();

    }
}
