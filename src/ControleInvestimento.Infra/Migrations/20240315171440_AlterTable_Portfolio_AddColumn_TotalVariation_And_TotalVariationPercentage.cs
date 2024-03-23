using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControleInvestimento.Infra.Migrations
{
    public partial class AlterTable_Portfolio_AddColumn_TotalVariation_And_TotalVariationPercentage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "TotalVariation",
                table: "Portifolio",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalVariationPercentage",
                table: "Portifolio",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalVariation",
                table: "Portifolio");

            migrationBuilder.DropColumn(
                name: "TotalVariationPercentage",
                table: "Portifolio");
        }
    }
}
