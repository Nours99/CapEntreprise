using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    internal class Bottle
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public string Appellation { get; set; }
        public int Vintage { get; set; }
        public int Location { get; set; }
    }
}
