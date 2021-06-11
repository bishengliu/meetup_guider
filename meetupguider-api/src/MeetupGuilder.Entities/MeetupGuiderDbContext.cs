using MeetupGuilder.Entities.Builders;
using MeetupGuilder.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MeetupGuilder.Entities
{
    public class MeetupGuiderDbContext : DbContext
    {
        public MeetupGuiderDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new RSVPGroupBuilder());
            modelBuilder.ApplyConfiguration(new GroupTopicBuilder());
        }

        public virtual DbSet<RSVPGroup> RSVPGroups { get; set; }
        public virtual DbSet<GroupTopic> GroupTopics { get; set; }

        public virtual DbSet<RSVPCity> RSVPCities { get; set; }
        public virtual DbSet<CountryTopic> CountryTopics { get; set; }
    }
}
