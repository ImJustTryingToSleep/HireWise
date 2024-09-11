using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HireWise.DAL.Repository.Migrations
{
    /// <inheritdoc />
    public partial class _techAndGrade_autoset : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "GradeLevels",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Junior" },
                    { 2, "Middle" },
                    { 3, "Senior" }
                });

            migrationBuilder.InsertData(
                table: "TechTransfers",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Java" },
                    { 2, "C#" },
                    { 3, "Python" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "GradeLevels",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "GradeLevels",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "GradeLevels",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TechTransfers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TechTransfers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TechTransfers",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
