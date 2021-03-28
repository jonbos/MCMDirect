﻿// <auto-generated />
using MCMDirect.Areas.Store.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MCMDirect.Migrations
{
    [DbContext(typeof(MCMContext))]
    [Migration("20210328182624_AddProduct")]
    partial class AddProduct
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.4");

            modelBuilder.Entity("MCMDirect.Areas.Store.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Image")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<double>("Price")
                        .HasColumnType("REAL");

                    b.HasKey("ProductId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            Description = "Leather Chair",
                            Image = "chair.png",
                            Name = "Leather Chair",
                            Price = 999.99000000000001
                        },
                        new
                        {
                            ProductId = 2,
                            Description = "A beautiful coffee table",
                            Image = "coffee_table.png",
                            Name = "Coffee Table",
                            Price = 499.99000000000001
                        },
                        new
                        {
                            ProductId = 3,
                            Description = "Walnut Credenza",
                            Image = "credenza.png",
                            Name = "Credenza",
                            Price = 1199.99
                        });
                });
#pragma warning restore 612, 618
        }
    }
}