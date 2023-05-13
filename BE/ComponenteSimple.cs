using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class ComponenteSimple : BEComposite
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        
        public override void AgregarHijo(BEComposite componente)
        {
            throw new NotImplementedException();
        }

        public override void EliminarComponente(BEComposite componente)
        {
            throw new NotImplementedException();
        }
    }
}
