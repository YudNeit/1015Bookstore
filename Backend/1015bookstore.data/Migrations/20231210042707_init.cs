using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _1015bookstore.data.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppConfigs",
                columns: table => new
                {
                    key = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    value = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppConfigs", x => x.key);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    categoryparentid = table.Column<int>(type: "int", nullable: true),
                    createdby = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    datecreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updatedby = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dateupdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    orderdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    paymentdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    deliverydate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    completedate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    address_id = table.Column<int>(type: "int", nullable: false),
                    user_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    alias = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    price = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    start_count = table.Column<float>(type: "real", nullable: false, defaultValue: 0f),
                    review_count = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    buy_count = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    flashsale = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    like_count = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    waranty = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    quanity = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    view_count = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    brand = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    madein = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    mfgdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    suppiler = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    author = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    nop = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    yop = table.Column<int>(type: "int", nullable: false),
                    createdby = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    datecreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updatedby = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dateupdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "PromotionalCodes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fromdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    todate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    createdby = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    datecreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updatedby = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dateupdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    discount_rate = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    status = table.Column<int>(type: "int", nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PromotionalCodes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    transactiondate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    externaltransactionid = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    fee = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    result = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false),
                    provider = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "UserAddresses",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    is_default = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    receiver_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    receiver_phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    city = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    district = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    sub_district = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    address_detail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    coordinates_X = table.Column<float>(type: "real", nullable: false),
                    coordinates_Y = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAddresses", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    product_id = table.Column<int>(type: "int", nullable: false),
                    user_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    datecreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => new { x.product_id, x.user_id });
                    table.ForeignKey(
                        name: "FK_Carts_Products_product_id",
                        column: x => x.product_id,
                        principalTable: "Products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    order_id = table.Column<int>(type: "int", nullable: false),
                    product_id = table.Column<int>(type: "int", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    price = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => new { x.product_id, x.order_id });
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_order_id",
                        column: x => x.order_id,
                        principalTable: "Orders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Products_product_id",
                        column: x => x.product_id,
                        principalTable: "Products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductInCategory",
                columns: table => new
                {
                    product_id = table.Column<int>(type: "int", nullable: false),
                    category_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductInCategory", x => new { x.product_id, x.category_id });
                    table.ForeignKey(
                        name: "FK_ProductInCategory_Categories_category_id",
                        column: x => x.category_id,
                        principalTable: "Categories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductInCategory_Products_product_id",
                        column: x => x.product_id,
                        principalTable: "Products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_order_id",
                table: "OrderDetails",
                column: "order_id");

            migrationBuilder.CreateIndex(
                name: "IX_ProductInCategory_category_id",
                table: "ProductInCategory",
                column: "category_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppConfigs");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "ProductInCategory");

            migrationBuilder.DropTable(
                name: "PromotionalCodes");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "UserAddresses");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
