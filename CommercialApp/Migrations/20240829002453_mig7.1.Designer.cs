﻿// <auto-generated />
using System;
using CommercialApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CommercialApp.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240829002453_mig7.1")]
    partial class mig71
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.32")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("CommercialApp.Models.Admin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<string>("Permission")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("character varying(15)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("character varying(15)");

                    b.HasKey("Id");

                    b.ToTable("Admins");
                });

            modelBuilder.Entity("CommercialApp.Models.Cargo", b =>
                {
                    b.Property<int>("CargoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CargoId"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("VarChar(400)");

                    b.Property<string>("Employee")
                        .IsRequired()
                        .HasColumnType("VarChar(30)");

                    b.Property<string>("Receiver")
                        .IsRequired()
                        .HasColumnType("VarChar(30)");

                    b.Property<string>("TrackingNumber")
                        .IsRequired()
                        .HasColumnType("VarChar(10)");

                    b.HasKey("CargoId");

                    b.ToTable("Cargos");
                });

            modelBuilder.Entity("CommercialApp.Models.CargoTracking", b =>
                {
                    b.Property<int>("CargoTrackingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CargoTrackingId"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("VarChar(150)");

                    b.Property<string>("TrackingNumber")
                        .IsRequired()
                        .HasColumnType("VarChar(10)");

                    b.HasKey("CargoTrackingId");

                    b.ToTable("CargoTrackings");
                });

            modelBuilder.Entity("CommercialApp.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Bilgisayar"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Telefon"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Mobilya"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Beyaz Eşya"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Mutfak"
                        });
                });

            modelBuilder.Entity("CommercialApp.Models.CustomerAccount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<bool>("State")
                        .HasColumnType("boolean");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.HasKey("Id");

                    b.ToTable("CustomerAccounts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            City = "Amasya",
                            Email = "mail",
                            Name = "Merve",
                            Password = "password123",
                            State = true,
                            Surname = "Sönmez"
                        },
                        new
                        {
                            Id = 2,
                            City = "Kütahya",
                            Email = "mail",
                            Name = "Tuğba",
                            Password = "password123",
                            State = true,
                            Surname = "Erman"
                        },
                        new
                        {
                            Id = 3,
                            City = "Ankara",
                            Email = "mail",
                            Name = "Erkan",
                            Password = "password123",
                            State = true,
                            Surname = "Cenk"
                        });
                });

            modelBuilder.Entity("CommercialApp.Models.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<bool>("State")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.ToTable("Departments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Yönetim",
                            State = true
                        },
                        new
                        {
                            Id = 2,
                            Name = "Muhasebe",
                            State = true
                        },
                        new
                        {
                            Id = 3,
                            Name = "Reklam",
                            State = true
                        },
                        new
                        {
                            Id = 4,
                            Name = "Ticaret",
                            State = true
                        });
                });

            modelBuilder.Entity("CommercialApp.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("DepartmentId")
                        .HasColumnType("integer");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("CommercialApp.Models.Expense", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("numeric");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.ToTable("Expenses");
                });

            modelBuilder.Entity("CommercialApp.Models.Invoice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("numeric");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("InvoiceNumber")
                        .IsRequired()
                        .HasMaxLength(6)
                        .HasColumnType("character varying(6)");

                    b.Property<string>("InvoiceSeries")
                        .IsRequired()
                        .HasMaxLength(1)
                        .HasColumnType("character varying(1)");

                    b.Property<string>("Receiver")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<string>("Sender")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<string>("TaxOffice")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("character varying(60)");

                    b.Property<string>("Time")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("char(5)");

                    b.HasKey("Id");

                    b.ToTable("Invoices");
                });

            modelBuilder.Entity("CommercialApp.Models.InvoiceItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)");

                    b.Property<int>("InvoiceId")
                        .HasColumnType("integer");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("numeric");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex("InvoiceId");

                    b.ToTable("InvoiceItems");
                });

            modelBuilder.Entity("CommercialApp.Models.PDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ProductInfo")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("character varying(2000)");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.HasKey("Id");

                    b.ToTable("PDetails");
                });

            modelBuilder.Entity("CommercialApp.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<decimal>("BuyingPrice")
                        .HasColumnType("numeric");

                    b.Property<int>("CategoryId")
                        .HasColumnType("integer");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<decimal>("SellingPrice")
                        .HasColumnType("numeric");

                    b.Property<bool>("State")
                        .HasColumnType("boolean");

                    b.Property<short>("Stock")
                        .HasColumnType("smallint");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Brand = "Asus",
                            BuyingPrice = 1000m,
                            CategoryId = 1,
                            Image = "img",
                            Name = "Asus UltraBook",
                            SellingPrice = 1500m,
                            State = true,
                            Stock = (short)100
                        },
                        new
                        {
                            Id = 2,
                            Brand = "Apple",
                            BuyingPrice = 10030m,
                            CategoryId = 2,
                            Image = "img",
                            Name = "Iphone 13",
                            SellingPrice = 12500m,
                            State = true,
                            Stock = (short)100
                        },
                        new
                        {
                            Id = 3,
                            Brand = "IKEA",
                            BuyingPrice = 500m,
                            CategoryId = 3,
                            Image = "img",
                            Name = "Salon Takımı",
                            SellingPrice = 700m,
                            State = true,
                            Stock = (short)100
                        },
                        new
                        {
                            Id = 4,
                            Brand = "Alarko",
                            BuyingPrice = 1000m,
                            CategoryId = 4,
                            Image = "img",
                            Name = "Kombi",
                            SellingPrice = 2500m,
                            State = true,
                            Stock = (short)100
                        },
                        new
                        {
                            Id = 5,
                            Brand = "Siemens",
                            BuyingPrice = 10000m,
                            CategoryId = 5,
                            Image = "img",
                            Name = "Çırpıcı",
                            SellingPrice = 15000m,
                            State = true,
                            Stock = (short)100
                        });
                });

            modelBuilder.Entity("CommercialApp.Models.SaleTransaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CustomerAccountsId")
                        .HasColumnType("integer");

                    b.Property<int>("EmployeesId")
                        .HasColumnType("integer");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<int>("ProductsId")
                        .HasColumnType("integer");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("numeric");

                    b.Property<DateTime>("TransactionDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("CustomerAccountsId");

                    b.HasIndex("EmployeesId");

                    b.HasIndex("ProductsId");

                    b.ToTable("SaleTransactions");
                });

            modelBuilder.Entity("CommercialApp.Models.ToDo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("State")
                        .HasColumnType("boolean");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.ToTable("ToDos");
                });

            modelBuilder.Entity("CommercialApp.Models.Employee", b =>
                {
                    b.HasOne("CommercialApp.Models.Department", "Department")
                        .WithMany("Employees")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("CommercialApp.Models.InvoiceItem", b =>
                {
                    b.HasOne("CommercialApp.Models.Invoice", "Invoice")
                        .WithMany("InvoiceItems")
                        .HasForeignKey("InvoiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Invoice");
                });

            modelBuilder.Entity("CommercialApp.Models.Product", b =>
                {
                    b.HasOne("CommercialApp.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("CommercialApp.Models.SaleTransaction", b =>
                {
                    b.HasOne("CommercialApp.Models.CustomerAccount", "CustomerAccounts")
                        .WithMany("SaleTransactions")
                        .HasForeignKey("CustomerAccountsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CommercialApp.Models.Employee", "Employees")
                        .WithMany("SaleTransactions")
                        .HasForeignKey("EmployeesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CommercialApp.Models.Product", "Products")
                        .WithMany("SaleTransactions")
                        .HasForeignKey("ProductsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CustomerAccounts");

                    b.Navigation("Employees");

                    b.Navigation("Products");
                });

            modelBuilder.Entity("CommercialApp.Models.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("CommercialApp.Models.CustomerAccount", b =>
                {
                    b.Navigation("SaleTransactions");
                });

            modelBuilder.Entity("CommercialApp.Models.Department", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("CommercialApp.Models.Employee", b =>
                {
                    b.Navigation("SaleTransactions");
                });

            modelBuilder.Entity("CommercialApp.Models.Invoice", b =>
                {
                    b.Navigation("InvoiceItems");
                });

            modelBuilder.Entity("CommercialApp.Models.Product", b =>
                {
                    b.Navigation("SaleTransactions");
                });
#pragma warning restore 612, 618
        }
    }
}
