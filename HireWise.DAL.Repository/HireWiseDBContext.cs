using HireWise.Common.Entities.GradeLevels.DB;
using HireWise.Common.Entities.QuestionModels.DB;
using HireWise.Common.Entities.RecordModels.DB;
using HireWise.Common.Entities.RoleModels.DB;
using HireWise.Common.Entities.TechTransferModels.DB;
using HireWise.Common.Entities.UserModels.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Linq.Expressions;

namespace HireWise.DAL.Repository
{
    public class HireWiseDBContext : DbContext
    {
        public HireWiseDBContext(DbContextOptions<HireWiseDBContext> options) : base(options) { }

        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Question> Questions { get; set; } = null!;
        public DbSet<Record> Records { get; set; } = null!;
        public DbSet<TechTransfer> TechTransfers { get; set; } = null!;
        public DbSet<GradeLevel> GradeLevels { get; set; } = null!;
        public DbSet<UserGroup> UserGroups { get; set; } = null!;
        public DbSet<Role> Roles { get; set; } = null!;

        // <summary>
        /// Конфигурирует модель при создании контекста базы данных.
        /// </summary>
        /// <param name="modelBuilder">Строитель модели.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ConfigureUser(modelBuilder);
            ConfigureTechTransfer(modelBuilder);
            ConfigureGradeLevel(modelBuilder);
        }

        /// <summary>
        /// Конфигурирует сущность пользователя.
        /// </summary>
        /// <param name="modelBuilder">Строитель модели.</param>
        private void ConfigureUser(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(u => u.Id);

                ConfigureUniqueProperty(entity, u => u.Login, 50);
                ConfigureUniqueProperty(entity, u => u.Email, 100);

                entity.Property(u => u.Password)
                    .HasMaxLength(256); // Пример ограничения длины
            });
        }

        /// <summary>
        /// Конфигурирует сущность модели передачи технологий.
        /// </summary>
        /// <param name="modelBuilder">Строитель модели.</param>
        private void ConfigureTechTransfer(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TechTransfer>(entity =>
            {
                entity.HasKey(u => u.Id);

                ConfigureRequiredUniqueProperty(entity, g => g.Name);
            });
            modelBuilder.Entity<TechTransfer>().HasData(
                new TechTransfer { Id = 1, Name = "Java" },
                new TechTransfer { Id = 2, Name = "C#" },
                new TechTransfer { Id = 3, Name = "Python" });
        }

        /// <summary>
        /// Конфигурирует сущность уровня оценки.
        /// </summary>
        /// <param name="modelBuilder">Строитель модели.</param>
        private void ConfigureGradeLevel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GradeLevel>(entity =>
            {
                entity.HasKey(u => u.Id);

                ConfigureRequiredUniqueProperty(entity, g => g.Name);
            });
            modelBuilder.Entity<GradeLevel>().HasData(
               new GradeLevel { Id = 1, Name = "Junior" },
               new GradeLevel { Id = 2, Name = "Middle" },
               new GradeLevel { Id = 3, Name = "Senior" });
        }

        /// <summary>
        /// Конфигурирует уникальное свойство сущности с заданной максимальной длиной.
        /// </summary>
        /// <typeparam name="T">Тип сущности.</typeparam>
        /// <param name="entity">Строитель сущности.</param>
        /// <param name="propertyExpression">Выражение для свойства.</param>
        /// <param name="maxLength">Максимальная длина свойства.</param>
        private void ConfigureUniqueProperty<T>(EntityTypeBuilder<T> entity, Expression<Func<T, object?>> propertyExpression, int maxLength) where T : class
        {
            entity.Property(propertyExpression)
                .IsRequired()
                .HasMaxLength(maxLength);

            entity.HasIndex(propertyExpression).IsUnique();
        }

        /// <summary>
        /// Конфигурирует обязательное уникальное свойство сущности.
        /// </summary>
        /// <typeparam name="T">Тип сущности.</typeparam>
        /// <param name="entity">Строитель сущности.</param>
        /// <param name="propertyExpression">Выражение для свойства.</param>
        private void ConfigureRequiredUniqueProperty<T>(EntityTypeBuilder<T> entity, Expression<Func<T, object?>> propertyExpression) where T : class
        {
            entity.Property(propertyExpression)
                .IsRequired();

            entity.HasIndex(propertyExpression).IsUnique();
        }
    }
}
