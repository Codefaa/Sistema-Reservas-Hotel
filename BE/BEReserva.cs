using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BEReserva
    {
        public DateTime FechaEntrada { get; set; }
        public DateTime FechaSalida { get; set; }
        public decimal Adelanto { get; set; }
        public BECliente unCliente { get; set; }
        public BEHabitacion unaHabitacion { get; set; }
        public BEReserva()
        {

        }

        public override string ToString()
        {
            return unaHabitacion.Numero.ToString();
        }
    }
}
