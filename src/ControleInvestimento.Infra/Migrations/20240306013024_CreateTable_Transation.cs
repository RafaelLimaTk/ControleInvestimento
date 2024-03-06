using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControleInvestimento.Infra.Migrations
{
    public partial class CreateTable_Transation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Ativos");

            migrationBuilder.DropColumn(
                name: "CurrentPrice",
                table: "Ativos");

            migrationBuilder.DropColumn(
                name: "InitialInvestment",
                table: "Ativos");

            migrationBuilder.DropColumn(
                name: "TotalBalance",
                table: "Ativos");

            migrationBuilder.DropColumn(
                name: "CategoryPercentage",
                table: "Ativos");

            migrationBuilder.DropColumn(
                name: "IdealPercentage",
                table: "Ativos");

            migrationBuilder.DropColumn(
                name: "IdealValue",
                table: "Ativos");

            migrationBuilder.CreateTable(
                name: "Transações",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AssetId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsBuy = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transações", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transações_Ativos_AssetId",
                        column: x => x.AssetId,
                        principalTable: "Ativos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transações_AssetId",
                table: "Transações",
                column: "AssetId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "CategoryPercentage",
                table: "Ativos",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "CurrentPrice",
                table: "Ativos",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "IdealPercentage",
                table: "Ativos",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "IdealValue",
                table: "Ativos",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "InitialInvestment",
                table: "Ativos",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Ativos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalBalance",
                table: "Ativos",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
