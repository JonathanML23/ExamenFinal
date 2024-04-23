using System;
using System.Configuration;
using System.EnterpriseServices;
using System.Web.Services;
using System.Web.UI.HtmlControls;
using ExamenFinal.CapaLogica;
using Microsoft.SqlServer.Server;

namespace ExamenFinal.Capa_Presentacion
{
    public partial class Agente_Vista : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // El método Page_Load está vacío porque no se necesita realizar ninguna acción al cargar la página.
            //  btnAgregarAgente.Click += AgregarAgente_Click;
            //btnBorrarAgente.Click += BorrarAgente_Click;
            //btnModificarAgente.Click += ModificarAgente_Click;
        }

        
        protected void AgregarAgente_Click(object sender, EventArgs e)
        {

            string nombre_ = nombre.Value;
            string email_ = email.Value;
            string telefono_ = telefono.Value;
            Agente_OP agente_OP = new Agente_OP(); // Instancia de la clase Agente_OP de la capa lógica.
            if (agente_OP.AgregarAgente(nombre_, email_, telefono_))
            {
                //return "Se agregó un agente correctamente.";
                limpiarFormulario("Agregar");
                mostrarMensajes("SUCCESS","Agente Agregado");
            }
            else
            {
                mostrarMensajes("ERROR", "Error al agregar agente, intente de nuevo.");
            }
        }


       
        protected void BorrarAgente_Click(object sender, EventArgs e)
        {
            String id_ = idBorrar.Value;
            Agente_OP agente_OP = new Agente_OP(); // Instancia de la clase Agente_OP de la capa lógica.
            if (agente_OP.BorrarAgente(int.Parse(id_)))
            {
                limpiarFormulario("Borrar");
                mostrarMensajes("SUCCESS", "Se eliminó un agente correctamente.");
            }
            else
            {
                mostrarMensajes("ERROR", "Error al eliminar agente, intente de nuevo.");
            }
        }

        
        protected void ModificarAgente_Click(object sender, EventArgs e)
        {

            String id_ = idModificar.Value;
            String nombre_ = nombreModificar.Value;
            String email_ = emailModificar.Value;
            String telefono_ = telefonoModificar.Value;
            Agente_OP agente_OP = new Agente_OP(); // Instancia de la clase Agente_OP de la capa lógica.
            if (agente_OP.ModificarAgente(int.Parse(id_), nombre_, email_, telefono_))
            {
                limpiarFormulario("Modificar");
                mostrarMensajes("SUCCESS", "Se modificó un agente correctamente.");
            }
            else
            {
                mostrarMensajes("ERROR", "Error al modificar agente, intente de nuevo.");
            }
        }


        public void mostrarMensajes(String tipo, String mensajes)
        {
            resultado.Text = mensajes;
            resultado.ForeColor = "ERROR".Equals(tipo) ? System.Drawing.Color.Red : System.Drawing.Color.Green;
        }
        public void limpiarFormulario(String formulario)
        {
            switch (formulario)
            {
                case "Agregar":
                    {
                        nombre.Value = "";
                        email.Value = "";
                        telefono.Value = "";
                        break;
                    }
                case "Borrar":
                    {
                        idBorrar.Value = null;
                        break;
                    }
                case "Modificar":
                    {
                        idModificar.Value = null;
                        nombreModificar.Value = "";
                        emailModificar.Value = "";
                        telefonoModificar.Value = "";
                        break;
                    }
            }
        }
    }
}
