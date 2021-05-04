using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MVC_NEWBDMATRICULA.Models;

// utilizar propiedades comunes de los elementos de ADO NET
using System.Data; 
// utilizar a SqlConnection, SqlCommand, SqlDataReader
using System.Data.SqlClient;
// Leer ar archivo web.config
using System.Configuration;

namespace MVC_NEWBDMATRICULA.Controllers
{
    public class Cursos_DAO
    {
        // obtener la cadena de conexion
        string CAD_CN = ConfigurationManager.ConnectionStrings["cnx"].ConnectionString;

        // método que nos devuelva los cursos de acuerdo a un codigo de especialidad
        // enviado como parámetro
        public List<pa_cursos_especialidad> CursosPorEspecialidad(string codesp)
        {
            List<pa_cursos_especialidad> lista = new List<pa_cursos_especialidad>();

            // variable del Sqlconnection
            SqlConnection conexion = new SqlConnection(CAD_CN);
            // abrir la conexion a la BD
            conexion.Open();

            // variable del SqlCommand
            SqlCommand comando = new SqlCommand("pa_cursos_especialidad", conexion);
            // indicarle al comando que va a ejecutar un procedimiento almacenado
            comando.CommandType = CommandType.StoredProcedure;
            // enviando el valor al parámetro del procedimiento almacenado
            comando.Parameters.Add("@codesp", SqlDbType.Char, 3).Value = codesp;

            //comando.Parameters.AddWithValue("@codesp", codesp);

            // Variable del SqlDataReader
            SqlDataReader dr = comando.ExecuteReader();

            // leer cada fila mientras se pueda del SqlDataReader 
            while (dr.Read())
            {
                // poblar la lista genérica
                lista.Add(new pa_cursos_especialidad() { 
                    // agregar los valores provenientes de cada columna del reader
                    // al objeto pa_cursos_especialidad que al final se agregara
                    // a la lista
                    CODCUR = dr.GetString(0), NOMCUR = dr.GetString(1),
                    COSTO = dr.GetDecimal(2), NROVAC = dr.GetInt32(3)
                });
            }
            dr.Close();

            // cerra la conexion a la BD
            conexion.Close();

            return lista;
        }

        public List<pa_cursos_por_costo> CursosPorCosto(decimal costo)
        {
            List<pa_cursos_por_costo> lista = new List<pa_cursos_por_costo>();

            // variable del Sqlconnection
            SqlConnection conexion = new SqlConnection(CAD_CN);
            // abrir la conexion a la BD
            conexion.Open();

            // variable del SqlCommand
            SqlCommand comando = new SqlCommand("pa_cursos_por_costo", conexion);
            // indicarle al comando que va a ejecutar un procedimiento almacenado
            comando.CommandType = CommandType.StoredProcedure;
            // enviando el valor al parámetro del procedimiento almacenado
            comando.Parameters.Add("@costo", SqlDbType.Decimal).Value = costo;

            //comando.Parameters.AddWithValue("@costo", costo);

            // Variable del SqlDataReader
            SqlDataReader dr = comando.ExecuteReader();

            // leer cada fila mientras se pueda del SqlDataReader 
            while (dr.Read())
            {
                // poblar la lista genérica
                lista.Add(new pa_cursos_por_costo()
                {
                    // agregar los valores provenientes de cada columna del reader
                    // al objeto pa_cursos_especialidad que al final se agregara
                    // a la lista
                    CODCUR = dr.GetString(0),
                    NOMCUR = dr.GetString(1),
                    COSTO = dr.GetDecimal(2),
                    NROVAC = dr.GetInt32(3)
                });
            }
            dr.Close();

            // cerra la conexion a la BD
            conexion.Close();

            return lista;
        }

        //CRUD
        public string RegistrarCurso(Cursos objCur)
        {

            string mensaje = "";
            SqlConnection cnx = new SqlConnection(CAD_CN);
            cnx.Open();

            try
            {
                SqlCommand command = new SqlCommand("PA_GRABAR_MODIFICAR_CURSO", cnx);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("@CODCUR", SqlDbType.Char, 5).Value = objCur.CODCUR;
                command.Parameters.Add("@CODESP", SqlDbType.Char, 3).Value = objCur.CODESP;
                command.Parameters.Add("@NOMCUR", SqlDbType.VarChar, 45).Value = objCur.CODCUR;
                command.Parameters.Add("@COSTO", SqlDbType.Decimal).Value = objCur.CODCUR;
                command.Parameters.Add("@NROVAC", SqlDbType.Int).Value = objCur.CODCUR;

                command.ExecuteNonQuery();
                //command.ExecuteScalar();

                mensaje = "El curso fue creado y/o modificado correctamente";

                cnx.Close();
            }
            catch (Exception)
            {

                mensaje = "Error al crear y/o modificar un curso";
            }

            return mensaje;

        }

        public string EliminarCurso(string codCur)
        {

            string mensaje = "";
            SqlConnection cnx = new SqlConnection(CAD_CN);
            cnx.Open();

            try
            {
                SqlCommand command = new SqlCommand("PA_ELIMINAR_MODIFICAR_CURSO", cnx);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("@CODCUR", SqlDbType.Char, 5).Value = codCur;
                
                command.ExecuteNonQuery();
                //command.ExecuteScalar();

                mensaje = "El curso fue eliminado correctamente";

                cnx.Close();
            }
            catch (Exception)
            {

                mensaje = "Error al eliminar el curso";
            }

            return mensaje;

        }

    }
}