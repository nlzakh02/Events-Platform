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
        [HttpGet("[action]")]
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
                            .OrderBy(c => c.Name)
                            .Skip(pageIndex * pageSize)
                            .Take(pageSize)
                            .ToListAsync();

            var model = new PaginatedItemsViewModel<Venue>
            {
                pageIndex = pageIndex,
                pageSize = venues.Count,
                Count = venuesCount,
                Data = venues
            };

            return Ok(model);
        }

        [HttpGet("[action]/state/{stateId}/city/{cityId}")]
        public async Task<IActionResult> GetVenue(
            string stateId = "None",
            string cityId = "None",
            [FromQuery] int pageIndex = 0,
            [FromQuery] int pageSize = 6)
        {
            var query = (IQueryable<Venue>)_context.Venues;

            if (stateId != "None")
            {
                query = query.Where(v => v.Address.Region == stateId);
            }

            if (cityId != "None")
            {
                query = query.Where(v => v.Address.City == cityId);
            }

            var venuesCount = await query.LongCountAsync();

            var venues = await query
                            .OrderBy(c => c.Name)
                            .Skip(pageIndex * pageSize)
                            .Take(pageSize)
                            .ToListAsync();

            var model = new PaginatedItemsViewModel<Venue>
            {
                pageIndex = pageIndex,
                pageSize = venues.Count,
                Count = venuesCount,
                Data = venues
            };

            return Ok(model);
        }
    }
}
