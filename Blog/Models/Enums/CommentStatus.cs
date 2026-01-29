namespace Blog.Models.Enums
{
    public enum CommentStatus : byte
    {
        Approved = 0,
        Restricted = 1,
        SoftDeleted = 2
    }
}