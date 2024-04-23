using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace ExamenFinal.CapaLogica
{
    public class Cliente_OP
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["Conexion Last Test"].ConnectionString;

        public bool AgregarCliente(string nombre, string email, string telefono)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("GestionarClientes", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@accion", "agregar");
                    command.Parameters.AddWithValue("@cliente_nombre", nombre);
                    command.Parameters.AddWithValue("@cliente_email", email);
                    command.Parameters.AddWithValue("@cliente_telefono", telefono);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool BorrarCliente(int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("GestionarClientes", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@accion", "borrar");
                    command.Parameters.AddWithValue("@cliente_id", id);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool ModificarCliente(int id, string nombre, string email, string telefono)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("GestionarClientes", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@accion", "modificar");
                    command.Parameters.AddWithValue("@cliente_id", id);
                    command.Parameters.AddWithValue("@cliente_nombre", nombre);
                    command.Parameters.AddWithValue("@cliente_email", email);
                    command.Parameters.AddWithValue("@cliente_telefono", telefono);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
