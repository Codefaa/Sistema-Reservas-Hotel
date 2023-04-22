using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Security.Cryptography;

namespace Servicios
{
    public class Encriptar
    {
        public string GenerarMD5(string contraseña)
        {
            try
            {
                UnicodeEncoding codigo = new UnicodeEncoding();
                byte[] bytetexto = codigo.GetBytes(contraseña);
                MD5CryptoServiceProvider MD5 = new MD5CryptoServiceProvider();
                byte[] bytehash = MD5.ComputeHash(bytetexto);
                return Convert.ToBase64String(bytehash);
            }
            catch(CryptographicException ex)
            {
                throw ex;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
