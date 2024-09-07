﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NotificationProgect.Repositories;

#nullable disable

namespace NotificationProgect.Migrations
{
    [DbContext(typeof(ToDoDbContext))]
    partial class ToDoDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("NotificationProgect.Entity.ToDoModelEntity", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<bool?>("Complited")
                        .HasColumnType("bit")
                        .HasColumnName("Complited");

                    b.Property<string>("Contact")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)")
                        .HasColumnName("Contact");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasMaxLength(1024)
                        .HasColumnType("nvarchar(1024)")
                        .HasColumnName("Description");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("EndDate");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("StartDate");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("ToDo", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
