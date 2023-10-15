using Catalog.Domain.ValueObjects;
using Eggcelent.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Domain.Aggregates.CatalogItemAggregate
{
    public class HistoricalPrice : AuditableEntity
    {
        public Money Money { get; }
        public DateTimeInterval Interval { get; }

        public HistoricalPrice(
            Money money,
            DateTimeInterval interval,
            DateTime createdAt,
            string createdBy) : base(createdAt, createdBy)
        {
            Money = money;
            Interval = interval;
        }

    }
}
