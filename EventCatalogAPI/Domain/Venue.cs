using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Cache;
using System.Threading.Tasks;

namespace EventCatalogAPI.Domain
{
    public class Venue
    {
        public Address Address { get; set; }
        public int VenueID { get; set; }
        public int OrganizationId { get; set; } // Id of organzation that created venue in database
        public int AgeRestriction { get; set; }
        public int Capacity { get; set; }
        public string Name { get; set; }
       // public decimal Latitude { get; set; }
      //  public decimal Longitude { get; set; }

        public void RetrieveVenue(int id) // To be implemented
        {
            // Retrieve a Venue by Venue ID.
            throw new NotImplementedException();
        }

        public void CreateVenue() // To be implemented
        {
            // Create new Venue under an Organization.
            throw new NotImplementedException();
        }

        public void UpdateVenue() // To be implemented
        {
            // Update a Venue by Venue ID.
            throw new NotImplementedException();
        }

        public void ListVenues() // To be implemented
        {
            // List Venues by Organization ID. Returns a paginated response.
            throw new NotImplementedException();
        }
    }
}
