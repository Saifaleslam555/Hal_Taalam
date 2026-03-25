using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hal_Taalam.Migrations
{
    /// <inheritdoc />
    public partial class xp_player : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "xp",
                table: "Players",
                type: "int",
                nullable: false,
                defaultValue: 20);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "xp",
                table: "Players");
        }
    }
}
