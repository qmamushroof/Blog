namespace Blog.Models.ViewModels
{
    public class TagAdminListViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }

        public int PostCount { get; set; }
    }
}
