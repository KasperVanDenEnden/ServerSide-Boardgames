using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations.ApplicationDb
{
    /// <inheritdoc />
    public partial class BasicEntitiesWithFK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Housenumber = table.Column<int>(type: "int", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Postal = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Gamenights",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HostId = table.Column<int>(type: "int", nullable: false),
                    AddressId = table.Column<int>(type: "int", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gamenights", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Gamenights_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Gamenights_User_HostId",
                        column: x => x.HostId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Boardgame",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Genre = table.Column<int>(type: "int", nullable: false),
                    IsPG18 = table.Column<bool>(type: "bit", nullable: false),
                    Image = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Gametype = table.Column<int>(type: "int", nullable: false),
                    GamenightId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boardgame", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Boardgame_Gamenights_GamenightId",
                        column: x => x.GamenightId,
                        principalTable: "Gamenights",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Participating",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    GamenightId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participating", x => new { x.UserId, x.GamenightId });
                    table.ForeignKey(
                        name: "FK_Participating_Gamenights_GamenightId",
                        column: x => x.GamenightId,
                        principalTable: "Gamenights",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Participating_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Boardgame_GamenightId",
                table: "Boardgame",
                column: "GamenightId");

            migrationBuilder.CreateIndex(
                name: "IX_Gamenights_AddressId",
                table: "Gamenights",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Gamenights_HostId",
                table: "Gamenights",
                column: "HostId");

            migrationBuilder.CreateIndex(
                name: "IX_Participating_GamenightId",
                table: "Participating",
                column: "GamenightId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Boardgame");

            migrationBuilder.DropTable(
                name: "Participating");

            migrationBuilder.DropTable(
                name: "Gamenights");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
