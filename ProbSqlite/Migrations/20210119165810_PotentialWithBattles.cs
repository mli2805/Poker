using Microsoft.EntityFrameworkCore.Migrations;

namespace ProbSqlite.Migrations
{
    public partial class PotentialWithBattles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Draw",
                table: "Potentials",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Lose",
                table: "Potentials",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Win",
                table: "Potentials",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Draw",
                table: "Potentials");

            migrationBuilder.DropColumn(
                name: "Lose",
                table: "Potentials");

            migrationBuilder.DropColumn(
                name: "Win",
                table: "Potentials");
        }
    }
}
