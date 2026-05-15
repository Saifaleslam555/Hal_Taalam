using Hal_Taalam.Data;
using Hal_Taalam.Repository.Interface;
using Microsoft.EntityFrameworkCore;
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

        //Task<T> IGenericRepository<T>.Add(T entity)
        //{
        //     context.Set<T>().Add(entity);

        //}

        //Task<T> IGenericRepository<T>.DeleteById(Guid id)
        //{
        //    throw new NotImplementedException();
        //}

        public IEnumerable<T> GetAll() 
        {
           return _dbSet.ToList();
        }

        public T GetById(object id)
        {
            return _dbSet.Find(id);
        }

        // Task<T> IGenericRepository<T>.GetById(Guid id)
        //{
        //    return _dbSet.FirstOrDefault(e=>e.Id==id); 
        //}

        //Task<T> IGenericRepository<T>.SaveChangesAsync()
        //{
        //    throw new NotImplementedException();
        //}

        //Task<T> IGenericRepository<T>.Update(T entity)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
