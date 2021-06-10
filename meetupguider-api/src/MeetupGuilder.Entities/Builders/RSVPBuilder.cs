using MeetupGuilder.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace MeetupGuilder.Entities.Builders
{
    public class RSVPBuilder: IEntityTypeConfiguration<RSVP>
    {
        public void Configure(EntityTypeBuilder<RSVP> builder)
        {
            builder.HasKey(b => b.Id);
        }
    }
}
