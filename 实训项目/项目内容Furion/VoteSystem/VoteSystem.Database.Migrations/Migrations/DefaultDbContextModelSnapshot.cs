﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VoteSystem.EntityFramework.Core;

#nullable disable

namespace VoteSystem.Database.Migrations.Migrations
{
    [DbContext(typeof(DefaultDbContext))]
    partial class DefaultDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("VoteSystem.Core.VoteModelCore.ActivityManager", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CandidateId")
                        .HasColumnType("int");

                    b.Property<int>("CandidateVoteNumber")
                        .HasColumnType("int");

                    b.Property<int>("VoteActivityId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CandidateId");

                    b.HasIndex("VoteActivityId");

                    b.ToTable("ActivityManager", (string)null);
                });

            modelBuilder.Entity("VoteSystem.Core.VoteModelCore.RootModel.Activity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("WhenEnd")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("WhenStart")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Activity", (string)null);
                });

            modelBuilder.Entity("VoteSystem.Core.VoteModelCore.RootModel.Users", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Account")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Img")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Introduce")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("YourRole")
                        .HasColumnType("int");

                    b.Property<int>("YourSex")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("VoteSystem.Core.VoteModelCore.VoteManager", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CandidateId")
                        .HasColumnType("int");

                    b.Property<int>("VoterId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CandidateId");

                    b.HasIndex("VoterId");

                    b.ToTable("VoteManager", (string)null);
                });

            modelBuilder.Entity("VoteSystem.Core.VoteModelCore.Admin", b =>
                {
                    b.HasBaseType("VoteSystem.Core.VoteModelCore.RootModel.Users");

                    b.Property<int>("ActivityId")
                        .HasColumnType("int");

                    b.ToTable("Admin", (string)null);
                });

            modelBuilder.Entity("VoteSystem.Core.VoteModelCore.Candidate", b =>
                {
                    b.HasBaseType("VoteSystem.Core.VoteModelCore.RootModel.Users");

                    b.Property<string>("Canvassing")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Candidate", (string)null);
                });

            modelBuilder.Entity("VoteSystem.Core.VoteModelCore.VoteActivity", b =>
                {
                    b.HasBaseType("VoteSystem.Core.VoteModelCore.RootModel.Activity");

                    b.Property<int>("AdminId")
                        .HasColumnType("int");

                    b.Property<int>("Catagory")
                        .HasColumnType("int");

                    b.Property<int>("EachInvoteNumber")
                        .HasColumnType("int");

                    b.HasIndex("AdminId");

                    b.ToTable("VoteActivity", (string)null);
                });

            modelBuilder.Entity("VoteSystem.Core.VoteModelCore.Voter", b =>
                {
                    b.HasBaseType("VoteSystem.Core.VoteModelCore.RootModel.Users");

                    b.Property<bool>("IsBannedComment")
                        .HasColumnType("bit");

                    b.ToTable("Voter", (string)null);
                });

            modelBuilder.Entity("VoteSystem.Core.VoteModelCore.ActivityManager", b =>
                {
                    b.HasOne("VoteSystem.Core.VoteModelCore.Candidate", "Candidate")
                        .WithMany("ActivityManagers")
                        .HasForeignKey("CandidateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VoteSystem.Core.VoteModelCore.VoteActivity", "VoteActivity")
                        .WithMany("ActivityManagers")
                        .HasForeignKey("VoteActivityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Candidate");

                    b.Navigation("VoteActivity");
                });

            modelBuilder.Entity("VoteSystem.Core.VoteModelCore.VoteManager", b =>
                {
                    b.HasOne("VoteSystem.Core.VoteModelCore.Candidate", "Candidate")
                        .WithMany("VoteManagers")
                        .HasForeignKey("CandidateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VoteSystem.Core.VoteModelCore.Voter", "Voter")
                        .WithMany()
                        .HasForeignKey("VoterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Candidate");

                    b.Navigation("Voter");
                });

            modelBuilder.Entity("VoteSystem.Core.VoteModelCore.Admin", b =>
                {
                    b.HasOne("VoteSystem.Core.VoteModelCore.RootModel.Users", null)
                        .WithOne()
                        .HasForeignKey("VoteSystem.Core.VoteModelCore.Admin", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("VoteSystem.Core.VoteModelCore.Candidate", b =>
                {
                    b.HasOne("VoteSystem.Core.VoteModelCore.RootModel.Users", null)
                        .WithOne()
                        .HasForeignKey("VoteSystem.Core.VoteModelCore.Candidate", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("VoteSystem.Core.VoteModelCore.VoteActivity", b =>
                {
                    b.HasOne("VoteSystem.Core.VoteModelCore.Admin", "Admin")
                        .WithMany("VoteActivities")
                        .HasForeignKey("AdminId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VoteSystem.Core.VoteModelCore.RootModel.Activity", null)
                        .WithOne()
                        .HasForeignKey("VoteSystem.Core.VoteModelCore.VoteActivity", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("Admin");
                });

            modelBuilder.Entity("VoteSystem.Core.VoteModelCore.Voter", b =>
                {
                    b.HasOne("VoteSystem.Core.VoteModelCore.RootModel.Users", null)
                        .WithOne()
                        .HasForeignKey("VoteSystem.Core.VoteModelCore.Voter", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("VoteSystem.Core.VoteModelCore.Admin", b =>
                {
                    b.Navigation("VoteActivities");
                });

            modelBuilder.Entity("VoteSystem.Core.VoteModelCore.Candidate", b =>
                {
                    b.Navigation("ActivityManagers");

                    b.Navigation("VoteManagers");
                });

            modelBuilder.Entity("VoteSystem.Core.VoteModelCore.VoteActivity", b =>
                {
                    b.Navigation("ActivityManagers");
                });
#pragma warning restore 612, 618
        }
    }
}
