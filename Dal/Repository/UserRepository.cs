using Dal.Interface;
using Microsoft.EntityFrameworkCore;
using Models;


namespace Dal.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly CellarContext context;
        public UserRepository(CellarContext cellarContext)
        {
            context = cellarContext;
        }

        // Get all users
        public async Task<List<User>> GetUsersAsync()
        {
            return await context.Users.ToListAsync();
        }

        // Get a user by his ID
        public async Task<User> GetUserByIDAsync(int id)
        {

            if (id > 0)
            {
                try
                {
                    return await context.Users.FindAsync(id);
                }
                catch
                {
                    throw new Exception("User not found");
                }
            }
            else
            {
                throw new Exception("Invalid ID");
            }
        }

        // Get a user by his Username
        public async Task<User> GetUserByUsernameAsync(string username)
        {
            return await context.Users.FirstOrDefaultAsync(u => u.Username == username);
        }

        // Get a user by his Email
        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await context.Users.FirstOrDefaultAsync(e => e.Email == email);
        }

        // Create a user
        public async Task CreateUserAsync(User user)
        {
            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();
        }

        //Delete a user
        public async Task DeleteUserAsync(int id)
        {
            throw new NotImplementedException();
        }

        //Update a user
        public Task UpdateUserAsync(User user)
        {
            throw new NotImplementedException();
        }
    }
}
