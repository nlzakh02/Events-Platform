using EventCatalogAPI.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventCatalogAPI.Data
{
    public class CatalogContext : DbContext
    {
        public CatalogContext(DbContextOptions options) : base(options)
        {

        }
        
        public DbSet<EventItem> EventItems { get; set; }

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

                i.HasOne(c => c.EventType)
                    .WithMany()
                    .HasForeignKey(c => c.EventTypeId);

                i.HasOne(c => c.EventState)
                    .WithMany()
                    .HasForeignKey(c => c.EventStateId);

                i.HasOne(c => c.EventCounty)
                    .WithMany()
                    .HasForeignKey(c => c.EventCountyId);
            });
        }
    }    
}

