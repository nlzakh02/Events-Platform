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
          
            if (!catalogContext.EventOrganizers.Any())
            {
                catalogContext.EventOrganizers.AddRange(GetEventOrganizers());
                catalogContext.SaveChanges();
            }

            if (!catalogContext.EventItems.Any())
            {
                catalogContext.EventItems.AddRange(GetEventItems());
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

        private static IEnumerable<EventItem> GetEventItems()
        {
            return new List<EventItem>
            {
                new EventItem {EventOrganizerId = 1, EventTypeId = 2, EventAddressId = 1, EventVenueId = 1, Name = "Mixology 101", Description = "Come join us as we introduce the basic cocktails that are in every good bartender's arsenal.", Price = 50.00M, StartTime = new DateTime(2020, 10, 11, 8, 30, 00), EndTime = new DateTime(2020, 10, 11, 10, 30, 00), PictureURL = "http://externalcatalogbaseurltobereplaced/api/pic/1" },
                new EventItem {EventOrganizerId = 2, EventTypeId = 1, EventAddressId = 2, EventVenueId = 1, Name = "Loans for Small Businesses", Description = "Thinking of starting business? Considering expanding your business? We'll tell you what you need to know to obtain a small business loan.", Price = 100.00M, StartTime = new DateTime(2020, 11, 20, 5, 30, 00), EndTime = new DateTime(2020, 11, 20, 6, 30, 00), PictureURL = "http://externalcatalogbaseurltobereplaced/api/pic/2" },
                new EventItem {EventOrganizerId = 3, EventTypeId = 18, EventAddressId = 3, EventVenueId = 1, Name = "BigTech Conference", Description = "An event for the brightest minds in the industry to collaborate and share the latest and greatest technology.", Price = 80.00M, StartTime = new DateTime(2020, 7, 2, 1, 30, 00), EndTime = new DateTime(2020, 7, 2, 9, 30, 00), PictureURL = "http://externalcatalogbaseurltobereplaced/api/pic/3" },
                new EventItem {EventOrganizerId = 4, EventTypeId = 11, EventAddressId = 4, EventVenueId = 1, Name = "Symphony Number One", Description = "Relax as you listen to classics such as Mozart.", Price = 30.00M, StartTime = new DateTime(2020, 9, 22, 5, 00, 00), EndTime = new DateTime(2020, 9, 22, 8, 00, 00), PictureURL = "http://externalcatalogbaseurltobereplaced/api/pic/4" },
                new EventItem {EventOrganizerId = 5, EventTypeId = 18, EventAddressId = 5, EventVenueId = 1, Name = "The Networkers' Networking", Description = "Meet people in your industry who may help you take the next step in your career.", Price = 85.00M, StartTime = new DateTime(2020, 8, 28, 4, 00, 00), EndTime = new DateTime(2020, 8, 28, 5, 00, 00), PictureURL = "http://externalcatalogbaseurltobereplaced/api/pic/5" },
                new EventItem {EventOrganizerId = 6, EventTypeId = 15, EventAddressId = 6, EventVenueId = 1, Name = "Monthly Town Hall Meeting", Description = "Hear the latest updates and voice concerns or suggestions to the City Council.", Price = 0.00M, StartTime = new DateTime(2020, 7, 5, 3, 00, 00), EndTime = new DateTime(2020, 7, 5, 4, 00, 00), PictureURL = "http://externalcatalogbaseurltobereplaced/api/pic/6" },
                new EventItem {EventOrganizerId = 7, EventTypeId = 8, EventAddressId = 7, EventVenueId = 1, Name = "Cultural Festival", Description = "Try a wide variety of food and learn the traditions of the cultures that make our community so vibrant.", Price = 10.00M, StartTime = new DateTime(2020, 8, 15, 7, 00, 00), EndTime = new DateTime(2020, 8, 15, 9, 00, 00), PictureURL = "http://externalcatalogbaseurltobereplaced/api/pic/7" },
                new EventItem {EventOrganizerId = 1, EventTypeId = 2, EventAddressId = 8, EventVenueId = 1, Name = "Drinks on Fifth", Description = "Participating bartenders will offer their signature cocktails to sample.", Price = 45.00M, StartTime = new DateTime(2020, 12, 1, 8, 00, 00), EndTime = new DateTime(2020, 12, 1, 11, 00, 00), PictureURL = "http://externalcatalogbaseurltobereplaced/api/pic/8" },
                new EventItem {EventOrganizerId = 2, EventTypeId = 1, EventAddressId = 9, EventVenueId = 1, Name = "The Next Big Thing", Description = "Learn which businesses will be booming in the next few years.", Price = 55.00M, StartTime = new DateTime(2020, 12, 5, 5, 00, 00), EndTime = new DateTime(2020, 12, 5, 6, 00, 00), PictureURL = "http://externalcatalogbaseurltobereplaced/api/pic/9" },
                new EventItem {EventOrganizerId = 3, EventTypeId = 18, EventAddressId = 10, EventVenueId = 1, Name = "Puzzle Quest", Description = "Form a team and try to solve the most puzzles in this day long puzzle event.", Price = 15.00M, StartTime = new DateTime(2020, 10, 5, 8, 00, 00), EndTime = new DateTime(2020, 10, 5, 10, 00, 00), PictureURL = "http://externalcatalogbaseurltobereplaced/api/pic/10" },
                new EventItem {EventOrganizerId = 4, EventTypeId = 11, EventAddressId = 11, EventVenueId = 1, Name = "Symphoney Number Two", Description = "Relax as you listen to classics such as Mozart.", Price = 30.00M, StartTime = new DateTime(2020, 10, 22, 5, 00, 00), EndTime = new DateTime(2020, 10, 22, 7, 00, 00), PictureURL = "http://externalcatalogbaseurltobereplaced/api/pic/4" },
                new EventItem {EventOrganizerId = 5, EventTypeId = 18, EventAddressId = 12, EventVenueId = 1, Name = "Video Game Night", Description = "Get your controllers ready as we hold MarioKart and Super Smash Bros tournaments.", Price = 20.00M, StartTime = new DateTime(2020, 7, 2, 5, 00, 00), EndTime = new DateTime(2020, 7, 2, 6, 00, 00), PictureURL = "http://externalcatalogbaseurltobereplaced/api/pic/11" },
                new EventItem {EventOrganizerId = 6, EventTypeId = 15, EventAddressId = 13, EventVenueId = 1, Name = "Monthly Town Hall Meeting", Description = "Hear the latest updates and voice concerns or suggestions to the City Council.", Price = 0.00M, StartTime = new DateTime(2020, 8, 12, 4, 00, 00), EndTime = new DateTime(2020, 8, 12, 5, 00, 00), PictureURL = "http://externalcatalogbaseurltobereplaced/api/pic/6" },
                new EventItem {EventOrganizerId = 7, EventTypeId = 8, EventAddressId = 14, EventVenueId = 1, Name = "Know Your Neighbor Forum", Description = "Hear fellow community members tell their experiences living in your town.", Price = 0.00M, StartTime = new DateTime(2020, 11, 19, 5, 00, 00), EndTime = new DateTime(2020, 11, 19, 8, 00, 00), PictureURL = "http://externalcatalogbaseurltobereplaced/api/pic/12" },
                new EventItem {EventOrganizerId = 1, EventTypeId = 2, EventAddressId = 15, EventVenueId = 1, Name = "Intro to the Old Fashioned", Description = "Learn how to make this classic cocktail that all bartenders should know.", Price = 50.00M, StartTime = new DateTime(2020, 10, 1, 5, 00, 00), EndTime = new DateTime(2020, 10, 1, 6, 00, 00), PictureURL = "http://externalcatalogbaseurltobereplaced/api/pic/13" }
            };
        }
    }
}
