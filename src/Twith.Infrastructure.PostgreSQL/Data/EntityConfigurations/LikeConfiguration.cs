using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Twith.Domain.Twith.Entities;

namespace Twith.Infrastructure.PostgreSQL.Data.EntityConfigurations
{
    public class LikeConfiguration : IEntityTypeConfiguration<Like>
    {
        public void Configure(EntityTypeBuilder<Like> builder)
        {
            builder.ToTable("likes");
            builder.HasKey(l => l.Id);
            builder.Property(l => l.Id)
                .ValueGeneratedNever()
                .HasColumnType("uuid");

            builder.OwnsOne(l => l.Author, a =>
            {
                a.Property(p => p.Id)
                    .HasColumnName("author_id")
                    .HasColumnType("uuid")
                    .IsRequired();

                a.OwnsOne(p => p.FirstName, fn =>
                {
                    fn.Property(x => x.Value)
                        .HasMaxLength(100)
                        .HasColumnName("author_first_name")
                        .HasColumnType("varchar(100)")
                        .IsRequired();
                });

                a.OwnsOne(p => p.LastName, fn =>
                {
                    fn.Property(x => x.Value)
                        .HasMaxLength(100)
                        .HasColumnName("author_last_name")
                        .HasColumnType("varchar(100)")
                        .IsRequired();
                });

                a.OwnsOne(p => p.NickName, fn =>
                {
                    fn.Property(x => x.Value)
                        .HasMaxLength(100)
                        .HasColumnName("author_nick_name")
                        .HasColumnType("varchar(100)")
                        .IsRequired();
                });
            });
            
            builder.Property(l => l.CreatedAt).IsRequired();
            builder.Property(l => l.UpdatedAt);
        }
    }
}