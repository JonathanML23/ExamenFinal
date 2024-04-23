using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration; // Asegúrate de agregar esta referencia

namespace ExamenFinal.CapaLogica
{
    public class Agente_OP
    {
        // Obtén la cadena de conexión desde el archivo de configuración de manera segura
        private string connectionString = ConfigurationManager.ConnectionStrings["Conexion Last Test"].ConnectionString;

        // Método para agregar un agente
        public bool AgregarAgente(string Nombre, string Email, string Telefono)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("GestionarAgentes", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@accion", "agregar");
                    command.Parameters.AddWithValue("@agente_nombre", Nombre);
                    command.Parameters.AddWithValue("@agente_email", Email);
                    command.Parameters.AddWithValue("@agente_telefono", Telefono);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                // Aquí podrías logear el error o manejarlo según necesites
                Console.WriteLine(ex.Message); // Muestra el mensaje de error en la consola
                return false;
            }
        }

        // Método para borrar un agente
        public bool BorrarAgente(int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("GestionarAgentes", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@accion", "borrar");
                    command.Parameters.AddWithValue("@agente_id", id);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        // Método para modificar un agente
        public bool ModificarAgente(int id, string nombre, string email, string telefono)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("GestionarAgentes", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@accion", "modificar");
                    command.Parameters.AddWithValue("@agente_id", id);
                    command.Parameters.AddWithValue("@agente_nombre", nombre);
                    command.Parameters.AddWithValue("@agente_email", email);
                    command.Parameters.AddWithValue("@agente_telefono", telefono);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
