using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;

namespace BLL
{
    public class BLLPermisos
    {
        DALPermisos _permisos;
        public BLLPermisos()
        {
            _permisos = new DALPermisos();
        }
        public Array GetAllPermission()
        {
            return _permisos.GetAllPermission();
        }
        public bool Existe(BEComposite c, int id)
        {
            bool existe = false;

            if (c.Id.Equals(id))
                existe = true;
            else

                foreach (var item in c.Hijos)
                {

                    existe = Existe(item, id);
                    if (existe) return true;
                }

            return existe;

        }
        public IList<BEComposite> GetAll(string familia)
        {
            return _permisos.GetAll(familia);

        }

        public void GuardarFamilia(BEComponente_compuesto c)
        {
            _permisos.GuardarFamilia(c);
        }
        public IList<BEComponenteSimple> GetAllPatentes()
        {
            return _permisos.GetAllPatentes();
        }
        public IList<BEComponente_compuesto> GetAllCompuestos()
        {
            return _permisos.GetAllCompuestos();
        }
        public BEComposite GuardarComponente(BEComposite p, bool esfamilia)
        {
            return _permisos.GuardarComponente(p, esfamilia);
        }
        public void FillFamilyComponents(BEComponente_compuesto familia)
        {
            _permisos.FillFamilyComponents(familia);
        }

    }
}
