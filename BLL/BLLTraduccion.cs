using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BE;
using DAL;

namespace BLL
{
    public class BLLTraduccion
    {
        DALObserver acceso = new DALObserver();
        public void AltaTraduccion(BETraduccion traduccion)
        {
            acceso.AltaTraduccion(traduccion);
        }
        public void BorrarTraduccion(BETraduccion traduccion)
        {
            acceso.BorrarTraduccion(traduccion);
        }
        public void ModificarTraduccion(BETraduccion traduccion)
        {
            acceso.ModificarTraduccion(traduccion);
        }
        public List<BETraduccion> LeerTraducciones(BETraduccion traduccion)
        {
            return acceso.LeerTraducciones(traduccion);
        }
    }
}