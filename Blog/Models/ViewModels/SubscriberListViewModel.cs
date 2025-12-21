using Blog.Models.Enums;

namespace Blog.Models.ViewModels
{
    public class SubscriberListViewModel
    {
        public int Id { get; set; }

        public string Email { get; set; } = string.Empty;
        public DateTime SubscribedAt { get; set; }
        public string Status { get; set; }
        public DateTime? UnsubscribedAt { get; set; }
    }
}
