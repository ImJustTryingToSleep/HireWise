using HireWise.Common.Entities.UserModels.DB;
using HireWise.DAL.Repository.Contracts;
using Microsoft.EntityFrameworkCore;

namespace HireWise.DAL.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DBContext _dbContext;

        public UserRepository(DBContext dbContext)
        {
            _dbContext = dbContext; 
        }

        public async Task CreateUserAsync(User user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<User?> GetAsync(string login, string password)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(u => u.Login == login && u.Password == password);
        }
    }
}
