﻿// <auto-generated />
using System;
using Aula3.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Aula3.Migrations
{
    [DbContext(typeof(Aula3Context))]
    [Migration("20241007173131_CreateCourses")]
    partial class CreateCourses
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Aula3.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("State")
                        .HasColumnType("bit");

                    b.Property<DateTime>("date")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("Aula3.Models.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<decimal>("Cost")
                        .HasColumnType("money");

                    b.Property<int>("Credits")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("State")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Course");
                });

            modelBuilder.Entity("Aula3.Models.Course", b =>
                {
                    b.HasOne("Aula3.Models.Category", "Category")
                        .WithMany("Courses")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Aula3.Models.Category", b =>
                {
                    b.Navigation("Courses");
                });
#pragma warning restore 612, 618
        }
    }
}
