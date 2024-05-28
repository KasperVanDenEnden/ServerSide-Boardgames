using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations.ApplicationDb
{
    /// <inheritdoc />
    public partial class GamenightBoardgameManyToMany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Boardgame_Gamenights_GamenightId",
                table: "Boardgame");

            migrationBuilder.DropIndex(
                name: "IX_Boardgame_GamenightId",
                table: "Boardgame");

            migrationBuilder.DropColumn(
                name: "GamenightId",
                table: "Boardgame");

            migrationBuilder.CreateTable(
                name: "GamenightBoardgame",
                columns: table => new
                {
                    GamenightId = table.Column<int>(type: "int", nullable: false),
                    BoardgameId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GamenightBoardgame", x => new { x.GamenightId, x.BoardgameId });
                    table.ForeignKey(
                        name: "FK_GamenightBoardgame_Boardgame_BoardgameId",
                        column: x => x.BoardgameId,
                        principalTable: "Boardgame",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GamenightBoardgame_Gamenights_GamenightId",
                        column: x => x.GamenightId,
                        principalTable: "Gamenights",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GamenightBoardgame_BoardgameId",
                table: "GamenightBoardgame",
                column: "BoardgameId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GamenightBoardgame");

            migrationBuilder.AddColumn<int>(
                name: "GamenightId",
                table: "Boardgame",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Boardgame_GamenightId",
                table: "Boardgame",
                column: "GamenightId");

            migrationBuilder.AddForeignKey(
                name: "FK_Boardgame_Gamenights_GamenightId",
                table: "Boardgame",
                column: "GamenightId",
                principalTable: "Gamenights",
                principalColumn: "Id");
        }
    }
}
