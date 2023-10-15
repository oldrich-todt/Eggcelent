using System.Runtime.Serialization;

namespace Catalog.Application.Common.Exceptions
{
    [Serializable]
    internal class CatalogItemNotFoundException : Exception
    {
        private Guid id;

        public CatalogItemNotFoundException()
        {
        }

        public CatalogItemNotFoundException(Guid id)
        {
            this.id = id;
        }

        public CatalogItemNotFoundException(string? message) : base(message)
        {
        }

        public CatalogItemNotFoundException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected CatalogItemNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}