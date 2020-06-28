using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventCatalogAPI.Data;
using EventCatalogAPI.Domain;
using EventCatalogAPI.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EventCatalogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly CatalogContext _context;
        private readonly IConfiguration _config;

        public EventController(CatalogContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> Items(
            [FromQuery]int pageIndex = 0,
            [FromQuery]int pageSize = 6)
        {
            var itemsCount = _context.EventItems.LongCountAsync();
            var items = await _context.EventItems
                                    .OrderBy(c => c.Name)
                                    .Skip(pageIndex * pageSize)
                                    .Take(pageSize)
                                    .ToListAsync();

            items = ChangePictureUrl(items);

            var model = new PaginatedItemsViewModel<EventItem>
            {
                PageIndex = pageIndex,
                PageSize = items.Count,
                Count = itemsCount.Result,
                Data = items
            };

            return Ok(model);
        }

        private List<EventItem> ChangePictureUrl(List<EventItem> items)
        {
            items.ForEach(item =>
                item.PictureURL = item.PictureURL.Replace(
                                    "http://externalcatalogbaseurltobereplaced",
                                    _config["ExternalCatalogBaseUrl"]));
            return items;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> Addresses()
        {
            var addresses = await _context.Addresses.ToListAsync();
            return Ok(addresses);
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> Venues()
        {
            var venues = await _context.Venues.ToListAsync();
            return Ok(venues);
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> EventTypes()
        {
            var types = await _context.EventTypes.ToListAsync();
            return Ok(types);
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> EventOrganizers()
        {
            var organizers = await _context.EventOrganizers.ToListAsync();
            return Ok(organizers);
        }

        [HttpGet("[action]/type/{eventTypeId}/brand/{eventOrganizerId}")]
        public async Task<IActionResult> Items(
            int? eventTypeId,
            int? eventOrganizerId,
            [FromQuery]int pageIndex = 0,
            [FromQuery]int pageSize = 6
            )
        {
            var query = (IQueryable<EventItem>)_context.EventItems
                    .Include(c => c.EventOrganizer)
                    .Include(c => c.EventType);

            if (eventTypeId.HasValue)
            {
                query = query.Where(c => c.EventTypeId == eventTypeId);
            }

            if (eventOrganizerId.HasValue)
            {
                query = query.Where(c => c.EventOrganizerId == eventOrganizerId);
            }

            var itemsCount = query.LongCountAsync();
            var items = await query
                                    .OrderBy(c => c.Name)
                                    .Skip(pageIndex * pageSize)
                                    .Take(pageSize)
                                    .ToListAsync();

            items = ChangePictureUrl(items);

            var model = new PaginatedItemsViewModel<EventItem>
            {
                PageIndex = pageIndex,
                PageSize = items.Count,
                Count = itemsCount.Result,
                Data = items
            };

            return Ok(model);
        }

    }
}
