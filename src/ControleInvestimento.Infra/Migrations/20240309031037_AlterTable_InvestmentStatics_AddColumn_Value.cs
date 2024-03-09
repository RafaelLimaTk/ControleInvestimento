using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControleInvestimento.Infra.Migrations
{
    public partial class AlterTable_InvestmentStatics_AddColumn_Value : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Value",
                table: "InvestmentStatics",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Value",
                table: "InvestmentStatics");
        }
    }
}
