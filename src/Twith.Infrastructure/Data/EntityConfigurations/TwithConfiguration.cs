using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Twith.Infrastructure.Data.EntityConfigurations
{
    public class TwithConfiguration : IEntityTypeConfiguration<Domain.Twith.Entities.Twith>
    {
        public void Configure(EntityTypeBuilder<Domain.Twith.Entities.Twith> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id)
                .HasColumnType("uuid");
            
            builder.OwnsOne(t => t.Content, c =>
            {
                c.Property(x => x.Value)
                    .HasMaxLength(140)
                    .HasColumnName("content")
                    .HasColumnType("varchar(140)")
                    .IsRequired();
            });
            
            builder.OwnsOne(t => t.Author, a =>
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
            
            builder.Property<int>("_likesCount")
                .HasColumnName("likes_count")
                .HasDefaultValue(0);
            
            builder.HasMany(t => t.Likes)
                .WithOne(l => l.Twith);
            
            builder.Property(t => t.CreatedAt).IsRequired();
            builder.Property(t => t.UpdatedAt);
        }
    }
}