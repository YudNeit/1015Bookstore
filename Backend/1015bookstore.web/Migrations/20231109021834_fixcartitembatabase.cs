using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _1015bookstore.web.Migrations
{
    /// <inheritdoc />
    public partial class fixcartitembatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_Products_productid",
                table: "CartItems");

            migrationBuilder.DropIndex(
                name: "IX_CartItems_productid",
                table: "CartItems");

            migrationBuilder.DropColumn(
                name: "productid",
                table: "CartItems");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItem_Product",
                table: "CartItems",
                column: "product_id",
                principalTable: "Products",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItem_Product",
                table: "CartItems");

            migrationBuilder.AddColumn<int>(
                name: "productid",
                table: "CartItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_productid",
                table: "CartItems",
                column: "productid");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_Products_productid",
                table: "CartItems",
                column: "productid",
                principalTable: "Products",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
