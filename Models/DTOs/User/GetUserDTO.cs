using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTOs.User
{
    public class GetUserDTO
    {
        public int Id { get; set; }

        public string? Username { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Birthday { get; set; }

        public string? Email { get; set; }

        public string? PhoneNumber { get; set; }

        public List<Bottle>? Bottles { get; set; }
    }
}
