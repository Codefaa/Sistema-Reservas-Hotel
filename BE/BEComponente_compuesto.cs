using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BEComponente_compuesto :BEComposite //Permisos
    {

        private IList<BEComposite> _hijos;
        public int Codigo { get; set; }
        public BEComponente_compuesto()
        {
            _hijos = new List<BEComposite>();
        }
        public override IList<BEComposite> Hijos
        {
            get
            {
                return _hijos.ToArray();
            }

        }
        public BEComponente_compuesto(int codigo, string nombre)
        {
            this.Codigo = codigo;
            this.Nombre = nombre;
        }

        public override void AgregarHijo(BEComposite componente)
        {
            this._hijos.Add(componente);
        }
        public  void VaciarHijos()
        {
            _hijos = new List<BEComposite>();
        }
        public override void EliminarComponente(BEComposite componente)
        {
            this._hijos.Remove(componente);
        }
    }
}
