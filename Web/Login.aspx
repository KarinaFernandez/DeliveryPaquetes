<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/PaginaMaestra.Master" CodeBehind="Login.aspx.cs" Inherits="Web.Login" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        LOGIN&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnCargaDatos" runat="server" CssClass="auto-style15" OnClick="btnCargaDatos_Click" Text="Cargar datos" />
        &nbsp;&nbsp;&nbsp;&nbsp;
    </div>
    <p>
        <asp:Label ID="lblUsuario" runat="server" Text="Usuario"></asp:Label>
        <asp:TextBox ID="txtUsuario" runat="server" Height="18px" Style="margin-left: 33px" Width="150px"></asp:TextBox>
    </p>
    <asp:Label ID="lblClave" runat="server" Text="Clave"></asp:Label>
    <asp:TextBox ID="txtClave" runat="server" Style="margin-left: 46px" Width="148px"></asp:TextBox>
    <br />
    <br />
    <asp:Button ID="btnLogin" runat="server" OnClick="btnLogin_Click" Text="Login" CssClass="auto-style1" />
    <br />
    <br />
    <asp:Label ID="lblMensaje" runat="server"></asp:Label>

</asp:Content>

<asp:Content ID="Content3" runat="server" contentplaceholderid="head">
    <style type="text/css">
        .auto-style1 {
            margin-left: 84px;
        }
        .auto-style15 {
            margin-left: 749px;
            margin-top: 10px;
        }
        </style>
</asp:Content>


