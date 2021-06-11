using System;
using System.Collections.Generic;
using System.Text;

namespace MeetupGuilder.Entities.Models
{
    public class RSVPGroup
    {
        public RSVPGroup()
        {
            Topics = new HashSet<GroupTopic>();
        }
        public int Id { get; set; }
        public int GroupId { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public float Lon { get; set; }
        public float Lat { get; set; }
        public int RsvpId { get; set; }
        public string Event { get; set; }
        public int EventId { get; set; }
        public long Mtime { get; set; }

        public virtual ICollection<GroupTopic> Topics { get; set; }
    }
}
