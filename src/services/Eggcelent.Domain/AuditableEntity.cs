using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eggcelent.SharedKernel
{
    public abstract class AuditableEntity: Entity
    {
        public DateTime CreatedAt { get; }
        public string CreatedBy { get; }

        public DateTime LastUpdatedAt { get; private set; }
        public string LastUpdatedBy { get; private set; }

        protected AuditableEntity(DateTime createdAt, string createdBy): this(Guid.NewGuid(), createdAt, createdBy)
        {
            
        }

        protected AuditableEntity(Guid id, DateTime createdAt, string createdBy): base(id)
        {
            CreatedAt = createdAt;
            CreatedBy = createdBy;
            LastUpdatedAt = createdAt;
            LastUpdatedBy = createdBy;
        }

        public void SetLastUpdate(DateTime lastUpdateAt, string lastUpdatedBy)
        {
            LastUpdatedAt = lastUpdateAt;
            LastUpdatedBy = lastUpdatedBy;
        }
    }
}
