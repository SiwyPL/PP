using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace PizzaWebAPI.Migrations
{
    public partial class After3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderMenuId",
                table: "menu_item_options");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrderMenuId",
                table: "menu_item_options",
                nullable: false,
                defaultValue: 0);
        }
    }
}
