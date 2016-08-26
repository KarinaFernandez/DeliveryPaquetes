<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/PaginaMaestra.Master" CodeBehind="AltaDocumento.aspx.cs" Inherits="Web.AltaDocumento" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div>

        ALTA DOCUMENTO
        <asp:Button ID="btnCargaDatos" runat="server" CssClass="auto-style15" OnClick="btnCargaDatos_Click" Text="Cargar datos" />
        <br />
        <br />
        Nro envio:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblNroEnvio" runat="server"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Oficina origen:&nbsp;
        <asp:DropDownList ID="dropDownOficinaActual" runat="server" CssClass="auto-style8" OnSelectedIndexChanged="dropDownOficinaActual_SelectedIndexChanged">
            <asp:ListItem></asp:ListItem>
        </asp:DropDownList>
        <br />
        Fecha:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtFecha" runat="server" Width="121px"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Id admin:&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtAdmin" runat="server" CssClass="auto-style11"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblAdmin" runat="server"></asp:Label>
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblFecha" runat="server"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Oficina retiro:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="dropDownOficinaFinal" runat="server" CssClass="auto-style18">
            <asp:ListItem></asp:ListItem>
        </asp:DropDownList>
        &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblOfiFinal" runat="server"></asp:Label>
        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        Peso:&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtPeso" runat="server" CssClass="auto-style12" Width="104px"></asp:TextBox>
&nbsp;gr&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblPeso" runat="server"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Precio:&nbsp;
        <asp:Label ID="lblPrecio" runat="server"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblEnvioOk" runat="server" Font-Size="Large"></asp:Label>
        <br />
        <br />
            <asp:RadioButton ID="rbPersonal" runat="server" Text="Personal" GroupName="Documento" OnCheckedChanged="rbPersonal_CheckedChanged" Checked="True"  />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:RadioButton ID="rbLegal" runat="server" Text="Legal" GroupName="Documento" OnCheckedChanged="rbLegal_CheckedChanged" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnCalcularEnvio" runat="server" CssClass="auto-style17" Text="Calcular Costo" OnClick="btnCalcularEnvio_Click" />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <asp:Panel ID="plRemitente" runat="server">
            <span class="auto-style9">Datos del remitente<br /> </span>
            <br />
            CI cliente:&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtCI" runat="server" CssClass="auto-style1"></asp:TextBox>
            <asp:Button ID="btnBuscarCli" runat="server" CssClass="auto-style14" OnClick="btnBuscarCli_Click" Text="Buscar cliente" Height="22px" Width="98px" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblCi" runat="server"></asp:Label>
            <br />
            Nombre<asp:TextBox ID="txtNombre" runat="server" AutoPostBack="True" CssClass="auto-style16" ReadOnly="True"></asp:TextBox>
            <br />
            Calle:
            <asp:TextBox ID="txtCalle" runat="server" CssClass="auto-style2" ReadOnly="True" Width="122px"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:CheckBox ID="cbModificarDir" runat="server" Text="Modificar" AutoPostBack="True" OnCheckedChanged="cbModificarDir_CheckedChanged" />
            <br />
            Nro puerta:<asp:TextBox ID="txtNroPuerta" runat="server" CssClass="auto-style3" ReadOnly="True"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblNroPuertaC" runat="server"></asp:Label>
            <br />
            Cod postal:<asp:TextBox ID="txtCodPos" runat="server" CssClass="auto-style4" ReadOnly="True"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblCodPostC" runat="server"></asp:Label>
            <br />
            Ciudad:<asp:TextBox ID="txtCiudad" runat="server" CssClass="auto-style5" ReadOnly="True"></asp:TextBox>
            <br />
            Pais:<asp:TextBox ID="txtPais" runat="server" CssClass="auto-style6" ReadOnly="True"></asp:TextBox>
            <br />
        </asp:Panel>
        <br />
        <asp:Panel ID="plDestinatario" runat="server">
            <span class="auto-style10">Datos del destinatario<br /> </span>
            <br />
            Nombre dest:<asp:TextBox ID="txtNomDest" runat="server" CssClass="auto-style7" Width="121px"></asp:TextBox>
            <br />
            Calle:
            <asp:TextBox ID="txtCalleD" runat="server" CssClass="auto-style2" Width="122px"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
            Nro puerta:<asp:TextBox ID="txtNroPuertaD" runat="server" CssClass="auto-style3"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblNroPuertaD" runat="server"></asp:Label>
            <br />
            Cod postal:<asp:TextBox ID="txtCodPosD" runat="server" CssClass="auto-style4"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblCodPostD" runat="server"></asp:Label>
            <br />
            Ciudad:<asp:TextBox ID="txtCiudadD" runat="server" CssClass="auto-style5"></asp:TextBox>
            <br />
            Pais:<asp:TextBox ID="txtPaisD" runat="server" CssClass="auto-style6"></asp:TextBox>
            <br />
        </asp:Panel>
        <br />
        <asp:Button ID="btnEnviar" runat="server" CssClass="auto-style13" OnClick="btnEnviar_Click" Text="Enviar" />
        <br />
        <br />

    </div>
    
</asp:Content>
<asp:Content ID="Content3" runat="server" ContentPlaceHolderID="head">
    <style type="text/css">
        .auto-style1 {
            margin-left: 20px;
        }
        .auto-style2 {
            margin-left: 58px;
        }
        .auto-style3 {
            margin-left: 26px;
        }
        .auto-style4 {
            margin-left: 27px;
        }
        .auto-style5 {
            margin-left: 50px;
        }
        .auto-style6 {
            margin-left: 69px;
        }
        .auto-style7 {
            margin-left: 12px;
        }
        .auto-style8 {
            margin-left: 15px;
        }
        .auto-style9 {
            font-size: medium;
            text-decoration: underline;
        }
        .auto-style10 {
            text-decoration: underline;
        }
        .auto-style11 {
            margin-left: 36px;
        }
        .auto-style12 {
            margin-left: 45px;
        }
        .auto-style13 {
            margin-left: 91px;
        }
    .auto-style14 {
        margin-left: 4px;
    }
        .auto-style15 {
            margin-left: 664px;
            margin-top: 10px;
        }
        .auto-style16 {
            margin-left: 46px;
        }
        .auto-style17 {
            margin-left: 34px;
        }
        .auto-style18 {
            margin-left: 0px;
        }
    </style>
</asp:Content>
