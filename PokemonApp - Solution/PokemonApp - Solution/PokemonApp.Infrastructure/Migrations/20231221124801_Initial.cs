using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PokemonApp.Infrastructure.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pokemons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pokemons", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Pokemons",
                columns: new[] { "Id", "Level", "Name", "Type" },
                values: new object[,]
                {
                    { 1, 15, "Pikachu", "Electric" },
                    { 2, 20, "Charmander", "Fire" },
                    { 3, 8, "Squirtle", "Water" },
                    { 4, 8, "Bulbasaur", "Grass" },
                    { 5, 5, "Jigglypuff", "Fairy" },
                    { 6, 20, "Snorlax", "Normal" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pokemons");
        }
    }
}
