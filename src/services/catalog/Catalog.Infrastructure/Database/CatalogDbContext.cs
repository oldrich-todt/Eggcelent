using Catalog.Domain.Aggregates.CatalogItemAggregate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Infrastructure.Database
{
    public class CatalogDbContext: DbContext
    {
        public DbSet<CatalogItem> CatalogItems { get; set; }

        public CatalogDbContext(DbContextOptions<CatalogDbContext> options): base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
