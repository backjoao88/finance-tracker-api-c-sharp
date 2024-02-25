using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinanceGoals.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddColumnDeadlineInGoalsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "End",
                table: "tbl_Goals",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "MonthlySavingAmount",
                table: "tbl_Goals",
                type: "decimal(65,30)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "Start",
                table: "tbl_Goals",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "End",
                table: "tbl_Goals");

            migrationBuilder.DropColumn(
                name: "MonthlySavingAmount",
                table: "tbl_Goals");

            migrationBuilder.DropColumn(
                name: "Start",
                table: "tbl_Goals");
        }
    }
}
