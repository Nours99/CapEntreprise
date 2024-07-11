using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal.Interface;
using Models;


namespace Dal.Repository
{
    public class UserRepository : IUserRepository

    {
        private readonly CellarContext _cellarContext;
        public UserRepository(CellarContext cellarContext)
        {
            _cellarContext = cellarContext;
        }

        public List<User> GetUsers()
        {
            return _cellarContext.Users.ToList();
        }
    }
}
