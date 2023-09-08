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
        public string Decrypt(string emailEn)
        {
            try
            {
                if (emailEn != null)
                {
                    string hash = "coding con c";
                    byte[] data = Convert.FromBase64String(emailEn);

                    MD5 md5 = MD5.Create();
                    TripleDES tripledes = TripleDES.Create();

                    tripledes.Key = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
                    tripledes.Mode = CipherMode.ECB;

                    ICryptoTransform transform = tripledes.CreateDecryptor();
                    byte[] result = transform.TransformFinalBlock(data, 0, data.Length);

                    return UTF8Encoding.UTF8.GetString(result);
                }
                else
                {
                    return null;
                }
            }
            catch (CryptographicException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string Encrypt(string email)
        {
            try
            {
                if (email != null)
                {
                    string hash = "coding con c";
                    byte[] data = UTF8Encoding.UTF8.GetBytes(email);

                    MD5 md5 = MD5.Create();
                    TripleDES tripledes = TripleDES.Create();

                    tripledes.Key = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
                    tripledes.Mode = CipherMode.ECB;

                    ICryptoTransform transform = tripledes.CreateEncryptor();
                    byte[] result = transform.TransformFinalBlock(data, 0, data.Length);

                    return Convert.ToBase64String(result);
                }
                else
                {
                    return null;
                }
            }
            catch (CryptographicException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string GenerarMD5(string contraseña)
        {
            try
            {
                if (contraseña != null)
                {
                    UnicodeEncoding codigo = new UnicodeEncoding();
                    byte[] bytetexto = codigo.GetBytes(contraseña);
                    MD5CryptoServiceProvider MD5 = new MD5CryptoServiceProvider();
                    byte[] bytehash = MD5.ComputeHash(bytetexto);
                    return Convert.ToBase64String(bytehash);
                }
                else
                {
                    return null;
                }
            }
            catch (CryptographicException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}