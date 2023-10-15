using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using Catalog.Domain.Aggregates.CatalogItemAggregate;
using Eggcelent.SharedKernel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Infrastructure.Database.Repositories
{
    public class Repository<T> : IRepository<T>, IReadOnlyRepository<T> where T : class, IAggregateRoot
    {
        private readonly CatalogDbContext context;
        private readonly ISpecificationEvaluator evaluator;
        
        public Repository(CatalogDbContext context): this(context, SpecificationEvaluator.Default) { }


        public Repository(CatalogDbContext context, ISpecificationEvaluator evaluator)
        {
            this.context = context;
            this.evaluator = evaluator;
        }


        public async Task<T> AddAsync(T entity, CancellationToken cancellationToken = default)
        {
            await context.Set<T>().AddAsync(entity, cancellationToken);

            return entity;
        }

        public async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
        {
            await context.Set<T>().AddRangeAsync(entities, cancellationToken);

            return entities;
        }

        public async Task<bool> AnyAsync(ISpecification<T> specification, CancellationToken cancellationToken = default)
        {
            return await Evaluate(context.Set<T>(), specification).AnyAsync(cancellationToken);
        }

        public async Task<bool> AnyAsync(CancellationToken cancellationToken = default)
        {
            return await context.Set<T>().AnyAsync(cancellationToken);
        }

        public IAsyncEnumerable<T> AsAsyncEnumerable(ISpecification<T> specification)
        {
            return context.Set<T>().AsAsyncEnumerable();
        }

        public async Task<int> CountAsync(ISpecification<T> specification, CancellationToken cancellationToken = default)
        {
            return await Evaluate(context.Set<T>(), specification).CountAsync(cancellationToken);
        }

        public async Task<int> CountAsync(CancellationToken cancellationToken = default)
        {
            return await context.Set<T>().CountAsync(cancellationToken);
        }

        public Task DeleteAsync(T entity, CancellationToken cancellationToken = default)
        {
            context.Set<T>().Remove(entity);

            return Task.CompletedTask;
        }

        public Task DeleteRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
        {
            context.Set<T>().RemoveRange(entities);

            return Task.CompletedTask;
        }

        public async Task<T?> FirstOrDefaultAsync(ISpecification<T> specification, CancellationToken cancellationToken = default)
        {
            return await Evaluate(context.Set<T>(), specification).FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<TResult?> FirstOrDefaultAsync<TResult>(ISpecification<T, TResult> specification, CancellationToken cancellationToken = default)
        {
            return await Evaluate(context.Set<T>(), specification).FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<T?> GetByIdAsync<TId>(TId id, CancellationToken cancellationToken = default) where TId : notnull
        {
            return await context.Set<T>().FindAsync(new object[] { id }, cancellationToken);
        }

        public async Task<T?> GetBySpecAsync(ISpecification<T> specification, CancellationToken cancellationToken = default)
        {
            return await Evaluate(context.Set<T>(), specification).FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<TResult?> GetBySpecAsync<TResult>(ISpecification<T, TResult> specification, CancellationToken cancellationToken = default)
        {
            return await Evaluate(context.Set<T>(), specification).FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<List<T>> ListAsync(CancellationToken cancellationToken = default)
        {
            return await context.Set<T>().ToListAsync(cancellationToken);
        }

        public async Task<List<T>> ListAsync(ISpecification<T> specification, CancellationToken cancellationToken = default)
        {
            return await Evaluate(context.Set<T>(), specification).ToListAsync(cancellationToken);
        }

        public async Task<List<TResult>> ListAsync<TResult>(ISpecification<T, TResult> specification, CancellationToken cancellationToken = default)
        {
            return await Evaluate(context.Set<T>(), specification).ToListAsync(cancellationToken);
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await context.SaveChangesAsync(cancellationToken);
        }

        public async Task<T?> SingleOrDefaultAsync(ISingleResultSpecification<T> specification, CancellationToken cancellationToken = default)
        {
            return await Evaluate(context.Set<T>(), specification).SingleOrDefaultAsync(cancellationToken);
        }

        public async Task<TResult?> SingleOrDefaultAsync<TResult>(ISingleResultSpecification<T, TResult> specification, CancellationToken cancellationToken = default)
        {
            return await Evaluate(context.Set<T>(), specification).SingleOrDefaultAsync(cancellationToken);
        }

        public Task UpdateAsync(T entity, CancellationToken cancellationToken = default)
        {
            context.Set<T>().Update(entity);

            return Task.CompletedTask;
        }

        public Task UpdateRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
        {
            context.Set<T>().UpdateRange(entities);

            return Task.CompletedTask;
        }

        private IQueryable<T> Evaluate(IQueryable<T> query, ISpecification<T> spec, bool evaluateCriteriaOnly = false)
        {
            return evaluator.GetQuery<T>(query, spec, evaluateCriteriaOnly);
        }

        private IQueryable<TResult> Evaluate<TResult>(IQueryable<T> query, ISpecification<T, TResult> spec)
        {
            return evaluator.GetQuery(query, spec);
        }
    }
}
