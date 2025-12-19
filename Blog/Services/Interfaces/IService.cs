namespace Blog.Services.Interfaces
{
    public interface IService<T> where T : class
    {
        Task<T?> GetByIdAsync(int id);
        Task<T?> GetBySlugAsync(string slug);

        Task<IEnumerable<T>> GetAllAsync();
        Task<int> AddAsync(T entity);
        Task<int> UpdateAsync(T entity);
        Task<int> RemoveAsync(T entity);
    }
}
