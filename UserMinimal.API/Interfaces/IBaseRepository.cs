using System.Linq.Expressions;
using UserMinimal.API.Constants;

namespace UserMinimal.API.Interfaces;
public interface IBaseRepository<T> where T : class
{
    T GetById(int id);
    Task<T> GetByIdAsync(int id);
    List<T> GetAll();
    Task<List<T>> GetAllAsync();
    T Find(Expression<Func<T, bool>> criteria, string[] includes = null);
    List<T> FindAll(Expression<Func<T, bool>> criteria, string[] includes = null);
    List<T> FindAll(Expression<Func<T, bool>> criteria, int skip, int take, string[] includes = null);
    List<T> FindAll(Expression<Func<T, bool>> criteria, int? skip, int? take, string[] includes = null, Expression<Func<T, object>> orderBy = null, string orderbyDirection = OrderBy.Asending);
    T Add(T entity);
    Task<T> AddAsync(T entity);
    List<T> AddRange(List<T> entities);
    Task<List<T>> AddRangeAsync(List<T> entities);
    T Update(T entity);
    void Delete(T entity);
    void DeleteRange(List<T> entities);
    void Attach(T entity);
    int Count();
    int Count(Expression<Func<T, bool>> criteria);
}
