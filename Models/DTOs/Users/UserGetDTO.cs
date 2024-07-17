using Models.DTOs.Bottles;

namespace Models.DTOs.Users
{
    public class UserGetDTO
    {
        public int Id { get; set; }

        public string? Username { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Birthday { get; set; }

        public string? Email { get; set; }

        public string? PhoneNumber { get; set; }

        public List<BottleGetDTO>? Bottles { get; set; }
    }
}
