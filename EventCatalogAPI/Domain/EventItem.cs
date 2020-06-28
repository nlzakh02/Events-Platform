using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventCatalogAPI.Domain
{
    public class EventItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public decimal Price { get; set; }
        public string PictureURL { get; set; }
        public int EventOrganizerId { get; set; }
        public int EventTypeId { get; set; }
        public int EventAddressId { get; set; }
        public int EventVenueId { get; set; }
        public EventOrganizer EventOrganizer { get; set; }
        public EventType EventType { get; set; }
        public Address EventAddress { get; set; }
        public Venue EventVenue { get; set; }
    }
}
