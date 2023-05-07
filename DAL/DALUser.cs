﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Abstraccion;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using BE;
namespace DAL
{
    public class DALUser
    {
        SqlConnection conexion = new SqlConnection(@"Data Source=DESKTOP-D1HGMQE\SQLEXPRESS;Initial Catalog=BD SIGG;Integrated Security=True");
        SqlTransaction transaccion;
        public void savelog(int idUser, DateTime schedule)
        {
            string consulta = "InsertLoginLog";
            Hashtable Hdatos = new Hashtable();
            Hdatos.Add("@UserId", idUser);
            Hdatos.Add("@Schedule", schedule);

            Escribir(consulta, Hdatos);

        }
        public IUser GetUser(string email)
        {
            string consulta = "GET_USER";
            Hashtable Hdatos = new Hashtable();
            Hdatos.Add("@Email", email);

            conexion.Open();
            IUser user = null;

            DataTable table = new DataTable();
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
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
                    var reader = comando.ExecuteReader();
                    while (reader.Read()) {
                        user = new BEUser();
                    
                        user.Email = reader["Email"].ToString();
                        user.Contraseña = reader["Password"].ToString();
                        user.Usuario = reader["Username"].ToString();
                        user.DNI = Convert.ToInt32(reader["DNI"].ToString());
                        user.id = Convert.ToInt32(reader["Id"].ToString());

                    }
                    reader.Close();

            
                }
                return user;

            }catch(Exception e)
            {
                throw e;
            }
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
