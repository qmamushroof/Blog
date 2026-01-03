using System.ComponentModel.DataAnnotations.Schema;
using System.Net;

namespace Blog.Models.Entities
{
    public class ShareTrack
    {
        public int Id { get; set; }

        public string? Platform { get; set; }
        public string? ShareUrl { get; set; }
        public DateTime SharedAt { get; set; } = DateTime.UtcNow;

        public IPAddress? UserIp { get; set; }

        [ForeignKey(nameof(Post))]
        public int PostId { get; set; }
        public Post? Post { get; set; }
    }
}