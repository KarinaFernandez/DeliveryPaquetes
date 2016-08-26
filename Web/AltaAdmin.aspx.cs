using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;

namespace Web
{
    public partial class AltaAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario aux = (Usuario)Session["usuarioLog"];
            if (aux == null || !aux.Admin) { 
                Response.Redirect("Login.aspx");
            }
        }


        protected void btnAltaAdm_Click(object sender, EventArgs e)
        {
            string mensaje = "";

            string usuario = this.txtUsuario.Text;
            string password = this.txtPassword.Text;

            //Doy de alta al administrador, si los campos no son vacios y no encontre el nombre del usuario 
            if (usuario != "" && password != "")
            {
                if (!Controladora.BuscarUsuario(usuario))
                {
                    bool ok = Controladora.Instancia.AltaAdmin(usuario, password);
                    if (ok)
                    {
                        lblNroEmp.Text = Usuario.UltId.ToString();
                        mensaje = "Alta de administrador exitosa";
                    }
                    else
                    {
                        mensaje = "No se pudo dar de alta";
                    }
                }
                else
                {
                    mensaje = "El nombre de usuario ya se encuentra ingresado";
                }
            }
            else
            {
                mensaje = "Por favor verifique que los campos no esten vacios";
            }
            this.lblMensaje.Text = mensaje;
        }

        protected void btnCargaDatos_Click(object sender, EventArgs e)
        {
            txtUsuario.Text = "admin1";
            txtPassword.Text = "admin1";
        }

    }
}