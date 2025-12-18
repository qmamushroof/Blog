using Blog.Models.Entities;
using Blog.Models.ViewModels;

namespace Blog.Services.Interfaces
{
    public interface ISubscriptionService
    {
        Task<List<Subscriber>> GetSubscribersAsync();
        Task<Subscriber> CreateSubscriberAsync(SubscribeViewModel viewModel);
    }
}
