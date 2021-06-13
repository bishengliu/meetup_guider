using MeetupGuilder.Entities;
using MeetupGuilder.Entities.Models;
using RSVPLoader.MeetupGuider.Spark.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace RSVPLoader
{
    public class RSVPService
    {
        private const string meetupUrl = "https://stream.meetup.com/2/rsvps";
        private readonly JsonSerializerOptions _options;

        public RSVPService()
        {
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true, IgnoreNullValues = true };           
        }
        public async Task RetrieveRSVPs(MeetupGuiderDbContext repoContext)
        {
            using HttpClient _client = new HttpClient();
            _client.Timeout = TimeSpan.FromMilliseconds(Timeout.Infinite);
            var request = new HttpRequestMessage(HttpMethod.Get, meetupUrl);
            using var response = _client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead).Result;
            response.EnsureSuccessStatusCode();

            var stream = await response.Content.ReadAsStreamAsync();
            using var reader = new StreamReader(stream);
            while (!reader.EndOfStream)
                try
                {
                    // Console.WriteLine(reader.ReadLine());

                    // deserialize
                    RSVP rsvp = JsonSerializer.Deserialize<RSVP>(reader.ReadLine(), _options);

                    // save to db
                    var group = MapRSVP(rsvp);
                    repoContext.RSVPGroups.Add(group);
                    repoContext.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
        }

        public RSVPGroup MapRSVP(RSVP rsvp)
        {
            var topics = new List<GroupTopic>();
            foreach (var item in rsvp.Group.Group_topics)
            {
                topics.Add(new GroupTopic()
                {
                    UrlKey = item.Urlkey,
                    TopicName = item.Topic_name
                });
            }
            RSVPGroup group = new RSVPGroup()
            {
                GroupId = rsvp.Group.Group_id,
                Country = rsvp.Group.Group_country,
                City = rsvp.Group.Group_city,
                Lon = rsvp.Group.Group_lon,
                Lat = rsvp.Group.Group_lat,
                RsvpId = rsvp.Rsvp_id,
                Event = rsvp.Event.Event_name,
                EventId = rsvp.Event.Event_id,
                Mtime = rsvp.Mtime,
                Topics = topics
            };
            return group;
        }
    }
}
