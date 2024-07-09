using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Cellar
    {
        public int Id { get; set; }
        public string? Designation { get; set; }
        public int UserId { get; set; }
        public required User User { get; set; }
        public List<Drawer> Drawers { get; set; }
    }
}
