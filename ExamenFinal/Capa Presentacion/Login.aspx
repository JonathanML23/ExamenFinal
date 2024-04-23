<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ExamenFinal.Presentacion.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../CSS/Login.css" rel="stylesheet" />
    <title></title>
    <style>

    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="login-container">
            <h2>Iniciar Sesión</h2>
            <div class="form-group">
                <label for="username">Usuario:</label>
                <input type="text" id="username" runat="server" />
            </div>
            <div class="form-group">
                <label for="password">Contraseña:</label>
                <input type="password" id="password" runat="server" />
            </div>
            <asp:Button ID="btnLogin" runat="server" Text="Iniciar Sesión" CssClass="btn-submit" OnClick="Button1_Click" />
            <br />
            <asp:Label ID="errorLabel" runat="server" CssClass="error-label" Visible="false"></asp:Label>
        </div>
    </form>
</body>
</html>



