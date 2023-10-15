using Eggcelent.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Domain.Exceptions
{
    [Serializable]
    public class PriceDateFromDoesNotFollowException: DomainException
    {
        public PriceDateFromDoesNotFollowException() : base()
        {
        }

        public PriceDateFromDoesNotFollowException(string message) : base(message)
        {
        }

        public PriceDateFromDoesNotFollowException(string message, Exception inner) : base(message, inner)
        {
        }

        protected PriceDateFromDoesNotFollowException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
