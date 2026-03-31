using FCA.Domain.Interfaces;
using FCA.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FCA.Infrastructure.Repositories;

public class Repository<T>(ApplicationDbContext _dbContext) : IRepository<T> where T : class
{
    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _dbContext.Set<T>()
                               .AsNoTracking()
                               .ToListAsync();
    }

    public async Task<T?> GetAsync(Expression<Func<T, bool>> predicate)
    {
        return await _dbContext.Set<T>()
                               .AsNoTracking()
                               .FirstOrDefaultAsync(predicate);
    }

    public T Create(T entity)
    {
        _dbContext.Set<T>().Add(entity);
        return entity;
    }
    
    public T Update(T entity)
    {
        _dbContext.Set<T>().Update(entity);
        return entity;
    }

    public T Delete(T entity)
    {
        _dbContext.Set<T>().Remove(entity);
        return entity;
    }
}
