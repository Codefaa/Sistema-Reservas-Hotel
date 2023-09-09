using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Configuration;
using BE;

namespace DAL
{
    public class DALHabitacion
    {
        SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["MiCadenaDeConexion"].ToString());
        SqlTransaction transaccion;

        public DataTable Leer(string consulta, Hashtable hdatos)
        {
            conexion.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexion;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = consulta;

            DataTable table = new DataTable();

            try
            {
                SqlDataAdapter adaptador = new SqlDataAdapter(cmd);

                if(hdatos != null)
                {
                    foreach (string dato in hdatos.Keys)
                    {
                        cmd.Parameters.AddWithValue(dato, hdatos[dato]);
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
            finally
            {
                conexion.Close();
            }
            return table;
        }
        public void Escribir(string consulta, Hashtable hdatos)
        {
            conexion.Open();
            transaccion = conexion.BeginTransaction();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexion;
            cmd.Transaction = transaccion;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = consulta;

            try
            {
                if(hdatos != null)
                {
                    foreach (string dato in hdatos.Keys)
                    {
                        cmd.Parameters.AddWithValue(dato, hdatos[dato]);
                    }
                }

                cmd.ExecuteNonQuery();
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

        public List<BEHabitacion> LeerHabitaciones()
        {
            string consulta = "S_Leer_Habitaciones";
            DataTable table = Leer(consulta, null);
            List<BEHabitacion> listaHabitaciones = new List<BEHabitacion>();

            if(table.Rows.Count > 0)
            {
                foreach (DataRow fila in table.Rows)
                {
                    BEHabitacion unaHabitacion = new BEHabitacion();
                    unaHabitacion.ID = Convert.ToInt32(fila["IDHabitacion"]);
                    unaHabitacion.Numero = Convert.ToInt32(fila["Numero"]);
                    unaHabitacion.Precio = Convert.ToDecimal(fila["Precio"]);
                    unaHabitacion.Categoria = fila["Categoria"].ToString();
                    unaHabitacion.Piso = fila["Piso"].ToString();
                    unaHabitacion.Estado = fila["Estado"].ToString();
                    
                    listaHabitaciones.Add(unaHabitacion);
                }
            }
            else
            {
                listaHabitaciones = null;
            }
            return listaHabitaciones;
        }
        public void AgregarHabitacion(BEHabitacion unaHabitacion)
        {
            string consulta = "S_Agregar_Habitacion";
            Hashtable hdatos = new Hashtable();
            hdatos.Add("@Numero", unaHabitacion.Numero);
            hdatos.Add("@Precio", unaHabitacion.Precio);
            hdatos.Add("@Categoria", unaHabitacion.Categoria);
            hdatos.Add("@Piso", unaHabitacion.Piso);
            hdatos.Add("@Estado", "Disponible");
            Escribir(consulta, hdatos);
        }
        public void BajaHabitacion(BEHabitacion unaHabitacion)
        {
            string consulta = "S_Baja_Habitacion";
            Hashtable hdatos = new Hashtable();
            hdatos.Add("@ID", unaHabitacion.ID);
            Escribir(consulta, hdatos);
        }
        public void ModificarHabitacion(BEHabitacion unaHabitacion)
        {
            string consulta = "S_Modificar_Habitacion";
            Hashtable hdatos = new Hashtable();
            hdatos.Add("@Numero", unaHabitacion.Numero);
            hdatos.Add("@Precio", unaHabitacion.Precio);
            hdatos.Add("@Categoria", unaHabitacion.Categoria);
            hdatos.Add("@Piso", unaHabitacion.Piso);
            hdatos.Add("@ID", unaHabitacion.ID);
            hdatos.Add("@Estado", unaHabitacion.Estado);
            Escribir(consulta, hdatos);
        }
        public void CambiarEstado(BEHabitacion unaHabitacion)
        {
            string consulta = "S_CambiarEstado_Habitacion";
            Hashtable hdatos = new Hashtable();
            hdatos.Add("@Estado", "Disponible");
            hdatos.Add("@IDHabitacion", unaHabitacion.ID);
            Escribir(consulta, hdatos);
        }
        public List<BEHabitacion> BuscarHabitacion(string pisoHabitacion)
        {
            string consulta = "S_Buscar_Habitacion";
            Hashtable hdatos = new Hashtable();
            hdatos.Add("@Piso", pisoHabitacion);
            DataTable table = Leer(consulta, hdatos);
            List<BEHabitacion> listaHabitaciones = new List<BEHabitacion>();

            if(table.Rows.Count > 0)
            {
                foreach (DataRow fila in table.Rows)
                {
                    BEHabitacion unaHabitacion = new BEHabitacion();
                    unaHabitacion.ID = Convert.ToInt32(fila["IDHabitacion"]);
                    unaHabitacion.Numero = Convert.ToInt32(fila["Numero"]);
                    unaHabitacion.Precio = Convert.ToDecimal(fila["Precio"]);
                    unaHabitacion.Categoria = fila["Categoria"].ToString();
                    unaHabitacion.Piso = fila["Piso"].ToString();
                    unaHabitacion.Estado = fila["Estado"].ToString();

                    listaHabitaciones.Add(unaHabitacion);
                }
            }
            else
            {
                listaHabitaciones = null;
            }
            return listaHabitaciones;
        }
    }
}
