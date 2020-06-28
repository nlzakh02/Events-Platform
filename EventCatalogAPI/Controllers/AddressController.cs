using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventCatalogAPI.Data;
using EventCatalogAPI.Domain;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using EventCatalogAPI.ViewModels;

namespace EventCatalogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly CatalogContext _context;
        private readonly IConfiguration _config;

        public AddressController(CatalogContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        // Get a single address
        [HttpGet("[action]/{id}")]
        public IActionResult GetAddress(int id)
        {
            return (IActionResult)_context.Addresses.Where(v => v.AddressId == id);
        }

        // List requested number of items from the page with requested index
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAddress(
            [FromQuery] int pageIndex = 0,
            [FromQuery] int pageSize = 6)
        {
            var addressesCount = await _context.Addresses.LongCountAsync();

            var addresses = await _context.Addresses
                            .OrderBy(c => c.Region)
                            .Skip(pageIndex * pageSize)
                            .Take(pageSize)
                            .ToListAsync();

            var model = new PaginatedItemsViewModel<Address>
            {
                pageIndex = pageIndex,
                pageSize = addresses.Count,
                Count = addressesCount,
                Data = addresses
            };

            return Ok(model);
        }

        // Filter by state and city
        [HttpGet("[action]/state/{stateId}/city/{cityId}")]
        public async Task<IActionResult> GetAddresses(
            string stateId = "None",
            string cityId = "None",
            [FromQuery] int pageIndex = 0,
            [FromQuery] int pageSize = 6)
        {
            var query = (IQueryable<Address>)_context.Addresses;

            if (stateId != "None")
            {
                query = query.Where(a => a.Region == stateId);
            }

            if (cityId != "None")
            {
                query = query.Where(a => a.City == cityId);
            }

            var addressesCount = await query.LongCountAsync();

            var addresses = await query
                            .OrderBy(c => c.Region)
                            .Skip(pageIndex * pageSize)
                            .Take(pageSize)
                            .ToListAsync();

            var model = new PaginatedItemsViewModel<Address>
            {
                pageIndex = pageIndex,
                pageSize = addresses.Count,
                Count = addressesCount,
                Data = addresses
            };

            return Ok(model);
        }

        // Filter by state
        [HttpGet("[action]/state/{stateId}")]
        public async Task<IActionResult> GetAddresses(
            string stateId = "None",
            [FromQuery] int pageIndex = 0,
            [FromQuery] int pageSize = 6)
        {
            var query = (IQueryable<Address>)_context.Addresses;

            if (stateId != "None")
            {
                query = query.Where(a => a.Region == stateId);
            }

            var addressesCount = await query.LongCountAsync();

            var addresses = await query
                            .OrderBy(c => c.Region)
                            .Skip(pageIndex * pageSize)
                            .Take(pageSize)
                            .ToListAsync();

            var model = new PaginatedItemsViewModel<Address>
            {
                pageIndex = pageIndex,
                pageSize = addresses.Count,
                Count = addressesCount,
                Data = addresses
            };

            return Ok(model);
        }
    }
}
