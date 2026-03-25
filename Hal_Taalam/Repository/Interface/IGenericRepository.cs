namespace Hal_Taalam.Repository.Interface
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(object id);
        void Add(T entity);
        void Update(T entity);
        void DeleteById(T entity);
        Task SaveChangesAsync();

    }
}
