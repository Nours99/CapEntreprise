using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [Table("drawer")]
    public class Drawer
    {
        [Key]
        public int Id { get; set; }

        public int DrawerNbr { get; set; }

        public int CellarId { get; set; }

        public Cellar Cellar { get; set; }

        public List<Bottle> Bottles { get; set; }
    }
}
