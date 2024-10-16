using BikeStoreApp_BackEnd.Models;

namespace BikeStoreApp_BackEnd.IServices
{
    public interface IUserRepository
    {
        Task<User> RegisterAsync(User user);
        Task<User> LoginAsync(string username, string password);
        Task<User> GetUserByIdAsync(int id);
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<bool> UpdateUserAsync(User user);
        Task<bool> DeleteUserAsync(int id);
        Task<User> GetUserByUsernameAsync(string username);
    }
}
