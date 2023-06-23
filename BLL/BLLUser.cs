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

        public bool validarDigito()
        {
            string digito = null;
            foreach (BEUser user in daluser.GetAll())
            {
                digito = digito + encriptar.GenerarMD5(user.Contraseña + user.Email + user.DNI + user.Usuario);
            }
            return daluser.validarDigito(encriptar.GenerarMD5(digito));

        }
        public  void regenerarDigito()
        {
            string digito = null;
            foreach (BEUser user in daluser.GetAll())
            {
                digito = digito + encriptar.GenerarMD5(user.Contraseña + user.Email + user.DNI + user.Usuario);
            }

            daluser.setDigitoTabla(encriptar.GenerarMD5(digito));
        }
        public void Create(IUser user)
        {
            user.Contraseña = encriptar.GenerarMD5(user.Contraseña);
            user.Digito = user.Contraseña + user.Email + user.DNI + user.Usuario;
            user.Digito = encriptar.GenerarMD5(user.Digito);

            daluser.CreateUser(user);
            daluser.setDigitoTabla(encriptar.GenerarMD5(daluser.armarDigitoTabla()));
            
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