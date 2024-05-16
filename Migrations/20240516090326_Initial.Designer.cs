﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using better_list_app_backend_dotnet.Data;

#nullable disable

namespace better_list_app_backend_dotnet.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240516090326_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("better_list_app_backend_dotnet.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CategoryTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Emoji")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<int?>("ParentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryTypeId");

                    b.HasIndex("ParentId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("better_list_app_backend_dotnet.Models.CategoryType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("CategoryTypes");
                });

            modelBuilder.Entity("better_list_app_backend_dotnet.Models.Entry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Image")
                        .HasColumnType("longtext");

                    b.Property<bool>("IsDone")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Url")
                        .HasColumnType("longtext");

                    b.Property<string>("Value")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Entries");
                });

            modelBuilder.Entity("better_list_app_backend_dotnet.Models.Category", b =>
                {
                    b.HasOne("better_list_app_backend_dotnet.Models.CategoryType", "CategoryType")
                        .WithMany()
                        .HasForeignKey("CategoryTypeId");

                    b.HasOne("better_list_app_backend_dotnet.Models.Category", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentId");

                    b.Navigation("CategoryType");

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("better_list_app_backend_dotnet.Models.Entry", b =>
                {
                    b.HasOne("better_list_app_backend_dotnet.Models.Category", "Category")
                        .WithMany("Entries")
                        .HasForeignKey("CategoryId");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("better_list_app_backend_dotnet.Models.Category", b =>
                {
                    b.Navigation("Children");

                    b.Navigation("Entries");
                });
#pragma warning restore 612, 618
        }
    }
}