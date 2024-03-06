using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControleInvestimento.Infra.Migrations
{
    public partial class Alter_NameTable_Transacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transações_Ativos_AssetId",
                table: "Transações");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Transações",
                table: "Transações");

            migrationBuilder.RenameTable(
                name: "Transações",
                newName: "Transacao");

            migrationBuilder.RenameIndex(
                name: "IX_Transações_AssetId",
                table: "Transacao",
                newName: "IX_Transacao_AssetId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Transacao",
                table: "Transacao",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Transacao_Ativos_AssetId",
                table: "Transacao",
                column: "AssetId",
                principalTable: "Ativos",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transacao_Ativos_AssetId",
                table: "Transacao");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Transacao",
                table: "Transacao");

            migrationBuilder.RenameTable(
                name: "Transacao",
                newName: "Transações");

            migrationBuilder.RenameIndex(
                name: "IX_Transacao_AssetId",
                table: "Transações",
                newName: "IX_Transações_AssetId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Transações",
                table: "Transações",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Transações_Ativos_AssetId",
                table: "Transações",
                column: "AssetId",
                principalTable: "Ativos",
                principalColumn: "Id");
        }
    }
}
