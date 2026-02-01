using System.ComponentModel.DataAnnotations;

namespace Blog.Models.ViewModels
{
    public class ShareTrackViewModel
    {
        public long Id { get; set; }

        public string PostTitle { get; set; } = string.Empty;

        [MaxLength(100)]
        public string? Platform { get; set; }
        public string? ShareUrl { get; set; }
        public DateTime SharedAt { get; set; }

        public string? UserIp { get; set; }

        public long PostId { get; set; }
    }
}