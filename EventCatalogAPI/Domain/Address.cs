using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventCatalogAPI.Domain
{
    public class Address
    {
        // All fields apart from address_1 and country are optional.
        public int Id { get; set; }
        public string address1 { get; set; } // The street/location address (part 1)
        public string address2 { get; set; } // The street/location address (part 2)
        public string address3 { get; set; } // The street/location address (part 3)
        public string City { get; set; }
        public string County { get; set; }
        public string Region { get; set; } // The ISO 3166-2 2- or 3-character region code for the state, province, region, or district
        public string PostalCode { get; set; }
        public string Country { get; set; } // The ISO 3166-1 2-character international code for the country
        public decimal Latitude { get; set; } // The latitude portion of the address coordinates
        public decimal Longitude { get; set; } // The longitude portion of the address coordinates
      //  public string LocalizedAddressDisplay { get; set; } // "333 O'Farrell St Suite 400, San Francisco, CA 94102",
      //  public string LocalizedAreaDisplay { get; set; } // "San Francisco, CA",
      //  public List<string> LocalizedMultiLineAddressDisplay { get; set; } // ["333 O'Farrell St", "Suite 400", "San Francisco, CA 94102"]
    }
}
