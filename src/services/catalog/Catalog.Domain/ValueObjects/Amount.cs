using Eggcelent.SharedKernel;

namespace Catalog.Domain.ValueObjects
{
    public sealed class Amount : ValueObject
    {
        public decimal Value { get; }

        public Amount(decimal value)
        {
            Value = value;
        }


        public override IEnumerable<object> GetEqualityParts()
        {
            yield return Value;
        }
    }
}