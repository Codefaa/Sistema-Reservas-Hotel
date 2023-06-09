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
        DALUser daluser = new DALUser();

        public void Create(IUser user)
        {
            user.Contraseña = encriptar.GenerarMD5(user.Contraseña);

            daluser.CreateUser(user);
        }
        public IUser Login(string email, string password)
        {
            try
            {
                IUser user = GetUser(email);

                if (user != null && user.Contraseña != encriptar.GenerarMD5(password))
                {
                    user = null;
                }
                if (user != null)
                {
                    daluser.savelog(user.id, user.Usuario);
                }
                Sesion.Instance.Login(user);
                return user;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public IUser GetUser(string email)
        {
            IUser r = daluser.GetUser(email);
            return r;
        }

        public List<BEUser> getAllUsers()
        {
            return daluser.GetAll();
        }
        public void GuardarPermisos(BEUser u)
        {
            daluser.GuardarPermisos(u);
        }
    }
}