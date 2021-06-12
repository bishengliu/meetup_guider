﻿// <auto-generated />
using MeetupGuilder.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MeetupGuilder.Entities.Migrations
{
    [DbContext(typeof(MeetupGuiderDbContext))]
    [Migration("20210611210159_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MeetupGuilder.Entities.Models.CountryTopic", b =>
                {
                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Lat")
                        .HasColumnType("real");

                    b.Property<float>("Lon")
                        .HasColumnType("real");

                    b.Property<int>("TopicCount")
                        .HasColumnType("int");

                    b.Property<string>("TopicName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Country");

                    b.ToTable("CountryTopics");
                });

            modelBuilder.Entity("MeetupGuilder.Entities.Models.GroupTopic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("GroupId")
                        .HasColumnType("int");

                    b.Property<string>("TopicName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UrlKey")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.ToTable("GroupTopics");
                });

            modelBuilder.Entity("MeetupGuilder.Entities.Models.RSVPCity", b =>
                {
                    b.Property<string>("City")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("CityCount")
                        .HasColumnType("int");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EventId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("GroupId")
                        .HasColumnType("bigint");

                    b.Property<float>("Lat")
                        .HasColumnType("real");

                    b.Property<float>("Lon")
                        .HasColumnType("real");

                    b.Property<int>("RsvpId")
                        .HasColumnType("int");

                    b.HasKey("City");

                    b.ToTable("RSVPCities");
                });

            modelBuilder.Entity("MeetupGuilder.Entities.Models.RSVPGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Event")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EventId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("GroupId")
                        .HasColumnType("bigint");

                    b.Property<float>("Lat")
                        .HasColumnType("real");

                    b.Property<float>("Lon")
                        .HasColumnType("real");

                    b.Property<long>("Mtime")
                        .HasColumnType("bigint");

                    b.Property<int>("RsvpId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("RSVPGroups");
                });

            modelBuilder.Entity("MeetupGuilder.Entities.Models.GroupTopic", b =>
                {
                    b.HasOne("MeetupGuilder.Entities.Models.RSVPGroup", "RSVPGroup")
                        .WithMany("Topics")
                        .HasForeignKey("GroupId")
                        .HasConstraintName("FK_Group_Topics")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
