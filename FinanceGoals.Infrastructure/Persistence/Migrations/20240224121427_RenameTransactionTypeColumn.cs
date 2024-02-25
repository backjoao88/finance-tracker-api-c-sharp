using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinanceGoals.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class RenameTransactionTypeColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Kind",
                table: "tbl_Transactions",
                newName: "TransactionType");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TransactionType",
                table: "tbl_Transactions",
                newName: "Kind");
        }
    }
}
