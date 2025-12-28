using Blog.Models.Enums;
using Blog.Repositories.Interfaces;

namespace Blog.Services
{
    public class SubscriptionService
    {
        private readonly ISubscriberRepository _subscriberRepository;

        public SubscriptionService(ISubscriberRepository subscriberRepository) => _subscriberRepository = subscriberRepository;

        public async Task<int> UnsubscribeByIdAsync(int id)
        {
            var subscriber = await _subscriberRepository.GetByIdAsync(id);
            subscriber!.Status = SubscriptionStatus.Unsubscribed;
            subscriber.UnsubscribedAt = DateTime.UtcNow;
            return await _subscriberRepository.SaveChangesAsync();
        }
    }
}