using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    [Table("bottle")]
    public class Bottle
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(5)]
        public string Color { get; set; }

        [StringLength(50)]
        public string Appellation { get; set; }

        public int Vintage { get; set; }

        public int Location { get; set; }

        public int DrawerId { get; set; }

        public Drawer Drawer { get; set; }
    }
}
