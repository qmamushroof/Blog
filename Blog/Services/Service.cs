using Blog.Repositories.Interfaces;
using Blog.Services.Interfaces;

namespace Blog.Services
{
    public class Service<T> : IService<T> where T : class
    {
        private readonly IRepository<T> _repository;

        public Service(IRepository<T> repository) => _repository = repository;

        public async Task<int> AddAsync(T entity)
        {
            await _repository.AddAsync(entity);
            return await _repository.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync() => await _repository.GetAllAsync();

        public async Task<T?> GetByIdAsync(int id) => await _repository.GetByIdAsync(id);

        public async Task<T?> GetBySlugAsync(string slug) => await _repository.GetBySlugAsync(slug);

        public async Task<int> RemoveAsync(T entity)
        {
            _repository.Remove(entity);
            return await _repository.SaveChangesAsync();
        }

        public async Task<int> UpdateAsync(T entity)
        {
            _repository.Update(entity);
            return await _repository.SaveChangesAsync();
        }
    }
}
