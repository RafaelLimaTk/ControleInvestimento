using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControleInvestimento.Infra.Migrations
{
    public partial class CreateTable_Portifolio_DropColumnTable_InvestimentStatics : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalInvested",
                table: "InvestmentStatics");

            migrationBuilder.RenameColumn(
                name: "Value",
                table: "InvestmentStatics",
                newName: "TotalValue");

            migrationBuilder.AddColumn<Guid>(
                name: "PortfolioId",
                table: "Ativos",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Portifolio",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TotalInvested = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Portifolio", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ativos_PortfolioId",
                table: "Ativos",
                column: "PortfolioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ativos_Portifolio_PortfolioId",
                table: "Ativos",
                column: "PortfolioId",
                principalTable: "Portifolio",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ativos_Portifolio_PortfolioId",
                table: "Ativos");

            migrationBuilder.DropTable(
                name: "Portifolio");

            migrationBuilder.DropIndex(
                name: "IX_Ativos_PortfolioId",
                table: "Ativos");

            migrationBuilder.DropColumn(
                name: "PortfolioId",
                table: "Ativos");

            migrationBuilder.RenameColumn(
                name: "TotalValue",
                table: "InvestmentStatics",
                newName: "Value");

            migrationBuilder.AddColumn<decimal>(
                name: "TotalInvested",
                table: "InvestmentStatics",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
