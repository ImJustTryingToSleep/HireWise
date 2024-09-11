using HireWise.Common.Entities.TechTransferModels.DB;
using HireWise.Common.Entities.UserModels.DB;
using HireWise.DAL.Repository.Contracts;
using Microsoft.EntityFrameworkCore;

namespace HireWise.DAL.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly HireWiseDBContext _dbContext;

        public UserRepository(HireWiseDBContext dbContext)
        {
            _dbContext = dbContext; 
        }

        public async Task CreateAsync(User user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<User?> GetAsync(string email) //???
        {
            var user = await _dbContext.Users
                    .Include(u => u.UserGroup)
                        .ThenInclude(ug => ug.Roles)
                    .FirstOrDefaultAsync(u => u.Email == email);

            return user;
        }

        public async Task<User?> GetAsync(Guid id)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == id);
        }

        public IAsyncEnumerable<User> GetAsync()
        {
            return _dbContext.Users.AsAsyncEnumerable();
        }

        public async Task UpdateAsync(User user)
        {
            _dbContext.Entry(user).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.Id == id);
            _dbContext.Users.Remove(user);
            await _dbContext.SaveChangesAsync();
        }
    }
}
