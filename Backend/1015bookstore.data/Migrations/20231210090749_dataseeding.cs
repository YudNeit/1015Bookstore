using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _1015bookstore.data.Migrations
{
    public partial class dataseeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AppConfigs",
                columns: new[] { "key", "value" },
                values: new object[,]
                {
                    { "HomeDescription", "This is description of eShopSolution" },
                    { "Homekeyword", "This is keyword of eShopSolution" },
                    { "HomeTitle", "This is home page of eShopSolution" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "id", "categoryparentid", "createdby", "datecreated", "dateupdated", "name", "updatedby" },
                values: new object[,]
                {
                    { 1, null, "HeThong", new DateTime(2023, 12, 10, 16, 7, 48, 782, DateTimeKind.Local).AddTicks(8097), new DateTime(2023, 12, 10, 16, 7, 48, 782, DateTimeKind.Local).AddTicks(8108), "Sách giáo khoa", "HeThong" },
                    { 2, null, "HeThong", new DateTime(2023, 12, 10, 16, 7, 48, 782, DateTimeKind.Local).AddTicks(8109), new DateTime(2023, 12, 10, 16, 7, 48, 782, DateTimeKind.Local).AddTicks(8110), "Sách ngôn ngữ", "HeThong" },
                    { 3, 1, "HeThong", new DateTime(2023, 12, 10, 16, 7, 48, 782, DateTimeKind.Local).AddTicks(8111), new DateTime(2023, 12, 10, 16, 7, 48, 782, DateTimeKind.Local).AddTicks(8111), "Sách giáo khoa lớp 1", "HeThong" },
                    { 4, 2, "HeThong", new DateTime(2023, 12, 10, 16, 7, 48, 782, DateTimeKind.Local).AddTicks(8112), new DateTime(2023, 12, 10, 16, 7, 48, 782, DateTimeKind.Local).AddTicks(8113), "Sách tiếng anh", "HeThong" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "id", "alias", "author", "brand", "createdby", "datecreated", "dateupdated", "description", "madein", "mfgdate", "name", "nop", "price", "quanity", "suppiler", "updatedby", "waranty", "yop" },
                values: new object[,]
                {
                    { 1, "Sach toan lop 1", "", "", "HeThong", new DateTime(2023, 12, 10, 16, 7, 48, 782, DateTimeKind.Local).AddTicks(8129), new DateTime(2023, 12, 10, 16, 7, 48, 782, DateTimeKind.Local).AddTicks(8130), "Đây là sách toán hay dành cho trẻ em", "", new DateTime(2023, 12, 10, 16, 7, 48, 782, DateTimeKind.Local).AddTicks(8128), "Sách toán lớp 1", "", 10000m, 100, "", "HeThong", 30, 2023 },
                    { 2, "Sach phat am Mai Lan Huong", "", "", "HeThong", new DateTime(2023, 12, 10, 16, 7, 48, 782, DateTimeKind.Local).AddTicks(8134), new DateTime(2023, 12, 10, 16, 7, 48, 782, DateTimeKind.Local).AddTicks(8135), "Đây là sách oke nè", "", new DateTime(2023, 12, 10, 16, 7, 48, 782, DateTimeKind.Local).AddTicks(8133), "Sách phát âm Mai Lan Hương", "", 10000m, 100, "", "HeThong", 30, 2023 }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName", "description" },
                values: new object[] { new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"), "d92fe8f3-7ca9-4a0e-bef0-399cc6be114a", "admin", "admin", "Administrator role" });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"), new Guid("69bd714f-9576-45ba-b5b7-f00649be00de") });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "dob", "firstname", "lastname" },
                values: new object[] { new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"), 0, "42ce7c6c-b114-4499-bc56-bcf03dcf632f", "21520208@gm.uit.edu.vn", true, false, null, "21520208@gm.uit.edu.vn", "admin", "AQAAAAEAACcQAAAAEGazOQ9i7j+DEoG7PCkTrpQEAztjsJOxG+LzNVYmIhsxaOlKZuGtNyGxK2gwOvywPA==", "0907448146", false, "", false, "admin", new DateTime(2020, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nguyen", "Duy" });

            migrationBuilder.InsertData(
                table: "ProductInCategory",
                columns: new[] { "category_id", "product_id" },
                values: new object[] { 3, 1 });

            migrationBuilder.InsertData(
                table: "ProductInCategory",
                columns: new[] { "category_id", "product_id" },
                values: new object[] { 4, 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppConfigs",
                keyColumn: "key",
                keyValue: "HomeDescription");

            migrationBuilder.DeleteData(
                table: "AppConfigs",
                keyColumn: "key",
                keyValue: "Homekeyword");

            migrationBuilder.DeleteData(
                table: "AppConfigs",
                keyColumn: "key",
                keyValue: "HomeTitle");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProductInCategory",
                keyColumns: new[] { "category_id", "product_id" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "ProductInCategory",
                keyColumns: new[] { "category_id", "product_id" },
                keyValues: new object[] { 4, 2 });

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"), new Guid("69bd714f-9576-45ba-b5b7-f00649be00de") });

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "id",
                keyValue: 2);
        }
    }
}
