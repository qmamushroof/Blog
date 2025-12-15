using System.ComponentModel.DataAnnotations;

namespace Blog.Models.Entities
{
    public class Tag
    {
        [Key]
        public int Id { get; set; }
    }
}
