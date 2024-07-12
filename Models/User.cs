using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    [Table("user")]
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(15)]
        public required string Username { get; set; }

        [Required]
        [StringLength(50)]
        public required string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public required string LastName { get; set; }

        [Required]
        public required String Birthday { get; set; }

        public string? Email { get; set; }

        public string? PhoneNumber { get; set; }

        public List<Cellar>? Cellars { get; set; }

    }
}
