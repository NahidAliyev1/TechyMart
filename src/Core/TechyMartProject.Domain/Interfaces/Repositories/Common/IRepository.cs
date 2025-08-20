using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TechyMartProject.Domain.Entities.Common;

namespace TechyMartProject.Domain.Interfaces.Repositories.Common;
public interface IRepository<T> where T : BaseEntity,new()
{
    Task<T?> FindAsync(Expression<Func<T, bool>> predicate, params string[] includes);
    Task<T?> FindByIdAsync(int id, params string[] includes);
    IQueryable<T>? GetAll(Expression<Func<T, bool>>? expression = null, params string[] includes);
    Task<T> CreateAsync(T entity);
    T Update(T entity);
    void Delete(T entity);

}
