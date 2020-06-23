using EventCatalogAPI.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace EventCatalogAPI.Data
{
    public class CatalogContext : DbContext
    {
        public CatalogContext(DbContextOptions options) : base(options)
        {

        }
        
        public DbSet<EventItem> EventItems { get; set; }

        public DbSet<Venue> Venues { get; set; }
        public DbSet<Address> Addresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventItem>(i =>
            {
                i.ToTable("EventItems");

                i.Property(p => p.Id)
                    .IsRequired()
                    .UseHiLo("event_item_hilo");

                i.Property(p => p.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                i.Property(p => p.Summary)
                    .IsRequired()
                    .HasMaxLength(1000);

                i.Property(p => p.Description)
                    .IsRequired();

                i.Property(p => p.StreetAddress)
                    .IsRequired();

                i.Property(p => p.StartTime)
                    .IsRequired();

                i.Property(p => p.EndTime)
                    .IsRequired();

                i.Property(p => p.Price)
                    .IsRequired();

                i.Property(p => p.PictureURL)
                    .IsRequired();

                i.HasOne(c => c.EventOrganizer)
                    .WithMany()
                    .HasForeignKey(c => c.EventOrganizerId);

                i.HasOne(c => c.EventCategory)
                    .WithMany()
                    .HasForeignKey(c => c.EventCategoryId);

                i.HasOne(c => c.EventState)
                    .WithMany()
                    .HasForeignKey(c => c.EventStateId);

                i.HasOne(c => c.EventCounty)
                    .WithMany()
                    .HasForeignKey(c => c.EventCountyId);
            });


        modelBuilder.Entity<Venue>( e =>
            {
                e.ToTable("Venues");

                e.Property(x => x.VenueID)
                 .IsRequired()
                 .UseHiLo("venues_hilo");

                // Needs editing to match definitions of organizing parties
                // Same venue can be used by many organizations
                // One organization can use multiple venues
                e.HasMany(x => x.OrganizationId)
                 .WithMany()
                 .HasForeignKey(c => c.OrganizerID);

                e.Property(x => x.Address)
                 .IsRequired();

                e.Property(x => x.AgeRestriction)
                 .HasDefaultValue(-1);

                e.Property(x => x.Capacity)
                 .HasDefaultValue(-1);

                e.Property(x => x.Name)
                 .HasMaxLength(100);

               // e.Property(x => x.Latitude)
              //   .IsRequired();

              //  e.Property(x => x.Longitude)
              //   .IsRequired();
            });

        

        modelBuilder.Entity<Address>(e =>
            {
                e.ToTable("Addresses");

                e.Property(x => x.AddressId)
                 .IsRequired();

                e.Property(x => x.address1)
                 .IsRequired()
                 .HasMaxLength(50);

                e.Property(x => x.address2)
                 .HasMaxLength(50)
                 .HasDefaultValue("None");

                e.Property(x => x.address3)
                 .HasMaxLength(50)
                 .HasDefaultValue("None");

                e.Property(x => x.City)
                 .HasMaxLength(100)
                 .HasDefaultValue("None");

                e.Property(x => x.County)
                 .HasMaxLength(100)
                 .HasDefaultValue("None");

                e.Property(x => x.Region)
                 .HasDefaultValue("None");

                e.Property(x => x.PostalCode)
                 .HasDefaultValue("None");

                e.Property(x => x.Country)
                 .HasDefaultValue("US")
                 .HasMaxLength(100);

                e.Property(x => x.Latitude)
                 .HasDefaultValue(900);

                e.Property(x => x.Longitude)
                 .HasDefaultValue(900);
           });
                 

            modelBuilder.Entity<EventOrganizer>(i =>
            {
                i.ToTable("EventOrganizer");
                i.Property(o => o.Id)
                   .IsRequired()
                   .UseHiLo("event_organizer_hilo");

                i.Property(o => o.Name)
                   .IsRequired()
                   .HasMaxLength(100);
            });

            modelBuilder.Entity<EventType>(i =>
            {
                i.ToTable("EventType");
                i.Property(t => t.Id)
                   .IsRequired()
                   .UseHiLo("event_type_hilo");

                i.Property(t => t.Type)
                   .IsRequired()
                   .HasMaxLength(100);

            });
        }
    }    
}

