﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using UniversityProject.Infrastructure.Persistance;

#nullable disable

namespace UniversityProject.Infrastructure.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20241116094943_kkkk")]
    partial class kkkk
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("UniversityProject.Domain.Entities.Auth.ApplicationUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Created_at")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("Deleted_at")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Full_name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PictureUrl")
                        .HasColumnType("text");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("country_id")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("country_id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("UniversityProject.Domain.Entities.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Bio_wikipediya")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("Created_at")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("Deleted_at")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Full_name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PictureUrl")
                        .HasColumnType("text");

                    b.Property<string>("Year")
                        .HasColumnType("text");

                    b.Property<int>("country_id")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("country_id")
                        .IsUnique();

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("UniversityProject.Domain.Entities.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Count")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Created_at")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("Deleted_at")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Length")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PictureUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Year")
                        .HasColumnType("integer");

                    b.Property<int>("author_id")
                        .HasColumnType("integer");

                    b.Property<int>("category_id")
                        .HasColumnType("integer");

                    b.Property<int>("countr_id")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("author_id");

                    b.HasIndex("category_id");

                    b.HasIndex("countr_id");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("UniversityProject.Domain.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Count")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Created_at")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("Deleted_at")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("UniversityProject.Domain.Entities.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Count")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Created_at")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("Deleted_at")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("UniversityProject.Domain.Entities.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Created_at")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("Deleted_at")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PictureUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("UniversityProject.Domain.Entities.Report", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Created_at")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("Deleted_at")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Page_name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("user_id")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("user_id")
                        .IsUnique();

                    b.ToTable("Reports");
                });

            modelBuilder.Entity("UniversityProject.Domain.Entities.Auth.ApplicationUser", b =>
                {
                    b.HasOne("UniversityProject.Domain.Entities.Country", "Country")
                        .WithMany("User")
                        .HasForeignKey("country_id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("UniversityProject.Domain.Entities.Author", b =>
                {
                    b.HasOne("UniversityProject.Domain.Entities.Country", "Country")
                        .WithOne("Author")
                        .HasForeignKey("UniversityProject.Domain.Entities.Author", "country_id");

                    b.Navigation("Country");
                });

            modelBuilder.Entity("UniversityProject.Domain.Entities.Book", b =>
                {
                    b.HasOne("UniversityProject.Domain.Entities.Author", "Author")
                        .WithMany("Books")
                        .HasForeignKey("author_id");

                    b.HasOne("UniversityProject.Domain.Entities.Category", "Category")
                        .WithMany("Books")
                        .HasForeignKey("category_id");

                    b.HasOne("UniversityProject.Domain.Entities.Country", "Country")
                        .WithMany("Books")
                        .HasForeignKey("countr_id");

                    b.Navigation("Author");

                    b.Navigation("Category");

                    b.Navigation("Country");
                });

            modelBuilder.Entity("UniversityProject.Domain.Entities.Report", b =>
                {
                    b.HasOne("UniversityProject.Domain.Entities.Auth.ApplicationUser", "User")
                        .WithOne("Report")
                        .HasForeignKey("UniversityProject.Domain.Entities.Report", "user_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("UniversityProject.Domain.Entities.Auth.ApplicationUser", b =>
                {
                    b.Navigation("Report")
                        .IsRequired();
                });

            modelBuilder.Entity("UniversityProject.Domain.Entities.Author", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("UniversityProject.Domain.Entities.Category", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("UniversityProject.Domain.Entities.Country", b =>
                {
                    b.Navigation("Author")
                        .IsRequired();

                    b.Navigation("Books");

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
