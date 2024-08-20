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
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options) { }

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
            //modelBuilder.Entity<UserGroup>()
            //    .HasMany(e => e.Roles)
            //    .WithMany(e => e.)
            //    .UsingEntity(
            //        "PostTag",
            //        l => l.HasOne(typeof(Tag)).WithMany().HasForeignKey("TagsId").HasPrincipalKey(nameof(Tag.Id)),
            //        r => r.HasOne(typeof(Post)).WithMany().HasForeignKey("PostsId").HasPrincipalKey(nameof(Post.Id)),
            //        j => j.HasKey("PostsId", "TagsId"));
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

//namespace HireWise.DAL.Repository
//{
//    public class DBContext : DbContext
//    {
//        public DBContext(DbContextOptions<DBContext> options) : base(options) { }

//        public DbSet<User> Users { get; set; } = null!;
//        public DbSet<Question> Questions { get; set; } = null!;
//        public DbSet<Record> Records { get; set; } = null!;
//        public DbSet<TechTransfer> TechTransfers { get; set; } = null!;
//        public DbSet<GradeLevel> GradeLevel { get; set; } = null!;

//        protected override void OnModelCreating(ModelBuilder modelBuilder)
//        {
//            modelBuilder.Entity<User>(entity =>
//            {
//                entity.HasKey(u => u.Id);

//                entity.Property(u => u.Login)
//                    .IsRequired()
//                    .HasMaxLength(50); // Пример ограничения длины

//                entity.HasIndex(u => u.Login)
//                    .IsUnique(); // Указывает, что значение должно быть уникальным

//                entity.Property(u => u.Email)
//                    .IsRequired()
//                    .HasMaxLength(100); // Пример ограничения длины

//                entity.HasIndex(u => u.Email)
//                    .IsUnique(); // Указывает, что значение должно быть уникальным

//                entity.Property(u => u.Password)
//                    .HasMaxLength(256); // Пример ограничения длины
//            });

//            modelBuilder.Entity<TechTransfer>()
//                .Property(g => g.Name)
//                .IsRequired(); // Указывает, что значение не может быть null

//            modelBuilder.Entity<TechTransfer>()
//                .HasIndex(g => g.Name)
//                .IsUnique(); // Указывает, что значение должно быть уникальным

//            modelBuilder.Entity<GradeLevel>()
//                .Property(g => g.Name)
//                .IsRequired(); // Указывает, что значение не может быть null

//            modelBuilder.Entity<GradeLevel>()
//                .HasIndex(g => g.Name)
//                .IsUnique(); // Указывает, что значение должно быть уникальным
//        }
//    }
//}
