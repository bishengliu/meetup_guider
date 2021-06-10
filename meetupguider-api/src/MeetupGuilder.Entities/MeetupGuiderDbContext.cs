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
            modelBuilder.ApplyConfiguration(new RSVPBuilder());

        }

        public virtual DbSet<RSVP> RSVP { get; set; }
    }
}
