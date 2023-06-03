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
        public int id { get; set; }
        public string Usuario { get; set; }
        public string Contraseña { get; set; }
        public int DNI { get; set; }
        public string Email { get; set; }
        public DateTime Horario { get; set; }
        public BEUser()
        {
            _permisos = new List<BEComposite>();
        }

        List<BEComposite> _permisos;
        public List<BEComposite> Permisos
        {
            get
            {
                return _permisos;
            }
        }
        public override string ToString()
        {
            return Usuario;
        }
    }
}
