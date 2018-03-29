using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CheeseMVC.Migrations
{
    public partial class addCategoryID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Cheeses",
                newName: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Cheeses_CategoryId",
                table: "Cheeses",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cheeses_Categories_CategoryId",
                table: "Cheeses",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cheeses_Categories_CategoryId",
                table: "Cheeses");

            migrationBuilder.DropIndex(
                name: "IX_Cheeses_CategoryId",
                table: "Cheeses");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Cheeses",
                newName: "Type");
        }
    }
}
