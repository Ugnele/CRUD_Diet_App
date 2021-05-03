using Microsoft.EntityFrameworkCore.Migrations;

namespace CrudDietApp.Migrations
{
    public partial class updatedRecipedb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_Users_UserId",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Recipes");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Recipes",
                newName: "CreatedById");

            migrationBuilder.RenameIndex(
                name: "IX_Recipes_UserId",
                table: "Recipes",
                newName: "IX_Recipes_CreatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_Users_CreatedById",
                table: "Recipes",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_Users_CreatedById",
                table: "Recipes");

            migrationBuilder.RenameColumn(
                name: "CreatedById",
                table: "Recipes",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Recipes_CreatedById",
                table: "Recipes",
                newName: "IX_Recipes_UserId");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Recipes",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_Users_UserId",
                table: "Recipes",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
