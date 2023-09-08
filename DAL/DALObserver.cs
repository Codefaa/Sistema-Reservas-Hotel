using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BE;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Configuration;

namespace DAL
{
    public class DALObserver
    {
        public SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["MiCadenaDeConexion"].ToString());
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
                    BEunaTraduccion.PalabraTraducida = fila["PalabraTraducida"].ToString();
                    BEPalabra BEunaPalabra = new BEPalabra();
                    BEunaPalabra.Id = Convert.ToInt32(fila["Id_Palabra"]);
                    BEunaPalabra.Texto = fila["Texto"].ToString();

                    BEunaTraduccion.Palabra = BEunaPalabra;

                    BEunIdioma.AgregarTraduccion(BEunaTraduccion);
                }
            }

            return BEunIdioma;
        }
        public List<BEPalabra> LeerPalabras()
        {
            List<BEPalabra> listaPalabras = new List<BEPalabra>();
            string query = "S_Palabra_Leer";
            DataTable table = Leer(query, null);

            if (table.Rows.Count > 0)
            {
                foreach (DataRow fila in table.Rows)
                {
                    BEPalabra BEunaPalabra = new BEPalabra();
                    BEunaPalabra.Id = Convert.ToInt32(fila["Id_Palabra"]);
                    BEunaPalabra.Texto = fila["Texto"].ToString();

                    listaPalabras.Add(BEunaPalabra);
                }
            }
            else
            {
                listaPalabras = null;
            }
            return listaPalabras;
        }
        public void AltaIdioma(BEIdioma idioma)
        {
            string query = "S_Idioma_Alta";
            Hashtable hdatos = new Hashtable();
            hdatos.Add("@Nombre", idioma.Nombre);
            Escribir(query, hdatos);
        }
        public void BajaIdioma(BEIdioma idioma)
        {
            string query = "S_Idioma_Borrar";
            Hashtable hdatos = new Hashtable();
            hdatos.Add("@Id", idioma.Id);
            Escribir(query, hdatos);
        }
        public void ModificarIdioma(BEIdioma idioma)
        {
            string query = "S_Idioma_Modificar";
            Hashtable hdatos = new Hashtable();
            hdatos.Add("@Id", idioma.Id);
            hdatos.Add("@Nombre", idioma.Nombre);
            Escribir(query, hdatos);
        }
        public List<BEIdioma> LeerIdiomas()
        {
            List<BEIdioma> listaIdioma = new List<BEIdioma>();
            string query = "S_Idioma_Leer";
            DataTable table = Leer(query, null);

            if (table.Rows.Count > 0)
            {
                foreach (DataRow fila in table.Rows)
                {
                    BEIdioma BEunIdioma = new BEIdioma();
                    BEunIdioma.Id = Convert.ToInt32(fila["Id"]);
                    BEunIdioma.Nombre = fila["Nombre"].ToString();

                    listaIdioma.Add(BEunIdioma);
                }
            }
            else
            {
                listaIdioma = null;
            }
            return listaIdioma;
        }
        public void AltaTraduccion(BETraduccion traduccion)
        {
            string query = "S_Traduccion_Alta";
            Hashtable hdatos = new Hashtable();
            hdatos.Add("@PalabraTraducida", traduccion.PalabraTraducida);
            hdatos.Add("@Id_Palabra", traduccion.Palabra.Id);
            hdatos.Add("@Id_Idioma", traduccion.Idioma.Id);
            Escribir(query, hdatos);    
        }
        public void BorrarTraduccion(BETraduccion traduccion)
        {
            string query = "S_Traduccion_Borrar";
            Hashtable hdatos = new Hashtable();
            hdatos.Add("@Id_Idioma", traduccion.Idioma.Id);
            hdatos.Add("@Id_Palabra", traduccion.Palabra.Id);
            Escribir(query, hdatos);
        }
        public void ModificarTraduccion(BETraduccion traduccion)
        {
            string query = "S_Traduccion_Modificar";
            Hashtable hdatos = new Hashtable();
            hdatos.Add("@PalabraTraducida", traduccion.PalabraTraducida);
            hdatos.Add("@Id_Idioma", traduccion.Idioma.Id);
            hdatos.Add("@Id_Palabra", traduccion.Palabra.Id);
            Escribir(query, hdatos);
        }
        public List<BETraduccion> LeerTraducciones(BETraduccion traduccion)
        {
            List<BETraduccion> listaTraducciones = new List<BETraduccion>();
            string query = "S_Traduccion_LeerxIdioma";
            Hashtable hdatos = new Hashtable();
            hdatos.Add(@"Id_Idioma", traduccion.Idioma.Id);
            DataTable table = Leer(query, hdatos);

            if (table.Rows.Count > 0)
            {
                foreach (DataRow fila in table.Rows)
                {
                    BETraduccion BEunaTraduccion = new BETraduccion();
                    BEunaTraduccion.PalabraTraducida = fila["PalabraTraducida"].ToString();
                    BEPalabra BEunaPalabra = new BEPalabra();
                    BEunaPalabra.Id = Convert.ToInt32(fila["Id_Palabra"]);
                    BEunaPalabra.Texto = fila["Texto"].ToString();
                    BEIdioma BEunIdioma = new BEIdioma();
                    BEunIdioma.Id = Convert.ToInt32(fila["Id"]);
                    BEunIdioma.Nombre = fila["Nombre"].ToString();

                    BEunaTraduccion.Palabra = BEunaPalabra;
                    BEunaTraduccion.Idioma = BEunIdioma;

                    listaTraducciones.Add(BEunaTraduccion);
                }
            }
            else
            {
                listaTraducciones = null;
            }

            return listaTraducciones;
        }
    }
}