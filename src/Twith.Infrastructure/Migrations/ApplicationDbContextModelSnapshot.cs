﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Twith.Infrastructure.Data;

namespace Twith.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityByDefaultColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("Twith.Domain.Twith.Entities.Like", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("created_at");

                    b.Property<Guid>("TwithId")
                        .HasColumnType("uuid")
                        .HasColumnName("twith_id");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("updated_at");

                    b.HasKey("Id")
                        .HasName("pk_likes");

                    b.HasIndex("TwithId")
                        .HasDatabaseName("ix_likes_twith_id");

                    b.ToTable("likes");
                });

            modelBuilder.Entity("Twith.Domain.Twith.Entities.Twith", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("created_at");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("updated_at");

                    b.Property<int>("_likesCount")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(0)
                        .HasColumnName("likes_count");

                    b.HasKey("Id")
                        .HasName("pk_twiths");

                    b.ToTable("twiths");
                });

            modelBuilder.Entity("Twith.Domain.User.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("created_at");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("updated_at");

                    b.HasKey("Id")
                        .HasName("pk_users");

                    b.ToTable("users");
                });

            modelBuilder.Entity("Twith.Domain.Twith.Entities.Like", b =>
                {
                    b.HasOne("Twith.Domain.Twith.Entities.Twith", "Twith")
                        .WithMany("Likes")
                        .HasForeignKey("TwithId")
                        .HasConstraintName("fk_likes_twiths_twith_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("Twith.Domain.Twith.ValueObjects.Author", "Author", b1 =>
                        {
                            b1.Property<Guid>("LikeId")
                                .HasColumnType("uuid")
                                .HasColumnName("id");

                            b1.Property<Guid>("Id")
                                .HasColumnType("uuid")
                                .HasColumnName("author_id");

                            b1.HasKey("LikeId")
                                .HasName("pk_likes");

                            b1.ToTable("likes");

                            b1.WithOwner()
                                .HasForeignKey("LikeId")
                                .HasConstraintName("fk_likes_likes_id");

                            b1.OwnsOne("Twith.Domain.Common.ValueObjects.Name", "FirstName", b2 =>
                                {
                                    b2.Property<Guid>("AuthorLikeId")
                                        .HasColumnType("uuid")
                                        .HasColumnName("id");

                                    b2.Property<string>("Value")
                                        .IsRequired()
                                        .HasMaxLength(100)
                                        .HasColumnType("varchar(100)")
                                        .HasColumnName("author_first_name");

                                    b2.HasKey("AuthorLikeId")
                                        .HasName("pk_likes");

                                    b2.ToTable("likes");

                                    b2.WithOwner()
                                        .HasForeignKey("AuthorLikeId")
                                        .HasConstraintName("fk_likes_likes_id");
                                });

                            b1.OwnsOne("Twith.Domain.Common.ValueObjects.Name", "LastName", b2 =>
                                {
                                    b2.Property<Guid>("AuthorLikeId")
                                        .HasColumnType("uuid")
                                        .HasColumnName("id");

                                    b2.Property<string>("Value")
                                        .IsRequired()
                                        .HasMaxLength(100)
                                        .HasColumnType("varchar(100)")
                                        .HasColumnName("author_last_name");

                                    b2.HasKey("AuthorLikeId")
                                        .HasName("pk_likes");

                                    b2.ToTable("likes");

                                    b2.WithOwner()
                                        .HasForeignKey("AuthorLikeId")
                                        .HasConstraintName("fk_likes_likes_id");
                                });

                            b1.OwnsOne("Twith.Domain.Common.ValueObjects.NickName", "NickName", b2 =>
                                {
                                    b2.Property<Guid>("AuthorLikeId")
                                        .HasColumnType("uuid")
                                        .HasColumnName("id");

                                    b2.Property<string>("Value")
                                        .IsRequired()
                                        .HasMaxLength(100)
                                        .HasColumnType("varchar(100)")
                                        .HasColumnName("author_nick_name");

                                    b2.HasKey("AuthorLikeId")
                                        .HasName("pk_likes");

                                    b2.ToTable("likes");

                                    b2.WithOwner()
                                        .HasForeignKey("AuthorLikeId")
                                        .HasConstraintName("fk_likes_likes_id");
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
                                .HasColumnType("uuid")
                                .HasColumnName("id");

                            b1.Property<Guid>("Id")
                                .HasColumnType("uuid")
                                .HasColumnName("author_id");

                            b1.HasKey("TwithId")
                                .HasName("pk_twiths");

                            b1.ToTable("twiths");

                            b1.WithOwner()
                                .HasForeignKey("TwithId")
                                .HasConstraintName("fk_twiths_twiths_id");

                            b1.OwnsOne("Twith.Domain.Common.ValueObjects.Name", "FirstName", b2 =>
                                {
                                    b2.Property<Guid>("AuthorTwithId")
                                        .HasColumnType("uuid")
                                        .HasColumnName("id");

                                    b2.Property<string>("Value")
                                        .IsRequired()
                                        .HasMaxLength(100)
                                        .HasColumnType("varchar(100)")
                                        .HasColumnName("author_first_name");

                                    b2.HasKey("AuthorTwithId")
                                        .HasName("pk_twiths");

                                    b2.ToTable("twiths");

                                    b2.WithOwner()
                                        .HasForeignKey("AuthorTwithId")
                                        .HasConstraintName("fk_twiths_twiths_id");
                                });

                            b1.OwnsOne("Twith.Domain.Common.ValueObjects.Name", "LastName", b2 =>
                                {
                                    b2.Property<Guid>("AuthorTwithId")
                                        .HasColumnType("uuid")
                                        .HasColumnName("id");

                                    b2.Property<string>("Value")
                                        .IsRequired()
                                        .HasMaxLength(100)
                                        .HasColumnType("varchar(100)")
                                        .HasColumnName("author_last_name");

                                    b2.HasKey("AuthorTwithId")
                                        .HasName("pk_twiths");

                                    b2.ToTable("twiths");

                                    b2.WithOwner()
                                        .HasForeignKey("AuthorTwithId")
                                        .HasConstraintName("fk_twiths_twiths_id");
                                });

                            b1.OwnsOne("Twith.Domain.Common.ValueObjects.NickName", "NickName", b2 =>
                                {
                                    b2.Property<Guid>("AuthorTwithId")
                                        .HasColumnType("uuid")
                                        .HasColumnName("id");

                                    b2.Property<string>("Value")
                                        .IsRequired()
                                        .HasMaxLength(100)
                                        .HasColumnType("varchar(100)")
                                        .HasColumnName("author_nick_name");

                                    b2.HasKey("AuthorTwithId")
                                        .HasName("pk_twiths");

                                    b2.ToTable("twiths");

                                    b2.WithOwner()
                                        .HasForeignKey("AuthorTwithId")
                                        .HasConstraintName("fk_twiths_twiths_id");
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
                                .HasColumnType("uuid")
                                .HasColumnName("id");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasMaxLength(140)
                                .HasColumnType("varchar(140)")
                                .HasColumnName("content");

                            b1.HasKey("TwithId")
                                .HasName("pk_twiths");

                            b1.ToTable("twiths");

                            b1.WithOwner()
                                .HasForeignKey("TwithId")
                                .HasConstraintName("fk_twiths_twiths_id");
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
                                .HasColumnType("uuid")
                                .HasColumnName("id");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("varchar(100)")
                                .HasColumnName("first_name");

                            b1.HasKey("UserId")
                                .HasName("pk_users");

                            b1.ToTable("users");

                            b1.WithOwner()
                                .HasForeignKey("UserId")
                                .HasConstraintName("fk_users_users_id");
                        });

                    b.OwnsOne("Twith.Domain.Common.ValueObjects.Name", "LastName", b1 =>
                        {
                            b1.Property<Guid>("UserId")
                                .HasColumnType("uuid")
                                .HasColumnName("id");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("varchar(100)")
                                .HasColumnName("last_name");

                            b1.HasKey("UserId")
                                .HasName("pk_users");

                            b1.ToTable("users");

                            b1.WithOwner()
                                .HasForeignKey("UserId")
                                .HasConstraintName("fk_users_users_id");
                        });

                    b.OwnsOne("Twith.Domain.Common.ValueObjects.NickName", "NickName", b1 =>
                        {
                            b1.Property<Guid>("UserId")
                                .HasColumnType("uuid")
                                .HasColumnName("id");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("varchar(100)")
                                .HasColumnName("nick_name");

                            b1.HasKey("UserId")
                                .HasName("pk_users");

                            b1.HasIndex("Value")
                                .IsUnique()
                                .HasDatabaseName("ix_users_nick_name");

                            b1.ToTable("users");

                            b1.WithOwner()
                                .HasForeignKey("UserId")
                                .HasConstraintName("fk_users_users_id");
                        });

                    b.OwnsOne("Twith.Domain.User.ValueObjects.Email", "Email", b1 =>
                        {
                            b1.Property<Guid>("UserId")
                                .HasColumnType("uuid")
                                .HasColumnName("id");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasMaxLength(255)
                                .HasColumnType("varchar(255)")
                                .HasColumnName("email");

                            b1.HasKey("UserId")
                                .HasName("pk_users");

                            b1.HasIndex("Value")
                                .IsUnique()
                                .HasDatabaseName("ix_users_email_value");

                            b1.ToTable("users");

                            b1.WithOwner()
                                .HasForeignKey("UserId")
                                .HasConstraintName("fk_users_users_id");
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
