using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Keodou.Notes.Web.Migrations
{
    /// <inheritdoc />
    public partial class NewEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("845d105e-1943-40af-b7f1-c76ece311183"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("dcda2ef5-4727-4be4-839f-bbc351a755e0"));

            migrationBuilder.CreateTable(
                name: "Notes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Head = table.Column<string>(type: "nvarchar(25)", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notes_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Notes",
                columns: new[] { "Id", "Head", "Text", "UserId" },
                values: new object[,]
                {
                    { new Guid("8f1c9edb-252e-4abb-90c8-5601940d9e8a"), "Резюме", "Составить резюме для поиска вакансии на джуна", new Guid("845d105e-1943-40af-b7f1-c76ece311183") },
                    { new Guid("921eca58-a972-46bc-8e40-b4236ba0cfba"), "Обед", "Сьесть суп и купить чипсы", new Guid("dcda2ef5-4727-4be4-839f-bbc351a755e0") },
                    { new Guid("decb6c0d-7369-43a7-ad39-769039b9241d"), "Завтрак", "Приготовить яичницу и сварить кофе", new Guid("dcda2ef5-4727-4be4-839f-bbc351a755e0") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Notes_UserId",
                table: "Notes",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notes");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Login", "Password" },
                values: new object[,]
                {
                    { new Guid("845d105e-1943-40af-b7f1-c76ece311183"), "sa", "sa" },
                    { new Guid("dcda2ef5-4727-4be4-839f-bbc351a755e0"), "sa2", "sa2" }
                });
        }
    }
}
