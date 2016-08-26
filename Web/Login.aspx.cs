using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;

namespace Web
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }



        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string nombre = this.txtUsuario.Text;
            string clave = this.txtClave.Text;

            if (nombre != "" && clave != "")
            {
                Usuario aux = Controladora.Instancia.DevuelveUsuario(nombre);
                if (aux != null && aux.Password == clave)
                {
                    Session["usuarioLog"] = aux;
                    lblMensaje.Text = "Logeado";

                    Session["usuario"] = nombre; //Para guardar el usuario como variable de session
                }
                else
                {
                    lblMensaje.Text = "Usuario o password incorrecta";
                }

            }
        }

        protected void btnCargaDatos_Click(object sender, EventArgs e)
        {
            txtUsuario.Text = "admin1";
            txtClave.Text = "admin1";
        }
    }
}