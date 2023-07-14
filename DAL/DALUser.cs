﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections;
using System.Data;
using System.Data.SqlClient;

using Abstraccion;
using BE;
namespace DAL
{
    public class DALUser
    {
        SqlConnection conexion = new SqlConnection(@"Data Source=.;Initial Catalog=BD SIGG;Integrated Security=True");
        SqlTransaction transaccion;

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

                if(hdatos != null)
                {
                    foreach (string dato in hdatos.Keys)
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
            finally
            {
                conexion.Close();
            }

            return table;
        }
        public void RestaurarEstado(BEUserLog log)
        {
            string consulta = "RestoreUserStatus";
            Hashtable Hdatos = new Hashtable();
            Hdatos.Add("@Username", log.Username);
            Hdatos.Add("@IdUser", log.IdUser);
            Hdatos.Add("@Dni", log.Dni);
            Hdatos.Add("@schedule", DateTime.Now);

            Escribir(consulta, Hdatos);
        }
        public List<BEUserLog> getLog(int IdUser)
        {
            List<BEUserLog> data = new List<BEUserLog>();
            
            string consulta = "GetLog";
            Hashtable Hdatos = new Hashtable();
            Hdatos.Add("@IdUser", IdUser);
            DataTable info = Leer(consulta, Hdatos);
            foreach (DataRow row in info.Rows)
            {
                BEUserLog beUserLog = new BEUserLog();
                beUserLog.IdUser = Convert.ToInt32(row["IdUser"]);
                beUserLog.Dni = Convert.ToInt32(row["Dni"]);
                beUserLog.Username = row["Username"].ToString();    
                beUserLog.Id = Convert.ToInt32(row["Idlog"]);
                beUserLog.Tipo = row["Tipo"].ToString();
                beUserLog.Fecha = Convert.ToDateTime(row["Fecha"]);
                    data.Add(beUserLog);
            }
            return data;
        }
        public void Modificar(BEUser user)
        {

            string consulta = "Modificar";
            Hashtable Hdatos = new Hashtable();
            Hdatos.Add("@username", user.Usuario);
            Hdatos.Add("@Id", user.id);
            Hdatos.Add("@dni", user.DNI);
            Hdatos.Add("@schedule", DateTime.Now);

            Escribir(consulta, Hdatos);
        }
        public bool validarDigito(string digito)
        {
            if(getDigitoTabla() == digito)
            {
                return true;
            }
            return false;
                }

        public string getDigitoTabla()
        {
            string data = null;
            string consulta = "getDigito";
            Hashtable Hdatos = new Hashtable();
            Hdatos.Add("@nombre", "Users");
            DataTable info = Leer(consulta, Hdatos);
            foreach (DataRow row in info.Rows)
            {
                data = row["digito_tabla"].ToString();
            }
            return data;
        }
        public void setDigitoTabla(string data)
        {
            string consulta = "setDigito";
            Hashtable Hdatos = new Hashtable();
            Hdatos.Add("@Tabla", "Users");
            Hdatos.Add("@Digito", data);
            Escribir(consulta, Hdatos);

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

        public void CreateUser(IUser user)
        {
            string consulta = "CREATE_USER";
            Hashtable Hdatos = new Hashtable();
            Hdatos.Add("@User", user.Usuario);
            Hdatos.Add("@Password", user.Contraseña);
            Hdatos.Add("@DNI", user.DNI);
            Hdatos.Add("@Email", user.Email);
            Hdatos.Add("@Digito", user.Digito);

            Escribir(consulta, Hdatos);
        }
        public IUser GetUser(string email)
        {
            string consulta = "GET_USER";
            Hashtable Hdatos = new Hashtable();
            Hdatos.Add("@Email", email);
            DataTable table = new DataTable();
            table = Leer(consulta, Hdatos);

            IUser user = null;

            if (table.Rows.Count > 0)
            {
                foreach (DataRow fila in table.Rows)
                {
                    user = new BEUser();
                    user.id = Convert.ToInt32(fila["Id"]);
                    user.Usuario = fila["Username"].ToString();
                    user.Contraseña = fila["Password"].ToString();
                    user.Email = fila["Email"].ToString();
                    user.DNI = Convert.ToInt32(fila["DNI"]);
                }
            }
            else
            {
                user = null;
            }

            return user;
        }
        public List<BEUser> GetAll()
        {
            conexion.Close();
            conexion.Open();
            var cmd = new SqlCommand();
            cmd.Connection = conexion;

            var sql = $@"select * from Users;";

            cmd.CommandText = sql;

            var reader = cmd.ExecuteReader();

            var lista = new List<BEUser>();

            while (reader.Read())
            {
                BEUser c = new BEUser();
                c.id = reader.GetInt32(reader.GetOrdinal("Id"));
                c.Usuario = reader.GetString(reader.GetOrdinal("Username"));
                c.DNI = reader.GetInt32(reader.GetOrdinal("DNI"));
                c.Contraseña = reader.GetString(reader.GetOrdinal("Password"));
                c.Digito = reader.GetString(reader.GetOrdinal("Digito"));
                c.Email = reader.GetString(reader.GetOrdinal("Email"));
                lista.Add(c);
            }

            reader.Close();
            conexion.Close();

            return lista;
        }
        public string armarDigitoTabla()
        {
            List<BEUser> lista = this.GetAll();
            string digito = null;
            foreach(BEUser user in lista)
            {
                digito = digito + user.Digito;
            }
            return digito; 
        }
        public void GuardarPermisos(BEUser u)
        {

            try
            {
                conexion.Close();
                conexion.Open();

                var cmd = new SqlCommand();
                cmd.Connection = conexion;

                cmd.CommandText = $@"delete from User_Permiso where IdUser=@id;";
                cmd.Parameters.Add(new SqlParameter("id", u.id));
                cmd.ExecuteNonQuery();

                foreach (var item in u.Permisos)
                {
                    cmd = new SqlCommand();
                    cmd.Connection = conexion;

                    cmd.CommandText = $@"insert into User_Permiso (IdUser,IdPermiso) values (@id_usuario,@id_permiso) "; ;
                    cmd.Parameters.Add(new SqlParameter("id_usuario", u.id));
                    cmd.Parameters.Add(new SqlParameter("id_permiso", item.Id));

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}