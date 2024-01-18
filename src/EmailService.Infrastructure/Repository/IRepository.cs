using EmailService.Domain;
using System.Linq.Expressions;

namespace EmailService.Infrastructure;

public interface IRepository<TEntity> where TEntity : Identity
{
    /// <summary>
    /// Получить сгруппированную коллекцию
    /// </summary>
    /// <typeparam name="TKey">Тип селектора</typeparam>
    /// <param name="keySelector">Селектор для проекции</param>
    /// <param name="notTracking">Чтобы отключить отслеживание изменений</param>
    /// <returns></returns>
    Task<IEnumerable<IGrouping<TKey, TEntity>>> GroupByAsync<TKey>
        (Expression<Func<TEntity, TKey>> keySelector, bool notTracking = true);

    /// <summary>
    /// Операция вставки
    /// </summary>
    /// <param name="entity">Сущность</param>
    /// <returns></returns>
    Task InsertAsync(TEntity entity);

    /// <summary>
    /// Операция вставки
    /// </summary>
    /// <param name="entities">Сущности</param>
    /// <returns></returns>
    Task InsertRangeAsync(IEnumerable<TEntity> entities);
}

