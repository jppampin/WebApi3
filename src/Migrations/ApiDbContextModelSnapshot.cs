﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApi.Data;

namespace WebApi.Migrations
{
    [DbContext(typeof(ApiDbContext))]
    partial class ApiDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5");

            modelBuilder.Entity("WebApi.Models.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Currency")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ItemsIds")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            Id = new Guid("9b1df6fe-30d0-4de3-8946-ad55ce6f41ff"),
                            Currency = "ARS",
                            ItemsIds = "1,2,3"
                        },
                        new
                        {
                            Id = new Guid("7b92e37f-f0d4-417d-89d7-3278ede73de3"),
                            Currency = "EUR",
                            ItemsIds = "1,2,3"
                        },
                        new
                        {
                            Id = new Guid("0ddc4a48-60ce-455e-98c9-20b1e4d73ff0"),
                            Currency = "USD",
                            ItemsIds = "1,2,3"
                        },
                        new
                        {
                            Id = new Guid("1ace235f-d628-4c50-bd55-2c97ca1a7382"),
                            Currency = "BRL",
                            ItemsIds = "1,2,3"
                        },
                        new
                        {
                            Id = new Guid("f8cea9e3-7fa9-4d4f-b3e9-0173952aa3ad"),
                            Currency = "???",
                            ItemsIds = "1,2,3"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
