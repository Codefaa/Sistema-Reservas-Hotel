using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BE;
using DAL;

namespace BLL
{
    public class BLLBitacora
    {
        DALBitacora acceso = new DALBitacora();
        public void insertBitacora(string usuario, string categoria, string texto)
        {
            acceso.savelog(usuario, categoria, texto);
        }
        public List<BEBitacora> Buscar(string categoria,DateTime desde, DateTime hasta)
        {
            return acceso.Buscar(categoria,desde,hasta);
        }
        public List<BEBitacora> getAll()
        {
            return acceso.getAll();
        }
    }
}
