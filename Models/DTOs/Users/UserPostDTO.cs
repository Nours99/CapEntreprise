using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTOs.Users
{
    public class UserPostDTO
    {
        public required string Username { get; set; }

        public required string FirstName { get; set; }

        public required string LastName { get; set; }

        public required string Birthday { get; set; }

        public string? Email { get; set; }

        public string? PhoneNumber { get; set; }
    }
}
