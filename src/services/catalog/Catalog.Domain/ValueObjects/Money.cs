using Eggcelent.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Domain.ValueObjects
{
    public sealed class Money : ValueObject
    {
        public Amount Amount { get; }
        public Currency Currency { get; }

        public Money(Amount amount, Currency currency)
        {
            Amount = amount;
            Currency = currency;
        }


        public override IEnumerable<object> GetEqualityParts()
        {
            yield return Amount;
            yield return Currency;
        }
    }
}
