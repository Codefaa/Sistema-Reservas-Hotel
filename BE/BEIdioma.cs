using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Abstraccion;

namespace BE
{
    public class BEIdioma : IIdioma
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public IList<ITraduccion> Traducciones { get; set; }

        public BEIdioma()
        {
            Id = 1;
            Nombre = "Español";
            Traducciones = new List<ITraduccion>();
        }
        public void AgregarTraduccion(ITraduccion traduccion)
        {
            Traducciones.Add(traduccion);
        }

        public string BuscarTraduccion(string texto)
        {
            foreach (var traduccion in Traducciones)
            {
                if (traduccion.Palabra.Texto == texto)
                {
                    return traduccion.PalabraTraducida;
                }
            }
            return string.Empty;
        }
    }
}
