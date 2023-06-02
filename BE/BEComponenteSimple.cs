using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BEComponenteSimple : BEComposite
    {

        public override IList<BEComposite> Hijos
        {
            get
            {
                return new List<BEComposite>();
            }

        }
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
