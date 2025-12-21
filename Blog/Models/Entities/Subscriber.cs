using Blog.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace Blog.Models.Entities
{
    public class Subscriber
    {
        [Key]
        public int Id { get; set; }

        public string Email { get; set; } = string.Empty;
        public DateTime SubscribedAt { get; set; } = DateTime.UtcNow;
        public SubscriptionStatus Status { get; set; } = SubscriptionStatus.Subscribed;
        public DateTime? UnsubscribedAt { get; set; }
    }
}
