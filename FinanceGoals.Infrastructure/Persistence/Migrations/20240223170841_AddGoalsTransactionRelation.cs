using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinanceGoals.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddGoalsTransactionRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "IdGoal",
                table: "tbl_Transactions",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Transactions_IdGoal",
                table: "tbl_Transactions",
                column: "IdGoal");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_Transactions_tbl_Goals_IdGoal",
                table: "tbl_Transactions",
                column: "IdGoal",
                principalTable: "tbl_Goals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_Transactions_tbl_Goals_IdGoal",
                table: "tbl_Transactions");

            migrationBuilder.DropIndex(
                name: "IX_tbl_Transactions_IdGoal",
                table: "tbl_Transactions");

            migrationBuilder.DropColumn(
                name: "IdGoal",
                table: "tbl_Transactions");
        }
    }
}
