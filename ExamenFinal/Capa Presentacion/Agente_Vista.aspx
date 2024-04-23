<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Agente_Vista.aspx.cs" Inherits="ExamenFinal.Capa_Presentacion.Agente_Vista" MasterPageFile="~/Capa Presentacion/Catalogos.Master" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../CSS/Agente.css" rel="stylesheet" />
    <style>
    </style>

    <div class="container">
        <h1>Gestión de Agentes</h1>

        <asp:Label ID="resultado" runat="server" Text="" ForeColor="Red"></asp:Label><br><br>

            <label for="nombre">Nombre:</label>
            <input type="text" id="nombre" name="nombre" runat="server"><br>
            <label for="email">Email:</label>
            <input type="email" id="email" name="email"  runat="server" pattern="[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,}$" title="Por favor, ingrese un correo electrónico válido."><br>
            <label for="telefono">Teléfono:</label>
            <input type="tel" id="telefono" name="telefono"  runat="server" pattern="^\d{8}$" title="Por favor, ingrese un teléfono válido de 8 dígitos."><br>
            <asp:Button ID="btnAgregarAgente" runat="server" Text="Agregar Agente" CssClass="btn-submit" OnClick="AgregarAgente_Click" />
        
            <label for="idBorrar">ID del Agente:</label>
            <input type="number" id="idBorrar" name="idBorrar" min="1" title="El ID debe ser un número positivo." runat="server"><br>
            <asp:Button CausesValidation="False" ID="btnBorrarAgente" runat="server" Text="Borrar Agente" CssClass="btn-submit" OnClick="BorrarAgente_Click" />
        
            <label for="idModificar">ID del Agente:</label>
            <input type="number" id="idModificar" name="idModificar" min="1" title="El ID debe ser un número positivo."  runat="server"><br>
            <label for="nombreModificar">Nuevo Nombre:</label>
            <input type="text" id="nombreModificar" name="nombreModificar"  runat="server"><br>
            <label for="emailModificar">Nuevo Email:</label>
            <input type="email" id="emailModificar"  runat="server" name="emailModificar" pattern="[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,}$" title="Por favor, ingrese un correo electrónico válido."><br>
            <label for="telefonoModificar">Nuevo Teléfono:</label>
            <input type="tel" runat="server" id="telefonoModificar" name="telefonoModificar" pattern="^\d{10}$" title="Por favor, ingrese un teléfono válido de 10 dígitos."><br>           
            <asp:Button CausesValidation="False" ID="btnModificarAgente" runat="server" Text="Modificar Agente" CssClass="btn-submit" OnClick="ModificarAgente_Click" /> 
        
    </div>

</asp:Content>
