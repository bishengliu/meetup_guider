using MeetupGuilder.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace MeetupGuilder.Entities.Builders
{
    public class GroupTopicBuilder: IEntityTypeConfiguration<GroupTopic>
    {
        public void Configure(EntityTypeBuilder<GroupTopic> builder)
        {
            builder.HasKey(b => b.Id);

            builder.HasOne(b => b.RSVPGroup)
                .WithMany(b => b.Topics)
                .HasForeignKey(d => d.GroupId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Group_Topics");
        }
    }
}
