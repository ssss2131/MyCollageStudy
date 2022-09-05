﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StoreEfCore;

#nullable disable

namespace StoreEfCore.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220728075612_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ShopStoreCore.System.GoodsType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CountInType")
                        .HasColumnType("int");

                    b.Property<string>("TypeName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("GoodsType");
                });

            modelBuilder.Entity("ShopStoreCore.System.Provicy.SystemOperation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("OperationName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("SystemOperation");
                });

            modelBuilder.Entity("ShopStoreCore.System.Provicy.SystemOpRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("SystemOperationId")
                        .HasColumnType("int");

                    b.Property<int>("SystemRoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SystemOperationId");

                    b.HasIndex("SystemRoleId");

                    b.ToTable("SystemOpRole");
                });

            modelBuilder.Entity("ShopStoreCore.System.SystemGoods", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<double>("CountInSeal")
                        .HasColumnType("float");

                    b.Property<double>("CountInStore")
                        .HasColumnType("float");

                    b.Property<string>("GoodsName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("GoodsPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("GoodsTypeId")
                        .HasColumnType("int");

                    b.Property<bool>("OnSeal")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("GoodsTypeId");

                    b.ToTable("SystemGoods");
                });

            modelBuilder.Entity("ShopStoreCore.System.SystemGoodsRecord", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("BuyTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("GoodId")
                        .HasColumnType("int");

                    b.Property<bool>("IsHandled")
                        .HasColumnType("bit");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GoodId");

                    b.HasIndex("UserId");

                    b.ToTable("SystemGoodsRecord");
                });

            modelBuilder.Entity("ShopStoreCore.System.SystemMenu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("MenuName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ParentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("SystemMenu");
                });

            modelBuilder.Entity("ShopStoreCore.System.SystemRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("SystemRole");
                });

            modelBuilder.Entity("ShopStoreCore.System.SystemUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SysRoleId")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserPassword")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("SysRoleId");

                    b.ToTable("SystemUser");
                });

            modelBuilder.Entity("ShopStoreCore.System.Provicy.SystemOpRole", b =>
                {
                    b.HasOne("ShopStoreCore.System.Provicy.SystemOperation", "SystemOperation")
                        .WithMany("SystemOpRole")
                        .HasForeignKey("SystemOperationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ShopStoreCore.System.SystemRole", "SystemRole")
                        .WithMany("SystemOpRole")
                        .HasForeignKey("SystemRoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SystemOperation");

                    b.Navigation("SystemRole");
                });

            modelBuilder.Entity("ShopStoreCore.System.SystemGoods", b =>
                {
                    b.HasOne("ShopStoreCore.System.GoodsType", "GoodsType")
                        .WithMany()
                        .HasForeignKey("GoodsTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GoodsType");
                });

            modelBuilder.Entity("ShopStoreCore.System.SystemGoodsRecord", b =>
                {
                    b.HasOne("ShopStoreCore.System.SystemGoods", "SystemGoods")
                        .WithMany()
                        .HasForeignKey("GoodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ShopStoreCore.System.SystemUser", "SystemUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SystemGoods");

                    b.Navigation("SystemUser");
                });

            modelBuilder.Entity("ShopStoreCore.System.SystemMenu", b =>
                {
                    b.HasOne("ShopStoreCore.System.SystemMenu", "RootSystemMenu")
                        .WithMany()
                        .HasForeignKey("ParentId");

                    b.Navigation("RootSystemMenu");
                });

            modelBuilder.Entity("ShopStoreCore.System.SystemUser", b =>
                {
                    b.HasOne("ShopStoreCore.System.SystemRole", "SystemRole")
                        .WithMany("SystemUser")
                        .HasForeignKey("SysRoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SystemRole");
                });

            modelBuilder.Entity("ShopStoreCore.System.Provicy.SystemOperation", b =>
                {
                    b.Navigation("SystemOpRole");
                });

            modelBuilder.Entity("ShopStoreCore.System.SystemRole", b =>
                {
                    b.Navigation("SystemOpRole");

                    b.Navigation("SystemUser");
                });
#pragma warning restore 612, 618
        }
    }
}
