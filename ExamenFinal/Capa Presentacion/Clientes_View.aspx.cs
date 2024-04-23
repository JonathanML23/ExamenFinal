using System;
using System.Web.UI;
using ExamenFinal.CapaLogica;

namespace ExamenFinal.Capa_Presentacion
{
    public partial class Clientes_View : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Configuración inicial para la carga de la página
        }

        protected void AgregarCliente_Click(object sender, EventArgs e)
        {
            string nombre = Request.Form["nombre"];
            string email = Request.Form["email"];
            string telefono = Request.Form["telefono"];
            Cliente_OP clienteOp = new Cliente_OP();
            if (clienteOp.AgregarCliente(nombre, email, telefono))
            {
                MostrarMensaje("Cliente agregado exitosamente.", true);
            }
            else
            {
                MostrarMensaje("Error al agregar cliente.", false);
            }
        }

        protected void BorrarCliente_Click(object sender, EventArgs e)
        {
            int clienteId = int.Parse(Request.Form["idBorrar"]);
            Cliente_OP clienteOp = new Cliente_OP();
            if (clienteOp.BorrarCliente(clienteId))
            {
                MostrarMensaje("Cliente borrado exitosamente.", true);
            }
            else
            {
                MostrarMensaje("Error al borrar cliente.", false);
            }
        }

        protected void ModificarCliente_Click(object sender, EventArgs e)
        {
            int clienteId = int.Parse(Request.Form["idModificar"]);
            string nombre = Request.Form["nombreModificar"];
            string email = Request.Form["emailModificar"];
            string telefono = Request.Form["telefonoModificar"];
            Cliente_OP clienteOp = new Cliente_OP();
            if (clienteOp.ModificarCliente(clienteId, nombre, email, telefono))
            {
                MostrarMensaje("Cliente modificado exitosamente.", true);
            }
            else
            {
                MostrarMensaje("Error al modificar cliente.", false);
            }
        }

        private void MostrarMensaje(string mensaje, bool exito)
        {
            var color = exito ? System.Drawing.Color.Green : System.Drawing.Color.Red;
            // Asumiendo que hay un control en el front-end para mostrar mensajes, como un Label con ID 'lblMensaje'.
            lblMensaje.Text = mensaje;
            lblMensaje.ForeColor = color;
        }
    }
}
