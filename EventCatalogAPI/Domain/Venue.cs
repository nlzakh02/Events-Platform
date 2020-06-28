using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Cache;
using System.Threading.Tasks;

namespace EventCatalogAPI.Domain
{
    public class Venue
    {
        public int VenueID { get; set; }
        public int VenueAddressId { get; set; }
        public Address VenueAddress { get; set; }
        //public EventOrganizer Organizer { get; set; }
        //public int EventOrganizerId { get; set; } // Id of organzation that created venue in database
        public int AgeRestriction { get; set; }
        public int Capacity { get; set; }
        public string VenueName { get; set; }
       // public decimal Latitude { get; set; }
      //  public decimal Longitude { get; set; }
    }
}
