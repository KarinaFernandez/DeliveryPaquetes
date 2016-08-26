<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/PaginaMaestra.Master" CodeBehind="Rastreo.aspx.cs" Inherits="Web.Rastreo" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    RASTREO<asp:Button ID="btnCargaDatos" runat="server" CssClass="auto-style15" OnClick="btnCargaDatos_Click" Text="Cargar datos" />
        <br />
    <br />
    Nro envio:&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="txtNroEnvio" runat="server"></asp:TextBox>
    <asp:Button ID="btnRastrear" runat="server" CssClass="auto-style1" OnClick="btnRastrear_Click" Text="Rastrear Envio" />
    <br />
    <br />
    <asp:Label ID="lblMensaje" runat="server"></asp:Label>
    <br />
    <br />
    <br />
    <asp:GridView ID="GridViewRastreoEnv" runat="server" AutoGenerateColumns="False" >
        <Columns>
            <asp:BoundField DataField="NroOficina" HeaderText="Nro Oficina" />
            <asp:BoundField DataField="FechaRecepcion" HeaderText="Fecha Recepcion" />
            <asp:BoundField DataField="FechaSalida" HeaderText="Fecha partida" />
            <asp:BoundField DataField="Status" HeaderText="Estado" />
        </Columns>
    </asp:GridView>
    </asp:Content>
<asp:Content ID="Content3" runat="server" contentplaceholderid="head">
    <style type="text/css">
        .auto-style1 {
            margin-left: 18px;
        }
        .auto-style15 {
            margin-left: 740px;
            margin-top: 10px;
        }
        </style>
</asp:Content>

