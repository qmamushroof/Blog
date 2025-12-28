using Blog.Models.Entities;
using Blog.Models.ViewModels;

namespace Blog.Services.Interfaces
{
    public interface ISubscriptionService : IService<Subscriber>
    {
        Task<int> UnsubscribeByIdAsync(int id);
    }
}