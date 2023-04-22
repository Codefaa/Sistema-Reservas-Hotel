using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Abstraccion;

namespace BE
{
    public class BEUser : IUser
    {
        public string Usuario { get; set; }
        public string Contraseña { get; set; }
        public int DNI { get; set; }
        public string Email { get; set; }
        public BEUser()
        {

        }
    }
}
