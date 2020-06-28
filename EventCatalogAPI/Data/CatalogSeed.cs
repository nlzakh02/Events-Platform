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
            if (!catalogContext.EventTypes.Any())
            {
                catalogContext.EventTypes.AddRange(GetEventTypes());
                catalogContext.SaveChanges();
            }
            if (!catalogContext.Addresses.Any())
            {
                catalogContext.Addresses.AddRange(GetAddresses());
                catalogContext.SaveChanges();
            }
            if (!catalogContext.Venues.Any())
            {
                catalogContext.Venues.AddRange(GetVenues());
                catalogContext.SaveChanges();
            }
        }

        private static IEnumerable<Venue> GetVenues()
        {
            return new List<Venue>
            {
                new Venue
                {
                    Address = { address1 = "2312 Cactus Rio Ln",
                                City = "Weatherford",
                                County = "Islands",
                                Region = "TX", //2- or 3-character region code for the state or district
                                PostalCode = "76087",},
                    AgeRestriction = 18,
                    Capacity = 10000,
                    Name = "Conference Center"
                },
                new Venue
                {
                    Address = { address1 = "2887 Teapot Ct",
                                address2 = "Suite 101",
                                City = "Reynoldsburg",
                                Region = "OH", //2- or 3-character region code for the state or district
                                PostalCode = "43068",},
                    AgeRestriction = 0,
                    Capacity = 5,
                    Name = "Aunty's Attic Store"
                },
                new Venue
                {
                    Address = { address1 = "172 Concord St",
                                City = "Marion",
                                County = "King",
                                Region = "LA", //2- or 3-character region code for the state or district
                                PostalCode = "71260",},                    
                    Capacity = 1000,
                    Name = "Job Fairground"
                },
                new Venue
                {
                    Address = { address1 = "144 Tubman Cir",
                                City = "Natchez",
                                County = "Grand",
                                Region = "MS", //2- or 3-character region code for the state or district
                                PostalCode = "39120",},
                    AgeRestriction = 21,
                    Capacity = 200,
                    Name = "Red Winery"
                },
                new Venue
                {
                    Address = { address1 = "1422 Wamajo Dr",
                                City = "Sandusky",
                                County = "Path",
                                Region = "OH", //2- or 3-character region code for the state or district
                                PostalCode = "44870",},
                    AgeRestriction = 12,
                    Capacity = 10,
                    Name = "Kids Camp"
                }
            };
        }

        private static IEnumerable<EventType> GetEventTypes()
            {
            return new List<EventType>
                {
                    new EventType
                    {
                        Type = "Business"
                    },
                    new EventType
                    {
                        Type = "Food & Drink"
                    },
                    new EventType
                    {
                        Type = "Health"
                    },
                    new EventType
                    {
                        Type = "Music"
                    },
                    new EventType
                    {
                        Type = "Auto, Boat & Air"
                    },
                    new EventType
                    {
                        Type = "Charity & Causes"
                    },
                    new EventType
                    {
                        Type = "Community"
                    },
                    new EventType
                    {
                        Type = "Family & Education"
                    },
                    new EventType
                    {
                        Type = "Fashion"
                    },
                    new EventType
                    {
                        Type = "Film & Media"
                    },
                    new EventType
                    {
                        Type = "Hobbies"
                    },
                    new EventType
                    {
                        Type = "Home & Lifestyle"
                    },
                    new EventType
                    {
                        Type = "Performing & Visual Arts"
                    },
                    new EventType
                    {
                        Type = "Government"
                    },
                    new EventType
                    {
                        Type = "Spirituality"
                    },
                    new EventType
                    {
                        Type = "School Activities"
                    },
                    new EventType
                    {
                        Type = "Science & Tech"
                    },
                    new EventType
                    {
                        Type = "Holiday"
                    },
                    new EventType
                    {
                        Type = "Sports & Fitness"
                    },
                    new EventType
                    {
                        Type = "Travel & Outdoor"
                    },
                    new EventType
                    {
                        Type = "Other"
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
    }
}
