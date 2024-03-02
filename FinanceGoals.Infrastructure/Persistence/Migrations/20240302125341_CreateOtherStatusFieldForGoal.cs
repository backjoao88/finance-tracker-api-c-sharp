using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinanceGoals.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class CreateOtherStatusFieldForGoal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TransactionType",
                table: "tbl_Transactions",
                newName: "ETransactionType");

            migrationBuilder.AlterColumn<int>(
                name: "Active",
                table: "tbl_Goals",
                type: "int",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)",
                oldDefaultValue: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ETransactionType",
                table: "tbl_Transactions",
                newName: "TransactionType");

            migrationBuilder.AlterColumn<bool>(
                name: "Active",
                table: "tbl_Goals",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
