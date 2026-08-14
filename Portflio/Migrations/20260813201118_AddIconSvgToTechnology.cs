using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Portflio.Migrations
{
    /// <inheritdoc />
    public partial class AddIconSvgToTechnology : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IconSvg",
                table: "Technologies",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IconSvg",
                table: "Technologies");
        }
    }
}
