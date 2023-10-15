using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eggcelent.SharedKernel
{
    public abstract class Entity
    {
        private readonly List<DomainEvent> _events = new List<DomainEvent>();

        public Guid Id { get; init; }

        public IReadOnlyCollection<DomainEvent> DomainEvents => _events.AsReadOnly();
        
        protected Entity(): this(Guid.NewGuid())
        {
            
        }

        protected Entity(Guid id)
        {
            Id = id;
        }

        public void AddEvent<T>(T @event) where T : DomainEvent
        {
            _events.Add(@event);
        }

        public void ClearEvents()
        {
            _events.Clear();
        }


        public override int GetHashCode()
        {
            return Id.GetHashCode() ^ 31;
        }

        public override bool Equals(object? obj)
        {
            if(obj is not Entity other)
            {
                return false;
            }

            if(ReferenceEquals(this, obj))
            {
                return true;
            }

            if(obj.GetType() != GetType())
            {
                return false;
            }

            return this.Id == other.Id;
        }
    }
}