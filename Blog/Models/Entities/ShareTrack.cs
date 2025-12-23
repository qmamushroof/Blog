using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Models.Entities
{
    public class ShareTrack
    {
        [Key]
        public int Id { get; set; }

        public string? Platform { get; set; }
        public string? ShareUrl { get; set; }
        public DateTime SharedAt { get; set; } = DateTime.UtcNow;

        public string? UserIp { get; set; }

        [ForeignKey(nameof(Post))]
        public int? PostId { get; set; }
        public Post? Post { get; set; }
    }
}
