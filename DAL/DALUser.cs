using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Abstraccion;
using System.Collections;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class DALUser
    {
        SqlConnection conexion = new SqlConnection(@"Data Source=.;Initial Catalog=BD SIGG;Integrated Security=True");
        SqlTransaction transaccion;
        
        //public DataTable LeerUser(string )
        //{
        //    conexion.Open();

        //    DataTable table = new DataTable();

        //    try
        //    {
        //        SqlDataAdapter adaptador = new SqlDataAdapter(table);
        //    }
        //    catch(SqlException ex)
        //    {
        //        throw ex;
        //    }
        //    catch(Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        conexion.Close();
        //    }

        //    return table;
        //}
        public void Escribir(string consulta, Hashtable Hdatos)
        {
            conexion.Open();

            transaccion = conexion.BeginTransaction();

            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion;
            comando.Transaction = transaccion;
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = consulta;

            try
            {
                if(Hdatos != null)
                {
                    foreach (string  dato in Hdatos.Keys)
                    {
                        comando.Parameters.AddWithValue(dato, Hdatos[dato]);
                    }
                }

                int respuesta = comando.ExecuteNonQuery();

                transaccion.Commit();
            }
            catch(SqlException ex)
            {
                transaccion.Rollback();
                throw ex;
            }
            catch(Exception ex)
            {
                transaccion.Rollback();
                throw ex;
            }
            finally
            {
                conexion.Close();
            }
        }

        public void CreateUser(IUser user)
        {
            string consulta = "CREATE_USER";
            Hashtable Hdatos = new Hashtable();
            Hdatos.Add("@User", user.Usuario);
            Hdatos.Add("@Password", user.Contraseña);
            Hdatos.Add("@DNI", user.DNI);
            Hdatos.Add("@Email", user.Email);

            Escribir(consulta, Hdatos);
        }
    }
}
