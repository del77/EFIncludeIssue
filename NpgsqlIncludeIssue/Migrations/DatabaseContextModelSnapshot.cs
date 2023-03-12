﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using NpgsqlIncludeIssue.Controllers;

#nullable disable

namespace NpgsqlIncludeIssue.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("NpgsqlIncludeIssue.Controllers.BaseMyClass", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("BaseEntityProperty")
                        .HasColumnType("boolean");

                    b.Property<Guid>("DirectNav1Id")
                        .HasColumnType("uuid");

                    b.Property<Guid>("DirectNav2Id")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("DirectNav1Id");

                    b.HasIndex("DirectNav2Id");

                    b.ToTable("BaseMyClasses");
                });

            modelBuilder.Entity("NpgsqlIncludeIssue.Controllers.DirectNav1", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("DirectNav1");
                });

            modelBuilder.Entity("NpgsqlIncludeIssue.Controllers.DirectNav2", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("DirectNav2");
                });

            modelBuilder.Entity("NpgsqlIncludeIssue.Controllers.Nav1", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("Nav1");
                });

            modelBuilder.Entity("NpgsqlIncludeIssue.Controllers.Nav2", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("Nav2");
                });

            modelBuilder.Entity("NpgsqlIncludeIssue.Controllers.BaseMyClass", b =>
                {
                    b.HasOne("NpgsqlIncludeIssue.Controllers.DirectNav1", "DirectNav1")
                        .WithMany()
                        .HasForeignKey("DirectNav1Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NpgsqlIncludeIssue.Controllers.DirectNav2", "DirectNav2")
                        .WithMany()
                        .HasForeignKey("DirectNav2Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("NpgsqlIncludeIssue.Controllers.Information", "Information", b1 =>
                        {
                            b1.Property<Guid>("BaseMyClassId")
                                .HasColumnType("uuid");

                            b1.Property<bool>("Boolean")
                                .HasColumnType("boolean");

                            b1.Property<Guid>("Nav1Id")
                                .HasColumnType("uuid");

                            b1.Property<Guid>("Nav2Id")
                                .HasColumnType("uuid");

                            b1.HasKey("BaseMyClassId");

                            b1.HasIndex("Nav1Id");

                            b1.HasIndex("Nav2Id");

                            b1.ToTable("BaseMyClasses");

                            b1.WithOwner()
                                .HasForeignKey("BaseMyClassId");

                            b1.HasOne("NpgsqlIncludeIssue.Controllers.Nav1", "Nav1")
                                .WithMany()
                                .HasForeignKey("Nav1Id")
                                .OnDelete(DeleteBehavior.Cascade)
                                .IsRequired();

                            b1.HasOne("NpgsqlIncludeIssue.Controllers.Nav2", "Nav2")
                                .WithMany()
                                .HasForeignKey("Nav2Id")
                                .OnDelete(DeleteBehavior.Cascade)
                                .IsRequired();

                            b1.Navigation("Nav1");

                            b1.Navigation("Nav2");
                        });

                    b.Navigation("DirectNav1");

                    b.Navigation("DirectNav2");

                    b.Navigation("Information")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
