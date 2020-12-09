using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ecommerce.Domain.Migrations
{
    public partial class RemoveCousponFromCart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carts_Couspons_CousponId",
                table: "Carts");

            migrationBuilder.DropIndex(
                name: "IX_Carts_CousponId",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "CousponId",
                table: "Carts");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CousponId",
                table: "Carts",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Carts_CousponId",
                table: "Carts",
                column: "CousponId");

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_Couspons_CousponId",
                table: "Carts",
                column: "CousponId",
                principalTable: "Couspons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
