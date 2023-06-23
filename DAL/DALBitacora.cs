using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BE;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace DAL
{
    public class DALBitacora
    {
        public SqlConnection conexion = new SqlConnection(@"Data Source=.;Initial Catalog=BD SIGG;Integrated Security=True");
        public SqlTransaction transaccion;

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
                if (hdatos != null)
                {
                    foreach (string dato in hdatos.Keys)
                    {
                        comando.Parameters.AddWithValue(dato, hdatos[dato]);
                    }
                }
                adaptador.Fill(table);

            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexion.Close();
            }

            return table;
        }
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
                if (Hdatos != null)
                {
                    foreach (string dato in Hdatos.Keys)
                    {
                        comando.Parameters.AddWithValue(dato, Hdatos[dato]);
                    }
                }

                comando.ExecuteNonQuery();

                transaccion.Commit();
            }
            catch (SqlException ex)
            {
                transaccion.Rollback();
                throw ex;
            }
            catch (Exception ex)
            {
                transaccion.Rollback();
                throw ex;
            }
            finally
            {
                conexion.Close();
            }
        }
        public void savelog(string usuario, string categoria, string text)
        {
            string consulta = "InsertBitacora";
            Hashtable Hdatos = new Hashtable();
            Hdatos.Add("@Username", usuario);
            Hdatos.Add("@Category", categoria);
            Hdatos.Add("@Text", text);
            Hdatos.Add("@Schedule", DateTime.Now);

            Escribir(consulta, Hdatos);
        }
        public List<BEBitacora> getAll()
        {
            List<BEBitacora> listaBitacoras = new List<BEBitacora>();

            string query = "S_Bitacora_getAll";

            DataTable table = Leer(query, null);

            if (table.Rows.Count > 0)
            {
                foreach (DataRow fila in table.Rows)
                {
                    BEBitacora BEunaBitacora = new BEBitacora();
                    BEunaBitacora.Usuario = fila["Username"].ToString();
                    BEunaBitacora.Categoria = fila["Categoria"].ToString();
                    BEunaBitacora.Texto = fila["Accion"].ToString();
                    BEunaBitacora.Fecha = Convert.ToDateTime(fila["Fecha"]);

                    listaBitacoras.Add(BEunaBitacora);
                }
            }
            else
            {
                listaBitacoras = null;
            }

            return listaBitacoras;
        }
        public List<BEBitacora> Buscar(string categoria,DateTime desde,DateTime hasta)
        {
            List<BEBitacora> listaBitacoras = new List<BEBitacora>();

            string query = "S_Bitacora_Buscar";

            Hashtable hdatos = new Hashtable();
            hdatos.Add("@Categoria", categoria);
            hdatos.Add("@desde", desde);
            hdatos.Add("@hasta", hasta);

            DataTable table = Leer(query, hdatos);

            if (table.Rows.Count > 0)
            {
                foreach (DataRow fila in table.Rows)
                {
                    BEBitacora BEunaBitacora = new BEBitacora();
                    BEunaBitacora.Usuario = fila["Username"].ToString();
                    BEunaBitacora.Categoria = fila["Categoria"].ToString();
                    BEunaBitacora.Texto = fila["Accion"].ToString();
                    BEunaBitacora.Fecha = Convert.ToDateTime(fila["Fecha"]);

                    listaBitacoras.Add(BEunaBitacora);
                }
            }
            else
            {
                listaBitacoras = null;
            }

            return listaBitacoras;
        }
    }
}