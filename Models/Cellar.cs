using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    [Table("cellar")]
    public class Cellar
    {
        [Key]
        public int Id { get; set; }

        [StringLength(70)]
        public string? Designation { get; set; }
       
        public int UserId { get; set; }

        public required User User { get; set; }

        public List<Drawer> Drawers { get; set; }
    }
}
