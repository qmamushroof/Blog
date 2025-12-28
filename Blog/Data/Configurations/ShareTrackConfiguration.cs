using Blog.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Net;

namespace Blog.Data.Configurations
{
    public class ShareTrackConfiguration : IEntityTypeConfiguration<ShareTrack>
    {
        public void Configure(EntityTypeBuilder<ShareTrack> builder)
        {
            builder.HasIndex(st => st.PostId);

            builder.Property(st => st.Platform).HasMaxLength(100);

            builder.Property(st => st.SharedAt).HasMaxLength(500);

            builder.Property(st => st.UserIp).HasMaxLength(40)
            .HasColumnType("varbinary(16)")
            .HasConversion(
                v => v!.GetAddressBytes(),
                v => new IPAddress(v)
            );

            builder.HasOne(st => st.Post).WithMany(p => p.ShareTracks)
            .HasForeignKey(st => st.PostId).OnDelete(DeleteBehavior.SetNull);
        }
    }
}