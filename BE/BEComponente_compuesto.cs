using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BEComponente_compuesto :BEComposite //Permisos
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public BEComponente_compuesto(int codigo, string nombre)
        {
            this.Codigo = codigo;
            this.Nombre = nombre;
        }

        public override void AgregarHijo(BEComposite componente)
        {
            this.ComponenteHijo.Add(componente);
        }

        public override void EliminarComponente(BEComposite componente)
        {
            this.ComponenteHijo.Remove(componente);
        }
    }
}
