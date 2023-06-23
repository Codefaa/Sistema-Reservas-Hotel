using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraccion
{
    public interface ITraduccion
    {
        string PalabraTraducida { get; set; }
        IPalabra Palabra { get; set; }
        IIdioma Idioma { get; set; }
    }
}
