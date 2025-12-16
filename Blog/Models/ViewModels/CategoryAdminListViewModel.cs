namespace Blog.Models.ViewModels
{
    public class CategoryAdminListViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }

        public int PostCount { get; set; }
    }
}
