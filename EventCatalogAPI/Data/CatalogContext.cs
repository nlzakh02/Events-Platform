using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventCatalogAPI.Data
{
    public class CatalogContext : DbContext
    {
        public CatalogContext(DbContextOptions options): base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
