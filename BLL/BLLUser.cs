using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BE;
using Abstraccion;
using Servicios;
using DAL;

namespace BLL
{
    public class BLLUser
    {
        Encriptar encriptar = new Encriptar();
        public void Create(IUser user)
        {
            user.Contraseña = encriptar.GenerarMD5(user.Contraseña);

            DALUser daluser = new DALUser();
            daluser.CreateUser(user);
        }
    }
}
