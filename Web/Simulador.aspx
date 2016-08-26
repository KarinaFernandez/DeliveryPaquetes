<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/PaginaMaestra.Master" CodeBehind="Simulador.aspx.cs" Inherits="Web.Simulador" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    SIMULADOR:&nbsp;&nbsp;
        <asp:Button ID="btnCargaDatos" runat="server" CssClass="auto-style15" OnClick="btnCargaDatos_Click" Text="Cargar datos" />
        <br />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <br />
    <asp:RadioButton ID="rbDocumento" runat="server" Text="Documento" GroupName="Envio" OnCheckedChanged="rbDocumento_CheckedChanged" />
    <br />
<asp:CheckBox ID="cbLegal" runat="server" OnCheckedChanged="cbLegal_CheckedChanged" Text="Legal" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="lblMensaje" runat="server"></asp:Label>
<br />
<br />
        Peso:&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtPesoDoc" runat="server" CssClass="auto-style12" Width="104px"></asp:TextBox>
&nbsp;gr&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblPesoDoc" runat="server"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
        <br />
        <br />
    <asp:RadioButton ID="rbPaquete" runat="server" Text="Paquete" GroupName="Envio" OnCheckedChanged="rbPaquete_CheckedChanged" Checked="True" />
<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
Alto:<asp:TextBox ID="txtAlto" runat="server" CssClass="auto-style22" style="margin-left: 20px"></asp:TextBox>
&nbsp;cm&nbsp; &nbsp;&nbsp;<asp:Label ID="lblAlto" runat="server"></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Peso:&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtPesoPaque" runat="server" CssClass="auto-style23" Width="115px"></asp:TextBox>
&nbsp;kg&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblPesoPaque" runat="server"></asp:Label>
        <br />
            Ancho:
<asp:TextBox ID="txtAncho" runat="server" CssClass="auto-style21" style="margin-left: 3px"></asp:TextBox>
&nbsp;cm&nbsp;&nbsp; &nbsp;<asp:Label ID="lblAncho" runat="server"></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Valor contenido&nbsp;
<asp:TextBox ID="txtValorCont" runat="server" CssClass="auto-style14"></asp:TextBox>
    <asp:Label ID="lblValor" runat="server"></asp:Label>
<br />
Largo:
<asp:TextBox ID="txtLargo" runat="server" CssClass="auto-style20" style="margin-left: 5px"></asp:TextBox>
&nbsp;cm&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblLargo" runat="server"></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="cbSeguro" runat="server" OnCheckedChanged="cbSeguro_CheckedChanged" Text="Seguro" />
<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<br />
<br />
&nbsp;<span class="auto-style18">Precio:&nbsp;</span>
        <asp:Label ID="lblPrecio" runat="server" Font-Bold="True"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
<br />
        <asp:Button ID="btnCalcularEnvio" runat="server" CssClass="auto-style17" Text="Calcular Envio" OnClick="btnCalcularEnvio_Click" />
    <br />
    <br />
    <br />
    <br />
    </asp:Content>
<asp:Content ID="Content3" runat="server" contentplaceholderid="head">
    <style type="text/css">

        .auto-style17 {
            margin-left: 34px;
        }
        .auto-style18 {
            font-size: large;
        }
        .auto-style15 {
            margin-left: 740px;
            margin-top: 10px;
        }
        </style>
</asp:Content>

