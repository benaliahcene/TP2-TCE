﻿// <auto-generated />
using System;
using EC_MicroServicesProduct;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EC_MicroServicesProduct.Migrations
{
    [DbContext(typeof(Service_ProductDbContext))]
    [Migration("20230414224815_ec_product_db")]
    partial class ec_product_db
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EC_MicroServicesProduct.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("Prix")
                        .HasColumnType("float");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("VendeurId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("VendeurId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("EC_MicroServicesUser.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Fonction")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("EC_MicroServicesProduct.Models.Product", b =>
                {
                    b.HasOne("EC_MicroServicesUser.Models.User", "Vendeur")
                        .WithMany()
                        .HasForeignKey("VendeurId");

                    b.Navigation("Vendeur");
                });
#pragma warning restore 612, 618
        }
    }
}