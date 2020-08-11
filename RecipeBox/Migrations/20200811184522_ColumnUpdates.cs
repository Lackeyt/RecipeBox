using Microsoft.EntityFrameworkCore.Migrations;

namespace RecipeBox.Migrations
{
    public partial class ColumnUpdates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_AspNetUsers_CategoryId",
                table: "Recipes");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Recipes",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Recipes_CategoryId",
                table: "Recipes",
                newName: "IX_Recipes_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_AspNetUsers_UserId",
                table: "Recipes",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_AspNetUsers_UserId",
                table: "Recipes");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Recipes",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Recipes_UserId",
                table: "Recipes",
                newName: "IX_Recipes_CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_AspNetUsers_CategoryId",
                table: "Recipes",
                column: "CategoryId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
