using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _1015bookstore.web.Migrations
{
    /// <inheritdoc />
    public partial class AddTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    parent_id = table.Column<int>(type: "int", nullable: false),
                    createdby = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    updatedby = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Categoryid = table.Column<int>(type: "int", nullable: true),
                    createdtime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updatedtime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    is_status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.id);
                    table.ForeignKey(
                        name: "FK_Categories_Categories_Categoryid",
                        column: x => x.Categoryid,
                        principalTable: "Categories",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "PromotionalCodes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    alias = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    createdby = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    updatedby = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    discount_rate = table.Column<int>(type: "int", nullable: false),
                    createdtime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updatedtime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    is_status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PromotionalCodes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    password = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    email = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    firstname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    lastname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    phone = table.Column<string>(type: "text", nullable: false),
                    createdtime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updatedtime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    is_status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "UserTypes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    alias = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    createdby = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    updatedby = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    createdtime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updatedtime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    is_status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTypes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    alias = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    category_id = table.Column<int>(type: "int", nullable: false),
                    image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    more_image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    price = table.Column<float>(type: "real", nullable: false),
                    starts = table.Column<float>(type: "real", nullable: true),
                    reviews = table.Column<int>(type: "int", nullable: true),
                    buy_count = table.Column<int>(type: "int", nullable: true),
                    flashsale = table.Column<bool>(type: "bit", nullable: true),
                    like_count = table.Column<int>(type: "int", nullable: true),
                    waranty = table.Column<int>(type: "int", nullable: false),
                    quanity = table.Column<int>(type: "int", nullable: false),
                    view_count = table.Column<int>(type: "int", nullable: true),
                    description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    createdby = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    updatedby = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    createdtime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updatedtime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    is_status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.id);
                    table.ForeignKey(
                        name: "FK_Product_Category",
                        column: x => x.category_id,
                        principalTable: "Categories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TypedCategories_Promotionals",
                columns: table => new
                {
                    category_id = table.Column<int>(type: "int", nullable: false),
                    promotional_id = table.Column<int>(type: "int", nullable: false),
                    expirationdate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypedCategories_Promotionals", x => new { x.category_id, x.promotional_id });
                    table.ForeignKey(
                        name: "FK_TypeCategories_Promotionals_1",
                        column: x => x.category_id,
                        principalTable: "Categories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TypeCategories_Promotionals_2",
                        column: x => x.promotional_id,
                        principalTable: "PromotionalCodes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    orderdate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    deliveried = table.Column<int>(type: "int", nullable: false),
                    deliverydate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    address_id = table.Column<int>(type: "int", nullable: true),
                    createdtime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updatedtime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    is_status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.id);
                    table.ForeignKey(
                        name: "FK_Order_User",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TypedUsers_Promotionals",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "int", nullable: false),
                    promotional_id = table.Column<int>(type: "int", nullable: false),
                    expirationdate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypedUsers_Promotionals", x => new { x.user_id, x.promotional_id });
                    table.ForeignKey(
                        name: "FK_TypeUsers_Promotionals_1",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TypeUsers_Promotionals_2",
                        column: x => x.promotional_id,
                        principalTable: "PromotionalCodes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserAddresses",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    is_default = table.Column<bool>(type: "bit", nullable: false),
                    receiver_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    receiver_phone = table.Column<string>(type: "text", nullable: false),
                    city = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    district = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    sub_district = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    address_detail = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    coordinates_X = table.Column<float>(type: "real", nullable: false),
                    coordinates_Y = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    createdtime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updatedtime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    is_status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAddresses", x => x.id);
                    table.ForeignKey(
                        name: "FK_UserAddress_User",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TypedUsers_UserTypes",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "int", nullable: false),
                    usertype_id = table.Column<int>(type: "int", nullable: false),
                    expirationdate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypedUsers_UserTypes", x => new { x.user_id, x.usertype_id });
                    table.ForeignKey(
                        name: "FK_TypeUsers_UserTypes_1",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TypeUsers_UserTypes_2",
                        column: x => x.usertype_id,
                        principalTable: "UserTypes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TypedUserTypes_Promotionals",
                columns: table => new
                {
                    usertype_id = table.Column<int>(type: "int", nullable: false),
                    promotional_id = table.Column<int>(type: "int", nullable: false),
                    expirationdate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypedUserTypes_Promotionals", x => new { x.usertype_id, x.promotional_id });
                    table.ForeignKey(
                        name: "FK_TypeUserTypes_Promotionals_1",
                        column: x => x.usertype_id,
                        principalTable: "UserTypes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TypeUserTypes_Promotionals_2",
                        column: x => x.promotional_id,
                        principalTable: "PromotionalCodes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "int", nullable: false),
                    product_id = table.Column<int>(type: "int", nullable: false),
                    productid = table.Column<int>(type: "int", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    price = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => new { x.product_id, x.user_id });
                    table.ForeignKey(
                        name: "FK_CartItem_User",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartItems_Products_productid",
                        column: x => x.productid,
                        principalTable: "Products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductDetails",
                columns: table => new
                {
                    product_id = table.Column<int>(type: "int", nullable: false),
                    brand = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    suppiler = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    author = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductDetails", x => x.product_id);
                    table.ForeignKey(
                        name: "FK_ProductDetails_Products_product_id",
                        column: x => x.product_id,
                        principalTable: "Products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    product_id = table.Column<int>(type: "int", nullable: false),
                    starts = table.Column<int>(type: "int", nullable: false),
                    contents = table.Column<string>(type: "ntext", nullable: false),
                    status = table.Column<bool>(type: "bit", nullable: false),
                    createdtime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    deletedtime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    deletedby = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.id);
                    table.ForeignKey(
                        name: "FK_Review_Product",
                        column: x => x.product_id,
                        principalTable: "Products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Review_User",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TypedProducts_Promotionals",
                columns: table => new
                {
                    product_id = table.Column<int>(type: "int", nullable: false),
                    promotional_id = table.Column<int>(type: "int", nullable: false),
                    expirationdate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypedProducts_Promotionals", x => new { x.product_id, x.promotional_id });
                    table.ForeignKey(
                        name: "FK_TypeProducts_Promotionals_1",
                        column: x => x.product_id,
                        principalTable: "Products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TypeProducts_Promotionals_2",
                        column: x => x.promotional_id,
                        principalTable: "PromotionalCodes",
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
                        name: "FK_Orderdetail_Order",
                        column: x => x.order_id,
                        principalTable: "Orders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orderdetail_Product",
                        column: x => x.product_id,
                        principalTable: "Products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_productid",
                table: "CartItems",
                column: "productid");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_user_id",
                table: "CartItems",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_Categoryid",
                table: "Categories",
                column: "Categoryid");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_order_id",
                table: "OrderDetails",
                column: "order_id");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_user_id",
                table: "Orders",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_Products_category_id",
                table: "Products",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_product_id",
                table: "Reviews",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_user_id",
                table: "Reviews",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_TypedCategories_Promotionals_promotional_id",
                table: "TypedCategories_Promotionals",
                column: "promotional_id");

            migrationBuilder.CreateIndex(
                name: "IX_TypedProducts_Promotionals_promotional_id",
                table: "TypedProducts_Promotionals",
                column: "promotional_id");

            migrationBuilder.CreateIndex(
                name: "IX_TypedUsers_Promotionals_promotional_id",
                table: "TypedUsers_Promotionals",
                column: "promotional_id");

            migrationBuilder.CreateIndex(
                name: "IX_TypedUsers_UserTypes_usertype_id",
                table: "TypedUsers_UserTypes",
                column: "usertype_id");

            migrationBuilder.CreateIndex(
                name: "IX_TypedUserTypes_Promotionals_promotional_id",
                table: "TypedUserTypes_Promotionals",
                column: "promotional_id");

            migrationBuilder.CreateIndex(
                name: "IX_UserAddresses_user_id",
                table: "UserAddresses",
                column: "user_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "ProductDetails");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "TypedCategories_Promotionals");

            migrationBuilder.DropTable(
                name: "TypedProducts_Promotionals");

            migrationBuilder.DropTable(
                name: "TypedUsers_Promotionals");

            migrationBuilder.DropTable(
                name: "TypedUsers_UserTypes");

            migrationBuilder.DropTable(
                name: "TypedUserTypes_Promotionals");

            migrationBuilder.DropTable(
                name: "UserAddresses");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "UserTypes");

            migrationBuilder.DropTable(
                name: "PromotionalCodes");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
