﻿// <auto-generated />
using System;
using BasketApp.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BasketApp.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220418194509_first")]
    partial class first
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("BasketApp.Domain.Entities.Basket", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("ProductCount")
                        .HasColumnType("integer");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("Basket");

                    b.HasData(
                        new
                        {
                            Id = new Guid("7a4ccfeb-0174-49e1-a3a2-b1a85c982608"),
                            CreateDate = new DateTime(2022, 4, 18, 19, 45, 8, 860, DateTimeKind.Utc).AddTicks(8215),
                            ProductCount = 2,
                            ProductId = new Guid("fbc178bf-6751-48bb-8df3-5dfbf00194ec")
                        },
                        new
                        {
                            Id = new Guid("e02167e2-db7e-4919-af3e-d7a8c5d0b594"),
                            CreateDate = new DateTime(2022, 4, 18, 19, 45, 8, 860, DateTimeKind.Utc).AddTicks(8292),
                            ProductCount = 4,
                            ProductId = new Guid("5c95c5d4-c887-493d-9589-0efc9f20e67e")
                        },
                        new
                        {
                            Id = new Guid("88dda06e-1796-46ac-adc7-ff4cf90a8a01"),
                            CreateDate = new DateTime(2022, 4, 18, 19, 45, 8, 860, DateTimeKind.Utc).AddTicks(8296),
                            ProductCount = 7,
                            ProductId = new Guid("f27e09f4-7a24-4890-a595-a02827a98aa4")
                        });
                });

            modelBuilder.Entity("BasketApp.Domain.Entities.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Stock")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = new Guid("fbc178bf-6751-48bb-8df3-5dfbf00194ec"),
                            CreateDate = new DateTime(2022, 4, 18, 19, 45, 8, 860, DateTimeKind.Utc).AddTicks(8016),
                            ProductName = "Pencil",
                            Stock = 20
                        },
                        new
                        {
                            Id = new Guid("5c95c5d4-c887-493d-9589-0efc9f20e67e"),
                            CreateDate = new DateTime(2022, 4, 18, 19, 45, 8, 860, DateTimeKind.Utc).AddTicks(8027),
                            ProductName = "Paper A4",
                            Stock = 10
                        },
                        new
                        {
                            Id = new Guid("f27e09f4-7a24-4890-a595-a02827a98aa4"),
                            CreateDate = new DateTime(2022, 4, 18, 19, 45, 8, 860, DateTimeKind.Utc).AddTicks(8029),
                            ProductName = "Book",
                            Stock = 100
                        });
                });

            modelBuilder.Entity("BasketApp.Domain.Entities.Basket", b =>
                {
                    b.HasOne("BasketApp.Domain.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });
#pragma warning restore 612, 618
        }
    }
}
