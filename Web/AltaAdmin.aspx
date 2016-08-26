<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/PaginaMaestra.Master" CodeBehind="AltaAdmin.aspx.cs" Inherits="Web.AltaAdmin" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div>
    
        ALTA DE ADMINISTRADOR:<asp:Button ID="btnCargaDatos" runat="server" CssClass="auto-style15" OnClick="btnCargaDatos_Click" Text="Cargar datos" />
        <br />
        <br />
        Nro Empleado&nbsp;
        <asp:Label ID="lblNroEmp" runat="server"></asp:Label>
        <br />
        <br />
        Usuario
        <asp:TextBox ID="txtUsuario" runat="server" CssClass="auto-style1"></asp:TextBox>
        <br />
        Password<asp:TextBox ID="txtPassword" runat="server" CssClass="auto-style2"></asp:TextBox>
        <br />
        <br />
            <asp:Button ID="btnAltaAdm" runat="server" OnClick="btnAltaAdm_Click" Text="Dar de alta" CssClass="auto-style3" />
    
    </div>
    <br />
        <asp:Label ID="lblMensaje" runat="server"></asp:Label>
    
</asp:Content>
<asp:Content ID="Content3" runat="server" contentplaceholderid="head">
    <style type="text/css">
        .auto-style1 {
            margin-left: 45px;
        }
        .auto-style2 {
            margin-left: 36px;
        }
        .auto-style3 {
            margin-left: 96px;
        }
        .auto-style15 {
            margin-left: 612px;
            margin-top: 10px;
        }
        </style>
</asp:Content>

