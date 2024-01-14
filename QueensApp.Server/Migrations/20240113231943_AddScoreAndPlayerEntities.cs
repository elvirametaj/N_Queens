using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace QueensApp.Server.Migrations
{
    public partial class AddScoreAndPlayerEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Username = table.Column<string>(type: "text", nullable: false),
                    TimeCreate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Scores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ScoreAmount = table.Column<int>(type: "integer", nullable: false),
                    PlayerId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Scores_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "TimeCreate", "Username" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 1, 13, 23, 19, 43, 342, DateTimeKind.Utc).AddTicks(8625), "Player1" },
                    { 2, new DateTime(2024, 1, 13, 23, 19, 43, 342, DateTimeKind.Utc).AddTicks(8710), "Player2" },
                    { 3, new DateTime(2024, 1, 13, 23, 19, 43, 342, DateTimeKind.Utc).AddTicks(8816), "Player3" }
                });

            migrationBuilder.InsertData(
                table: "Scores",
                columns: new[] { "Id", "PlayerId", "ScoreAmount" },
                values: new object[,]
                {
                    { 100, 3, 200 },
                    { 101, 2, 500 },
                    { 102, 1, 10 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Scores_PlayerId",
                table: "Scores",
                column: "PlayerId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Scores");

            migrationBuilder.DropTable(
                name: "Players");
        }
    }
}
