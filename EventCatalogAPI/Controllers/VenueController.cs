using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventCatalogAPI.Data;
using EventCatalogAPI.Domain;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using EventCatalogAPI.ViewModels;
using Microsoft.EntityFrameworkCore.Internal;

namespace EventCatalogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VenueController : ControllerBase
    {
        private readonly CatalogContext _context;
        private readonly IConfiguration _config;

        public VenueController(CatalogContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        // Get a single venue
        [HttpGet("[action]/{id}")]
        public IActionResult GetVenue(int id)
        {
            return (IActionResult)_context.Venues.Where(v => v.VenueID == id);
        }

        // List requested number of items from the page with requested index
        // as in context of listing venues for several events
        [HttpGet("[action]")]
        public async Task<IActionResult> GetVenue(
            [FromQuery]int pageIndex = 0,
            [FromQuery]int pageSize = 6)
        {
            var venuesCount = await _context.Venues.LongCountAsync();

            var venues = await _context.Venues
                            .OrderBy(c => c.VenueName)
                            .Skip(pageIndex * pageSize)
                            .Take(pageSize)
                            .ToListAsync();

            var model = new PaginatedItemsViewModel<Venue>
            {
                PageIndex = pageIndex,
                PageSize = venues.Count,
                Count = venuesCount,
                Data = venues
            };

            return Ok(model);
        }

        // Filter venues by state and city
        [HttpGet("[action]/state/{stateId}/city/{cityId}")]
        public async Task<IActionResult> GetVenue(
            string stateId = "None",
            string cityId = "None",
            [FromQuery] int pageIndex = 0,
            [FromQuery] int pageSize = 6)
        {
            var venues = (IQueryable<Venue>)_context.Venues;

            var addresses = (IQueryable<Address>)_context.Addresses;

            // Filter on state
            if (stateId != "None")
            {
                addresses = addresses.Where(v => v.Region == stateId);
            }

            // Filter on city
            if (cityId != "None")
            {
                addresses = addresses.Where(v => v.City == cityId);
            }

            var query = venues.Join(addresses,
                                    venloc => venloc.VenueAddressId,
                                    addr => addr.Id,
                                    (venloc, addr) =>
                                        new
                                        {
                                            Id = venloc.VenueID,
                                            eventOrganizerId = venloc.EventOrganizerId,
                                            ageRestriction = venloc.AgeRestriction,
                                            capacity = venloc.Capacity,
                                            name = venloc.VenueName,
                                            address_1 = addr.address1,
                                            address_2 = addr.address2,
                                            address_3 = addr.address3,
                                            city = addr.City,
                                            county = addr.County,
                                            region = addr.Region,
                                            postalCode = addr.PostalCode,
                                            country = addr.Country,
                                            latitude = addr.Latitude,
                                            longitude = addr.Longitude
                                        });

            var venuesCount = await query.LongCountAsync();

            var finalvenues = await query
                                    .OrderBy(c => c.name)
                                    .Skip(pageIndex * pageSize)
                                    .Take(pageSize)
                                    .ToListAsync();

            var model = new PaginatedItemsViewModel<Venue>
            {
                PageIndex = pageIndex,
                PageSize = finalvenues.Count,
                Count = venuesCount,
                Data = (IEnumerable<Venue>)finalvenues
            };

            return Ok(model);
        }

        // Filter venues by state
        [HttpGet("[action]/state/{stateId}")]
        public async Task<IActionResult> GetVenue(
            string stateId = "None",
            [FromQuery] int pageIndex = 0,
            [FromQuery] int pageSize = 6)
        {
          //  var venues = (IQueryable<Venue>)_context.Venues;

            var addresses = (IQueryable<Address>)_context.Addresses;

            // Filter on state
            if (stateId != "None")
            {
                addresses = addresses.Where(v => v.Region == stateId);
            }

            var query = _context.Venues.Join(addresses,
                                    venloc => venloc.VenueAddressId,
                                    addr => addr.Id,
                                    (venloc, addr) =>
                                        new
                                        {
                                            Id = venloc.VenueID,
                                            eventOrganizerId = venloc.EventOrganizerId,
                                            ageRestriction = venloc.AgeRestriction,
                                            capacity = venloc.Capacity,
                                            name = venloc.VenueName,
                                            address_1 = addr.address1,
                                            address_2 = addr.address2,
                                            address_3 = addr.address3,
                                            city = addr.City,
                                            county = addr.County,
                                            region = addr.Region,
                                            postalCode = addr.PostalCode,
                                            country = addr.Country,
                                            latitude = addr.Latitude,
                                            longitude = addr.Longitude
                                        });

            var venuesCount = await query.LongCountAsync();

            var venues = await query
                                    .OrderBy(c => c.name)
                                    .Skip(pageIndex * pageSize)
                                    .Take(pageSize)
                                    .ToListAsync();

            var model = new PaginatedItemsViewModel<Venue>
            {
                PageIndex = pageIndex,
                PageSize = venues.Count,
                Count = venuesCount,
                Data = (IEnumerable<Venue>)venues
            };

            return Ok(model);
        }
    }
}
