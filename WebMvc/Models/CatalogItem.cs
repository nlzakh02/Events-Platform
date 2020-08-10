using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMvc.Models
{
    public class CatalogItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public decimal Price { get; set; }
        public string PictureUrl { get; set; }
        public int EventOrganizerId { get; set; }
        public int EventTypeId { get; set; }
        public int EventAddressId { get; set; }
        public int EventVenueId { get; set; }
        public string EventOrganizer { get; set; }
        public string EventType { get; set; }
        public string EventAddress { get; set; }
        public string EventVenue { get; set; }
    }
}
