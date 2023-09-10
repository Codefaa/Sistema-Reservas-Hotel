using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DAL;
using BE;

namespace BLL
{
    public class BLLReserva
    {
        DALReserva dal = new DALReserva();

        public void AgregarReserva(BEReserva unaReserva)
        {
            dal.AgregarReserva(unaReserva);
        }
        public void BajaReserva(BEReserva unaReserva)
        {
            dal.BajaReserva(unaReserva);
        }
        public void ModificarReserva(BEReserva unaReserva)
        {
            dal.ModificarReserva(unaReserva);
        }
        public BEReserva BuscarReserva(BEHabitacion unaHabitacion)
        {
            return dal.BuscarReserva(unaHabitacion);
        }
        public List<BEReserva> LeerReservas()
        {
            return dal.LeerReservas();
        }
        public decimal CalcularPrecioFinal(BEReserva unaReserva)
        {
            TimeSpan diferencia = unaReserva.FechaSalida - unaReserva.FechaEntrada;
            int diferenciaDias = diferencia.Days + 1;
            return unaReserva.unaHabitacion.Precio * diferenciaDias;
        }
        public decimal CalcularTotal(BEReserva unaReserva)
        {
            return unaReserva.PrecioFinal - unaReserva.Adelanto;
        }
    }
}
