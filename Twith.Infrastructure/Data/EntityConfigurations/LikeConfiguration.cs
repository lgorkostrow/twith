using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Twith.Domain.Twith.Entities;

namespace Twith.Infrastructure.Data.EntityConfigurations
{
    public class LikeConfiguration : IEntityTypeConfiguration<Like>
    {
        public void Configure(EntityTypeBuilder<Like> builder)
        {
            builder.ToTable("Likes");
            builder.HasKey(l => l.Id);
            builder.Property(l => l.Id)
                .ValueGeneratedNever()
                .HasColumnType("uuid");

            builder.OwnsOne(l => l.Author, a =>
            {
                a.Property(p => p.Id)
                    .HasColumnName("AuthorIdentificator")
                    .HasColumnType("uuid")
                    .IsRequired();

                a.OwnsOne(p => p.FirstName, fn =>
                {
                    fn.Property(x => x.Value)
                        .HasMaxLength(100)
                        .HasColumnName("AuthorFirstName")
                        .HasColumnType("varchar(100)")
                        .IsRequired();
                });

                a.OwnsOne(p => p.LastName, fn =>
                {
                    fn.Property(x => x.Value)
                        .HasMaxLength(100)
                        .HasColumnName("AuthorLastName")
                        .HasColumnType("varchar(100)")
                        .IsRequired();
                });

                a.OwnsOne(p => p.NickName, fn =>
                {
                    fn.Property(x => x.Value)
                        .HasMaxLength(100)
                        .HasColumnName("AuthorNickName")
                        .HasColumnType("varchar(100)")
                        .IsRequired();
                });
            });
        }
    }
}