<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/PaginaMaestra.Master" CodeBehind="Listados.aspx.cs" Inherits="Web.Listados" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    LISTADOS
        <asp:Button ID="btnCargaDatos" runat="server" CssClass="auto-style15" OnClick="btnCargaDatos_Click" Text="Cargar datos" />
        <br />
<br />
    <asp:RadioButton ID="rbEnviosEntreg" runat="server" GroupName="Listado" OnCheckedChanged="rbEnviosEntreg_CheckedChanged" Text="Envios ya entregados" />
&nbsp;&nbsp;&nbsp;
    <asp:RadioButton ID="rbFacturado" runat="server" GroupName="Listado" OnCheckedChanged="rbFacturado_CheckedChanged" Text="Facturado entre fechas" Checked="True" />
&nbsp;&nbsp;&nbsp;
    <asp:RadioButton ID="rbEnviosMonto" runat="server" GroupName="Listado" OnCheckedChanged="rbEnviosSup_CheckedChanged" Text="Envios por monto " />
&nbsp;&nbsp;&nbsp;
    <asp:RadioButton ID="rbEnviosTransito" runat="server" GroupName="Listado" OnCheckedChanged="rbEnviosTransito_CheckedChanged" Text="Envios en transito" />
    <br />
    <br />
<br />
CI:
<asp:TextBox ID="txtCI" runat="server" CssClass="auto-style16"></asp:TextBox>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblMensaje" runat="server"></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<strong><br />
<br />
    <br />
    &nbsp;</strong>Fecha Inicial:<asp:TextBox ID="txtFechaIni" runat="server" CssClass="auto-style19"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
<asp:Label ID="lblFechaIni" runat="server"></asp:Label>
<br />
&nbsp;Fecha Final:<asp:TextBox ID="txtFechaFin" runat="server" CssClass="auto-style18"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
<asp:Label ID="lblFechaFin" runat="server"></asp:Label>
    <br />
    <br />
    Precio: <strong>&nbsp;
<asp:TextBox ID="txtPrecio" runat="server" CssClass="auto-style20"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp; </strong>
<asp:Label ID="lblPrecio" runat="server"></asp:Label>
<br />
<br />
    Total Facturado:&nbsp;&nbsp;&nbsp;&nbsp;
<asp:Label ID="lblTotal" runat="server"></asp:Label>
<strong>
<br />
<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:Button ID="btnBuscarEnvios" runat="server" CssClass="auto-style17" Text="Buscar Envios" OnClick="btnBuscarEnvios_Click" />
</strong>
<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:GridView ID="GridViewRastreoEnv" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="NroEnvio" HeaderText="Nro Envio" />
            <asp:BoundField DataField="OficinaAct" HeaderText="Ultima Oficina" />
            <asp:BoundField DataField="FechaEnvio" HeaderText="Fecha Envio" />
            <asp:BoundField DataField="FechaSalida" HeaderText="Fecha Salida" />
            <asp:BoundField DataField="Precio" HeaderText="Precio" />
            <asp:BoundField DataField="Estado" HeaderText="Estado" />
        </Columns>
    </asp:GridView>
    <br />
<br />
<br />
        <br />
        </asp:Content>
<asp:Content ID="Content3" runat="server" contentplaceholderid="head">
    <style type="text/css">


        .auto-style16 {
        margin-left: 81px;
    }
    .auto-style17 {
        margin-left: 28px;
    }
    .auto-style18 {
        margin-left: 27px;
            }
        .auto-style19 {
            margin-left: 21px;
            }
        .auto-style20 {
            margin-left: 50px;
        }
    
        .auto-style15 {
            margin-left: 688px;
        margin-top: 10px;
    }
        </style>
</asp:Content>

