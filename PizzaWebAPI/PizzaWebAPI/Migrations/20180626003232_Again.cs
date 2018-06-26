using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace PizzaWebAPI.Migrations
{
    public partial class Again : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "account",
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
                    table.PrimaryKey("PK_account", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ingredients",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ingredients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "payment_types",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_payment_types", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "restaurants",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Address = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    CoordX = table.Column<float>(nullable: false),
                    CoordY = table.Column<float>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_restaurants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "statuses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_statuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "accounts_roles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AccountId = table.Column<int>(nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    EmployeeId = table.Column<int>(nullable: true),
                    RoleName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_accounts_roles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_accounts_roles_account_AccountId",
                        column: x => x.AccountId,
                        principalTable: "account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "menu_items",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    HasIngredients = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    RestaurantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_menu_items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_menu_items_restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "restaurants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "employee_data",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AccountRoleId = table.Column<int>(nullable: false),
                    Phone = table.Column<string>(nullable: true),
                    Position = table.Column<string>(nullable: true),
                    RestaurantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employee_data", x => x.Id);
                    table.ForeignKey(
                        name: "FK_employee_data_accounts_roles_AccountRoleId",
                        column: x => x.AccountRoleId,
                        principalTable: "accounts_roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_employee_data_restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "restaurants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "menu_item_options",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MenuItemId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_menu_item_options", x => x.Id);
                    table.ForeignKey(
                        name: "FK_menu_item_options_menu_items_MenuItemId",
                        column: x => x.MenuItemId,
                        principalTable: "menu_items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "menu_items_-_ingredients",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IngredientId = table.Column<int>(nullable: false),
                    MenuItemId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_menu_items_-_ingredients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_menu_items_-_ingredients_ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "ingredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_menu_items_-_ingredients_menu_items_MenuItemId",
                        column: x => x.MenuItemId,
                        principalTable: "menu_items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "orders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Annotation = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    EmployeeId = table.Column<int>(nullable: true),
                    PaymentTypeId = table.Column<int>(nullable: false),
                    RestaurantId = table.Column<int>(nullable: false),
                    StatusId = table.Column<int>(nullable: false),
                    TotalPrice = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_orders_employee_data_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "employee_data",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_orders_payment_types_PaymentTypeId",
                        column: x => x.PaymentTypeId,
                        principalTable: "payment_types",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_orders_statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "order_menu_items",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Count = table.Column<int>(nullable: false),
                    MenuItemId = table.Column<int>(nullable: false),
                    MenuItemOptionId = table.Column<int>(nullable: false),
                    OrderId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_order_menu_items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_order_menu_items_menu_items_MenuItemId",
                        column: x => x.MenuItemId,
                        principalTable: "menu_items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_order_menu_items_menu_item_options_MenuItemOptionId",
                        column: x => x.MenuItemOptionId,
                        principalTable: "menu_item_options",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_order_menu_items_orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "order_menu_items_-_ingredients",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IngredientId = table.Column<int>(nullable: false),
                    OrderMenuItemId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_order_menu_items_-_ingredients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_order_menu_items_-_ingredients_ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "ingredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_order_menu_items_-_ingredients_order_menu_items_OrderMenuItemId",
                        column: x => x.OrderMenuItemId,
                        principalTable: "order_menu_items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_accounts_roles_AccountId",
                table: "accounts_roles",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_employee_data_AccountRoleId",
                table: "employee_data",
                column: "AccountRoleId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_employee_data_RestaurantId",
                table: "employee_data",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_menu_item_options_MenuItemId",
                table: "menu_item_options",
                column: "MenuItemId");

            migrationBuilder.CreateIndex(
                name: "IX_menu_items_RestaurantId",
                table: "menu_items",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_menu_items_-_ingredients_IngredientId",
                table: "menu_items_-_ingredients",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_menu_items_-_ingredients_MenuItemId",
                table: "menu_items_-_ingredients",
                column: "MenuItemId");

            migrationBuilder.CreateIndex(
                name: "IX_order_menu_items_MenuItemId",
                table: "order_menu_items",
                column: "MenuItemId");

            migrationBuilder.CreateIndex(
                name: "IX_order_menu_items_MenuItemOptionId",
                table: "order_menu_items",
                column: "MenuItemOptionId");

            migrationBuilder.CreateIndex(
                name: "IX_order_menu_items_OrderId",
                table: "order_menu_items",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_order_menu_items_-_ingredients_IngredientId",
                table: "order_menu_items_-_ingredients",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_order_menu_items_-_ingredients_OrderMenuItemId",
                table: "order_menu_items_-_ingredients",
                column: "OrderMenuItemId");

            migrationBuilder.CreateIndex(
                name: "IX_orders_EmployeeId",
                table: "orders",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_orders_PaymentTypeId",
                table: "orders",
                column: "PaymentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_orders_StatusId",
                table: "orders",
                column: "StatusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "menu_items_-_ingredients");

            migrationBuilder.DropTable(
                name: "order_menu_items_-_ingredients");

            migrationBuilder.DropTable(
                name: "ingredients");

            migrationBuilder.DropTable(
                name: "order_menu_items");

            migrationBuilder.DropTable(
                name: "menu_item_options");

            migrationBuilder.DropTable(
                name: "orders");

            migrationBuilder.DropTable(
                name: "menu_items");

            migrationBuilder.DropTable(
                name: "employee_data");

            migrationBuilder.DropTable(
                name: "payment_types");

            migrationBuilder.DropTable(
                name: "statuses");

            migrationBuilder.DropTable(
                name: "accounts_roles");

            migrationBuilder.DropTable(
                name: "restaurants");

            migrationBuilder.DropTable(
                name: "account");
        }
    }
}
