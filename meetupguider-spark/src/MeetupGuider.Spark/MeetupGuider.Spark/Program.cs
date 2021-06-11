using MeetupGuider.Spark.Services;
using Microsoft.Spark.Sql;
using Microsoft.Spark.Sql.Streaming;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace MeetupGuider.Spark
{
    class Program
    {
        static async Task Main(string[] args)
        {
            SparkSession spark = SparkSession
                            .Builder()
                            .AppName("meetup-guider")
                            .GetOrCreate();

            // MeetupService meetupService = new MeetupService();
            // await meetupService.SaveGetRSVPs();

            var df = spark.Read().Json("./data/meetup.json");


            df.PrintSchema();
            var group = df.Select("group").ToDF();
           // group = group.Select("group_id", "group_city", "group_country", "group_name", "group_lon", "group_lat");
            group.Show();
            // df.Show();



        }
    }
}
