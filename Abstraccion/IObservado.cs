using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraccion
{
    public interface IObservado
    {
        IList<IObservador> ObservadoresRegistrados { get; set; }
        void RegistrarObservador(IObservador observador);
        void DesregistrarObservador(IObservador observador);
        void ActualizarObservadores(IIdioma idioma);
    }
}
