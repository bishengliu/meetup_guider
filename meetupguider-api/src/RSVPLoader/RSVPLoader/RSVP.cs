using System;
using System.Collections.Generic;
using System.Text;

namespace RSVPLoader
{
    namespace MeetupGuider.Spark.Services
    {
        public class RSVP
        {
            public Venue Venue { get; set; }
            public string Visibility { get; set; }
            public string Response { get; set; }
            public int Guests { get; set; }
            public Member Member { get; set; }
            public int Rsvp_id { get; set; }
            public long Mtime { get; set; }
            public Event Event { get; set; }
            public Group Group { get; set; }

        }

        public class Venue
        {
            public int Venue_id { get; set; }
            public string Venue_name { get; set; }
            public double Lon { get; set; }
            public double Lat { get; set; }
        }
        public class Member
        {
            public int Member_id { get; set; }
            public string Photo { get; set; }
            public string Member_name { get; set; }
        }

        public class Event
        {
            public string Event_name { get; set; }
            public string Event_id { get; set; }
            public long Time { get; set; }
            public string Event_url { get; set; }
        }

        public class Group
        {
            public List<Group_topics> Group_topics { get; set; }
            public long Group_id { get; set; }
            public string Group_urlname { get; set; }
            public string Group_city { get; set; }
            public string Group_country { get; set; }
            public string Group_name { get; set; }
            public float Group_lon { get; set; }
            public float Group_lat { get; set; }
        }

        public class Group_topics
        {
            public string Urlkey { get; set; }
            public string Topic_name { get; set; }
        }

    }
}
