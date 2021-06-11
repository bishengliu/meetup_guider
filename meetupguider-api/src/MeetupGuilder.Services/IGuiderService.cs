using MeetupGuilder.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MeetupGuilder.Services
{
    public interface IGuiderService
    {
        /// <summary>
        /// get all the rsvps
        /// </summary>
        /// <returns></returns>
        IEnumerable<RSVPGroup> GetRSVPs();

        /// <summary>
        /// get rsvps of a country by city
        /// </summary>
        /// <param name="city"></param>
        /// <returns></returns>
        IEnumerable<RSVPGroup> GetRSVPsByCity (string city);
    }
}
