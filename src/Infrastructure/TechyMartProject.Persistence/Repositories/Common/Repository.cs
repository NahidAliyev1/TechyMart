using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TechyMartProject.Domain.Entities.Common;
using TechyMartProject.Domain.Interfaces.Repositories.Common;
using TechyMartProject.Persistence.Contexts;

namespace TechyMartProject.Persistence.Repositories.Common;
public class Repository<T> : IRepository<T> where T : BaseEntity, new()
{
    private readonly TechyMartDbContext _techyMartDbContext;
    private readonly DbSet<T> _dbSet;

    public Repository(TechyMartDbContext techyMartDbContext)
    {
        _techyMartDbContext = techyMartDbContext;
        _dbSet = _techyMartDbContext.Set<T>();
    }

   
    public async Task<T> CreateAsync(T entity)  
    {
       _dbSet.Add(entity);
        return _techyMartDbContext.SavedChanges();
        return entity;
    }

    public void Delete(T entity)
    {
        _dbSet.Remove(entity);
        _techyMartDbContext.SaveChanges();
    }

    public Task<T?> FindAsync(Expression<Func<T, bool>> predicate, params string[] includes)
    {
        throw new NotImplementedException();
    }

    public Task<T?> FindByIdAsync(int id, params string[] includes)
    {
        throw new NotImplementedException();
    }

    public IQueryable<T>? GetAll(Expression<Func<T, bool>>? expression = null, params string[] includes)
    {
       
        return _techyMartDbContext.Set<T>().AsQueryable();
    }

    public T Update(T entity)
    {
        throw new NotImplementedException();
    }
}
