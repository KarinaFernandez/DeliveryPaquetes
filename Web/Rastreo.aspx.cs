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
    public partial class Rastreo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


        }

        protected void btnRastrear_Click(object sender, EventArgs e)
        {
            string campoNroEnvio = txtNroEnvio.Text;
            int nroResult;
            bool resultNro = int.TryParse(this.txtNroEnvio.Text, out nroResult);
            int nroEnvio = nroResult;

            if (resultNro)
            {
                lblMensaje.Text = "";


                if (Controladora.Instancia.ExisteEnvio(nroEnvio))
                {
                    Envio envAux = Controladora.Instancia.BuscarEnvio(nroEnvio);
                    List<Recorrido> listaTemporal = envAux.ListaRecorrido;

                    GridViewRastreoEnv.DataSource = listaTemporal;
                    GridViewRastreoEnv.DataBind();
                }
                else {
                    lblMensaje.Text = "No se encontro el numero de envio ingresado";
                }

            }
            else
            {
                lblMensaje.Text = "Numero de envio no valido";
            }
        }

        protected void btnCargaDatos_Click(object sender, EventArgs e)
        {
            txtNroEnvio.Text = "1";
        }

    }
}