using HireWise.Common.Utilities;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HireWise.DAL.Repository.Migrations
{
    /// <inheritdoc />
    public partial class InitData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
            table: "Roles",
            columns: new[] { "Id", "Name" },
            values: new object[,]
            {
                { 1, "User" },
                { 2, "Admin" },
                { 3, "Root" }
            });

            // Добавляем группы пользователей
            migrationBuilder.InsertData(
                table: "UserGroups",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                { 1, "RegisteredUsers" },
                { 2, "SuperUser" }
                });

            // связываем группы и роли
            migrationBuilder.InsertData(
            table: "RoleUserGroup",
            columns: new[] { "RolesId", "UserGroupsId" },
            values: new object[,]
            {
                    { 1, 1 },
                    { 1, 2 },
                    { 2, 2 },
                    { 3, 2 },
            });

            // Добавляем root пользователя
            var passHasher = new PasswordHasher();
            var hashedPassword = passHasher.HashPassword("root");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Login", "Email", "Password", "UserGroupId", "IsBanned" },
                values: new object[]
                {
                    Guid.NewGuid(), "root", "root@mail.example", hashedPassword, 2, false // ID группы SuperUser
                });
        }
    }
}
