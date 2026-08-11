using System.Net;

namespace proj1.Repos
{
    public interface IRepos<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<T> AddAsync(T entity);//insert        
        Task<T> Update(T entity);
        Task<T> Delete(T entity);
    }
}
