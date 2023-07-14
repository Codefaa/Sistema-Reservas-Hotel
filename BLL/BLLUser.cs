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
            List<BEUser> list = daluser.GetAll();
            if(list.Count == 0)
            {
                return true;
            }
            foreach (BEUser user in list)
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
            user.Email = encriptar.Encrypt(user.Email);
            user.Digito = user.Contraseña + user.Email + user.DNI + user.Usuario;
            user.Digito = encriptar.GenerarMD5(user.Digito);

            daluser.CreateUser(user);
            //se crea el digito desde 0
            this.regenerarDigito();
            
        }
        public IUser Login(string email, string password)
        {
            try
            {
                IUser user = GetUser(encriptar.Encrypt(email));

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
        public void Modificar(BEUser user)
        {
            daluser.Modificar(user);

            //se calcula devuelta el digito
            this.regenerarDigito();
        }
        public void RestaurarEstado(BEUserLog log)
        {
            daluser.RestaurarEstado(log);
            this.regenerarDigito();
        }
         public List<BEUserLog> getLog(BEUser user)
        {
            return daluser.getLog(user.id);
        }
        public IUser GetUser(string email)
        {
            IUser r = daluser.GetUser(email);
            return r;
        }

        public List<BEUser> getAllUsers()
        {
            List<BEUser> listaUsuarios = new List<BEUser>();

            if (daluser.GetAll().Count > 0)
            {
                foreach (BEUser item in daluser.GetAll())
                {
                    BEUser user = new BEUser();
                    user.id = item.id;
                    user.Usuario = item.Usuario;
                    user.Contraseña = item.Contraseña;
                    user.Email = encriptar.Decrypt(item.Email);
                    user.DNI = item.DNI;

                    listaUsuarios.Add(user);
                }
            }
            else
            {
                listaUsuarios = null;
            }

            return listaUsuarios;
        }
        public void GuardarPermisos(BEUser u)
        {
            daluser.GuardarPermisos(u);
        }
    }
}