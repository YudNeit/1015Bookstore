using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _1015bookstore.data.Migrations
{
    public partial class addproductimage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductImages",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    product_id = table.Column<int>(type: "int", nullable: false),
                    imagepath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    caption = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    is_default = table.Column<bool>(type: "bit", nullable: false),
                    sizeimage = table.Column<long>(type: "bigint", nullable: false),
                    createdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updatedate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    sortorder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImages", x => x.id);
                    table.ForeignKey(
                        name: "FK_ProductImages_Products_product_id",
                        column: x => x.product_id,
                        principalTable: "Products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "datecreated", "dateupdated" },
                values: new object[] { new DateTime(2023, 12, 17, 9, 35, 55, 841, DateTimeKind.Local).AddTicks(3992), new DateTime(2023, 12, 17, 9, 35, 55, 841, DateTimeKind.Local).AddTicks(4000) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "datecreated", "dateupdated" },
                values: new object[] { new DateTime(2023, 12, 17, 9, 35, 55, 841, DateTimeKind.Local).AddTicks(4002), new DateTime(2023, 12, 17, 9, 35, 55, 841, DateTimeKind.Local).AddTicks(4003) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "datecreated", "dateupdated" },
                values: new object[] { new DateTime(2023, 12, 17, 9, 35, 55, 841, DateTimeKind.Local).AddTicks(4004), new DateTime(2023, 12, 17, 9, 35, 55, 841, DateTimeKind.Local).AddTicks(4004) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "datecreated", "dateupdated" },
                values: new object[] { new DateTime(2023, 12, 17, 9, 35, 55, 841, DateTimeKind.Local).AddTicks(4005), new DateTime(2023, 12, 17, 9, 35, 55, 841, DateTimeKind.Local).AddTicks(4006) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "datecreated", "dateupdated", "mfgdate" },
                values: new object[] { new DateTime(2023, 12, 17, 9, 35, 55, 841, DateTimeKind.Local).AddTicks(4022), new DateTime(2023, 12, 17, 9, 35, 55, 841, DateTimeKind.Local).AddTicks(4023), new DateTime(2023, 12, 17, 9, 35, 55, 841, DateTimeKind.Local).AddTicks(4020) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "datecreated", "dateupdated", "mfgdate" },
                values: new object[] { new DateTime(2023, 12, 17, 9, 35, 55, 841, DateTimeKind.Local).AddTicks(4027), new DateTime(2023, 12, 17, 9, 35, 55, 841, DateTimeKind.Local).AddTicks(4028), new DateTime(2023, 12, 17, 9, 35, 55, 841, DateTimeKind.Local).AddTicks(4026) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "c4c93676-ecfb-4403-8296-e64a32889c82");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a51da11b-29de-473d-85d0-19dd0dcb8501", "AQAAAAEAACcQAAAAENPtygPKmMXn4MRPwM1PtHnqGxMgI2FLEpyO9EpsXLI9AGKv4yYDBWbDXG7ByvTPag==" });

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_product_id",
                table: "ProductImages",
                column: "product_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductImages");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "datecreated", "dateupdated" },
                values: new object[] { new DateTime(2023, 12, 10, 16, 7, 48, 782, DateTimeKind.Local).AddTicks(8097), new DateTime(2023, 12, 10, 16, 7, 48, 782, DateTimeKind.Local).AddTicks(8108) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "datecreated", "dateupdated" },
                values: new object[] { new DateTime(2023, 12, 10, 16, 7, 48, 782, DateTimeKind.Local).AddTicks(8109), new DateTime(2023, 12, 10, 16, 7, 48, 782, DateTimeKind.Local).AddTicks(8110) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "datecreated", "dateupdated" },
                values: new object[] { new DateTime(2023, 12, 10, 16, 7, 48, 782, DateTimeKind.Local).AddTicks(8111), new DateTime(2023, 12, 10, 16, 7, 48, 782, DateTimeKind.Local).AddTicks(8111) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "datecreated", "dateupdated" },
                values: new object[] { new DateTime(2023, 12, 10, 16, 7, 48, 782, DateTimeKind.Local).AddTicks(8112), new DateTime(2023, 12, 10, 16, 7, 48, 782, DateTimeKind.Local).AddTicks(8113) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "datecreated", "dateupdated", "mfgdate" },
                values: new object[] { new DateTime(2023, 12, 10, 16, 7, 48, 782, DateTimeKind.Local).AddTicks(8129), new DateTime(2023, 12, 10, 16, 7, 48, 782, DateTimeKind.Local).AddTicks(8130), new DateTime(2023, 12, 10, 16, 7, 48, 782, DateTimeKind.Local).AddTicks(8128) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "datecreated", "dateupdated", "mfgdate" },
                values: new object[] { new DateTime(2023, 12, 10, 16, 7, 48, 782, DateTimeKind.Local).AddTicks(8134), new DateTime(2023, 12, 10, 16, 7, 48, 782, DateTimeKind.Local).AddTicks(8135), new DateTime(2023, 12, 10, 16, 7, 48, 782, DateTimeKind.Local).AddTicks(8133) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "d92fe8f3-7ca9-4a0e-bef0-399cc6be114a");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "42ce7c6c-b114-4499-bc56-bcf03dcf632f", "AQAAAAEAACcQAAAAEGazOQ9i7j+DEoG7PCkTrpQEAztjsJOxG+LzNVYmIhsxaOlKZuGtNyGxK2gwOvywPA==" });
        }
    }
}
