using Blog.Models.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Models.ViewModels
{
    public class CommentViewModel : BaseViewModel
    {
        public int PostId { get; set; }
    }
}