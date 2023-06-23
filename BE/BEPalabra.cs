using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Abstraccion;

namespace BE
{
    public class BEPalabra : IPalabra
    {
        public int Id { get; set; }
        public string Texto { get; set; }

    }
}
