using EventCatalogAPI.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace EventCatalogAPI.Data
{
    public static class CatalogSeed
    {
        public static void Seed(CatalogContext catalogContext)
        {
            catalogContext.Database.Migrate();
            if (!catalogContext.EventCatogories.Any())
            {
                catalogContext.EventCategories.AddRange(GetEventCategories());
                catalogContext.SaveChanges();
            }
            if (!catalogContext.Addresses.Any())
            {
                catalogContext.Addresses.AddRange(GetAddresses());
                catalogContext.SaveChanges();
            }
            if (!catalogContext.EventOrganizers.Any())
            {
                catalogContext.EventOrganizers.AddRange(GetEventOrganizers());
                catalogContext.SaveChanges();
            }
        }

        private static IEnumerable<EventCategory> GetEventCategories()
            {
            return new List<EventCategory>
                {
                    new EventCategory
                    {
                        CategoryName = "Business"
                    },
                    new EventCategory
                    {
                        CategoryName = "Food & Drink"
                    },
                    new EventCategory
                    {
                        CategoryName = "Health"
                    },
                    new EventCategory
                    {
                        CategoryName = "Music"
                    },
                    new EventCategory
                    {
                        CategoryName = "Auto, Boat & Air"
                    },
                    new EventCategory
                    {
                        CategoryName = "Charity & Causes"
                    },
                    new EventCategory
                    {
                        CategoryName = "Community"
                    },
                    new EventCategory
                    {
                        CategoryName = "Family & Education"
                    },
                    new EventCategory
                    {
                        CategoryName = "Fashion"
                    },
                    new EventCategory
                    {
                        CategoryName = "Film & Media"
                    },
                    new EventCategory
                    {
                        CategoryName = "Hobbies"
                    },
                    new EventCategory
                    {
                        CategoryName = "Home & Lifestyle"
                    },
                    new EventCategory
                    {
                        CategoryName = "Performing & Visual Arts"
                    },
                    new EventCategory
                    {
                        CategoryName = "Government"
                    },
                    new EventCategory
                    {
                        CategoryName = "Spirituality"
                    },
                    new EventCategory
                    {
                        CategoryName = "School Activities"
                    },
                    new EventCategory
                    {
                        CategoryName = "Science & Tech"
                    },
                    new EventCategory
                    {
                        CategoryName = "Holiday"
                    },
                    new EventCategory
                    {
                        CategoryName = "Sports & Fitness"
                    },
                    new EventCategory
                    {
                        CategoryName = "Travel & Outdoor"
                    },
                    new EventCategory
                    {
                        CategoryName = "Other"
                    }
                };
            }

        private static IEnumerable<Address> GetAddresses()
        {
            return new List<Address>
            {
                new Address
                {
                    address1 = "7306 Fieldstone Street",
                    address2 = "Suite 123",
                    address3 = "",
                    City = "Ottawa",
                    County = "",
                    Region = "IL", //2- or 3-character region code for the state or district
                    PostalCode = "61350",
                    //Latitude = 0,
                    //Longitude = 0
                },
                new Address
                {
                    address1 = "353 Hill Field Road",
                    address2 = "",
                    address3 = "",
                    City = "Lake Worth",
                    County = "",
                    Region = "FL", //2- or 3-character region code for the state or district
                    PostalCode = "33460",
                    //Latitude = 0,
                    //Longitude = 0
                },
                new Address
                {
                    address1 = "3 S. Glen Eagles Ave.",
                    address2 = "",
                    address3 = "",
                    City = "Dallas",
                    County = "",
                    Region = "GA", //2- or 3-character region code for the state or district
                    PostalCode = "30132",
                   // Latitude = 0,
                    //Longitude = 0
                },
                new Address
                {
                    address1 = "516 W. Division Dr.",
                    address2 = "Munster",
                    address3 = "",
                    City = "",
                    County = "",
                    Region = "IN", //2- or 3-character region code for the state or district
                    PostalCode = "46321",
                    //Latitude = 0,
                    //Longitude = 0
                },
                new Address
                {
                    address1 = "8739 Meadowbrook St.",
                    address2 = "",
                    address3 = "",
                    City = "Loxahatchee",
                    County = "",
                    Region = "FL", //2- or 3-character region code for the state or district
                    PostalCode = "33470",
                   // Latitude = 0,
                    //Longitude = 0
                },
                new Address
                {
                    address1 = "2 Fulton Ave.",
                    address2 = "",
                    address3 = "",
                    City = "Southaven",
                    County = "",
                    Region = "MS", //2- or 3-character region code for the state or district
                    PostalCode = "38671",
                    //Latitude = 0,
                    //Longitude = 0
                },
                new Address
                {
                    address1 = "7205 Fairfield Ave.",
                    address2 = "",
                    address3 = "",
                    City = "Youngstown",
                    County = "",
                    Region = "OH", //2- or 3-character region code for the state or district
                    PostalCode = "44512",
                   // Latitude = 0,
                    //Longitude = 0
                },
                new Address
                {
                    address1 = "7701 Maple Street",
                    address2 = "",
                    address3 = "",
                    City = "Middle Village",
                    County = "",
                    Region = "NY", //2- or 3-character region code for the state or district
                    PostalCode = "11379",
                   // Latitude = 0,
                   // Longitude = 0
                },
                new Address
                {
                    address1 = "7509 Bowman Ave.",
                    address2 = "",
                    address3 = "",
                    City = "Altoona",
                    County = "",
                    Region = "PA", //2- or 3-character region code for the state or district
                    PostalCode = "16601",
                    //Latitude = 0,
                    //Longitude = 0
                },
                new Address
                {
                    address1 = "61 N. Sage Road",
                    address2 = "",
                    address3 = "",
                    City = "Sykesville",
                    County = "",
                    Region = "MD", //2- or 3-character region code for the state or district
                    PostalCode = "21784",
                    //Latitude = 0,
                    //Longitude = 0
                },
                new Address
                {
                    address1 = "8707 Shub Farm St.",
                    address2 = "",
                    address3 = "",
                    City = "Maplewood",
                    County = "",
                    Region = "NJ", //2- or 3-character region code for the state or district
                    PostalCode = "07040",
                    //Latitude = 0,
                    //Longitude = 0
                },
                new Address
                {
                    address1 = "504 West York Dr.",
                    address2 = "",
                    address3 = "",
                    City = "Longwood",
                    County = "",
                    Region = "FL", //2- or 3-character region code for the state or district
                    PostalCode = "32779",
                    //Latitude = 0,
                   // Longitude = 0
                },
                new Address
                {
                    address1 = "386 West Division Street",
                    address2 = "",
                    address3 = "",
                    City = "New York",
                    County = "",
                    Region = "NY", //2- or 3-character region code for the state or district
                    PostalCode = "10002",
                    //Latitude = 0,
                    //Longitude = 0
                },
                new Address
                {
                    address1 = "40 Cherry Hill Ave.",
                    address2 = "",
                    address3 = "",
                    City = "Savannah",
                    County = "",
                    Region = "GA", //2- or 3-character region code for the state or district
                    PostalCode = "31404",
                    //Latitude = 0,
                    //Longitude = 0
                },
                new Address
                {
                    address1 = "487 West Broad Lane",
                    address2 = "",
                    address3 = "",
                    City = "Dekalb",
                    County = "",
                    Region = "IL", //2- or 3-character region code for the state or district
                    PostalCode = "60115",
                    //Latitude = 0,
                    //Longitude = 0
                },
                new Address
                {
                    address1 = "93 Nicolls Street",
                    address2 = "",
                    address3 = "",
                    City = "Cornelius",
                    County = "",
                    Region = "NC", //2- or 3-character region code for the state or district
                    PostalCode = "28031",
                    //Latitude = 0,
                    //Longitude = 0
                },
                new Address
                {
                    address1 = "749 Henry Smith Street",
                    address2 = "",
                    address3 = "",
                    City = "Atwater",
                    County = "",
                    Region = "CA", //2- or 3-character region code for the state or district
                    PostalCode = "95301",
                    //Latitude = 0,
                    //Longitude = 0
                },
                new Address
                {
                    address1 = "9484 N. Devonshire Rd.",
                    address2 = "",
                    address3 = "",
                    City = "Henderson",
                    County = "",
                    Region = "KY", //2- or 3-character region code for the state or district
                    PostalCode = "42420",
                    //Latitude = 0,
                    //Longitude = 0
                },
                new Address
                {
                    address1 = "714 W. Glenridge St.",
                    address2 = "",
                    address3 = "",
                    City = "Gulfport",
                    County = "",
                    Region = "MS", //2- or 3-character region code for the state or district
                    PostalCode = "39503",
                    //Latitude = 0,
                    //Longitude = 0
                },
                new Address
                {
                    address1 = "8739 Meadowbrook St.",
                    address2 = "",
                    address3 = "",
                    City = "Loxahatchee",
                    County = "",
                    Region = "FL", //2- or 3-character region code for the state or district
                    PostalCode = "33470",
                   // Latitude = 0,
                   // Longitude = 0
                }
            };
        }
        private static IEnumerable<EventOrganizer> GetEventOrganizers()
        {
            return new List<EventOrganizer>
            {
                new EventOrganizer
                { 
                    Name = "The Professional Bartending Academy"
                },
                new EventOrganizer
                {
                    Name = "My Business Support"
                },
                new EventOrganizer
                {
                    Name = "WeCloudData"
                },
                new EventOrganizer
                {
                    Name = "ConcertMode At Home"
                },
                new EventOrganizer
                {
                    Name = "KOTRA Silicone Valley"
                },
                new EventOrganizer
                {
                    Name = "SS United States Conservancy"
                },
                new EventOrganizer
                {
                    Name = "Office for Diversity, Equity and Engagement"
                },
            };

        }
    }
}
