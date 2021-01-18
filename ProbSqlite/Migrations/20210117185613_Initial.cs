using Microsoft.EntityFrameworkCore.Migrations;

namespace ProbSqlite.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cards",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Suit = table.Column<int>(nullable: false),
                    Kind = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Potentials",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Value = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Potentials", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pairs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstId = table.Column<int>(nullable: true),
                    SecondId = table.Column<int>(nullable: true),
                    PairString = table.Column<string>(nullable: true),
                    PotentialId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pairs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pairs_Cards_FirstId",
                        column: x => x.FirstId,
                        principalTable: "Cards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pairs_Potentials_PotentialId",
                        column: x => x.PotentialId,
                        principalTable: "Potentials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pairs_Cards_SecondId",
                        column: x => x.SecondId,
                        principalTable: "Cards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PairToPairs",
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
                name: "IX_Pairs_FirstId",
                table: "Pairs",
                column: "FirstId");

            migrationBuilder.CreateIndex(
                name: "IX_Pairs_PotentialId",
                table: "Pairs",
                column: "PotentialId");

            migrationBuilder.CreateIndex(
                name: "IX_Pairs_SecondId",
                table: "Pairs",
                column: "SecondId");

            migrationBuilder.CreateIndex(
                name: "IX_PairToPairs_FirstPairId",
                table: "PairToPairs",
                column: "FirstPairId");

            migrationBuilder.CreateIndex(
                name: "IX_PairToPairs_SecondPairId",
                table: "PairToPairs",
                column: "SecondPairId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PairToPairs");

            migrationBuilder.DropTable(
                name: "Pairs");

            migrationBuilder.DropTable(
                name: "Cards");

            migrationBuilder.DropTable(
                name: "Potentials");
        }
    }
}
