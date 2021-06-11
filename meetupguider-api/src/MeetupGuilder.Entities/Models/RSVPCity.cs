using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MeetupGuilder.Entities.Models
{
    [Table("RSVPCities")]
    public class RSVPCity
    {
        public int GroupId { get; set; }
        public string Country { get; set; }
        [Key]
        public string City { get; set; }
        public int CityCount { get; set; }
        public float Lat { get; set; }
        public float Lon { get; set; }
        public int RsvpId { get; set; }
        public string EventId { get; set; }
    }
}
