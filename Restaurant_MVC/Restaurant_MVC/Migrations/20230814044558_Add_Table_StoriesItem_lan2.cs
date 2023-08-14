using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restaurant_MVC.Migrations
{
    /// <inheritdoc />
    public partial class Add_Table_StoriesItem_lan2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LongDescription",
                table: "StoriesItem",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShortDescription",
                table: "StoriesItem",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LongDescription",
                table: "StoriesItem");

            migrationBuilder.DropColumn(
                name: "ShortDescription",
                table: "StoriesItem");
        }
    }
}
