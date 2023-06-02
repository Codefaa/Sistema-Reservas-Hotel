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
    public class DALPermisos
    {
        public SqlConnection conexion = new SqlConnection(@"Data Source=.;Initial Catalog=BD SIGG;Integrated Security=True");

        public Array GetAllPermission()
        {
            return Enum.GetValues(typeof(TipoPermiso));
        }
        private string GetConnectionString()
        {
            var cs = new SqlConnectionStringBuilder();
            cs.IntegratedSecurity = true;
            cs.DataSource = ".";
            cs.InitialCatalog = "BD SIGG";
            return cs.ConnectionString;
        }
        public BEComposite GuardarComponente(BEComposite p, bool esfamilia)
        {
            try
            {
                var cnn = new SqlConnection(GetConnectionString());
                cnn.Open();
                var cmd = new SqlCommand();
                cmd.Connection = cnn;

                var sql = $@"insert into Permiso (nombre,permiso) values (@nombre,@permiso);  SELECT ID AS LastID FROM permiso WHERE ID = @@Identity;       ";

                cmd.CommandText = sql;
                cmd.Parameters.Add(new SqlParameter("nombre", p.Nombre));


                if (esfamilia)
                    cmd.Parameters.Add(new SqlParameter("permiso", DBNull.Value));

                else
                    cmd.Parameters.Add(new SqlParameter("permiso", p.Permiso.ToString()));

                var id = cmd.ExecuteScalar();
                p.Id = (int)id;
                return p;
            }
            catch (Exception e)
            {


                throw e;
            }


        }
        public IList<BEComponenteSimple> GetAllPatentes()
        {

            var cnn = new SqlConnection(GetConnectionString());
            cnn.Open();
            var cmd = new SqlCommand();
            cmd.Connection = cnn;

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
            cnn.Close();


            return lista;
        }
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
        public void GuardarFamilia(BEComponente_compuesto c)
        {

            try
            {
                var cnn = new SqlConnection(GetConnectionString());
                cnn.Open();
                var cmd = new SqlCommand();
                cmd.Connection = cnn;


                var sql = $@"delete from permiso_permiso where id_permiso_padre=@id;       ";

                cmd.CommandText = sql;
                cmd.Parameters.Add(new SqlParameter("id", c.Id));
                cmd.ExecuteNonQuery();

                foreach (var item in c.Hijos)
                {
                    cmd = new SqlCommand();
                    cmd.Connection = cnn;


                    sql = $@"insert into permiso_permiso (id_permiso_padre,id_permiso_hijo) values (@id_permiso_padre,@id_permiso_hijo) ";

                    cmd.CommandText = sql;
                    cmd.Parameters.Add(new SqlParameter("id_permiso_padre", c.Id));
                    cmd.Parameters.Add(new SqlParameter("id_permiso_hijo", item.Id));

                    cmd.ExecuteNonQuery();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        public IList<BEComponente_compuesto> GetAllCompuestos()
        {

            var cnn = new SqlConnection(GetConnectionString());
            cnn.Open();
            var cmd = new SqlCommand();
            cmd.Connection = cnn;

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
            cnn.Close();


            return lista;
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
            cs.DataSource = ".";
            cs.InitialCatalog = "upf";
            var cnn = new SqlConnection(cs.ConnectionString);
            cnn.Open();
            var cmd = new SqlCommand();
            cmd.Connection = cnn;

            var sql = $@"with recursivo as (
                        select sp2.id_permiso_padre, sp2.id_permiso_hijo  from permiso_permiso SP2
                        where sp2.id_permiso_padre {where} --acá se va variando la familia que busco
                        UNION ALL 
                        select sp.id_permiso_padre, sp.id_permiso_hijo from permiso_permiso sp 
                        inner join recursivo r on r.id_permiso_hijo= sp.id_permiso_padre
                        )
                        select r.id_permiso_padre,r.id_permiso_hijo,p.id,p.nombre, p.permiso
                        from recursivo r 
                        inner join permiso p on r.id_permiso_hijo = p.id 
						
                        ";

            cmd.CommandText = sql;

            var reader = cmd.ExecuteReader();

            var lista = new List<BEComposite>();

            while (reader.Read())
            {
                int id_padre = 0;
                if (reader["id_permiso_padre"] != DBNull.Value)
                {
                    id_padre = reader.GetInt32(reader.GetOrdinal("id_permiso_padre"));
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

        //public List<BEComposite> getRoles()
        //{
        //    List<BEComposite> listaComponentesSimples = new List<BEComposite>();
        //    string query = "S_GetPermisos";
        //    DataTable table = new DataTable();
        //    table = Leer(query, null);

        //    if(table.Rows.Count > 0)
        //    {
        //        foreach (DataRow fila in table.Rows)
        //        {
        //            BEComposite unComponenteSimple = new BEComponenteSimple();
        //            unComponenteSimple.Id = Convert.ToInt32(fila["Id"]);
        //            unComponenteSimple.Nombre = fila["Nombre"].ToString();

        //            listaComponentesSimples.Add(unComponenteSimple);
        //        }
        //    }
        //    else
        //    {
        //        listaComponentesSimples = null;
        //    }
        //    return listaComponentesSimples;
        //}

    }
}
