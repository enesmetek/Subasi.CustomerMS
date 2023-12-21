﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Subasi.CustomerMS.API.Persistance.Context;

#nullable disable

namespace Subasi.CustomerMS.API.Persistance.Migrations
{
    [DbContext(typeof(SubasiCustomerMSDbContext))]
    partial class SubasiCustomerMSDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Subasi.CustomerMS.API.Core.Domain.Concrete.Address", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("AddressLine")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AddressType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CustomerID")
                        .HasColumnType("int");

                    b.Property<string>("District")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Province")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("CustomerID");

                    b.ToTable("Addresses");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            AddressLine = "Yavrukus St. No:19/1",
                            AddressType = "Home",
                            CustomerID = 1,
                            District = "Sisli",
                            Province = "Istanbul"
                        },
                        new
                        {
                            ID = 2,
                            AddressLine = "Lalegul St. No:5",
                            AddressType = "Office",
                            CustomerID = 1,
                            District = "Kagithane",
                            Province = "Istanbul"
                        },
                        new
                        {
                            ID = 3,
                            AddressLine = "Ali Riza Efendi St. No:22",
                            AddressType = "Home",
                            CustomerID = 2,
                            District = "Kesan",
                            Province = "Edirne"
                        },
                        new
                        {
                            ID = 4,
                            AddressLine = "Seher St. No:16/60",
                            AddressType = "Home",
                            CustomerID = 6,
                            District = "Maltepe",
                            Province = "Istanbul"
                        });
                });

            modelBuilder.Entity("Subasi.CustomerMS.API.Core.Domain.Concrete.Customer", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Email = "emkafali@gmail.com",
                            FirstName = "Enes Mete",
                            LastName = "Kafali",
                            PhoneNumber = "553-580-9653"
                        },
                        new
                        {
                            ID = 2,
                            Email = "tktaskiran@gmail.com",
                            FirstName = "Tolga Kagan",
                            LastName = "Taskiran",
                            PhoneNumber = "546-602-3272"
                        },
                        new
                        {
                            ID = 3,
                            Email = "temelatanc@gmail.com",
                            FirstName = "Can",
                            LastName = "Temelatan",
                            PhoneNumber = "533-559-0511"
                        },
                        new
                        {
                            ID = 4,
                            Email = "yildirimgul@gmail.com",
                            FirstName = "Yildirim",
                            LastName = "Gul",
                            PhoneNumber = "545-332-2239"
                        },
                        new
                        {
                            ID = 5,
                            Email = "kafali22@gmail.com",
                            FirstName = "Mustafa",
                            LastName = "Kafali",
                            PhoneNumber = "542-366-6688"
                        },
                        new
                        {
                            ID = 6,
                            Email = "mert@outlook.com",
                            FirstName = "Mert",
                            LastName = "Kafali",
                            PhoneNumber = "546-297-5518"
                        });
                });

            modelBuilder.Entity("Subasi.CustomerMS.API.Core.Domain.Concrete.Address", b =>
                {
                    b.HasOne("Subasi.CustomerMS.API.Core.Domain.Concrete.Customer", "Customer")
                        .WithMany("Addresses")
                        .HasForeignKey("CustomerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("Subasi.CustomerMS.API.Core.Domain.Concrete.Customer", b =>
                {
                    b.Navigation("Addresses");
                });
#pragma warning restore 612, 618
        }
    }
}