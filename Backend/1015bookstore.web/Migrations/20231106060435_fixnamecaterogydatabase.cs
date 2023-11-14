using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _1015bookstore.web.Migrations
{
    /// <inheritdoc />
    public partial class fixnamecaterogydatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryParentId",
                table: "Categories",
                type: "int",
                nullable: true);

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Categories_CategoryParentId",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_CategoryParentId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "CategoryParentId",
                table: "Categories");
        }
    }
}
