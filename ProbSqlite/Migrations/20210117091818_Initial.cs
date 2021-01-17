using Microsoft.EntityFrameworkCore.Migrations;

namespace ProbSqlite.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PairToPairs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstPair = table.Column<string>(nullable: true),
                    SecondPair = table.Column<string>(nullable: true),
                    Win = table.Column<int>(nullable: false),
                    Draw = table.Column<int>(nullable: false),
                    Lose = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PairToPairs", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PairToPairs");
        }
    }
}
