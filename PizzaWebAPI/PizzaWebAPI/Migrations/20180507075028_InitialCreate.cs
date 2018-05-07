using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace PizzaWebAPI.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(nullable: true),
                    EmailVerificationHash = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    IsConfirmed = table.Column<bool>(nullable: false),
                    Login = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Payment_Type",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment_Type", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Restaurants",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Adress = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    CoordX = table.Column<float>(nullable: false),
                    CoordY = table.Column<float>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AccountRole",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AccountId = table.Column<int>(nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    Employee_Id = table.Column<int>(nullable: false),
                    RoleName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountRole", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccountRole_Account_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Menu_Items",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Has_Ingredients = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    RestaurantId = table.Column<int>(nullable: true),
                    Restaurant_Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menu_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Menu_Items_Restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Employee_Data",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AccountRole_Id = table.Column<int>(nullable: false),
                    Phone = table.Column<string>(nullable: true),
                    Position = table.Column<string>(nullable: true),
                    RestaurantId = table.Column<int>(nullable: true),
                    Restaurant_Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee_Data", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employee_Data_AccountRole_AccountRole_Id",
                        column: x => x.AccountRole_Id,
                        principalTable: "AccountRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employee_Data_Restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Menu_Item_Ingredients",
                columns: table => new
                {
                    Menu_Item_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Ingredient_Id = table.Column<int>(nullable: false),
                    Menu_Items_IdId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menu_Item_Ingredients", x => x.Menu_Item_Id);
                    table.ForeignKey(
                        name: "FK_Menu_Item_Ingredients_Ingredients_Ingredient_Id",
                        column: x => x.Ingredient_Id,
                        principalTable: "Ingredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Menu_Item_Ingredients_Menu_Items_Menu_Items_IdId",
                        column: x => x.Menu_Items_IdId,
                        principalTable: "Menu_Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    EmployeeId = table.Column<int>(nullable: true),
                    Employee_Id = table.Column<int>(nullable: false),
                    Payment_Type_Id = table.Column<int>(nullable: false),
                    Status_Id = table.Column<int>(nullable: false),
                    Total_Price = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Employee_Data_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee_Data",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Payment_Type_Payment_Type_Id",
                        column: x => x.Payment_Type_Id,
                        principalTable: "Payment_Type",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Status_Status_Id",
                        column: x => x.Status_Id,
                        principalTable: "Status",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Order_Menu_Items",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Count = table.Column<int>(nullable: false),
                    Menu_ItemId = table.Column<int>(nullable: true),
                    Menu_Item_Id = table.Column<int>(nullable: false),
                    Menu_Item_Option_Id = table.Column<int>(nullable: false),
                    OrderId = table.Column<int>(nullable: true),
                    Order_Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order_Menu_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_Menu_Items_Menu_Items_Menu_ItemId",
                        column: x => x.Menu_ItemId,
                        principalTable: "Menu_Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Order_Menu_Items_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Menu_Item_Options",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Menu_ItemId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Order_Menu_Id = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menu_Item_Options", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Menu_Item_Options_Menu_Items_Menu_ItemId",
                        column: x => x.Menu_ItemId,
                        principalTable: "Menu_Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Menu_Item_Options_Order_Menu_Items_Order_Menu_Id",
                        column: x => x.Order_Menu_Id,
                        principalTable: "Order_Menu_Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Order_Menu_Item_Ingredients",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IngredientId = table.Column<int>(nullable: true),
                    Ingredient_Id = table.Column<int>(nullable: false),
                    Order_Menu_ItemId = table.Column<int>(nullable: true),
                    Order_Menu_Item_Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order_Menu_Item_Ingredients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_Menu_Item_Ingredients_Ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Order_Menu_Item_Ingredients_Order_Menu_Items_Order_Menu_ItemId",
                        column: x => x.Order_Menu_ItemId,
                        principalTable: "Order_Menu_Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountRole_AccountId",
                table: "AccountRole",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_Data_AccountRole_Id",
                table: "Employee_Data",
                column: "AccountRole_Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employee_Data_RestaurantId",
                table: "Employee_Data",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_Menu_Item_Ingredients_Ingredient_Id",
                table: "Menu_Item_Ingredients",
                column: "Ingredient_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Menu_Item_Ingredients_Menu_Items_IdId",
                table: "Menu_Item_Ingredients",
                column: "Menu_Items_IdId");

            migrationBuilder.CreateIndex(
                name: "IX_Menu_Item_Options_Menu_ItemId",
                table: "Menu_Item_Options",
                column: "Menu_ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Menu_Item_Options_Order_Menu_Id",
                table: "Menu_Item_Options",
                column: "Order_Menu_Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Menu_Items_RestaurantId",
                table: "Menu_Items",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_Menu_Item_Ingredients_IngredientId",
                table: "Order_Menu_Item_Ingredients",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_Menu_Item_Ingredients_Order_Menu_ItemId",
                table: "Order_Menu_Item_Ingredients",
                column: "Order_Menu_ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_Menu_Items_Menu_ItemId",
                table: "Order_Menu_Items",
                column: "Menu_ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_Menu_Items_OrderId",
                table: "Order_Menu_Items",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_EmployeeId",
                table: "Orders",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_Payment_Type_Id",
                table: "Orders",
                column: "Payment_Type_Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_Status_Id",
                table: "Orders",
                column: "Status_Id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Menu_Item_Ingredients");

            migrationBuilder.DropTable(
                name: "Menu_Item_Options");

            migrationBuilder.DropTable(
                name: "Order_Menu_Item_Ingredients");

            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.DropTable(
                name: "Order_Menu_Items");

            migrationBuilder.DropTable(
                name: "Menu_Items");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Employee_Data");

            migrationBuilder.DropTable(
                name: "Payment_Type");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropTable(
                name: "AccountRole");

            migrationBuilder.DropTable(
                name: "Restaurants");

            migrationBuilder.DropTable(
                name: "Account");
        }
    }
}
