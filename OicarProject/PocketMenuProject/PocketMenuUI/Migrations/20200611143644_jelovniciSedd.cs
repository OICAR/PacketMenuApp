﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace PocketMenuUI.Migrations
{
    public partial class jelovniciSedd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Meals",
                columns: new[] { "ID", "Amount", "Ingredients", "Price", "Title" },
                values: new object[] { 1, 1, "Sauce,Lettuce,Leafs", 18.0, "Salad" });

            migrationBuilder.InsertData(
                table: "Meals",
                columns: new[] { "ID", "Amount", "Ingredients", "Price", "Title" },
                values: new object[] { 2, 1, "Cheese,Ham,Tomato sauce", 33.0, "Pizza" });

            migrationBuilder.InsertData(
                table: "Meals",
                columns: new[] { "ID", "Amount", "Ingredients", "Price", "Title" },
                values: new object[] { 3, 1, "Meat,sauce", 26.0, "Spaghetti bolognese" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "ID",
                keyValue: 3);
        }
    }
}
