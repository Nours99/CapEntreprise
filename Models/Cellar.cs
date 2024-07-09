using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
