using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restaurant_MVC.Migrations
{
    /// <inheritdoc />
    public partial class Add_Foreign_Key_Lan1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_FoodItem_FoodCategoryId",
                table: "FoodItem",
                column: "FoodCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_FoodItem_FoodCategory_FoodCategoryId",
                table: "FoodItem",
                column: "FoodCategoryId",
                principalTable: "FoodCategory",
                principalColumn: "FoodCategoryId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FoodItem_FoodCategory_FoodCategoryId",
                table: "FoodItem");

            migrationBuilder.DropIndex(
                name: "IX_FoodItem_FoodCategoryId",
                table: "FoodItem");
        }
    }
}
