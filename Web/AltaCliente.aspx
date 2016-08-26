<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/PaginaMaestra.Master" CodeBehind="AltaCliente.aspx.cs" Inherits="Web.AltaCliente" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
    
        <br />
    
        <asp:Label ID="lblAltadeCliente" runat="server" Text="ALTA DE CLIENTE:"></asp:Label>
        &nbsp;<br />
        <br />
        Nombre<asp:TextBox ID="txtNombre" runat="server" Width="120px" CssClass="auto-style1"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Usuario<asp:TextBox ID="txtUsuario" runat="server" CssClass="auto-style4"></asp:TextBox>
        <br />
        Apellido<asp:TextBox ID="txtApellido" runat="server" Width="120px" CssClass="auto-style1"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Password<asp:TextBox ID="txtClave" runat="server" CssClass="auto-style3"></asp:TextBox>
        <br />
        CI<asp:TextBox ID="txtCI" runat="server" style="margin-left: 92px; margin-top: 0px"></asp:TextBox>
        <br />
        Telefono<asp:TextBox ID="txtTelefono" runat="server" CssClass="auto-style2"></asp:TextBox>
        <asp:Button ID="btnAltaCliente" runat="server" OnClick="btnAltaCliente_Click" Text="Dar de alta" CssClass="auto-style5" />
        <br />
        Calle<asp:TextBox ID="txtCalle" runat="server" CssClass="auto-style8"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblMensaje" runat="server"></asp:Label>
        <br />
        Nro Puerta<asp:TextBox ID="txtNroPuerta" runat="server" CssClass="auto-style7"></asp:TextBox>
        <br />
        Cod Postal<asp:TextBox ID="txtCodPostal" runat="server" CssClass="auto-style9"></asp:TextBox>
        <br />
        Ciudad<asp:TextBox ID="txtCiudad" runat="server" CssClass="auto-style10"></asp:TextBox>
        <br />
        Pais<asp:TextBox ID="txtPais" runat="server" CssClass="auto-style11"></asp:TextBox>
            <br />
        <asp:ListBox ID="lstClientes" runat="server" Width="324px"></asp:ListBox>
        <br />
        
    
    </div>
  </asp:Content>
<asp:Content ID="Content3" runat="server" contentplaceholderid="head">
    <style type="text/css">
        .auto-style1 {
            margin-left: 57px;
        }
        .auto-style2 {
            margin-left: 55px;
        }
        .auto-style3 {
            margin-left: 27px;
        }
        .auto-style4 {
            margin-left: 40px;
        }
        .auto-style5 {
            margin-left: 198px;
        }
        .auto-style7 {
            margin-left: 41px;
        }
        .auto-style8 {
            margin-left: 78px;
        }
        .auto-style9 {
            margin-left: 42px;
        }
        .auto-style10 {
            margin-left: 66px;
            margin-top: 0px;
        }
        .auto-style11 {
            margin-left: 84px;
        }
    </style>
</asp:Content>

