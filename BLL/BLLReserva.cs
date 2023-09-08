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
        public BEReserva BuscarReserva(BEHabitacion unaHabitacion)
        {
            return dal.BuscarReserva(unaHabitacion);
        }
        public List<BEReserva> LeerReservas()
        {
            return dal.LeerReservas();
        }
    }
}
