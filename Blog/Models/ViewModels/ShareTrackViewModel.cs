namespace Blog.Models.ViewModels
{
    public class ShareTrackViewModel
    {
        public int Id { get; set; }

        public string PostTitle { get; set; } = string.Empty;

        public string? Platform { get; set; }
        public string? ShareUrl { get; set; }
        public DateTime SharedAt { get; set; }

        public string? UserIp { get; set; }
        public int PostId { get; set; }
    }
}
