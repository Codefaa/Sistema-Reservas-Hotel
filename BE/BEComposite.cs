using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public abstract class BEComposite //Permisos
    {
        //https://gitlab.com/UAI-TCTD/usuario-patente-familia-con-composite-y-persistencia/-/blob/master/CompositePersistente.DAL/PermisosRepository.cs
        public virtual int Id { get; set; }
        public virtual string Nombre { get; set; }

        public abstract void AgregarHijo(BEComposite componente);
        public abstract void EliminarComponente(BEComposite componente);

        public List<BEComposite> ComponenteHijo = new List<BEComposite>(); 

    }
}
