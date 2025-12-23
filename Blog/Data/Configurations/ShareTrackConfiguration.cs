using Blog.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Blog.Data.Configurations
{
    public class ShareTrackConfiguration
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ShareTrack>(entity =>
            {
                entity.HasIndex(st => st.PostId);

                entity.Property(st => st.Platform).HasMaxLength(100);

                entity.HasOne(st => st.Post).WithMany(p => p.ShareTracks)
                .HasForeignKey(st => st.PostId).OnDelete(DeleteBehavior.SetNull);
            });
        }
    }
}
