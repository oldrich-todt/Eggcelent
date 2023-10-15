using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eggcelent.SharedKernel
{
    public abstract class DomainEvent
    {
        public DateTime CreatedAt { get; set; }
    }
}
