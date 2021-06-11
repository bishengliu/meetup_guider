using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace MeetupGuider.Spark.Services
{
    public class MeetupService
    {
        private const string meetupUrl = "https://stream.meetup.com/2/rsvps";
        private readonly JsonSerializerOptions _options;
        public MeetupService() {
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true, IgnoreNullValues = true };
        }

        public async Task SaveGetRSVPs()
        {
            using var client = new HttpClient();
            client.Timeout = TimeSpan.FromMilliseconds(Timeout.Infinite);
            var request = new HttpRequestMessage(HttpMethod.Get, meetupUrl);
            using var response = client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead).Result;
            response.EnsureSuccessStatusCode();

            var stream = await response.Content.ReadAsStreamAsync();
            //FileStream file = new FileStream("./data/meetup.json", FileMode.Open, FileAccess.ReadWrite);
            using var reader = new StreamReader(stream);
            StreamWriter file = new StreamWriter("./data/meetup.json", append: true);
            while (!reader.EndOfStream)
                await file.WriteLineAsync(reader.ReadLine());
            file.Close();

        }
        public async Task<IEnumerable<RSVP>> GetRSVPs()
        {
            using var client = new HttpClient();
            client.Timeout = TimeSpan.FromMilliseconds(Timeout.Infinite);
            var request = new HttpRequestMessage(HttpMethod.Get, meetupUrl);
            using var response = client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead).Result;
            response.EnsureSuccessStatusCode();

            var stream = await response.Content.ReadAsStreamAsync();
            //using var reader = new StreamReader(stream);
            //RSVP result = new RSVP() ;
            //while (!reader.EndOfStream)
            //    try
            //    {
            //        Console.WriteLine(reader.ReadLine());
            //        result = JsonSerializer.Deserialize<RSVP>(reader.ReadLine(), _options);
            //    }
            //    catch(Exception ex)
            //    {
            //        Console.WriteLine(ex);
            //    }

            return await JsonSerializer.DeserializeAsync<IEnumerable<RSVP>>(stream, _options);

            //using var reader = new StreamReader(stream);
            //while (!reader.EndOfStream)
            //    Console.WriteLine(reader.ReadLine());
            //foreach (var item in res)
            //{
            //    Console.WriteLine(item.Rsvp_id);
            //}
        }
    }
}
