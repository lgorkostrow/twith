using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Twith.Infrastructure.Data.EntityConfigurations
{
    public class TwithConfiguration : IEntityTypeConfiguration<Domain.Twith.Entities.Twith>
    {
        public void Configure(EntityTypeBuilder<Domain.Twith.Entities.Twith> builder)
        {
            builder.ToTable("Twiths");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id)
                .HasColumnType("uuid");
            
            builder.OwnsOne(t => t.Content, c =>
            {
                c.Property(x => x.Value)
                    .HasMaxLength(140)
                    .HasColumnName("Content")
                    .HasColumnType("varchar(140)")
                    .IsRequired();
            });
            
            builder.OwnsOne(t => t.Author, a =>
            {
                a.Property(p => p.Id)
                    .HasColumnName("AuthorId")
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