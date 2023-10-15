using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eggcelent.SharedKernel
{
    public abstract class ValueObject
    {
        protected ValueObject() { }

        public abstract IEnumerable<object> GetEqualityParts();

        public override int GetHashCode()
        {
            const int initialSeed = 1;
            return GetEqualityParts()
                .Aggregate(initialSeed, (accumulate, equalityPart) => accumulate += (equalityPart?.GetHashCode() ?? 0) ^ 31);
        }

        public override bool Equals(object? obj)
        {
            if(obj is null)
            {
                return false;
            }

            if(ReferenceEquals(this, obj))
            {
                return true;
            }

            var objType = obj.GetType();

            if(objType != typeof(ValueObject))
            {
                return false;
            }

            if(objType != this.GetType())
            {
                return false;
            }

            return this.GetHashCode() == obj.GetHashCode();
        }
    }
}
