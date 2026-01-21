using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace QuizApplication.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionString = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Answers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnswerText = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    QuestionId = table.Column<int>(type: "int", nullable: false),
                    IsCorrect = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Answers_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "CategoryId", "QuestionString" },
                values: new object[,]
                {
                    { 1, 4, "What is the capital of France?" },
                    { 2, 3, "Which planet is known as the 'Red Planet'?" },
                    { 3, 2, "Who wrote the play 'Romeo and Juliet'?" },
                    { 4, 3, "What is the closest planet to the sun?" },
                    { 5, 1, "Which gas do plants absorb from the atmosphere during photosynthesis?" },
                    { 6, 2, "Who painted the Mona Lisa?" },
                    { 7, 1, "What is the largest mammal in the world?" },
                    { 8, 4, "What is the capital of Japan?" },
                    { 9, 1, "Which gas do humans exhale when they breathe?" },
                    { 10, 1, "What is the largest organ in the human body?" }
                });

            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "Id", "AnswerText", "IsCorrect", "QuestionId" },
                values: new object[,]
                {
                    { 1, "Rome", false, 1 },
                    { 2, "Madrid", false, 1 },
                    { 3, "Berlin", false, 1 },
                    { 4, "Brussels", false, 1 },
                    { 5, "Jupiter", false, 2 },
                    { 6, "Venus", false, 2 },
                    { 7, "Mars", true, 2 },
                    { 8, "Saturn", false, 2 },
                    { 9, "Charles Dickens", false, 3 },
                    { 10, "William Shakespeare", true, 3 },
                    { 11, "Jane Austen", false, 3 },
                    { 12, "Mark Twain", false, 3 },
                    { 13, "Mercury", true, 4 },
                    { 14, "Uranus", false, 4 },
                    { 15, "Neptunus", false, 4 },
                    { 16, "Earth", false, 4 },
                    { 17, "Oxygen", false, 5 },
                    { 18, "Nitrogen", false, 5 },
                    { 19, "Carbon dioxide", true, 5 },
                    { 20, "Hydrogen", false, 5 },
                    { 21, "Vincent van Gogh", false, 6 },
                    { 22, "Pablo Picasso", false, 6 },
                    { 23, "Leonardo da Vinci", true, 6 },
                    { 24, "Michelangelo", false, 6 },
                    { 25, "Elephant", false, 7 },
                    { 26, "Giraffe", false, 7 },
                    { 27, "Blue whale", true, 7 },
                    { 28, "Lion", false, 7 },
                    { 29, "Beijing", false, 8 },
                    { 30, "Seoul", false, 8 },
                    { 31, "Shanghai", false, 8 },
                    { 32, "Tokyo", true, 8 },
                    { 33, "Oxygen", false, 9 },
                    { 34, "Carbon dioxide", true, 9 },
                    { 35, "Hydrogen", false, 9 },
                    { 36, "Nitrogen", false, 9 },
                    { 37, "Brain", false, 10 },
                    { 38, "Skin", true, 10 },
                    { 39, "Heart", false, 10 },
                    { 40, "Liver", false, 10 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Answers_QuestionId",
                table: "Answers",
                column: "QuestionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Answers");

            migrationBuilder.DropTable(
                name: "Questions");
        }
    }
}
