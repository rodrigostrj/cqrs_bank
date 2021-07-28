﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SaltpayBank.Infrastructure.Data;

namespace SaltpayBank.Infrastructure.Migrations
{
    [DbContext(typeof(EFContext))]
    [Migration("20210727025318_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SaltpayBank.Domain.AccountAggregate.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<int?>("CustomerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("SaltpayBank.Domain.AccountAggregate.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Arisha Barron"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Branden Gibson"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Rhonda Church"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Georgina Hazel"
                        });
                });

            modelBuilder.Entity("SaltpayBank.Domain.AccountAggregate.Account", b =>
                {
                    b.HasOne("SaltpayBank.Domain.AccountAggregate.Customer", "Customer")
                        .WithMany("AccountList")
                        .HasForeignKey("CustomerId");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("SaltpayBank.Domain.AccountAggregate.Customer", b =>
                {
                    b.Navigation("AccountList");
                });
#pragma warning restore 612, 618
        }
    }
}
