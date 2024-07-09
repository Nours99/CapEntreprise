using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Repository
{
    public class UserRepository
    {
        private readonly CellarContext _cellarContext;
        public UserRepository(CellarContext cellarContext) 
        {
            _cellarContext = cellarContext;
        }

    }
}
