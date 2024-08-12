using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HireWise.DAL.Repository.Migrations
{
    /// <inheritdoc />
    public partial class rework_question : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GradeId",
                table: "Questions");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GradeId",
                table: "Questions",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
