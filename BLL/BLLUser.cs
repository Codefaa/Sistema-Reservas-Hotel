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
        public IUser GetUser(string email)
        {
            DALUser daluser = new DALUser();
            IUser r = daluser.GetUser(email);
            return r;
        }
        public IUser Login(string email, string password, DateTime schedule)
        {
            try
            {
                DALUser daluser = new DALUser();

                Encriptar encriptar = new Encriptar();
                IUser user = GetUser(email);
                
                if (user != null && user.Contraseña != encriptar.GenerarMD5(password)) {
                    user = null;
                }
                if(user != null)
                {
                    daluser.savelog(user.id, schedule);
                }
                Sesion.Instance.Login(user);
                return user;
            }
            catch(Exception e)
            {
                throw e;
            }
        }


    }
}
