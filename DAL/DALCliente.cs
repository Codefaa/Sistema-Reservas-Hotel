using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using BE;
using System.Collections;

namespace DAL
{
    public class DALCliente
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

                if (hdatos != null)
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

        public List<BECliente> LeerClientes()
        {
            string consulta = "S_Leer_Clientes";
            DataTable table = Leer(consulta, null);
            List<BECliente> listaClientes = new List<BECliente>();

            if(table.Rows.Count > 0)
            {
                foreach (DataRow fila in table.Rows)
                {
                    BECliente unCliente = new BECliente();
                    unCliente.ID = Convert.ToInt32(fila["IDCliente"]);
                    unCliente.Nombre = fila["Nombre"].ToString();
                    unCliente.Apellido = fila["Apellido"].ToString();
                    unCliente.DNI = Convert.ToInt32(fila["DNI"]);
                    unCliente.Correo = fila["Correo"].ToString();

                    listaClientes.Add(unCliente);
                }
            }
            else
            {
                listaClientes = null;
            }
            return listaClientes;
        }
        public void AgregarCliente(BECliente unCliente)
        {
            string consulta = "S_Agregar_Cliente";
            Hashtable hdatos = new Hashtable();
            hdatos.Add("@Nombre", unCliente.Nombre);
            hdatos.Add("@Apellido", unCliente.Apellido);
            hdatos.Add("@DNI", unCliente.DNI);
            hdatos.Add("@Correo", unCliente.Correo);
            Escribir(consulta, hdatos);
        }
        public void BajaCliente(BECliente unCliente)
        {
            string consulta = "S_Baja_Cliente";
            Hashtable hdatos = new Hashtable();
            hdatos.Add("@ID", unCliente.ID);
            Escribir(consulta, hdatos);
        }
        public void ModificarCliente(BECliente unCliente)
        {
            string consulta = "S_Modificar_Cliente";
            Hashtable hdatos = new Hashtable();
            hdatos.Add("@Nombre", unCliente.Nombre);
            hdatos.Add("@Apellido", unCliente.Apellido);
            hdatos.Add("@DNI", unCliente.DNI);
            hdatos.Add("@Correo", unCliente.Correo);
            hdatos.Add("@ID", unCliente.ID);
            Escribir(consulta, hdatos);
        }
        public List<BECliente> BuscarClienteSinReserva()
        {
            string consulta = "S_Buscar_ClientesSinReservas";
            DataTable table = Leer(consulta, null);
            List<BECliente> listaClientes = new List<BECliente>();

            if (table.Rows.Count > 0)
            {
                foreach (DataRow fila in table.Rows)
                {
                    BECliente unCliente = new BECliente();
                    unCliente.ID = Convert.ToInt32(fila["IDCliente"]);
                    unCliente.Nombre = fila["Nombre"].ToString();
                    unCliente.Apellido = fila["Apellido"].ToString();
                    unCliente.DNI = Convert.ToInt32(fila["DNI"]);
                    unCliente.Correo = fila["Correo"].ToString();

                    listaClientes.Add(unCliente);
                }
            }
            else
            {
                listaClientes = null;
            }
            return listaClientes;
        }
        public List<BECliente> BuscarCliente(string nombreCliente)
        {
            string consulta = "S_Buscar_Cliente";
            Hashtable hdatos = new Hashtable();
            hdatos.Add("@Nombre", nombreCliente);
            DataTable table = Leer(consulta, hdatos);
            List<BECliente> listaClientes = new List<BECliente>();

            if(table.Rows.Count > 0)
            {
                foreach (DataRow fila in table.Rows)
                {
                    BECliente unCliente = new BECliente();
                    unCliente.ID = Convert.ToInt32(fila["IDCliente"]);
                    unCliente.Nombre = fila["Nombre"].ToString();
                    unCliente.Apellido = fila["Apellido"].ToString();
                    unCliente.DNI = Convert.ToInt32(fila["DNI"]);
                    unCliente.Correo = fila["Correo"].ToString();

                    listaClientes.Add(unCliente);
                }
            }
            else
            {
                listaClientes = null;
            }
            return listaClientes;
        }
    }
}