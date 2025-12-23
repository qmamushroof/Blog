using Blog.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Blog.Data.Configurations
{
    public static class BlogConfiguration
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            PostConfiguration.Configure(modelBuilder);
            CategoryConfiguration.Configure(modelBuilder);
            TagConfiguration.Configure(modelBuilder);
            PostTagConfiguration.Configure(modelBuilder);
            SubscriberConfiguration.Configure(modelBuilder);
            ShareTrackConfiguration.Configure(modelBuilder);
        }
    }
}
