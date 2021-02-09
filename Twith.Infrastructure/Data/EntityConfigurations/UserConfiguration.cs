using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Twith.Domain.User.Entities;

namespace Twith.Infrastructure.Data.EntityConfigurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id)
                .HasColumnType("uuid");
            
            builder.OwnsOne(u => u.Email, fn =>
            {
                fn.HasIndex(x => x.Value).IsUnique();
                fn.Property(x => x.Value)
                    .HasMaxLength(255)
                    .HasColumnName("Email")
                    .HasColumnType("varchar(255)")
                    .IsRequired();
            });
            
            builder.OwnsOne(u => u.FirstName, fn =>
            {
                fn.Property(x => x.Value)
                    .HasMaxLength(100)
                    .HasColumnName("FirstName")
                    .HasColumnType("varchar(100)")
                    .IsRequired();
            });
            
            builder.OwnsOne(u => u.LastName, fn =>
            {
                fn.Property(x => x.Value)
                    .HasMaxLength(100)
                    .HasColumnName("LastName")
                    .HasColumnType("varchar(100)")
                    .IsRequired();
            });
            
            builder.OwnsOne(u => u.NickName, fn =>
            {
                fn.HasIndex(x => x.Value).IsUnique();
                fn.Property(x => x.Value)
                    .HasMaxLength(100)
                    .HasColumnName("NickName")
                    .HasColumnType("varchar(100)")
                    .IsRequired();
            });
        }
    }
}