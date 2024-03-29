﻿// <auto-generated />
using Bulky.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Bulky.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    [Migration("20240322182526_AddCategoryTable")]
    partial class AddCategoryTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Bulky.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DisplayOrder")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Category");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DisplayOrder = 8,
                            Name = "Category 1"
                        },
                        new
                        {
                            Id = 2,
                            DisplayOrder = 8,
                            Name = "Category 2"
                        },
                        new
                        {
                            Id = 3,
                            DisplayOrder = 8,
                            Name = "Category 3"
                        },
                        new
                        {
                            Id = 4,
                            DisplayOrder = 8,
                            Name = "Category 4"
                        },
                        new
                        {
                            Id = 5,
                            DisplayOrder = 8,
                            Name = "Category 5"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
