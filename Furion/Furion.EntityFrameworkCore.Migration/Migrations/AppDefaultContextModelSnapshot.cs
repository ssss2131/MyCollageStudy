﻿// <auto-generated />
using System;
using Furion.EntitFramework.Core.MyDbContext.sqlLite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Furion.EntityFrameworkCore.MyMigration.Migrations
{
    [DbContext(typeof(AppDefaultContext))]
    partial class AppDefaultContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.6");

            modelBuilder.Entity("Furion.Core.Model.Furion.TypeBuilder.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset>("CreatedTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<DateTimeOffset?>("UpdatedTime")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("Name");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("Furion.Core.Model.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Age")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset>("CreatedTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("TEXT");

                    b.Property<DateTimeOffset?>("UpdatedTime")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Person", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
