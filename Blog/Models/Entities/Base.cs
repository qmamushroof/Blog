using System.ComponentModel.DataAnnotations;

namespace Blog.Models.Entities
{
    public class Base
    {
        [Key]
        public int Id { get; set; }
    }
}
