using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Keodou.Notes.Web.Migrations
{
    /// <inheritdoc />
    public partial class RemakeEntries : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Notes",
                keyColumn: "Id",
                keyValue: new Guid("8f1c9edb-252e-4abb-90c8-5601940d9e8a"),
                column: "UserId",
                value: new Guid("2b5944b6-3e64-4904-a74e-c2b93e598d0f"));

            migrationBuilder.UpdateData(
                table: "Notes",
                keyColumn: "Id",
                keyValue: new Guid("921eca58-a972-46bc-8e40-b4236ba0cfba"),
                column: "UserId",
                value: new Guid("e859f530-c911-4a70-9e94-9c16042ba884"));

            migrationBuilder.UpdateData(
                table: "Notes",
                keyColumn: "Id",
                keyValue: new Guid("decb6c0d-7369-43a7-ad39-769039b9241d"),
                column: "UserId",
                value: new Guid("e859f530-c911-4a70-9e94-9c16042ba884"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Login", "Password" },
                values: new object[,]
                {
                    { new Guid("2b5944b6-3e64-4904-a74e-c2b93e598d0f"), "sa2", "sa2" },
                    { new Guid("e859f530-c911-4a70-9e94-9c16042ba884"), "sa", "sa" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("2b5944b6-3e64-4904-a74e-c2b93e598d0f"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("e859f530-c911-4a70-9e94-9c16042ba884"));

            migrationBuilder.UpdateData(
                table: "Notes",
                keyColumn: "Id",
                keyValue: new Guid("8f1c9edb-252e-4abb-90c8-5601940d9e8a"),
                column: "UserId",
                value: new Guid("845d105e-1943-40af-b7f1-c76ece311183"));

            migrationBuilder.UpdateData(
                table: "Notes",
                keyColumn: "Id",
                keyValue: new Guid("921eca58-a972-46bc-8e40-b4236ba0cfba"),
                column: "UserId",
                value: new Guid("dcda2ef5-4727-4be4-839f-bbc351a755e0"));

            migrationBuilder.UpdateData(
                table: "Notes",
                keyColumn: "Id",
                keyValue: new Guid("decb6c0d-7369-43a7-ad39-769039b9241d"),
                column: "UserId",
                value: new Guid("dcda2ef5-4727-4be4-839f-bbc351a755e0"));
        }
    }
}
