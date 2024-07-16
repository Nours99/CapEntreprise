using Models;

namespace Dal.Interface
{
    public interface IUserRepository
    {
        Task<List<User>> GetUsersAsync();
        Task<User> GetUserByIDAsync(int id);
        Task<User> GetUserByUsernameAsync(string username);
        Task<User> GetUserByEmailAsync(string email);
        Task CreateUserAsync(User user);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(int id);
        Task<List<Bottle>> GetUserWithBottlesAsync(int id);
        Task<User> GetUserWithCellarsAsync(int id);
        
    }
}
