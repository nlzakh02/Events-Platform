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
        public string Summary { get; set; }
        public string Description { get; set; }
        public string StreetAddress { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public decimal Price { get; set; }
        public string PictureURL { get; set; }
        public int EventOrganizerId { get; set; }
        public int EventTypeId { get; set; }
        public int EventStateId { get; set; }
        public int EventCountyId { get; set; }

        // Property types below may need to be changed if class names are different
        public EventOrganizer EventOrganizer { get; set; }
        public EventType EventType { get; set; }
        public EventState EventState { get; set; }
        public EventCounty EventCounty { get; set; }
    }
}
