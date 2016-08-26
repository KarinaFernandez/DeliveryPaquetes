<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/PaginaMaestra.Master" CodeBehind="AltaOficina.aspx.cs" Inherits="Web.AltaOficina" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    ALTA DE OFICINA<asp:Button ID="btnCargaDatos" runat="server" CssClass="auto-style15" OnClick="btnCargaDatos_Click" Text="Cargar datos" />
        <br />
<br />
Nro Oficina&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblIdOficina" runat="server"></asp:Label>
    <br />
Detalle<asp:TextBox ID="txtDesc" runat="server" CssClass="auto-style21"></asp:TextBox>
<br />
Calle
    <asp:TextBox ID="txtCalle" runat="server" Style="margin-left: 70px"></asp:TextBox>
    <br />
Nro puerta<asp:TextBox ID="txtNroPuerta" runat="server" CssClass="auto-style16"></asp:TextBox>
    <br />
Codigo postal<asp:TextBox ID="txtCP" runat="server" CssClass="auto-style17"></asp:TextBox>
    <br />
Ciudad
        <asp:TextBox ID="txtCiudad" runat="server" CssClass="auto-style18"></asp:TextBox>
    <br />
Pais<asp:TextBox ID="txtPais" runat="server" CssClass="auto-style19"></asp:TextBox>
    <br />
<br />
        <asp:Button ID="btnAltaOfi" runat="server" Text="Dar de alta" OnClick="btnAltaOfi_Click" CssClass="auto-style20" />
    <br />
<br />
<asp:Label ID="lblMensaje" runat="server"></asp:Label>
<p>
        &nbsp;</p>
    
</asp:Content>
<asp:Content ID="Content3" runat="server" contentplaceholderid="head">
    <style type="text/css">

        .auto-style15 {
            margin-left: 664px;
            margin-top: 10px;
        }
        .auto-style16 {
        margin-left: 38px;
    }
    .auto-style17 {
        margin-left: 20px;
    }
    .auto-style18 {
        margin-left: 58px;
    }
    .auto-style19 {
        margin-left: 80px;
    }
    .auto-style20 {
        margin-left: 103px;
    }
    .auto-style21 {
        margin-left: 63px;
    }
</style>
</asp:Content>

