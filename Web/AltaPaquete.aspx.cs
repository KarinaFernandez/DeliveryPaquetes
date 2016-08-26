using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Utilidades;

namespace Web
{
    public partial class AltaPaquete : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario aux = (Usuario)Session["usuarioLog"];
            if (aux == null || !aux.Admin)
            {
                Response.Redirect("Login.aspx");
            }

            lblEnvioOk.Text = "";
            lblNroEnvio.Text = Envio.UltimoNroEnvio.ToString();
            lblPrecio.Text = "";

            if (!IsPostBack)
            {
                List<Oficina> listaOfi = Controladora.Instancia.ListaOficinas();
                dropDownOficinaActual.DataSource = listaOfi;
                dropDownOficinaActual.DataTextField = "desc";
                dropDownOficinaActual.DataValueField = "nroOficina";
                dropDownOficinaActual.DataBind();

                dropDownOficinaFinal.DataSource = listaOfi;
                dropDownOficinaFinal.DataTextField = "desc";
                dropDownOficinaFinal.DataValueField = "nroOficina";
                dropDownOficinaFinal.DataBind();

            }

        }

        protected void btnBuscarCli_Click(object sender, EventArgs e)
        {
            string ciCli = txtCI.Text;
            Cliente auxCli = Controladora.Instancia.BuscarClienteXCi(ciCli);

            if (ciCli != "")
            {
                if (auxCli != null)
                {
                    txtNombre.Text = auxCli.NombreCli;
                    txtCalle.Text = auxCli.DirCliente.Calle;
                    txtNroPuerta.Text = auxCli.DirCliente.NumPuerta.ToString();
                    txtCodPos.Text = auxCli.DirCliente.CodPostal.ToString();
                    txtCiudad.Text = auxCli.DirCliente.Ciudad;
                    txtPais.Text = auxCli.DirCliente.Pais;

                }
                else
                {
                    lblCi.Text = "La CI ingresada no corresponde a un cliente registrado";
                }
            }
        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            #region valores
            string nroOfiOrig = this.dropDownOficinaActual.SelectedValue;
            string nroOfiFinal = this.dropDownOficinaFinal.SelectedValue;

            string admin = txtAdmin.Text;

            string campoFecha = txtFecha.Text;
            DateTime fechaResult;
            bool resultFecha = DateTime.TryParse(this.txtFecha.Text, out fechaResult);
            DateTime fecha = fechaResult;

            string campoPeso = txtPeso.Text;
            decimal pesoResult;
            bool resultPeso = Decimal.TryParse(this.txtPeso.Text, out pesoResult);
            decimal peso = pesoResult;

            string campoAlto = txtAlto.Text;
            decimal altoResult;
            bool resultAlto = Decimal.TryParse(this.txtAlto.Text, out altoResult);
            decimal alto = altoResult;

            string campoAncho = txtAncho.Text;
            decimal anchoResult;
            bool resultAncho = Decimal.TryParse(this.txtAncho.Text, out anchoResult);
            decimal ancho = anchoResult;

            string campoLargo = txtLargo.Text;
            decimal largoResult;
            bool resultLargo = Decimal.TryParse(this.txtLargo.Text, out largoResult);
            decimal largo = largoResult;

            string desc = txtDesc.Text;

            string campoValor = txtValorCont.Text;
            decimal valorResult;
            bool resultValor = Decimal.TryParse(this.txtValorCont.Text, out valorResult);
            decimal valorCont = valorResult;

            bool seguro = false;
            string ci = txtCI.Text;
            string nombreD = txtNomDest.Text;
            string calleD = txtCalleD.Text;
            string nroPuertaD = txtNroPuertaD.Text;
            string codPostalD = txtCodPosD.Text;
            string ciudadD = txtCiudadD.Text;
            string paisD = txtPaisD.Text;
            #endregion

            //Validar que los campos no sea vacios
            if (admin != "" && campoFecha != "" && campoPeso != "" && peso != 0 && campoAlto != "" && alto != 0
                && campoAncho != "" && ancho != 0 && campoLargo != "" && largo != 0 && desc != "" && campoValor != ""
                && valorCont != 0 && ci != "" && calleD != "" && nroPuertaD != "" && codPostalD != "" && ciudadD != ""
                && paisD != "")
            {
                if (nroOfiOrig != nroOfiFinal)
                {
                    lblOfiFinal.Text = "";
                    if (Herramientas.FechaValida(fecha))
                    {
                        lblFecha.Text = "";
                        if (Herramientas.esDecimal(campoAlto))
                        {
                            lblAlto.Text = "";
                            if (Herramientas.esDecimal(campoAncho))
                            {
                                lblAncho.Text = "";
                                if (Herramientas.esDecimal(campoLargo))
                                {
                                    lblLargo.Text = "";
                                    if (Herramientas.esDecimal(campoValor))
                                    {
                                        lblValor.Text = "";
                                        if (Herramientas.esFecha(campoFecha))
                                        {
                                            lblFecha.Text = "";
                                            if (Herramientas.esNumero(admin))
                                            {
                                                lblAdmin.Text = "";
                                                if (Controladora.Instancia.ExisteAdmin(int.Parse(admin)))
                                                {
                                                    lblAdmin.Text = "";
                                                    if (Herramientas.esDecimal(campoPeso))
                                                    {
                                                        lblPeso.Text = "";
                                                        if (Herramientas.esNumero(ci))
                                                        {
                                                            lblCi.Text = "";
                                                            if (Controladora.Instancia.ExisteCliente(int.Parse(ci)))
                                                            {
                                                                lblCi.Text = "";
                                                                if (Herramientas.esNumero(nroPuertaD))
                                                                {
                                                                    lblNroPuertaD.Text = "";
                                                                    if (resultFecha)
                                                                    {
                                                                        if (cbSeguro.Checked)
                                                                        {
                                                                            seguro = true;
                                                                        }

                                                                        decimal precio = Controladora.Instancia.CalcularEnvioPaquete(alto, ancho, largo, peso, valorCont, seguro);
                                                                        lblPrecio.Text = precio.ToString();
                                                                        Usuario adm = Controladora.Instancia.BuscarAdminXId(int.Parse(admin));
                                                                        Cliente cli = Controladora.Instancia.BuscarClienteXCi(ci);
                                                                        Oficina ofiOrig = Controladora.Instancia.BuscarOficina(int.Parse(nroOfiOrig));
                                                                        Oficina ofiFinal = Controladora.Instancia.BuscarOficina(int.Parse(nroOfiFinal));

                                                                        Direccion dirD = new Direccion(calleD, int.Parse(nroPuertaD), codPostalD, ciudadD, paisD);
                                                                        Destinatario dest = new Destinatario(nombreD, dirD);

                                                                        if (Controladora.Instancia.AltaPaquete(desc, valorCont, ancho, alto, largo, seguro, peso, precio,
                                                                            fecha, cli, adm, dest, cli.DirCliente, ofiOrig, ofiFinal))
                                                                        {
                                                                            lblEnvioOk.Text = "Alta de paquete exitoso";
                                                                            this.LimpiarCampos();
                                                                        }
                                                                    }
                                                                    else
                                                                    {
                                                                        lblFecha.Text = "La fecha no es valida";
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    lblNroPuertaD.Text = "El numero de puerta ingresado no es valido";
                                                                }
                                                            }
                                                            else
                                                            {
                                                                lblCi.Text = "La CI ingresada no se encuentra registrada";
                                                            }
                                                        }
                                                        else
                                                        {
                                                            lblCi.Text = "La CI ingresada no es valida";
                                                        }

                                                    }
                                                    else
                                                    {
                                                        lblPeso.Text = "El peso ingresado no es valido";
                                                    }
                                                }
                                                else
                                                {
                                                    lblAdmin.Text = "El id ingresado no se encontro";
                                                }
                                            }
                                            else
                                            {
                                                lblAdmin.Text = "Debe ingresar un numero de administrador";
                                            }
                                        }
                                        else
                                        {
                                            lblFecha.Text = "La fecha ingresada no es valida";
                                        }
                                    }
                                    else
                                    {
                                        lblValor.Text = "Valor invalido";
                                    }
                                }
                                else
                                {
                                    lblLargo.Text = "Largo no es valido";
                                }
                            }
                            else
                            {
                                lblAncho.Text = "Ancho no es valido";
                            }
                        }
                        else
                        {
                            lblAlto.Text = "Alto no es valido";
                        }
                    }
                    else
                    {
                        lblFecha.Text = "La fecha debe ser menor al dia actual";
                    }
                }
            }
            else
            {
                lblOfiFinal.Text = "La oficina de retiro debe de ser distinta a la de entrega";
            }
        }


        public void LimpiarCampos()
        {
            txtFecha.Text = "";
            txtAdmin.Text = "";
            txtPeso.Text = "";
            txtDesc.Text = "";
            txtValorCont.Text = "";
            txtAlto.Text = "";
            txtAncho.Text = "";
            txtLargo.Text = "";
            txtCI.Text = "";
            txtNombre.Text = "";
            txtCalle.Text = "";
            txtNroPuerta.Text = "";
            txtCodPos.Text = "";
            txtCiudad.Text = "";
            txtPais.Text = "";
            txtNomDest.Text = "";
            txtCalleD.Text = "";
            txtNroPuertaD.Text = "";
            txtCodPosD.Text = "";
            txtCiudadD.Text = "";
            txtPaisD.Text = "";
        }

        protected void btnCalcularEnvio_Click(object sender, EventArgs e)
        {
            string campoPesoPaque = txtPeso.Text;
            decimal pesoPaqueResult;
            bool resultPesoPaque = Decimal.TryParse(this.txtPeso.Text, out pesoPaqueResult);
            decimal pesoPaque = pesoPaqueResult;

            string campoAlto = txtAlto.Text;
            decimal altoResult;
            bool resultAlto = Decimal.TryParse(this.txtAlto.Text, out altoResult);
            decimal alto = altoResult;

            string campoAncho = txtAncho.Text;
            decimal anchoResult;
            bool resultAncho = Decimal.TryParse(this.txtAncho.Text, out anchoResult);
            decimal ancho = anchoResult;

            string campoLargo = txtLargo.Text;
            decimal largoResult;
            bool resultLargo = Decimal.TryParse(this.txtLargo.Text, out largoResult);
            decimal largo = largoResult;

            string campoValor = txtValorCont.Text;
            decimal valorResult;
            bool resultValor = Decimal.TryParse(this.txtValorCont.Text, out valorResult);
            decimal valorCont = valorResult;

            if (resultPesoPaque && resultAlto && resultAncho && resultLargo && resultValor && pesoPaque != 0 && alto != 0 &&
                ancho != 0 && largo != 0 && valorCont != 0)
            {
                lblMensajePrecio.Text = "";
                bool seguro = false;
                if (cbSeguro.Checked)
                {
                    seguro = true;
                }

                decimal precio = Controladora.Instancia.CalcularEnvioPaquete(alto, ancho, largo, pesoPaque, valorCont, seguro);
                lblPrecio.Text = precio.ToString();
            }
            else
            {
                lblMensajePrecio.Text = "Por favor verifique los valores ingresados";
            }
        }

        protected void btnCargaDatos_Click(object sender, EventArgs e)
        {
            txtFecha.Text = "20/06/2015";
            txtAdmin.Text = "1";
            txtPeso.Text = "2";
            txtAlto.Text = "10";
            txtAncho.Text = "20";
            txtLargo.Text = "20";
            txtDesc.Text = "Cargadores";
            txtValorCont.Text = " 500";
            txtCI.Text = "1111";
            txtCalle.Text = "25 de Mayo";
            txtNroPuerta.Text = "123";
            txtCodPos.Text = "11300";
            txtCiudad.Text = "Montevideo";
            txtPais.Text = "Uruguay";
            txtNomDest.Text = "Juan";
            txtCalleD.Text = "Scoseria";
            txtNroPuertaD.Text = "789";
            txtCodPosD.Text = "19780";
            txtCiudadD.Text = "Montevideo";
            txtPaisD.Text = "Uruguay";
        }

        protected void cbSeguro_CheckedChanged(object sender, EventArgs e)
        {

        }

    }
}