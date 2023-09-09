using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BE;
using DAL;

namespace BLL
{
    public class BLLHabitacion
    {
        DALHabitacion dal = new DALHabitacion();

        public List<BEHabitacion> LeerHabitaciones()
        {
            return dal.LeerHabitaciones();
        }
        public void AgregarHabitacion(BEHabitacion unaHabitacion)
        {
            dal.AgregarHabitacion(unaHabitacion);
        }
        public void BajaHabitacion(BEHabitacion unaHabitacion)
        {
            dal.BajaHabitacion(unaHabitacion);
        }
        public void ModificarHabitacion(BEHabitacion unaHabitacion)
        {
            dal.ModificarHabitacion(unaHabitacion);
        }
        public void CambiarEstado(BEHabitacion unaHabitacion)
        {
            dal.CambiarEstado(unaHabitacion);
        }
        public List<BEHabitacion> BuscarHabitacion(string pisoHabitacion)
        {
            return dal.BuscarHabitacion(pisoHabitacion);
        }
    }
}