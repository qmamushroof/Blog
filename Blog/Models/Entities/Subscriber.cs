using System.ComponentModel.DataAnnotations;

namespace Blog.Models.Entities
{
    public class Subscriber
    {
        [Key]
        public int Id { get; set; }

        public string? Email { get; set; }
        public DateTime SubscribedAt { get; set; }
    }
}
