using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Abstraccion;

namespace BE
{
    public class BETraduccion : ITraduccion
    {
        public int Id { get; set; }
        public string PalabraTraducida { get; set; }
        public IPalabra Palabra { get; set; }
    }
}
