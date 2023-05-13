using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using System.Collections;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class DALComposite
    {
        public SqlConnection conexion = new SqlConnection();

        public DataTable Leer(string query, Hashtable hdatos)
        {
            conexion.Open();
            DataTable table = new DataTable();

            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion;
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = query;

            try
            {
                SqlDataAdapter adaptador = new SqlDataAdapter();
                if(hdatos != null)
                {
                    foreach (string dato in hdatos)
                    {
                        comando.Parameters.AddWithValue(dato, hdatos[dato]);
                    }
                }
                adaptador.Fill(table);

            }
            catch(SqlException ex)
            {
                throw ex;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return table;
        }


        public List<BEComposite> getRoles()
        {
            string query = "";
            Hashtable hdatos = new Hashtable();
            hdatos.Add(@"");
        }

    }
}
