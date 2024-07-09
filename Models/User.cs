namespace Models
{
    public class User
    {
        public int Id { get; set; }
        public required string UserName { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required DateOnly Birthday { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }

    }
}
