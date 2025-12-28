using Blog.Models.Enums;

namespace Blog.Models.Entities
{
    public class Subscriber
    {
        public int Id { get; set; }

        public string Email { get; set; } = string.Empty;
        public DateTime SubscribedAt { get; set; } = DateTime.UtcNow;
        public SubscriptionStatus Status { get; set; } = SubscriptionStatus.Subscribed;
        public DateTime? UnsubscribedAt { get; set; }
    }
}