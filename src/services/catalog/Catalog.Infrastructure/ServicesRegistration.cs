using Catalog.Domain.Aggregates.CatalogItemAggregate;
using Catalog.Infrastructure.Database;
using Catalog.Infrastructure.Database.Repositories;
using Eggcelent.SharedKernel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Infrastructure
{
    public static class ServicesRegistration
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddDbContext<CatalogDbContext>(builder =>
            {
                builder.UseSqlServer("Server=OLDA-DESKTOP\\SQLEXPRESS;Database=EggcelentDb;Integrated Security=true;Trusted_Connection=True;TrustServerCertificate=True;");
            });
            services.AddScoped(typeof(IReadOnlyRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            return services;
        }
    }
}
