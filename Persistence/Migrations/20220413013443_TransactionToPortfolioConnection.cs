using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class TransactionToPortfolioConnection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PortfolioId",
                table: "Transactions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_PortfolioId",
                table: "Transactions",
                column: "PortfolioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Portfolios_PortfolioId",
                table: "Transactions",
                column: "PortfolioId",
                principalTable: "Portfolios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Portfolios_PortfolioId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_PortfolioId",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "PortfolioId",
                table: "Transactions");
        }
    }
}
