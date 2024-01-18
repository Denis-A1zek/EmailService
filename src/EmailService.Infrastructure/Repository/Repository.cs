using EmailService.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EmailService.Infrastructure;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : Identity
{
    private readonly DbSet<TEntity> _dbSet;
    public Repository(PostgreDbContext context)
        => _dbSet = context.Set<TEntity>();

    public async Task InsertAsync(TEntity entity)
        => await _dbSet.AddAsync(entity);

    public async Task InsertRangeAsync(IEnumerable<TEntity> entities)
        => await _dbSet.AddRangeAsync(entities);

    public async Task<IEnumerable<IGrouping<TKey, TEntity>>> GroupByAsync<TKey>
        (Expression<Func<TEntity, TKey>> keySelector,bool notTracking = true)
    {
        if (notTracking)
            _dbSet.AsNoTracking();

        return await _dbSet.GroupBy(keySelector).ToListAsync();
    }
}
