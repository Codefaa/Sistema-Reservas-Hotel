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
        public SqlConnection conexion = new SqlConnection(@"Data Source=.;Initial Catalog=BD SIGG;Integrated Security=True");

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
                SqlDataAdapter adaptador = new SqlDataAdapter(comando);

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
            List<BEComposite> listaComponentesSimples = new List<BEComposite>();
            string query = "S_GetPermisos";
            DataTable table = new DataTable();
            table = Leer(query, null);

            if(table.Rows.Count > 0)
            {
                foreach (DataRow fila in table.Rows)
                {
                    BEComposite unComponenteSimple = new BEComponenteSimple();
                    unComponenteSimple.Id = Convert.ToInt32(fila["Id"]);
                    unComponenteSimple.Nombre = fila["Nombre"].ToString();

                    listaComponentesSimples.Add(unComponenteSimple);
                }
            }
            else
            {
                listaComponentesSimples = null;
            }
            return listaComponentesSimples;
        }

    }
}
