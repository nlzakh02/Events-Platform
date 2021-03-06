﻿// <auto-generated />
using System;
using EventCatalogAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EventCatalogAPI.Migrations
{
    [DbContext(typeof(CatalogContext))]
    [Migration("20200628191104_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("Relational:Sequence:.Addresses_hilo", "'Addresses_hilo', '', '1', '10', '', '', 'Int64', 'False'")
                .HasAnnotation("Relational:Sequence:.eventItems_hilo", "'eventItems_hilo', '', '1', '10', '', '', 'Int64', 'False'")
                .HasAnnotation("Relational:Sequence:.eventorganizer_hilo", "'eventorganizer_hilo', '', '1', '10', '', '', 'Int64', 'False'")
                .HasAnnotation("Relational:Sequence:.eventtype_hilo", "'eventtype_hilo', '', '1', '10', '', '', 'Int64', 'False'")
                .HasAnnotation("Relational:Sequence:.venueshilo", "'venueshilo', '', '1', '10', '', '', 'Int64', 'False'")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EventCatalogAPI.Domain.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:HiLoSequenceName", "Addresses_hilo")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.SequenceHiLo);

                    b.Property<string>("City")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100)
                        .HasDefaultValue("None");

                    b.Property<string>("Country")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100)
                        .HasDefaultValue("US");

                    b.Property<string>("County")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100)
                        .HasDefaultValue("None");

                    b.Property<decimal>("Latitude")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(18,2)")
                        .HasDefaultValue(900m);

                    b.Property<decimal>("Longitude")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(18,2)")
                        .HasDefaultValue(900m);

                    b.Property<string>("PostalCode")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("None");

                    b.Property<string>("Region")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("None");

                    b.Property<string>("address1")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("address2")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50)
                        .HasDefaultValue("None");

                    b.Property<string>("address3")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50)
                        .HasDefaultValue("None");

                    b.HasKey("Id");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("EventCatalogAPI.Domain.EventItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:HiLoSequenceName", "eventItems_hilo")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.SequenceHiLo);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("EventAddressId")
                        .HasColumnType("int");

                    b.Property<int>("EventOrganizerId")
                        .HasColumnType("int");

                    b.Property<int>("EventTypeId")
                        .HasColumnType("int");

                    b.Property<int>("EventVenueId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("PictureUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("EventAddressId");

                    b.HasIndex("EventOrganizerId");

                    b.HasIndex("EventTypeId");

                    b.HasIndex("EventVenueId");

                    b.ToTable("EventItems");
                });

            modelBuilder.Entity("EventCatalogAPI.Domain.EventOrganizer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:HiLoSequenceName", "eventorganizer_hilo")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.SequenceHiLo);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("EventOrganizers");
                });

            modelBuilder.Entity("EventCatalogAPI.Domain.EventType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:HiLoSequenceName", "eventtype_hilo")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.SequenceHiLo);

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("EventTypes");
                });

            modelBuilder.Entity("EventCatalogAPI.Domain.Venue", b =>
                {
                    b.Property<int>("VenueID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:HiLoSequenceName", "venueshilo")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.SequenceHiLo);

                    b.Property<int>("AgeRestriction")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(-1);

                    b.Property<int>("Capacity")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(-1);

                    b.Property<int>("VenueAddressId")
                        .HasColumnType("int");

                    b.Property<string>("VenueName")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("VenueID");

                    b.HasIndex("VenueAddressId");

                    b.ToTable("Venues");
                });

            modelBuilder.Entity("EventCatalogAPI.Domain.EventItem", b =>
                {
                    b.HasOne("EventCatalogAPI.Domain.Address", "EventAddress")
                        .WithMany()
                        .HasForeignKey("EventAddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EventCatalogAPI.Domain.EventOrganizer", "EventOrganizer")
                        .WithMany()
                        .HasForeignKey("EventOrganizerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EventCatalogAPI.Domain.EventType", "EventType")
                        .WithMany()
                        .HasForeignKey("EventTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EventCatalogAPI.Domain.Venue", "EventVenue")
                        .WithMany()
                        .HasForeignKey("EventVenueId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("EventCatalogAPI.Domain.Venue", b =>
                {
                    b.HasOne("EventCatalogAPI.Domain.Address", "VenueAddress")
                        .WithMany()
                        .HasForeignKey("VenueAddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
