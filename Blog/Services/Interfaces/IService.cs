namespace Blog.Services.Interfaces
{
    public interface IService<T> where T : class
    {
        Task<T?> GetByIdAsync(long id);
        Task<T?> GetBySlugAsync(string slug);
        Task<IEnumerable<T>> GetAllAsync();
        Task<int> CreateAsync(T entity);
        Task<int> UpdateAsync(T entity);
        Task<int> DeleteByIdAsync(long id);
    }
}