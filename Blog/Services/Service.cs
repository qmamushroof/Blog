using Blog.Repositories.Interfaces;
using Blog.Services.Interfaces;

namespace Blog.Services
{
    public class Service<T> : IService<T> where T : class
    {
        private readonly IRepository<T> _repository;

        public Service(IRepository<T> repository) => _repository = repository;

        public async Task<T?> GetByIdAsync(long id) => await _repository.GetByIdAsync(id);

        public async Task<IEnumerable<T>> GetAllAsync() => await _repository.GetAllAsync();

        public virtual async Task<int> CreateAsync(T entity)
        {
            await _repository.AddAsync(entity);
            return await _repository.SaveChangesAsync();
        }

        public virtual async Task<int> UpdateAsync(T entity)
        {
            _repository.Update(entity);
            return await _repository.SaveChangesAsync();
        }

        public async Task<int> DeleteByIdAsync(long id)
        {
            var entity = await GetByIdAsync(id);
            _repository.Remove(entity!);
            return await _repository.SaveChangesAsync();
        }
    }
}