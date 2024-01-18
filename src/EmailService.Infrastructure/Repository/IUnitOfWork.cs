using EmailService.Domain;

namespace EmailService.Infrastructure;
public interface IUnitOfWork
{
    /// <summary>
    /// Get repository by model type
    /// </summary>
    /// <typeparam name="TEntity">Model type</typeparam>
    /// <returns>Repository of type TEntity</returns>
    IRepository<TEntity> GetRepository<TEntity>() where TEntity : Identity;

    /// <summary>
    /// Get repository by model type
    /// </summary>
    /// <typeparam name="type">Model type</typeparam>
    /// <returns>Repository of type TEntity</returns>
    object GetRepository(Type type);

    /// <summary>
    /// Save the results of operations in the database
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns>Number of successful operations</returns>
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
