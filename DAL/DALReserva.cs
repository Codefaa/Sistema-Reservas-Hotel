using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using System.Collections;
using BE;
using System.Configuration;

namespace DAL
{
    public class DALReserva
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
                if (hdatos != null) 
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

        public List<BEReserva> LeerReservas()
        {
            string consulta = "S_Leer_Reservas";
            DataTable table = Leer(consulta, null);
            List<BEReserva> listaReservas = new List<BEReserva>();

            if(table.Rows.Count > 0)
            {
                foreach (DataRow fila in table.Rows)
                {
                    BEReserva reserva = new BEReserva();
                    reserva.FechaEntrada = Convert.ToDateTime(fila["FechaEntrada"]);
                    reserva.FechaSalida = Convert.ToDateTime(fila["FechaSalida"]);
                    reserva.Adelanto = Convert.ToDecimal(fila["Adelanto"]);

                    BEHabitacion habitacion = new BEHabitacion();
                    habitacion.ID = Convert.ToInt32(fila["IDHabitacion"]);
                    habitacion.Numero = Convert.ToInt32(fila["Numero"]);
                    habitacion.Precio = Convert.ToDecimal(fila["Precio"]);
                    habitacion.Categoria = fila["Categoria"].ToString();
                    habitacion.Piso = fila["Piso"].ToString();
                    habitacion.Estado = fila["Estado"].ToString();

                    BECliente cliente = new BECliente();
                    cliente.ID = Convert.ToInt32(fila["IDCliente"]);
                    cliente.Nombre = fila["Nombre"].ToString();
                    cliente.Apellido = fila["Apellido"].ToString();
                    cliente.DNI = Convert.ToInt32(fila["DNI"]);
                    cliente.Correo = fila["Correo"].ToString();

                    reserva.unaHabitacion = habitacion;
                    reserva.unCliente = cliente;

                    listaReservas.Add(reserva);
                }
            }
            else
            {
                listaReservas = null;
            }
            return listaReservas;
        }
        public void AgregarReserva(BEReserva unaReserva)
        {
            string consulta = "S_Agregar_Reserva";
            Hashtable hdatos = new Hashtable();
            hdatos.Add("@FechaEntrada", unaReserva.FechaEntrada);
            hdatos.Add("@FechaSalida", unaReserva.FechaSalida);
            hdatos.Add("@Adelanto", unaReserva.Adelanto);
            hdatos.Add("@IDCliente", unaReserva.unCliente.ID);
            hdatos.Add("@IDHabitacion", unaReserva.unaHabitacion.ID);
            Escribir(consulta, hdatos);
        }
        public BEReserva BuscarReserva(BEHabitacion unaReserva)
        {
            string consulta = "S_Buscar_Reserva";
            Hashtable hdatos = new Hashtable();
            hdatos.Add("@IDHabitacion", unaReserva.ID);
            DataTable table = Leer(consulta, hdatos);
            BEReserva reserva = new BEReserva();

            if (table.Rows.Count > 0)
            {
                foreach (DataRow fila in table.Rows)
                {
                    reserva.FechaEntrada = Convert.ToDateTime(fila["FechaEntrada"]);
                    reserva.FechaSalida = Convert.ToDateTime(fila["FechaSalida"]);
                    reserva.Adelanto = Convert.ToDecimal(fila["Adelanto"]);

                    BEHabitacion habitacion = new BEHabitacion();
                    habitacion.ID = Convert.ToInt32(fila["IDHabitacion"]);
                    habitacion.Numero = Convert.ToInt32(fila["Numero"]);
                    habitacion.Precio = Convert.ToDecimal(fila["Precio"]);
                    habitacion.Categoria = fila["Categoria"].ToString();
                    habitacion.Piso = fila["Piso"].ToString();
                    habitacion.Estado = fila["Estado"].ToString();

                    BECliente cliente = new BECliente();
                    cliente.ID = Convert.ToInt32(fila["IDCliente"]);
                    cliente.Nombre = fila["Nombre"].ToString();
                    cliente.Apellido = fila["Apellido"].ToString();
                    cliente.DNI = Convert.ToInt32(fila["DNI"]);
                    cliente.Correo = fila["Correo"].ToString();

                    reserva.unaHabitacion = habitacion;
                    reserva.unCliente = cliente;
                }
            }
            else
            {
                reserva = null;
            }
            return reserva;
        }

    }
}
