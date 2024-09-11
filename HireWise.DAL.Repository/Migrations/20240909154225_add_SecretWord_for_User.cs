using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HireWise.DAL.Repository.Migrations
{
    /// <inheritdoc />
    public partial class add_SecretWord_for_User : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SecretWord",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SecretWord",
                table: "Users");
        }
    }
}
