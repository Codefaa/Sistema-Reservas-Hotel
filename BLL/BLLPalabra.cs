using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BE;
using DAL;

namespace BLL
{
    public class BLLPalabra
    {
        DALObserver acceso = new DALObserver();
        public List<BEPalabra> LeerPalabras()
        {
            return acceso.LeerPalabras();
        }
    }
}
