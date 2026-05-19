using System.Linq.Expressions;

namespace Hal_Taalam.Repository.Interface
{
    public interface IGenericRepository<T> where T : class
    {
        IQueryable<T> GetAll(Expression<Func<T, bool>>? expression = null, bool tracked = true, params Expression<Func<T, object>>[] inculdeProp);


        T? GetOne(Expression<Func<T, bool>>? expression = null, bool tracked = true, params Expression<Func<T, object>>[] inculdeProp);

        T? Find(Expression<Func<T, bool>> expression, bool tracked = true);

        Task<T> GetById(object id);
        Task Add(T entity);
        void Update(T entity);
        void DeleteById(T entity);
        Task<int> GetCount();
        Task SaveChangesAsync();

    }
}
