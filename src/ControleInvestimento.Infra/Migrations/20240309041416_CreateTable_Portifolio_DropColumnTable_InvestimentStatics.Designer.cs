﻿// <auto-generated />
using System;
using ControleInvestimento.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ControleInvestimento.Infra.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240309041416_CreateTable_Portifolio_DropColumnTable_InvestimentStatics")]
    partial class CreateTable_Portifolio_DropColumnTable_InvestimentStatics
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.27")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ControleInvestimento.Business.Models.Asset.Asset", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Category")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<Guid>("PortfolioId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("PortfolioId");

                    b.ToTable("Ativos", (string)null);
                });

            modelBuilder.Entity("ControleInvestimento.Business.Models.Asset.InvestmentStatics", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AssetId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("AveragePrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("CurrentPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("TotalValue")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("AssetId")
                        .IsUnique();

                    b.ToTable("InvestmentStatics");
                });

            modelBuilder.Entity("ControleInvestimento.Business.Models.Portifolio.Portfolio", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("TotalInvested")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Portifolio", (string)null);
                });

            modelBuilder.Entity("ControleInvestimento.Business.Models.Transaction.Transaction", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AssetId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsBuy")
                        .HasColumnType("bit");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AssetId");

                    b.ToTable("Transacao", (string)null);
                });

            modelBuilder.Entity("ControleInvestimento.Business.Models.Asset.Asset", b =>
                {
                    b.HasOne("ControleInvestimento.Business.Models.Portifolio.Portfolio", "Portfolio")
                        .WithMany("Assets")
                        .HasForeignKey("PortfolioId")
                        .IsRequired();

                    b.Navigation("Portfolio");
                });

            modelBuilder.Entity("ControleInvestimento.Business.Models.Asset.InvestmentStatics", b =>
                {
                    b.HasOne("ControleInvestimento.Business.Models.Asset.Asset", "Asset")
                        .WithOne("InvestmentStatics")
                        .HasForeignKey("ControleInvestimento.Business.Models.Asset.InvestmentStatics", "AssetId")
                        .IsRequired();

                    b.Navigation("Asset");
                });

            modelBuilder.Entity("ControleInvestimento.Business.Models.Transaction.Transaction", b =>
                {
                    b.HasOne("ControleInvestimento.Business.Models.Asset.Asset", "Asset")
                        .WithMany("Transactions")
                        .HasForeignKey("AssetId")
                        .IsRequired();

                    b.Navigation("Asset");
                });

            modelBuilder.Entity("ControleInvestimento.Business.Models.Asset.Asset", b =>
                {
                    b.Navigation("InvestmentStatics")
                        .IsRequired();

                    b.Navigation("Transactions");
                });

            modelBuilder.Entity("ControleInvestimento.Business.Models.Portifolio.Portfolio", b =>
                {
                    b.Navigation("Assets");
                });
#pragma warning restore 612, 618
        }
    }
}
