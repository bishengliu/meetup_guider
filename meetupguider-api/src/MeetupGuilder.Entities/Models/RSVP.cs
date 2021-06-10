using System;
using System.Collections.Generic;
using System.Text;

namespace MeetupGuilder.Entities.Models
{
    public class RSVP
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public decimal Lon { get; set; }
        public decimal Lat { get; set; }
        public int RsvpId { get; set; }
        public string Event { get; set; }
        public int EventId { get; set; }
        public long Mtime { get; set; }
    }
}
