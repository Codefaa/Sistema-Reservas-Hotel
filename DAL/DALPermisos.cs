using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BE;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DAL
{
    public class DALPermisos
    {
        public SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["MiCadenaDeConexion"].ToString());

        public IList<BEComponenteSimple> GetAllPatentes()   //Leer permisos
        {
            conexion.Open();
            
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexion;

            var sql = $@"select * from Permiso p where p.Permiso is not null;";

            cmd.CommandText = sql;

            var reader = cmd.ExecuteReader();

            var lista = new List<BEComponenteSimple>();

            while (reader.Read())
            {
                var id = reader.GetInt32(reader.GetOrdinal("Id"));
                var nombre = reader.GetString(reader.GetOrdinal("Nombre"));
                var permiso = reader.GetString(reader.GetOrdinal("Permiso"));

                BEComponenteSimple c = new BEComponenteSimple();

                c.Id = id;
                c.Nombre = nombre;
                c.Permiso = (TipoPermiso)Enum.Parse(typeof(TipoPermiso), permiso);
                lista.Add(c);

            }

            reader.Close();
            conexion.Close();

            return lista;
        }
        public IList<BEComponente_compuesto> GetAllCompuestos()     //Leer familias
        {
            conexion.Open();
            
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexion;

            var sql = $@"select * from Permiso p where p.Permiso is  null;";

            cmd.CommandText = sql;

            var reader = cmd.ExecuteReader();

            var lista = new List<BEComponente_compuesto>();

            while (reader.Read())
            {
                var id = reader.GetInt32(reader.GetOrdinal("id"));
                var nombre = reader.GetString(reader.GetOrdinal("nombre"));

                BEComponente_compuesto miComponente = new BEComponente_compuesto();

                miComponente.Id = id;
                miComponente.Nombre = nombre;
                lista.Add(miComponente);
            }

            reader.Close();
            conexion.Close();

            return lista;
        }
        public void GuardarFamilia(BEComponente_compuesto c)    //Guardar familias
        {
            try
            {
                conexion.Open();
                var cmd = new SqlCommand();
                cmd.Connection = conexion;

                var sql = $@"delete from permiso_permiso where Id_PermisoPadre=@id;       ";

                cmd.CommandText = sql;
                cmd.Parameters.Add(new SqlParameter("id", c.Id));
                cmd.ExecuteNonQuery();

                foreach (var item in c.Hijos)
                {
                    cmd = new SqlCommand();
                    cmd.Connection = conexion;


                    sql = $@"insert into permiso_permiso (Id_PermisoPadre,Id_PermisoHijo) values (@id_permiso_padre,@id_permiso_hijo) ";

                    cmd.CommandText = sql;
                    cmd.Parameters.Add(new SqlParameter("id_permiso_padre", c.Id));
                    cmd.Parameters.Add(new SqlParameter("id_permiso_hijo", item.Id));

                    cmd.ExecuteNonQuery();
                }
                conexion.Close();
            }
            catch (Exception)
            {
                conexion.Close();
                throw;
            }
        }       
        public BEComposite GuardarComponente(BEComposite p, bool esfamilia)
        {
            try
            {
                conexion.Open();
                var cmd = new SqlCommand();
                cmd.Connection = conexion;

                var sql = $@"insert into Permiso (nombre,permiso) values (@nombre,@permiso);  SELECT ID AS LastID FROM permiso WHERE ID = @@Identity;       ";

                cmd.CommandText = sql;
                cmd.Parameters.Add(new SqlParameter("nombre", p.Nombre));


                if (esfamilia)
                    cmd.Parameters.Add(new SqlParameter("permiso", DBNull.Value));

                else
                    cmd.Parameters.Add(new SqlParameter("permiso", p.Permiso.ToString()));

                var id = cmd.ExecuteScalar();
                p.Id = (int)id;

                conexion.Close();

                return p;
            }
            catch (Exception e)
            {
                conexion.Close();
                throw e;
            }
        }
        public Array GetAllPermission()
        {
            return Enum.GetValues(typeof(TipoPermiso));
        }
        private BEComposite GetComponent(int id, IList<BEComposite> lista)
        {
            BEComposite component = lista != null ? lista.Where(i => i.Id.Equals(id)).FirstOrDefault() : null;

            if (component == null && lista != null)
            {
                foreach (var c in lista)
                {
                    var l = GetComponent(id, c.Hijos);
                    if (l != null && l.Id == id) return l;
                    else
                    if (l != null)
                   
                    return GetComponent(id, l.Hijos);
                }
            }

            return component;
        }
        public void FillFamilyComponents(BEComponente_compuesto familia)
        {
            familia.VaciarHijos();
            foreach (var item in GetAll("=" + familia.Id))
            {
                familia.AgregarHijo(item);
            }
        }
        public void FillUserComponents(BEUser u)
        {
            conexion.Open();

            var cmd2 = new SqlCommand();
            cmd2.Connection = conexion;
            cmd2.CommandText = $@"select p.* from User_Permiso up inner join Permiso p on up.IdPermiso=p.Id where IdUser=@id;";
            cmd2.Parameters.AddWithValue("id", u.id);

            var reader = cmd2.ExecuteReader();
            u.Permisos.Clear();

            while (reader.Read())
            {
                var idp = reader.GetInt32(reader.GetOrdinal("Id"));
                var nombrep = reader.GetString(reader.GetOrdinal("nombre"));

                var permisop = String.Empty;
                if (reader["permiso"] != DBNull.Value)
                    permisop = reader.GetString(reader.GetOrdinal("permiso"));

                BEComposite c1;

                if (!String.IsNullOrEmpty(permisop))
                {
                    c1 = new BEComponenteSimple();
                    c1.Id = idp;
                    c1.Nombre = nombrep;
                    c1.Permiso = (TipoPermiso)Enum.Parse(typeof(TipoPermiso), permisop);
                    u.Permisos.Add(c1);
                }
                else
                {
                    c1 = new BEComponente_compuesto();
                    c1.Id = idp;
                    c1.Nombre = nombrep;

                    var f = GetAll("=" + idp);

                    foreach (var familia in f)
                    {
                        c1.AgregarHijo(familia);
                    }
                    u.Permisos.Add(c1);
                }
            }

            reader.Close();
            conexion.Close();
        }
        public IList<BEComposite> GetAll(string familia)
        {
            var where = "is NULL";

            if (!String.IsNullOrEmpty(familia))
            {
                where = familia;
            }

            var cs = new SqlConnectionStringBuilder();
            cs.IntegratedSecurity = true;
            cs.DataSource = @".";
            cs.InitialCatalog = "BD SIGG";
            var cnn = new SqlConnection(cs.ConnectionString);
            cnn.Open();
            var cmd = new SqlCommand();
            cmd.Connection = cnn;

            var sql = $@"with recursivo as (
                        select sp2.Id_PermisoPadre, sp2.Id_PermisoHijo  from Permiso_Permiso sp2
                        where sp2.Id_PermisoPadre {where}
                        UNION ALL 
                        select sp.Id_PermisoPadre, sp.Id_PermisoHijo from Permiso_Permiso sp 
                        inner join recursivo r on r.Id_PermisoHijo= sp.Id_PermisoPadre
                        )
                        select r.Id_PermisoPadre,r.Id_PermisoHijo,p.id,p.nombre, p.permiso
                        from recursivo r 
                        inner join permiso p on r.Id_PermisoHijo = p.id 
						
                        ";

            cmd.CommandText = sql;

            var reader = cmd.ExecuteReader();

            var lista = new List<BEComposite>();

            while (reader.Read())
            {
                int id_padre = 0;
                if (reader["id_PermisoPadre"] != DBNull.Value)
                {
                    id_padre = reader.GetInt32(reader.GetOrdinal("id_PermisoPadre"));
                }

                var id = reader.GetInt32(reader.GetOrdinal("id"));
                var nombre = reader.GetString(reader.GetOrdinal("nombre"));

                var permiso = string.Empty;
                if (reader["permiso"] != DBNull.Value)
                    permiso = reader.GetString(reader.GetOrdinal("permiso"));

                BEComposite c;

                if (string.IsNullOrEmpty(permiso))//usamos este campo para identificar. Solo las patentes van a tener un permiso del sistema relacionado
                    c = new BEComponente_compuesto();

                else
                    c = new BEComponenteSimple();

                c.Id = id;
                c.Nombre = nombre;
                if (!string.IsNullOrEmpty(permiso))
                    c.Permiso = (TipoPermiso)Enum.Parse(typeof(TipoPermiso), permiso);

                var padre = GetComponent(id_padre, lista);

                if (padre == null)
                {
                    lista.Add(c);
                }
                else
                {
                    padre.AgregarHijo(c);
                }
            }

            reader.Close();
            cnn.Close();

            return lista;
        }
    }
}