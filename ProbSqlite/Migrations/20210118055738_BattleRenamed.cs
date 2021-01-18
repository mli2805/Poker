using Microsoft.EntityFrameworkCore.Migrations;

namespace ProbSqlite.Migrations
{
    public partial class BattleRenamed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PairToPairs");

            migrationBuilder.CreateTable(
                name: "Battles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstPairId = table.Column<int>(nullable: true),
                    SecondPairId = table.Column<int>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Win = table.Column<int>(nullable: false),
                    Draw = table.Column<int>(nullable: false),
                    Lose = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Battles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Battles_Pairs_FirstPairId",
                        column: x => x.FirstPairId,
                        principalTable: "Pairs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Battles_Pairs_SecondPairId",
                        column: x => x.SecondPairId,
                        principalTable: "Pairs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Battles_FirstPairId",
                table: "Battles",
                column: "FirstPairId");

            migrationBuilder.CreateIndex(
                name: "IX_Battles_SecondPairId",
                table: "Battles",
                column: "SecondPairId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Battles");

            migrationBuilder.CreateTable(
                name: "PairToPairs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Draw = table.Column<int>(type: "INTEGER", nullable: false),
                    FirstPairId = table.Column<int>(type: "INTEGER", nullable: true),
                    Lose = table.Column<int>(type: "INTEGER", nullable: false),
                    SecondPairId = table.Column<int>(type: "INTEGER", nullable: true),
                    Title = table.Column<string>(type: "TEXT", nullable: true),
                    Win = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PairToPairs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PairToPairs_Pairs_FirstPairId",
                        column: x => x.FirstPairId,
                        principalTable: "Pairs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PairToPairs_Pairs_SecondPairId",
                        column: x => x.SecondPairId,
                        principalTable: "Pairs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PairToPairs_FirstPairId",
                table: "PairToPairs",
                column: "FirstPairId");

            migrationBuilder.CreateIndex(
                name: "IX_PairToPairs_SecondPairId",
                table: "PairToPairs",
                column: "SecondPairId");
        }
    }
}
