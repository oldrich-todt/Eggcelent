using Eggcelent.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Domain.ValueObjects
{
    public class DateTimeInterval : ValueObject
    {
        public DateTime From { get; }
        public DateTime To { get; }

        public DateTimeInterval(DateTime from, DateTime to)
        {
            From = from;
            To = to;
        }


        public override IEnumerable<object> GetEqualityParts()
        {
            yield return From;
            yield return To;
        }

        public static bool Overlaps(DateTimeInterval firstInterval, DateTimeInterval secondInterval)
        {
            return (firstInterval.From >= secondInterval.From && firstInterval.To <= secondInterval.To)
                || (firstInterval.From <= secondInterval.From && firstInterval.To >= secondInterval.From)
                || (firstInterval.From <= secondInterval.To && firstInterval.To >= secondInterval.To);
        }
    }
}
