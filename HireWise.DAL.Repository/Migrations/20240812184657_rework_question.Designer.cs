﻿// <auto-generated />
using System;
using HireWise.DAL.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace HireWise.DAL.Repository.Migrations
{
    [DbContext(typeof(DBContext))]
    [Migration("20240812184657_rework_question")]
    partial class rework_question
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("HireWise.Common.Entities.GradeLevels.DB.GradeLevel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("GradeLevels");
                });

            modelBuilder.Entity("HireWise.Common.Entities.QuestionModels.DB.Question", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("Counter")
                        .HasColumnType("integer");

                    b.Property<int?>("GradeLevelId")
                        .HasColumnType("integer");

                    b.Property<bool>("IsPublished")
                        .HasColumnType("boolean");

                    b.Property<string>("QuestionBody")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("QuestionName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("TechTransferId")
                        .HasColumnType("integer");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("GradeLevelId");

                    b.HasIndex("TechTransferId");

                    b.HasIndex("UserId");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("HireWise.Common.Entities.RecordModels.DB.Record", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("GradeId")
                        .HasColumnType("integer");

                    b.Property<int?>("GradeLevelId")
                        .HasColumnType("integer");

                    b.Property<bool>("IsPublished")
                        .HasColumnType("boolean");

                    b.Property<string>("Link")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("TechTransferId")
                        .HasColumnType("integer");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("GradeLevelId");

                    b.HasIndex("TechTransferId");

                    b.HasIndex("UserId");

                    b.ToTable("Records");
                });

            modelBuilder.Entity("HireWise.Common.Entities.RoleModels.DB.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("HireWise.Common.Entities.TechTransferModels.DB.TechTransfer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("TechTransfers");
                });

            modelBuilder.Entity("HireWise.Common.Entities.UserModels.DB.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<int>("UserGroupId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("Login")
                        .IsUnique();

                    b.HasIndex("UserGroupId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("HireWise.Common.Entities.UserModels.DB.UserGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("UserGroups");
                });

            modelBuilder.Entity("RoleUserGroup", b =>
                {
                    b.Property<int>("RolesId")
                        .HasColumnType("integer");

                    b.Property<int>("UserGroupsId")
                        .HasColumnType("integer");

                    b.HasKey("RolesId", "UserGroupsId");

                    b.HasIndex("UserGroupsId");

                    b.ToTable("RoleUserGroup");
                });

            modelBuilder.Entity("HireWise.Common.Entities.QuestionModels.DB.Question", b =>
                {
                    b.HasOne("HireWise.Common.Entities.GradeLevels.DB.GradeLevel", null)
                        .WithMany("Questions")
                        .HasForeignKey("GradeLevelId");

                    b.HasOne("HireWise.Common.Entities.TechTransferModels.DB.TechTransfer", null)
                        .WithMany("Questions")
                        .HasForeignKey("TechTransferId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HireWise.Common.Entities.UserModels.DB.User", "Author")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");
                });

            modelBuilder.Entity("HireWise.Common.Entities.RecordModels.DB.Record", b =>
                {
                    b.HasOne("HireWise.Common.Entities.GradeLevels.DB.GradeLevel", null)
                        .WithMany("Records")
                        .HasForeignKey("GradeLevelId");

                    b.HasOne("HireWise.Common.Entities.TechTransferModels.DB.TechTransfer", null)
                        .WithMany("Records")
                        .HasForeignKey("TechTransferId");

                    b.HasOne("HireWise.Common.Entities.UserModels.DB.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("HireWise.Common.Entities.UserModels.DB.User", b =>
                {
                    b.HasOne("HireWise.Common.Entities.UserModels.DB.UserGroup", "UserGroup")
                        .WithMany("Users")
                        .HasForeignKey("UserGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserGroup");
                });

            modelBuilder.Entity("RoleUserGroup", b =>
                {
                    b.HasOne("HireWise.Common.Entities.RoleModels.DB.Role", null)
                        .WithMany()
                        .HasForeignKey("RolesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HireWise.Common.Entities.UserModels.DB.UserGroup", null)
                        .WithMany()
                        .HasForeignKey("UserGroupsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HireWise.Common.Entities.GradeLevels.DB.GradeLevel", b =>
                {
                    b.Navigation("Questions");

                    b.Navigation("Records");
                });

            modelBuilder.Entity("HireWise.Common.Entities.TechTransferModels.DB.TechTransfer", b =>
                {
                    b.Navigation("Questions");

                    b.Navigation("Records");
                });

            modelBuilder.Entity("HireWise.Common.Entities.UserModels.DB.UserGroup", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
