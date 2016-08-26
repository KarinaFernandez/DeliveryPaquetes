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
    public partial class AltaOficina : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario aux = (Usuario)Session["usuarioLog"];
            if (aux == null || !aux.Admin)
            {
                Response.Redirect("Login.aspx");
            }
            
            
            lblIdOficina.Text = Oficina.UltOficina.ToString();
        }


        //Solo los administradores pueden dar de alta
        protected void btnAltaOfi_Click(object sender, EventArgs e)
        {
            string desc = txtDesc.Text;
            string calle = txtCalle.Text;
            string campoNroPuerta = txtNroPuerta.Text;
            string codPost = txtCP.Text;
            string ciudad = txtCiudad.Text;
            string pais = txtPais.Text;

            if (desc != "" && calle != "" && campoNroPuerta != "" && Herramientas.esNumero(campoNroPuerta) && codPost != "" && ciudad != "" && pais != "")
            {

                int nroPuertaResult;
                bool resultNroPuerta = int.TryParse(this.txtNroPuerta.Text, out nroPuertaResult);
                int nroPuerta = nroPuertaResult;

                if (Controladora.Instancia.AltaOficina(calle, nroPuerta, codPost, ciudad, pais, desc))
                {
                    lblMensaje.Text = "Oficina dada de alta";
                }
                else
                {
                    lblMensaje.Text = "La direccion ya se encuentra registrada";
                    this.LimpiarCampos();
                }
            }
        }

        protected void btnCargaDatos_Click(object sender, EventArgs e)
        {
            txtDesc.Text = "Sucursal Centro";
            txtCalle.Text = "18 de Julio";
            txtNroPuerta.Text = "182";
            txtCP.Text = "10000";
            txtCiudad.Text = "Paysandu";
            txtPais.Text = "Uruguay";
        }

        public void LimpiarCampos()
        {
            txtDesc.Text = "";
            txtCalle.Text = "";
            txtNroPuerta.Text = "";
            txtCP.Text = "";
            txtCiudad.Text = "";
            txtPais.Text = "";
            lblMensaje.Text = "";
        }
        
    }
}