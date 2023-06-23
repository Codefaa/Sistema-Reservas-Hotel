using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BE;
using Abstraccion;

namespace Servicios
{
    public class Sesion : IObservado
    {
        private IUser _user { get; set; }

        private static Sesion _instance = null;
        public static BEIdioma Idioma { get; set; } 
        public IList<IObservador> ObservadoresRegistrados { get; set; } 
        private Sesion()
        {
            Idioma = new BEIdioma();
            ObservadoresRegistrados = new List<IObservador>(); 
        }
        public static Sesion Instance
        {
            get
            {
                if (_instance == null) _instance = new Sesion();

                return _instance;
            }
        }
        public IUser DevolverUsuario()
        {
            return _user;
        }
        public void Login(IUser user)
        {
            _user = user;
        }
        public void Logout()
        {
            _user = null;
        }

        public void RegistrarObservador(IObservador observador)
        {
            ObservadoresRegistrados.Add(observador);
        }
        #region Posible solucion 
        //public void RegistrarObservador(Form formulario)
        //{
        //    if (!ObservadoresRegistrados.Contains(formulario))
        //    {
        //        ObservadoresRegistrados.Add(formulario);
        //    }
        //}

        //public void CambiarIdioma(BEIdioma i)
        //{
        //    Idioma = i;
        //    ActualizarObservadores(i);
        //}
        #endregion
        public void DesregistrarObservador(IObservador observador)
        {
            ObservadoresRegistrados.Remove(observador);
        }
        public void ActualizarObservadores(IIdioma i)
        {
            foreach (var item in ObservadoresRegistrados)
            {
                item.Actualizar(i);
            }
        }
    }
}
