using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _1015bookstore.web.Migrations
{
    /// <inheritdoc />
    public partial class fixnamecaterogydatabase2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Categories_CategoryParentId",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Categories_Categoryid",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_Categoryid",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_CategoryParentId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "Categoryid",
                table: "Categories");

            migrationBuilder.RenameColumn(
                name: "CategoryParentId",
                table: "Categories",
                newName: "categoryparentid");

            migrationBuilder.AlterColumn<int>(
                name: "categoryparentid",
                table: "Categories",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "categoryparentid",
                table: "Categories",
                newName: "CategoryParentId");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryParentId",
                table: "Categories",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Categoryid",
                table: "Categories",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_Categoryid",
                table: "Categories",
                column: "Categoryid");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_CategoryParentId",
                table: "Categories",
                column: "CategoryParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Categories_CategoryParentId",
                table: "Categories",
                column: "CategoryParentId",
                principalTable: "Categories",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Categories_Categoryid",
                table: "Categories",
                column: "Categoryid",
                principalTable: "Categories",
                principalColumn: "id");
        }
    }
}
