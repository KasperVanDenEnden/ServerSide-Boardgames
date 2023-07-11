using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations.ApplicationDb
{
    /// <inheritdoc />
    public partial class Reviews : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GamenightBoardgames_Boardgame_BoardgameId",
                table: "GamenightBoardgames");

            migrationBuilder.DropForeignKey(
                name: "FK_Gamenights_User_HostId",
                table: "Gamenights");

            migrationBuilder.DropForeignKey(
                name: "FK_Participating_Gamenights_GamenightId",
                table: "Participating");

            migrationBuilder.DropForeignKey(
                name: "FK_Participating_User_UserId",
                table: "Participating");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Participating",
                table: "Participating");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Boardgame",
                table: "Boardgame");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "Participating",
                newName: "Participatings");

            migrationBuilder.RenameTable(
                name: "Boardgame",
                newName: "Boardgames");

            migrationBuilder.RenameIndex(
                name: "IX_Participating_GamenightId",
                table: "Participatings",
                newName: "IX_Participatings_GamenightId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Participatings",
                table: "Participatings",
                columns: new[] { "UserId", "GamenightId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Boardgames",
                table: "Boardgames",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GamenightId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_Gamenights_GamenightId",
                        column: x => x.GamenightId,
                        principalTable: "Gamenights",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reviews_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_GamenightId",
                table: "Reviews",
                column: "GamenightId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_UserId",
                table: "Reviews",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_GamenightBoardgames_Boardgames_BoardgameId",
                table: "GamenightBoardgames",
                column: "BoardgameId",
                principalTable: "Boardgames",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Gamenights_Users_HostId",
                table: "Gamenights",
                column: "HostId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Participatings_Gamenights_GamenightId",
                table: "Participatings",
                column: "GamenightId",
                principalTable: "Gamenights",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Participatings_Users_UserId",
                table: "Participatings",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GamenightBoardgames_Boardgames_BoardgameId",
                table: "GamenightBoardgames");

            migrationBuilder.DropForeignKey(
                name: "FK_Gamenights_Users_HostId",
                table: "Gamenights");

            migrationBuilder.DropForeignKey(
                name: "FK_Participatings_Gamenights_GamenightId",
                table: "Participatings");

            migrationBuilder.DropForeignKey(
                name: "FK_Participatings_Users_UserId",
                table: "Participatings");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Participatings",
                table: "Participatings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Boardgames",
                table: "Boardgames");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "User");

            migrationBuilder.RenameTable(
                name: "Participatings",
                newName: "Participating");

            migrationBuilder.RenameTable(
                name: "Boardgames",
                newName: "Boardgame");

            migrationBuilder.RenameIndex(
                name: "IX_Participatings_GamenightId",
                table: "Participating",
                newName: "IX_Participating_GamenightId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Participating",
                table: "Participating",
                columns: new[] { "UserId", "GamenightId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Boardgame",
                table: "Boardgame",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GamenightBoardgames_Boardgame_BoardgameId",
                table: "GamenightBoardgames",
                column: "BoardgameId",
                principalTable: "Boardgame",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Gamenights_User_HostId",
                table: "Gamenights",
                column: "HostId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Participating_Gamenights_GamenightId",
                table: "Participating",
                column: "GamenightId",
                principalTable: "Gamenights",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Participating_User_UserId",
                table: "Participating",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
