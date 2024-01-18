using EmailService.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace EmailService.Infrastructure;

public interface IRepository<TEntity> where TEntity : Identity
{
    IQueryable<TEntity> GetQurable();
    Task<TEntity> GetByIdAsync(ulong id);
    Task<IEnumerable<TEntity>> GetAllAsync(
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null);

    Task<IEnumerable<IGrouping<TKey, TEntity>>> GroupByAsync<TKey>
        (Expression<Func<TEntity, TKey>> keySelector, bool notTracking = true);

    Task<IEnumerable<TEntity>> FindAsync
        (Expression<Func<TEntity, bool>> predicate,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include,
        bool enableTracking = false);
    Task<IEnumerable<TEntity>> GetPagedAsync
        (int pageNumber, int pageSize,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity,
        object>>? include = null,
        bool disableTracking = true);


    Task<TEntity?> GetFirstOrDefaultAsync(Expression<Func<TEntity, bool>>? predicate = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
        bool disableTracking = true,
        bool ignoreQueryFilters = false,
        bool ignoreAutoIncludes = false);

    Task InsertAsync(TEntity entity);
    Task InsertRangeAsync(IEnumerable<TEntity> entities);
    void Update(TEntity entity);
    void Delete(TEntity entity);
}
