﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PhoneShop.Business.Data;

namespace PhoneShop.Business.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20220117124210_update")]
    partial class update
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PhoneShop.Data.Entities.Brand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Brands");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Motorola"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Xiaomi"
                        });
                });

            modelBuilder.Entity("PhoneShop.Data.Entities.Phone", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BrandId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.ToTable("Phones");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BrandId = 1,
                            Description = "testing",
                            Price = 54.0,
                            Stock = 12,
                            Type = "test1"
                        },
                        new
                        {
                            Id = 2,
                            BrandId = 2,
                            Description = "testing",
                            Price = 54.0,
                            Stock = 12,
                            Type = "test2"
                        },
                        new
                        {
                            Id = 3,
                            BrandId = 1,
                            Description = "testing",
                            Price = 54.0,
                            Stock = 12,
                            Type = "test3"
                        },
                        new
                        {
                            Id = 4,
                            BrandId = 2,
                            Description = "testing",
                            Price = 54.0,
                            Stock = 12,
                            Type = "test4"
                        },
                        new
                        {
                            Id = 5,
                            BrandId = 1,
                            Description = "testing",
                            Price = 54.0,
                            Stock = 12,
                            Type = "test5"
                        });
                });

            modelBuilder.Entity("PhoneShop.Data.Entities.Phone", b =>
                {
                    b.HasOne("PhoneShop.Data.Entities.Brand", "Brand")
                        .WithMany()
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");
                });
#pragma warning restore 612, 618
        }
    }
}
