using System;
using System.Collections.Generic;
using System.Text;

namespace MeetupGuilder.Entities.Models
{
    public class GroupTopic
    {
        public int Id { get; set; }
        public int GroupId { get; set; }
        public string UrlKey { get; set; }
        public string TopicName { get; set; }

        public virtual RSVPGroup RSVPGroup { get; set; }
    }
}
