using Ardalis.Specification;
using Catalog.Domain.Aggregates.CatalogItemAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Domain.Specifications
{
    public class GetCatalogItemByIdSpecification: SingleResultSpecification<CatalogItem>
    {
        public GetCatalogItemByIdSpecification(Guid id)
        {
            Query
                .Where(ci => ci.Id == id)
                .Include(ci => ci.Prices);
        }
    }
}
