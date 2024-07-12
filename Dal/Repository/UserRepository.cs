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
            ////ancienne méthode
            //context.Users.Remove(await GetUserByIDAsync(id));
            //await context.SaveChangesAsync();

            await context.Users.Where(u => u.Id == id).ExecuteDeleteAsync();
        }

        //Update a user
        public async Task UpdateUserAsync(User user)
        {
            await context.Users
                .Where(u => u.Id == user.Id)
                .ExecuteUpdateAsync(update => update
                    .SetProperty(u => u.Username, user.Username)
                    .SetProperty(u => u.Email, user.Email)
                    .SetProperty(u => u.FirstName, user.FirstName)
                    .SetProperty(u => u.LastName, user.LastName)
                    .SetProperty(u => u.Birthday, user.Birthday)
                    .SetProperty(u => u.PhoneNumber, user.PhoneNumber)
                );
        }

        async Task<User> IUserRepository.GetUserWithBottlesAsync(int id)
        {
            throw new NotImplementedException();  
        }

        async Task<User> IUserRepository.GetUserWithCellarsAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
