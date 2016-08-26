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
    public partial class AltaCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Controladora inst = Controladora.Instancia;
            List<Usuario> listaU = inst.ListaUsuario;
            
            //Si la lista no esta vacia que me muestre el contenido
            if (listaU.Count != 0)
            {
                lstClientes.DataSource = inst.ListaUsuario;
                lstClientes.DataTextField = "NombreUsuario";
                lstClientes.DataBind();
            }

        }

        #region boton alta cliente
        //Validar ci int y que no haya otra igual. Validar que usuario no se repita y que nada sea null
        protected void btnAltaCliente_Click(object sender, EventArgs e)
        {
            string mensaje = "";
            string ci = this.txtCI.Text;
          

            //Si la cedula es valida y no la encontre en la lista de clientes
            if (Cliente.CiValida(ci) == true && Cliente.EncontreCi(ci) == false)
            {
                string nombre = this.txtNombre.Text;
                string apellido = this.txtApellido.Text;

                //Parseo el telefono
                int telResult;
                bool resultadoTel = int.TryParse(this.txtTelefono.Text, out telResult);
                int telefono = telResult;

                string calle = this.txtCalle.Text;

                //Parseo el nro de puerta
                int nroPuertaResult;
                bool resultadoNroPuerta = int.TryParse(this.txtNroPuerta.Text, out nroPuertaResult);
                int nroPuerta = nroPuertaResult;
                

                string codPostal = this.txtCodPostal.Text;
                string ciudad = this.txtCiudad.Text;
                string pais = this.txtPais.Text;
                string usuario = this.txtUsuario.Text;
                string password = this.txtClave.Text;

                

                //Si ninguno de los campos es vacio
                if (nombre != "" && apellido != "" && telefono != 0 && Direccion.validarDireccion(calle, nroPuerta, codPostal, ciudad, pais)
                    && usuario != "" && password != "")
                {
                    //Si no encontre el nombre del usuario
                    if (!Controladora.BuscarUsuario(usuario))
                    {
                        Direccion dir = new Direccion(calle, nroPuerta, codPostal, ciudad, pais);
                        //Trato de dar de alta
                        bool ok = Controladora.Instancia.AltaCliente(nombre, apellido, ci, telefono, dir, usuario, password);
                        if (ok)
                        {
                            mensaje = "Alta de cliente exitosa";
                        }
                        else
                        {
                            mensaje = "No se pudo dar de alta";
                        }
                    }
                    else
                    {
                        mensaje = "El nombre de usuario no es valido";
                    }
                }
                else
                {
                    mensaje = "Por favor verifique los valores ingresados";
                }
            }
            else
            {
                mensaje = "La CI ingresada no es valida";
            }
            this.lblMensaje.Text = mensaje;
        }
        #endregion


        

        



    }
}

