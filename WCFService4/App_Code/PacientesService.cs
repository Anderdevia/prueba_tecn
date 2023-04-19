using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

// NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
public class Service : IPacientesIService
{
    string cadenaConexion = ConfigurationManager.ConnectionStrings["myConexion"].ConnectionString;

    public List<Pacientes> MostrarRegistro()
    {
        List<Pacientes> lista = new List<Pacientes>();


        try
        {
            SqlConnection cnn = new SqlConnection(cadenaConexion);
            cnn.Open();
            SqlCommand cmd = new SqlCommand("sp_datos", cnn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@parametro", 1);

            SqlDataReader rd = cmd.ExecuteReader();
            if (rd.HasRows)
            {
                while (rd.Read())
                {
                    lista.Add(new Pacientes
                    {
                        Tipo_documento = rd.GetInt32(0),
                        Documento = rd.GetInt32(0),
                        Nombres = rd.GetString(2),
                        Apellidos = rd.GetString(2),
                        Correo = rd.GetString(2),
                        Telefono = rd.GetInt32(2),
                        Fecha_de_nacimiento = rd.GetDateTime(3),
                        Estado_afiliacion = rd.GetInt32(4)
                    });
                }
            }

            cnn.Close();

        }
        catch (Exception ex)
        {
            throw new Exception("Error al mostrar datos", ex);
        }
        return lista;
    }

    public int NuevoRegistro(Pacientes pacientes)
    {
        int res = 0;
        try
        {
            SqlConnection cnn = new SqlConnection(cadenaConexion);
            cnn.Open();
            SqlCommand cmd = new SqlCommand("sp_datos", cnn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@tipo_documento", pacientes.Tipo_documento);
            cmd.Parameters.AddWithValue("@documento", pacientes.Documento);
            cmd.Parameters.AddWithValue("@nombres", pacientes.Nombres);
            cmd.Parameters.AddWithValue("@apellidos", pacientes.Apellidos);
            cmd.Parameters.AddWithValue("@correo", pacientes.Correo);
            cmd.Parameters.AddWithValue("@fecha", pacientes.Fecha_de_nacimiento);
            cmd.Parameters.AddWithValue("@telefono", pacientes.Telefono);
            cmd.Parameters.AddWithValue("@estado", pacientes.Estado_afiliacion);
            cmd.Parameters.AddWithValue("@parametro", 1);

            cnn.Close();

        }
        catch (Exception ex)
        {
            throw new Exception("Error al insertar", ex);
        }
        return res;
    }
}
