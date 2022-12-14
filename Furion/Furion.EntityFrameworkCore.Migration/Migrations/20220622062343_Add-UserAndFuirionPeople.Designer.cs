// <auto-generated />
using System;
using Furion.EntitFramework.Core.MyDbContext.sqlLite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Furion.EntityFrameworkCore.MyMigration.Migrations
{
    [DbContext(typeof(AppDefaultContext))]
    [Migration("20220622062343_Add-UserAndFuirionPeople")]
    partial class AddUserAndFuirionPeople
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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
#pragma warning restore 612, 618
        }
    }
}
