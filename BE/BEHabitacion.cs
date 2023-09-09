using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BEHabitacion
    {
        public int ID { get; set; }
        public int Numero { get; set; }
        public decimal Precio { get; set; }
        public string Categoria { get; set; }
        public string Piso { get; set; }
        public string Estado { get; set; }
        public BEHabitacion()
        {

        }

        public override string ToString()
        {
            return Numero.ToString();
        }
    }
}
