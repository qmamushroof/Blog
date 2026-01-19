namespace Blog.Models.Enums
{
    public enum PostStatus : byte
    {
        Draft = 0,
        Published = 1,
        Expired = 2,
        SoftDeleted = 3
    }
}