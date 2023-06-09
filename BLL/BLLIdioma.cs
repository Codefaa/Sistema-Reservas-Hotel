using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BE;
using DAL;

namespace BLL
{
    public class BLLIdioma
    {
        DALObserver acceso = new DALObserver();
        public BEIdioma GenerarDiccionarios(BEIdioma idioma)
        {
            return acceso.GenerarDiccionarios(idioma);
        }
    }
}
