using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControleInvestimento.Infra.Migrations
{
    public partial class CreatedTable_InvestedStatics : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AveragePrice",
                table: "Ativos");

            migrationBuilder.CreateTable(
                name: "InvestmentStatics",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AssetId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AveragePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CurrentPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalInvested = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvestmentStatics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvestmentStatics_Ativos_AssetId",
                        column: x => x.AssetId,
                        principalTable: "Ativos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_InvestmentStatics_AssetId",
                table: "InvestmentStatics",
                column: "AssetId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InvestmentStatics");

            migrationBuilder.AddColumn<decimal>(
                name: "AveragePrice",
                table: "Ativos",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
