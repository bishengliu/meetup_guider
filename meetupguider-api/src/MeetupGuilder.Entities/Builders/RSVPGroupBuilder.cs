using MeetupGuilder.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace MeetupGuilder.Entities.Builders
{
    public class RSVPGroupBuilder: IEntityTypeConfiguration<RSVPGroup>
    {
        public void Configure(EntityTypeBuilder<RSVPGroup> builder)
        {
            builder.HasKey(b => b.Id);
        }
    }
}
