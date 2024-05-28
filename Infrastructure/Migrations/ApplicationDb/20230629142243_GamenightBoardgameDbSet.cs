using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations.ApplicationDb
{
    /// <inheritdoc />
    public partial class GamenightBoardgameDbSet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GamenightBoardgame_Boardgame_BoardgameId",
                table: "GamenightBoardgame");

            migrationBuilder.DropForeignKey(
                name: "FK_GamenightBoardgame_Gamenights_GamenightId",
                table: "GamenightBoardgame");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GamenightBoardgame",
                table: "GamenightBoardgame");

            migrationBuilder.RenameTable(
                name: "GamenightBoardgame",
                newName: "GamenightBoardgames");

            migrationBuilder.RenameIndex(
                name: "IX_GamenightBoardgame_BoardgameId",
                table: "GamenightBoardgames",
                newName: "IX_GamenightBoardgames_BoardgameId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GamenightBoardgames",
                table: "GamenightBoardgames",
                columns: new[] { "GamenightId", "BoardgameId" });

            migrationBuilder.AddForeignKey(
                name: "FK_GamenightBoardgames_Boardgame_BoardgameId",
                table: "GamenightBoardgames",
                column: "BoardgameId",
                principalTable: "Boardgame",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GamenightBoardgames_Gamenights_GamenightId",
                table: "GamenightBoardgames",
                column: "GamenightId",
                principalTable: "Gamenights",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GamenightBoardgames_Boardgame_BoardgameId",
                table: "GamenightBoardgames");

            migrationBuilder.DropForeignKey(
                name: "FK_GamenightBoardgames_Gamenights_GamenightId",
                table: "GamenightBoardgames");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GamenightBoardgames",
                table: "GamenightBoardgames");

            migrationBuilder.RenameTable(
                name: "GamenightBoardgames",
                newName: "GamenightBoardgame");

            migrationBuilder.RenameIndex(
                name: "IX_GamenightBoardgames_BoardgameId",
                table: "GamenightBoardgame",
                newName: "IX_GamenightBoardgame_BoardgameId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GamenightBoardgame",
                table: "GamenightBoardgame",
                columns: new[] { "GamenightId", "BoardgameId" });

            migrationBuilder.AddForeignKey(
                name: "FK_GamenightBoardgame_Boardgame_BoardgameId",
                table: "GamenightBoardgame",
                column: "BoardgameId",
                principalTable: "Boardgame",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GamenightBoardgame_Gamenights_GamenightId",
                table: "GamenightBoardgame",
                column: "GamenightId",
                principalTable: "Gamenights",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
