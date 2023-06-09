using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraccion
{
    public interface IIdioma
    {
        int Id { get; set; }
        string Nombre { get; set; }
        IList<ITraduccion> Traducciones { get; set; }
        void AgregarTraduccion(ITraduccion traduccion);
        string BuscarTraduccion(string texto);
    }
}
