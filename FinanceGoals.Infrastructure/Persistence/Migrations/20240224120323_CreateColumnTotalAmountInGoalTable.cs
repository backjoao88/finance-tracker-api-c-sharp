using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinanceGoals.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class CreateColumnTotalAmountInGoalTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "TotalAmount",
                table: "tbl_Goals",
                type: "decimal(65,30)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalAmount",
                table: "tbl_Goals");
        }
    }
}
