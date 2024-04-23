<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Clientes_View.aspx.cs" Inherits="ExamenFinal.Capa_Presentacion.Clientes_View" MasterPageFile="~/Capa Presentacion/Catalogos.Master" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../CSS/Clientes.css" rel="stylesheet" />
    <style>
      
    </style>

    <div class="container">
        <h1>Gestión de Clientes</h1>

        <asp:Label ID="lblMensaje" runat="server" Text="" ForeColor="Red"></asp:Label><br><br>

        <label for="nombre">Nombre:</label>
        <input type="text" id="nombre" name="nombre" runat="server" required><br>
        <label for="email">Email:</label>
        <input type="email" id="email" name="email" runat="server" required pattern="[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,}$" title="Por favor, ingrese un correo electrónico válido."><br>
        <label for="telefono">Teléfono:</label>
        <input type="tel" id="telefono" name="telefono" runat="server" required pattern="^\d{8}$" title="Por favor, ingrese un teléfono válido de 8 dígitos."><br>
        <asp:Button ID="btnAgregarCliente" runat="server" Text="Agregar Cliente" CssClass="btn-submit" OnClick="AgregarCliente_Click" />
        
        <label for="idBorrar">ID del Cliente:</label>
        <input type="number" id="idBorrar" name="idBorrar" runat="server" min="1" title="El ID debe ser un número positivo." required><br>
        <asp:Button ID="btnBorrarCliente" runat="server" Text="Borrar Cliente" CssClass="btn-submit" OnClick="BorrarCliente_Click" />
        
        <label for="idModificar">ID del Cliente:</label>
        <input type="number" id="idModificar" name="idModificar" runat="server" min="1" title="El ID debe ser un número positivo." required><br>
        <label for="nombreModificar">Nuevo Nombre:</label>
        <input type="text" id="nombreModificar" name="nombreModificar" runat="server"><br>
        <label for="emailModificar">Nuevo Email:</label>
        <input type="email" id="emailModificar" name="emailModificar" runat="server" pattern="[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,}$" title="Por favor, ingrese un correo electrónico válido."><br>
        <label for="telefonoModificar">Nuevo Teléfono:</label>
        <input type="tel" id="telefonoModificar" name="telefonoModificar" runat="server" pattern="^\d{10}$" title="Por favor, ingrese un teléfono válido de 10 dígitos."><br>
        <asp:Button ID="btnModificarCliente" runat="server" Text="Modificar Cliente" CssClass="btn-submit" OnClick="ModificarCliente_Click" />

    </div>

</asp:Content>

