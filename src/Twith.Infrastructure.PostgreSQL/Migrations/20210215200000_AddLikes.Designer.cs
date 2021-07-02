﻿// <auto-generated />

using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Twith.Infrastructure.PostgreSQL.Data;

namespace Twith.Infrastructure.PostgreSQL.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210215200000_AddLikes")]
    partial class AddLikes
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityByDefaultColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("Twith.Domain.Twith.Entities.Like", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("TwithId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("TwithId");

                    b.ToTable("Likes");
                });

            modelBuilder.Entity("Twith.Domain.Twith.Entities.Twith", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("_likesCount")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(0)
                        .HasColumnName("LikesCount");

                    b.HasKey("Id");

                    b.ToTable("Twiths");
                });

            modelBuilder.Entity("Twith.Domain.User.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Twith.Domain.Twith.Entities.Like", b =>
                {
                    b.HasOne("Twith.Domain.Twith.Entities.Twith", "Twith")
                        .WithMany("Likes")
                        .HasForeignKey("TwithId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("Twith.Domain.Twith.ValueObjects.Author", "Author", b1 =>
                        {
                            b1.Property<Guid>("LikeId")
                                .HasColumnType("uuid");

                            b1.Property<Guid>("Id")
                                .HasColumnType("uuid")
                                .HasColumnName("AuthorIdentificator");

                            b1.HasKey("LikeId");

                            b1.ToTable("Likes");

                            b1.WithOwner()
                                .HasForeignKey("LikeId");

                            b1.OwnsOne("Twith.Domain.Common.ValueObjects.Name", "FirstName", b2 =>
                                {
                                    b2.Property<Guid>("AuthorLikeId")
                                        .HasColumnType("uuid");

                                    b2.Property<string>("Value")
                                        .IsRequired()
                                        .HasMaxLength(100)
                                        .HasColumnType("varchar(100)")
                                        .HasColumnName("AuthorFirstName");

                                    b2.HasKey("AuthorLikeId");

                                    b2.ToTable("Likes");

                                    b2.WithOwner()
                                        .HasForeignKey("AuthorLikeId");
                                });

                            b1.OwnsOne("Twith.Domain.Common.ValueObjects.Name", "LastName", b2 =>
                                {
                                    b2.Property<Guid>("AuthorLikeId")
                                        .HasColumnType("uuid");

                                    b2.Property<string>("Value")
                                        .IsRequired()
                                        .HasMaxLength(100)
                                        .HasColumnType("varchar(100)")
                                        .HasColumnName("AuthorLastName");

                                    b2.HasKey("AuthorLikeId");

                                    b2.ToTable("Likes");

                                    b2.WithOwner()
                                        .HasForeignKey("AuthorLikeId");
                                });

                            b1.OwnsOne("Twith.Domain.Common.ValueObjects.NickName", "NickName", b2 =>
                                {
                                    b2.Property<Guid>("AuthorLikeId")
                                        .HasColumnType("uuid");

                                    b2.Property<string>("Value")
                                        .IsRequired()
                                        .HasMaxLength(100)
                                        .HasColumnType("varchar(100)")
                                        .HasColumnName("AuthorNickName");

                                    b2.HasKey("AuthorLikeId");

                                    b2.ToTable("Likes");

                                    b2.WithOwner()
                                        .HasForeignKey("AuthorLikeId");
                                });

                            b1.Navigation("FirstName")
                                .IsRequired();

                            b1.Navigation("LastName")
                                .IsRequired();

                            b1.Navigation("NickName")
                                .IsRequired();
                        });

                    b.Navigation("Author")
                        .IsRequired();

                    b.Navigation("Twith");
                });

            modelBuilder.Entity("Twith.Domain.Twith.Entities.Twith", b =>
                {
                    b.OwnsOne("Twith.Domain.Twith.ValueObjects.Author", "Author", b1 =>
                        {
                            b1.Property<Guid>("TwithId")
                                .HasColumnType("uuid");

                            b1.Property<Guid>("Id")
                                .HasColumnType("uuid")
                                .HasColumnName("AuthorId");

                            b1.HasKey("TwithId");

                            b1.ToTable("Twiths");

                            b1.WithOwner()
                                .HasForeignKey("TwithId");

                            b1.OwnsOne("Twith.Domain.Common.ValueObjects.Name", "FirstName", b2 =>
                                {
                                    b2.Property<Guid>("AuthorTwithId")
                                        .HasColumnType("uuid");

                                    b2.Property<string>("Value")
                                        .IsRequired()
                                        .HasMaxLength(100)
                                        .HasColumnType("varchar(100)")
                                        .HasColumnName("AuthorFirstName");

                                    b2.HasKey("AuthorTwithId");

                                    b2.ToTable("Twiths");

                                    b2.WithOwner()
                                        .HasForeignKey("AuthorTwithId");
                                });

                            b1.OwnsOne("Twith.Domain.Common.ValueObjects.Name", "LastName", b2 =>
                                {
                                    b2.Property<Guid>("AuthorTwithId")
                                        .HasColumnType("uuid");

                                    b2.Property<string>("Value")
                                        .IsRequired()
                                        .HasMaxLength(100)
                                        .HasColumnType("varchar(100)")
                                        .HasColumnName("AuthorLastName");

                                    b2.HasKey("AuthorTwithId");

                                    b2.ToTable("Twiths");

                                    b2.WithOwner()
                                        .HasForeignKey("AuthorTwithId");
                                });

                            b1.OwnsOne("Twith.Domain.Common.ValueObjects.NickName", "NickName", b2 =>
                                {
                                    b2.Property<Guid>("AuthorTwithId")
                                        .HasColumnType("uuid");

                                    b2.Property<string>("Value")
                                        .IsRequired()
                                        .HasMaxLength(100)
                                        .HasColumnType("varchar(100)")
                                        .HasColumnName("AuthorNickName");

                                    b2.HasKey("AuthorTwithId");

                                    b2.ToTable("Twiths");

                                    b2.WithOwner()
                                        .HasForeignKey("AuthorTwithId");
                                });

                            b1.Navigation("FirstName")
                                .IsRequired();

                            b1.Navigation("LastName")
                                .IsRequired();

                            b1.Navigation("NickName")
                                .IsRequired();
                        });

                    b.OwnsOne("Twith.Domain.Twith.ValueObjects.Content", "Content", b1 =>
                        {
                            b1.Property<Guid>("TwithId")
                                .HasColumnType("uuid");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasMaxLength(140)
                                .HasColumnType("varchar(140)")
                                .HasColumnName("Content");

                            b1.HasKey("TwithId");

                            b1.ToTable("Twiths");

                            b1.WithOwner()
                                .HasForeignKey("TwithId");
                        });

                    b.Navigation("Author")
                        .IsRequired();

                    b.Navigation("Content")
                        .IsRequired();
                });

            modelBuilder.Entity("Twith.Domain.User.Entities.User", b =>
                {
                    b.OwnsOne("Twith.Domain.Common.ValueObjects.Name", "FirstName", b1 =>
                        {
                            b1.Property<Guid>("UserId")
                                .HasColumnType("uuid");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("varchar(100)")
                                .HasColumnName("FirstName");

                            b1.HasKey("UserId");

                            b1.ToTable("Users");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.OwnsOne("Twith.Domain.Common.ValueObjects.Name", "LastName", b1 =>
                        {
                            b1.Property<Guid>("UserId")
                                .HasColumnType("uuid");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("varchar(100)")
                                .HasColumnName("LastName");

                            b1.HasKey("UserId");

                            b1.ToTable("Users");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.OwnsOne("Twith.Domain.Common.ValueObjects.NickName", "NickName", b1 =>
                        {
                            b1.Property<Guid>("UserId")
                                .HasColumnType("uuid");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("varchar(100)")
                                .HasColumnName("NickName");

                            b1.HasKey("UserId");

                            b1.HasIndex("Value")
                                .IsUnique();

                            b1.ToTable("Users");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.OwnsOne("Twith.Domain.User.ValueObjects.Email", "Email", b1 =>
                        {
                            b1.Property<Guid>("UserId")
                                .HasColumnType("uuid");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasMaxLength(255)
                                .HasColumnType("varchar(255)")
                                .HasColumnName("Email");

                            b1.HasKey("UserId");

                            b1.HasIndex("Value")
                                .IsUnique();

                            b1.ToTable("Users");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.Navigation("Email")
                        .IsRequired();

                    b.Navigation("FirstName")
                        .IsRequired();

                    b.Navigation("LastName")
                        .IsRequired();

                    b.Navigation("NickName")
                        .IsRequired();
                });

            modelBuilder.Entity("Twith.Domain.Twith.Entities.Twith", b =>
                {
                    b.Navigation("Likes");
                });
#pragma warning restore 612, 618
        }
    }
}