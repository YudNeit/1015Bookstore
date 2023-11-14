using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _1015bookstore.web.Migrations
{
    /// <inheritdoc />
    public partial class fixorderdatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "orderdate",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "deliveried",
                table: "Orders",
                newName: "status_order");

            migrationBuilder.AlterColumn<int>(
                name: "address_id",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "completedate",
                table: "Orders",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "paymentdate",
                table: "Orders",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "completedate",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "paymentdate",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "status_order",
                table: "Orders",
                newName: "deliveried");

            migrationBuilder.AlterColumn<int>(
                name: "address_id",
                table: "Orders",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<DateTime>(
                name: "orderdate",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "getutcdate()");
        }
    }
}
