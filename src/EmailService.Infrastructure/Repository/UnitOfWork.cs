using EmailService.Domain;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;
using System.Reflection;

namespace EmailService.Infrastructure;

public class UnitOfWork : IUnitOfWork
{
    private readonly PostgreDbContext _context;

    private Dictionary<string, object> _repositories;
    private IDbContextTransaction? _currentTransaction;
    private ILogger<IUnitOfWork> _logger;

    public UnitOfWork(PostgreDbContext context, ILogger<IUnitOfWork> logger)
        => (_context, _logger) = (context, logger);

    public IRepository<TEntity> GetRepository<TEntity>() where TEntity : Identity
    {
        if (_repositories == null)
            _repositories = new Dictionary<string, object>();

        var type = typeof(TEntity).Name;

        if (_repositories.ContainsKey(type))
            return (IRepository<TEntity>)_repositories[type];
        Type repositoryType = typeof(Repository<>).MakeGenericType(typeof(TEntity));

        ConstructorInfo constructor = repositoryType.GetConstructor(new[] { typeof(PostgreDbContext) });

        _repositories.Add(type, constructor.Invoke(new object[] { _context }));

        return (IRepository<TEntity>)_repositories[type];
    }

    public object GetRepository(Type type)
    {
        if (_repositories == null)
            _repositories = new Dictionary<string, object>();

        if (_repositories.ContainsKey(type.Name))
            return (IRepository<Identity>)_repositories[type.Name];
        Type repositoryType = typeof(Repository<>).MakeGenericType(type);

        ConstructorInfo constructor = repositoryType.GetConstructor(new[] { typeof(PostgreDbContext) });

        _repositories.Add(type.Name, constructor.Invoke(new object[] { _context }));

        return _repositories[type.Name];
    }

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return _context.SaveChangesAsync(cancellationToken);
    }

}
