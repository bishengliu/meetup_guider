using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MeetupGuilder.Entities.Models
{
    [Table("CountryTopics")]
    public class CountryTopic
    {
        [Key]
        public string Country { get; set; }
        public string City { get; set; }
        public float Lon { get; set; }
        public float Lat { get; set; }
        public string TopicName { get; set; }
        public int TopicCount { get; set; }
    }
}
