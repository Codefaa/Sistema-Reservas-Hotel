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
    public class DALObserver
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

                int respuesta = comando.ExecuteNonQuery();

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

        public BEIdioma GenerarDiccionarios(BEIdioma idioma)
        {
            string query = "S_GenerarDiccionario";
            Hashtable hdatos = new Hashtable();
            hdatos.Add(@"Nombre", idioma.Nombre);
            DataTable table = Leer(query, hdatos);

            BEIdioma BEunIdioma = new BEIdioma();
            BEunIdioma.Id = idioma.Id;
            BEunIdioma.Nombre = idioma.Nombre;

            if (table.Rows.Count > 0)
            {
                foreach (DataRow fila in table.Rows)
                {
                    BETraduccion BEunaTraduccion = new BETraduccion();
                    BEunaTraduccion.Id = Convert.ToInt32(fila["Id"]);
                    BEunaTraduccion.PalabraTraducida = fila["PalabraTraducida"].ToString();
                    BEPalabra BEunaPalabra = new BEPalabra();
                    BEunaPalabra.Id = Convert.ToInt32(fila["Id_Palabra"]);
                    BEunaPalabra.Texto = fila["Texto"].ToString();

                    BEunaTraduccion.Palabra = BEunaPalabra;

                    BEunIdioma.AgregarTraduccion(BEunaTraduccion);
                }
            }
            else
            {
                BEunIdioma = null;
            }

            return BEunIdioma;
        }
    }
}
