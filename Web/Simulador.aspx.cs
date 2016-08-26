using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;

namespace Web
{
    public partial class Simulador : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCalcularEnvio_Click(object sender, EventArgs e)
        {
            if (rbDocumento.Checked)
            {
                string campoPesoDoc = txtPesoDoc.Text;
                decimal pesoDocResult;
                bool resultPesoDoc = Decimal.TryParse(this.txtPesoDoc.Text, out pesoDocResult);
                decimal pesoDoc = pesoDocResult;

                if (resultPesoDoc && pesoDoc != 0)
                {
                    lblMensaje.Text = "";

                    bool legal = false;
                    if (cbLegal.Checked)
                    {
                        legal = true;
                    }

                    decimal precio = Controladora.Instancia.CalcularEnvioDoc(legal, pesoDoc);
                    lblPrecio.Text = precio.ToString();
                }
                else
                {
                    lblMensaje.Text = "Peso invalido";
                }
            }
            else if (rbPaquete.Checked)
            {
                string campoPesoPaque = txtPesoPaque.Text;
                decimal pesoPaqueResult;
                bool resultPesoPaque = Decimal.TryParse(this.txtPesoPaque.Text, out pesoPaqueResult);
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
                    lblMensaje.Text = "";

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
                    lblMensaje.Text = "Por favor verifique los valores ingresados";
                }

            }
            else
            {
                lblMensaje.Text = "Debo seleccionar un tipo de envio";
            }
        }

        protected void cbLegal_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void rbPaquete_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void rbDocumento_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void cbSeguro_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void btnCargaDatos_Click(object sender, EventArgs e)
        {
            txtAlto.Text = "10";
            txtAncho.Text = "20";
            txtLargo.Text = "20";
            txtPesoPaque.Text = "5";
            txtValorCont.Text = "100";
        }
    }
}