using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraccion
{
    public interface IUser
    {
        string Usuario { get; set; }
        string Contraseña { get; set; }
        int DNI { get; set; }
        string Email { get; set; }
    }
}
