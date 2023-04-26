using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Abstraccion;
namespace Servicios
{
    public class Sesion
    {
        private IUser _user { get; set; }

        private static Sesion _instance = null;
        private Sesion()
        {

        }
        public static Sesion Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Sesion();
                return _instance;
            }
        }

        public void Login(IUser user)
        {
            _user = user;
        }


    }
}
