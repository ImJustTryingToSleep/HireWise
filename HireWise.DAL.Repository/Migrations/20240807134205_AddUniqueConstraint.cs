using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HireWise.DAL.Repository.Migrations
{
    /// <inheritdoc />
    public partial class AddUniqueConstraint : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_GradeLevel_GradeLevelId",
                table: "Questions");

            migrationBuilder.DropForeignKey(
                name: "FK_Records_GradeLevel_GradeLevelId",
                table: "Records");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GradeLevel",
                table: "GradeLevel");

            migrationBuilder.RenameTable(
                name: "GradeLevel",
                newName: "GradeLevels");

            migrationBuilder.RenameColumn(
                name: "TechTransferName",
                table: "TechTransfers",
                newName: "Name");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "character varying(256)",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Login",
                table: "Users",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GradeLevels",
                table: "GradeLevels",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Login",
                table: "Users",
                column: "Login",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TechTransfers_Name",
                table: "TechTransfers",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GradeLevels_Name",
                table: "GradeLevels",
                column: "Name",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_GradeLevels_GradeLevelId",
                table: "Questions",
                column: "GradeLevelId",
                principalTable: "GradeLevels",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Records_GradeLevels_GradeLevelId",
                table: "Records",
                column: "GradeLevelId",
                principalTable: "GradeLevels",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_GradeLevels_GradeLevelId",
                table: "Questions");

            migrationBuilder.DropForeignKey(
                name: "FK_Records_GradeLevels_GradeLevelId",
                table: "Records");

            migrationBuilder.DropIndex(
                name: "IX_Users_Email",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_Login",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_TechTransfers_Name",
                table: "TechTransfers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GradeLevels",
                table: "GradeLevels");

            migrationBuilder.DropIndex(
                name: "IX_GradeLevels_Name",
                table: "GradeLevels");

            migrationBuilder.RenameTable(
                name: "GradeLevels",
                newName: "GradeLevel");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "TechTransfers",
                newName: "TechTransferName");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(256)",
                oldMaxLength: 256);

            migrationBuilder.AlterColumn<string>(
                name: "Login",
                table: "Users",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AddPrimaryKey(
                name: "PK_GradeLevel",
                table: "GradeLevel",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_GradeLevel_GradeLevelId",
                table: "Questions",
                column: "GradeLevelId",
                principalTable: "GradeLevel",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Records_GradeLevel_GradeLevelId",
                table: "Records",
                column: "GradeLevelId",
                principalTable: "GradeLevel",
                principalColumn: "Id");
        }
    }
}
