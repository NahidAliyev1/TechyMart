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
         _techyMartDbContext.SaveChanges();
        return entity;
    }

    public void Delete(T entity)
    {
        _dbSet.Remove(entity);
        _techyMartDbContext.SaveChanges();
    }

    public async Task<T?> FindAsync(Expression<Func<T, bool>> predicate, params string[] includes)
    {
        IQueryable<T> query = _dbSet;

        // Əgər navigation property-lər varsa, include edirik
        foreach (var include in includes)
        {
            query = query.Include(include);
        }

        return await query.FirstOrDefaultAsync(predicate);
    }

    public async Task<T?> FindByIdAsync(int id, params string[] includes)
    {
        IQueryable<T> query = _dbSet;

        foreach (var include in includes)
        {
            query = query.Include(include);
        }

        return await query.FirstOrDefaultAsync(x => x.Id == id); ;
    }

    public IQueryable<T>? GetAll(Expression<Func<T, bool>>? expression = null, params string[] includes)
    {

        IQueryable<T> query = _dbSet;

        // Navigation property-lər varsa əlavə edirik
        foreach (var include in includes)
        {
            query = query.Include(include);
        }

        // Filter varsa tətbiq edirik
        if (expression != null)
        {
            query = query.Where(expression);
        }

        return query;
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _techyMartDbContext.SaveChangesAsync();
    }

    public T Update(T entity)
    {
        _dbSet.Update(entity);   // Entity update edilir
        _techyMartDbContext.SaveChanges(); // Dəyişikliklər DB-yə tətbiq olunur
        return entity;
    }
}
