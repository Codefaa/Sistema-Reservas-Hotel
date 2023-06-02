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
        public  int Id { get; set; }
        public  string Nombre { get; set; }
        public TipoPermiso Permiso { get; set; }

        public abstract void AgregarHijo(BEComposite componente);
        public abstract void EliminarComponente(BEComposite componente);

        public abstract IList<BEComposite> Hijos { get; }
        public override string ToString()
        {
            return Nombre;
        }
    }
}
