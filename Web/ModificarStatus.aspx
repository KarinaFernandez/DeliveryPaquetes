<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/PaginaMaestra.Master" CodeBehind="ModificarStatus.aspx.cs" Inherits="Web.ModificarStatus" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    MODIFICAR ESTADO<asp:Button ID="btnCargaDatos" runat="server" CssClass="auto-style15" OnClick="btnCargaDatos_Click" Text="Cargar datos" />
        <br />
    <br />
    Id admin:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="txtIdAdm" runat="server" CssClass="auto-style9"></asp:TextBox>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:Label ID="lblIdAdm" runat="server"></asp:Label>
    <br />
    Nro envio:&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="txtNroEnvio" runat="server" CssClass="auto-style9"></asp:TextBox>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;<asp:Label ID="lblMensaje" runat="server"></asp:Label>
    <br />
    <br />
Fecha recep:
<asp:TextBox ID="txtFechaRec" runat="server" CssClass="auto-style10"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<asp:Label ID="lblFechaRec" runat="server"></asp:Label>
        <br />
    Fecha partida:&nbsp;&nbsp;&nbsp; <asp:TextBox ID="txtFechaSal" runat="server" CssClass="auto-style13"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:Label ID="lblFechaSal" runat="server"></asp:Label>
        <br />
    Oficina actual: <asp:DropDownList ID="dropDownOficinaActual" runat="server" CssClass="auto-style8" OnSelectedIndexChanged="dropDownOficinaActual_SelectedIndexChanged">
            <asp:ListItem></asp:ListItem>
        </asp:DropDownList>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblOficina" runat="server"></asp:Label>
    <br />
    <asp:CheckBox ID="cbEntregar" runat="server" Enabled="False" OnCheckedChanged="cbEntregar_CheckedChanged" Text="Entregar" />
    <br />
    <br />
    Receptor:<asp:TextBox ID="txtReceptor" runat="server" CssClass="auto-style11" Enabled="False"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="lblReceptor" runat="server"></asp:Label>
    <br />
    Foto:<asp:FileUpload ID="FileUploadFirma" runat="server" CssClass="auto-style12" Enabled="False" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="lblFirma" runat="server"></asp:Label>
    <br />
    <asp:Button ID="btnModificarEstado" runat="server" Text="Modificar Estado" OnClick="btnModificarEstado_Click" />
    &nbsp;<asp:Button ID="btnVerEstado0" runat="server" Text="Ver estado" OnClick="btnVerEstado_Click" />
    <br />
    <br />
    <br />
    <asp:GridView ID="GridViewRastreoEnv" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="NroOficina" HeaderText="Nro Oficina" />
            <asp:BoundField DataField="FechaRecepcion" HeaderText="Fecha Recepcion" />
            <asp:BoundField DataField="FechaSalida" HeaderText="Fecha partida" />
            <asp:BoundField DataField="Status" HeaderText="Estado" />
        </Columns>
    </asp:GridView>
    <br />
    <br />
    <br />
    </asp:Content>

<asp:Content ID="Content3" runat="server" contentplaceholderid="head">
    <style type="text/css">

        .auto-style8 {
            margin-left: 15px;
        }
        .auto-style9 {
            margin-left: 21px;
        }
    .auto-style10 {
        margin-left: 22px;
    }
        .auto-style11 {
            margin-left: 43px;
        }
        .auto-style12 {
            margin-left: 69px;
        }
        .auto-style13 {
            margin-left: 2px;
        }
        .auto-style15 {
            margin-left: 664px;
            margin-top: 10px;
        }
        </style>
</asp:Content>


