﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace PocketMenuUI.Data.Migrations
{
    public partial class filerTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "SaladFilter",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SaladFilter",
                table: "AspNetUsers");
        }
    }
}
