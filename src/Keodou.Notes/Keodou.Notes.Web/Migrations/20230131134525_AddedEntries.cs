using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Keodou.Notes.Web.Migrations
{
    /// <inheritdoc />
    public partial class AddedEntries : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Login", "Password" },
                values: new object[,]
                {
                    { new Guid("845d105e-1943-40af-b7f1-c76ece311183"), "sa", "sa" },
                    { new Guid("dcda2ef5-4727-4be4-839f-bbc351a755e0"), "sa2", "sa2" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("845d105e-1943-40af-b7f1-c76ece311183"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("dcda2ef5-4727-4be4-839f-bbc351a755e0"));
        }
    }
}
