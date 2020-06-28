using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventCatalogAPI.Data;
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

        
    }
}
