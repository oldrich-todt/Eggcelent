using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eggcelent.SharedKernel
{
    public interface IRepository<T>: IReadOnlyRepository<T>, IRepositoryBase<T> where T : class, IAggregateRoot
    {
    }
}
