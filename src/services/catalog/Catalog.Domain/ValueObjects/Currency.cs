using Eggcelent.SharedKernel;

namespace Catalog.Domain.ValueObjects
{
    public sealed class Currency : ValueObject
    {
        public string Code { get; }

        public Currency(string code)
        {
            Code = code;
        }


        public override IEnumerable<object> GetEqualityParts()
        {
            yield return Code;
        }

        public static Currency Czk => new("czk");
    }
}