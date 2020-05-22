using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI;

namespace MVCPlantilla.Utilerias
{
      public class BaseHelper
    {
        public static int ejecutarSentencia(String sentencia,
                           CommandType tipo,out string mensaje,
                           List<SqlParameter> parametros = null)
        {
            mensaje = string.Empty;
            SqlConnection con = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            int filas;
            filas = 0;
            try
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;
                con.Open();
                comando.Connection = con;
                comando.CommandType = tipo;
                comando.CommandText = sentencia;

                if (parametros != null)
                {
                    comando.Parameters.AddRange(parametros.ToArray());
                }

                filas = comando.ExecuteNonQuery();
            } //try
            catch (Exception e) 
            {
                mensaje = e.Message;
                //throw; 
            }
            finally
            {
                con.Close();
            } //finally	
            return filas;
        } // funcion ejecutar sentencia  

        public static void MsgBox(String ex, Page pg, Object obj)
        {
            string s = "<SCRIPT language='javascript'>alert('" + ex.Replace("\r\n", "\\n").Replace("'", "") + "'); </SCRIPT>";
            Type cstype = obj.GetType();
            ClientScriptManager cs = pg.ClientScript;
            cs.RegisterClientScriptBlock(cstype, s, s.ToString());
        }

        public static int ejecutarAgregar(String sentencia, CommandType tipo, List<SqlParameter> parametros = null)
        {
            SqlConnection con = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataAdapter adaptador = new SqlDataAdapter();

            int RegistrosAfectados = 0;
            try
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;
                con.Open();
                comando.Connection = con;
                comando.CommandType = tipo;
                comando.CommandText = sentencia;
                adaptador.SelectCommand = comando;
                if (parametros != null)
                {
                    comando.Parameters.AddRange(parametros.ToArray());
                }

               RegistrosAfectados = comando.ExecuteNonQuery();
            }
            catch (Exception) { throw; }
            finally
            {
                con.Close();
            }
            
            //BaseHelper EjecutarSentencia("INSERT INTO Videos" + "VALUES (@idvideo, @titulo, @reproducciones, @url)", CommandType.Text, parametros);   
            
            //return View("Mensaje");
           
            return RegistrosAfectados;
 
        }
        public static DataTable ejecutarConsulta(String sentencia,
                             CommandType tipo,
                             List<SqlParameter> parametros = null)
        {
            SqlConnection con = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataAdapter adaptador = new SqlDataAdapter();
            DataTable datos = new DataTable();
            try
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;
                con.Open();
                comando.Connection = con;
                comando.CommandType = tipo;
                comando.CommandText = sentencia;
                adaptador.SelectCommand = comando;
                if (parametros != null)
                {
                    comando.Parameters.AddRange(parametros.ToArray());
                }

                adaptador.Fill(datos);
            } //try
            catch (Exception) { throw; }
            finally
            {
                con.Close();
            } //finally	
            return datos;
        } //ejecutarSentencia
    } //clase basehelper
}
