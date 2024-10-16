using BikeStoreApp_BackEnd.Data;
using BikeStoreApp_BackEnd.IServices;
using BikeStoreApp_BackEnd.Models;
using Microsoft.EntityFrameworkCore;

namespace BikeStoreApp_BackEnd.Services
{
    public class UserRepository : IUserRepository
    {
        private readonly BikeStoreContext _context;

        public UserRepository(BikeStoreContext context)
        {
            _context = context;
        }

        public async Task<User> RegisterAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User> LoginAsync(string username, string password)
        {
            // Find user by username
            var user = await _context.Users.SingleOrDefaultAsync(u => u.UserName == username);

            // Check if user exists and verify password (here it's simple plain text comparison)
            if (user != null && user.Password == password)
            {
                return user;
            }
            return null;
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<bool> UpdateUserAsync(User user)
        {
            _context.Users.Update(user);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return false;

            _context.Users.Remove(user);
            return await _context.SaveChangesAsync() > 0;
        }
        public async Task<User> GetUserByUsernameAsync(string username)
        {
            return await _context.Users.SingleOrDefaultAsync(u => u.UserName == username);
        }
    }
}
