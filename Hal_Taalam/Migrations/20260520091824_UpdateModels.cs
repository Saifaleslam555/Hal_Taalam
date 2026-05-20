using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hal_Taalam.Migrations
{
    /// <inheritdoc />
    public partial class UpdateModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameResults_Players_playerId1",
                table: "GameResults");

            migrationBuilder.DropIndex(
                name: "IX_GameResults_playerId1",
                table: "GameResults");

            migrationBuilder.DropColumn(
                name: "playerId1",
                table: "GameResults");

            migrationBuilder.AlterColumn<int>(
                name: "playerId",
                table: "GameResults",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_GameResults_playerId",
                table: "GameResults",
                column: "playerId");

            migrationBuilder.AddForeignKey(
                name: "FK_GameResults_Players_playerId",
                table: "GameResults",
                column: "playerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameResults_Players_playerId",
                table: "GameResults");

            migrationBuilder.DropIndex(
                name: "IX_GameResults_playerId",
                table: "GameResults");

            migrationBuilder.AlterColumn<string>(
                name: "playerId",
                table: "GameResults",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "playerId1",
                table: "GameResults",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_GameResults_playerId1",
                table: "GameResults",
                column: "playerId1");

            migrationBuilder.AddForeignKey(
                name: "FK_GameResults_Players_playerId1",
                table: "GameResults",
                column: "playerId1",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
