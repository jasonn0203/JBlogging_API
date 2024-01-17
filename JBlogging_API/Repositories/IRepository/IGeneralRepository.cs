namespace JBlogging_API.Repositories.IRepository
{
    public interface IGeneralRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();

        Task<T?> GetByIDAsync(int id);

        Task<IEnumerable<T?>?> GetByNameAsync(string name);

        Task AddAsync(T entity);

        Task UpdateAsync(int id, T entity);

        Task DeleteAsync(int id);
    }
}
