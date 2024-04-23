using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.HtmlControls;

namespace ExamenFinal.Presentacion
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            btnLogin.Click += Button1_Click;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            HtmlInputText txtUsername = (HtmlInputText)form1.FindControl("username");
            HtmlInputText txtPassword = (HtmlInputText)form1.FindControl("password");

            string username = txtUsername.Value;
            string password = txtPassword.Value;

            string connectionString = ConfigurationManager.ConnectionStrings["Conexion Last Test"].ConnectionString;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "EXEC LoginUsuario @nombre_usuario, @contraseña";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@nombre_usuario", username);
                    cmd.Parameters.AddWithValue("@contraseña", password);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows && reader.Read())
                    {
                        string estado = reader["Estado"].ToString();

                        if (estado == "Login exitoso")
                        {
                            Session["username"] = username;
                            Response.Redirect("MenuMaster.aspx");
                        }
                        else
                        {
                            errorLabel.Text = "Credenciales incorrectas";
                            errorLabel.Visible = true;
                        }
                    }
                    else
                    {
                        errorLabel.Text = "Credenciales incorrectas";
                        errorLabel.Visible = true;
                    }

                    reader.Close();
                }
            }
            catch (SqlException ex)
            {
                errorLabel.Text = "Error de base de datos: " + ex.Message;
                errorLabel.Visible = true;
            }
            catch (Exception ex)
            {
                errorLabel.Text = "Error general: " + ex.Message;
                errorLabel.Visible = true;
            }
        }
    }
}

