using Blog.Models.Entities;
using Blog.Models.Enums;
using Blog.Repositories.Interfaces;
using Blog.Services.Interfaces;

namespace Blog.Services
{
    public class SubscriptionService : Service<Subscriber>, ISubscriptionService
    {
        private readonly ISubscriberRepository _subscriberRepository;

        public SubscriptionService(ISubscriberRepository subscriberRepository) : base(subscriberRepository) => _subscriberRepository = subscriberRepository;

        public async Task<int> UnsubscribeByIdAsync(int id)
        {
            var subscriber = await GetByIdAsync(id);
            if (subscriber is null) return 0;
            subscriber.Status = SubscriptionStatus.Unsubscribed;
            subscriber.UnsubscribedAt = DateTime.UtcNow;
            return await _subscriberRepository.SaveChangesAsync();
        }
    }
}