using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BEUserLog
    {
        public int Id { get; set; }     
        public int IdUser { get; set; }    
        public  int Dni { get; set; }
        public string Username { get; set; }
        public string Tipo {get; set; }
        public DateTime Fecha { get; set; }     
    }
}
