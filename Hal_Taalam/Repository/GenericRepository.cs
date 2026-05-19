using Hal_Taalam.Data;
using Hal_Taalam.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Hal_Taalam.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly HalTaalamContext context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(HalTaalamContext context)
        {
            this.context = context;
            _dbSet=context.Set<T>();
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>>? expression = null,
            bool tracked = true,
            params Expression<Func<T, object>>[] inculdeProp)
        {
            IQueryable<T> query = _dbSet;


            if (inculdeProp != null && inculdeProp.Length > 0)
            {
                foreach (var item in inculdeProp)
                {
                    query = query.Include(item);
                }

            }
            if (expression != null)
            {
                query = query.Where(expression);
            }
            if (!tracked)
            {
                query = query.AsNoTracking();
            }
            return query;

        }

        public T? GetOne(Expression<Func<T, bool>>? expression = null,
            bool tracked = true,
            params Expression<Func<T, object>>[] inculdeProp)
        {
            return GetAll(expression, tracked, inculdeProp).FirstOrDefault();
        }

        public T? Find(Expression<Func<T, bool>> expression, bool tracked = true)
        {
            var query = _dbSet.AsQueryable();

            if (!tracked)
                query = query.AsNoTracking();

            return query.FirstOrDefault(expression);
        }

        public void Add(T entity)
        {
           _dbSet.Add(entity);
        }

        public void DeleteById(T entity)
        {
            _dbSet.Remove(entity);
        }

        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public IEnumerable<T> GetAll() 
        {
           return _dbSet.ToList();
        }

        public int GetCount()
        {
            return _dbSet.Count();
        }

        public T GetById(object id)
        {
            return _dbSet.Find(id);
        }

    }
}
