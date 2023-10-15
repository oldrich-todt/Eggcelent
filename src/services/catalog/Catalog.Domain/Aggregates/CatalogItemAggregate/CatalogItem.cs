using Catalog.Domain.Exceptions;
using Catalog.Domain.ValueObjects;
using Eggcelent.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Domain.Aggregates.CatalogItemAggregate
{
    public class CatalogItem : AuditableEntity, IAggregateRoot
    {
        private readonly string _name;
        private readonly List<HistoricalPrice> _prices = new();

        public string Name => _name;
        public IReadOnlyCollection<HistoricalPrice> Prices => _prices;

        public CatalogItem(
            string name,
            DateTime createdAt,
            string createdBy) : base(createdAt, createdBy)
        {
            _name = name;
        }
    }
}
