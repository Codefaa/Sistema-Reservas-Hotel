using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BE;
using BLL;
using DAL;
using Servicios;

namespace BLL
{
    public class BLLIdioma
    {
        DALObserver acceso = new DALObserver();
        public BEIdioma GenerarDiccionarios(BEIdioma idioma)
        {
            BLLPalabra BLLunaPalabra = new BLLPalabra();
            List<BEPalabra> listaPalabras = BLLunaPalabra.LeerPalabras();

            int contadorTraducciones = acceso.GenerarDiccionarios(idioma).Traducciones.Count;

            if (contadorTraducciones == listaPalabras.Count)
            {
                return Sesion.Idioma = acceso.GenerarDiccionarios(idioma);
            }
            else
            {
                return null;
            }
        }
        public void AltaIdioma(BEIdioma idioma)
        {
            acceso.AltaIdioma(idioma);
        }
        public void BajaIdioma(BEIdioma idioma)
        {
            acceso.BajaIdioma(idioma);
        }
        public void ModificarIdioma(BEIdioma idioma)
        {
            acceso.ModificarIdioma(idioma);
        }
        public List<BEIdioma> LeerIdiomas()
        {
            return acceso.LeerIdiomas();
        }
    }
}
