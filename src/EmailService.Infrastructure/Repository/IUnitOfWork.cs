using EmailService.Domain;

namespace EmailService.Infrastructure;
public interface IUnitOfWork
{
    IRepository<TEntity> GetRepository<TEntity>() where TEntity : Identity;
    object GetRepository(Type type);
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
