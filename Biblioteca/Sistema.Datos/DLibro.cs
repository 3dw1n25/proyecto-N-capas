using System;
using System.Data;
using Sistema.Entidades;
using System.Data.SqlClient;

namespace Sistema.Datos
{
    class DLibro
    {
        public DataTable Listar()
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand Comando = new SqlCommand("libro_listar", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;
                SqlCon.Open();
                Resultado = Comando.ExecuteReader();
                Tabla.Load(Resultado);
                return Tabla;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
        }

        public DataTable Buscar(string Valor)
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand Comando = new SqlCommand("libro_buscar", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@valor", SqlDbType.VarChar).Value = Valor;
                SqlCon.Open();
                Resultado = Comando.ExecuteReader();
                Tabla.Load(Resultado);
                return Tabla;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
        }

        public string Existe(string Valor)
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand Comando = new SqlCommand("libro_existe", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@valor", SqlDbType.VarChar).Value = Valor;
                SqlParameter ParExiste = new SqlParameter();
                ParExiste.ParameterName = "@existe";
                ParExiste.SqlDbType = SqlDbType.Int;
                ParExiste.Direction = ParameterDirection.Output;
                Comando.Parameters.Add(ParExiste);
                SqlCon.Open();
                Comando.ExecuteNonQuery();
                Rpta = Convert.ToString(ParExiste.Value);
            }
            catch (Exception ex)
            {
                Rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return Rpta;
        }

        public string Insertar(Libro Obj)
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand Comando = new SqlCommand("libro_insertar", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@numeroejemplar", SqlDbType.VarChar).Value = Obj.NumeroEjemplar;
                Comando.Parameters.Add("@isb", SqlDbType.VarChar).Value = Obj.ISBN;
                Comando.Parameters.Add("@titulo", SqlDbType.VarChar).Value = Obj.Titulo;
                Comando.Parameters.Add("@autor", SqlDbType.VarChar).Value = Obj.Autor;
                Comando.Parameters.Add("@editorial", SqlDbType.VarChar).Value = Obj.Editorial;
                Comando.Parameters.Add("@añoedicion", SqlDbType.VarChar).Value = Obj.AñoEdicion;
                Comando.Parameters.Add("@numeroedicion", SqlDbType.VarChar).Value = Obj.NumeroEdicion;
                Comando.Parameters.Add("@pais", SqlDbType.VarChar).Value = Obj.Pais;
                Comando.Parameters.Add("@idioma", SqlDbType.VarChar).Value = Obj.Idioma;
                Comando.Parameters.Add("@materia", SqlDbType.VarChar).Value = Obj.Materia;
                Comando.Parameters.Add("@numeropagina", SqlDbType.VarChar).Value = Obj.NumeroPagina;
                Comando.Parameters.Add("@ubicacion", SqlDbType.VarChar).Value = Obj.Ubicacion;
                Comando.Parameters.Add("@descripcion", SqlDbType.VarChar).Value = Obj.Descripcion;
                SqlCon.Open();
                Rpta = Comando.ExecuteNonQuery() == 1 ? "OK" : "No se pudo ingresar el registro";
            }
            catch (Exception ex)
            {
                Rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return Rpta;
        }

        public string Actualizar(Libro Obj)
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand Comando = new SqlCommand("libro_actualizar", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@idlibro", SqlDbType.VarChar).Value = Obj.IdLibro;
                Comando.Parameters.Add("@numeroejemplar", SqlDbType.VarChar).Value = Obj.NumeroEjemplar;
                Comando.Parameters.Add("@isb", SqlDbType.VarChar).Value = Obj.ISBN;
                Comando.Parameters.Add("@titulo", SqlDbType.VarChar).Value = Obj.Titulo;
                Comando.Parameters.Add("@autor", SqlDbType.VarChar).Value = Obj.Autor;
                Comando.Parameters.Add("@editorial", SqlDbType.VarChar).Value = Obj.Editorial;
                Comando.Parameters.Add("@añoedicion", SqlDbType.VarChar).Value = Obj.AñoEdicion;
                Comando.Parameters.Add("@numeroedicion", SqlDbType.VarChar).Value = Obj.NumeroEdicion;
                Comando.Parameters.Add("@pais", SqlDbType.VarChar).Value = Obj.Pais;
                Comando.Parameters.Add("@idioma", SqlDbType.VarChar).Value = Obj.Idioma;
                Comando.Parameters.Add("@materia", SqlDbType.VarChar).Value = Obj.Materia;
                Comando.Parameters.Add("@numeropagina", SqlDbType.VarChar).Value = Obj.NumeroPagina;
                Comando.Parameters.Add("@ubicacion", SqlDbType.VarChar).Value = Obj.Ubicacion;
                Comando.Parameters.Add("@descripcion", SqlDbType.VarChar).Value = Obj.Descripcion;
                SqlCon.Open();
                Rpta = Comando.ExecuteNonQuery() == 1 ? "OK" : "No se pudo actualizar el registro";
            }
            catch (Exception ex)
            {
                Rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return Rpta;
        }

        public string Eliminar(int Id)
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand Comando = new SqlCommand("libro_eliminar", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@idlibro", SqlDbType.Int).Value = Id;
                SqlCon.Open();
                Rpta = Comando.ExecuteNonQuery() == 1 ? "OK" : "No se pudo eliminar el registro";
            }
            catch (Exception ex)
            {
                Rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return Rpta;
        }
    }
}
