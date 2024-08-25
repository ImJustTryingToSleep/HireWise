﻿using HireWise.BLL.Logic.Contracts.Services;
using HireWise.BLL.Logic.Services;
using HireWise.Common.Entities.RoleModels.DB;
using HireWise.Common.Entities.UserModels.DB;
using HireWise.DAL.Repository;

namespace HireWise.Api.Initializer
{
    public static class DbInitializer
    {
        public static void Initialize(DBContext context, IPasswordService passwordService)
        {
            context.Database.EnsureCreated();

            // Проверка на наличие данных
            if (context.Roles.Any() || context.UserGroups.Any() || context.Users.Any())
            {
                return; // База данных уже инициализирована
            }

            // Создаем роли и группы пользователей
            var userRole = new Role { Id = 1, Name = "User" };
            var adminRole = new Role { Id = 2, Name = "Admin" };
            var rootRole = new Role { Id = 3, Name = "Root" };

            var regUserGroup = new UserGroup { Id = 1, Name = "RegisteredUsers" };
            var sprUser = new UserGroup { Id = 2, Name = "SuperUser" };

            // Добавляем роли и группы в контекст
            context.Roles.AddRange(userRole, adminRole, rootRole);
            context.UserGroups.AddRange(regUserGroup, sprUser);

            // Сохраняем изменения
            context.SaveChanges();

            // Создаем root пользователя
            var rootUser = new User
            {
                Login = "root",
                Password = passwordService.HashPassword("root"),
                UserGroupId = sprUser.Id,
                UserGroup = sprUser
            };

            context.Users.Add(rootUser);
            context.SaveChanges();

            context.SaveChanges();
        }
    }

}
