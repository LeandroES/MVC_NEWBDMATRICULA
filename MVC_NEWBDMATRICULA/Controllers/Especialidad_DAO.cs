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
    public class Especialidad_DAO
    {
        // obtener la cadena de conexion
        string CAD_CN = ConfigurationManager.ConnectionStrings["cnx"].ConnectionString;

        public List<pa_listar_especialidad> Especialidades()
        {
            List<pa_listar_especialidad> lista = new List<pa_listar_especialidad>();

            // ACCESO A DATOS 
            SqlConnection conexion = new SqlConnection(CAD_CN);
            conexion.Open();

            SqlCommand comando = new SqlCommand("pa_listar_especialidad", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            SqlDataReader dr = comando.ExecuteReader();

            while (dr.Read())
            {
                lista.Add(new pa_listar_especialidad(){

                    CODESP = dr.GetString(0), 
                    NOMESP = dr.GetString(1)
                });
            }
            dr.Close();

            conexion.Close();

            return lista;
        }

    }
}