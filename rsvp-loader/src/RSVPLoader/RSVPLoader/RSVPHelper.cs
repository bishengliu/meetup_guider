using MeetupGuilder.Entities;
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
    public class RSVPHelper
    {
        private const string meetupUrl = "https://stream.meetup.com/2/rsvps";
        private readonly JsonSerializerOptions _options;

        public RSVPHelper()
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
                    Console.WriteLine(reader.ReadLine());
                    RSVP result = JsonSerializer.Deserialize<RSVP>(reader.ReadLine(), _options);
                    var group = repoContext.RSVPGroups.FirstOrDefault();
                    Console.WriteLine(group.City);

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
        }
    }
}
