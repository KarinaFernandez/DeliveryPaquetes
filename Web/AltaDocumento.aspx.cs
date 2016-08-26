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
    public partial class AltaDocumento : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario aux = (Usuario)Session["usuarioLog"];
            if (aux == null || !aux.Admin)
            {
                Response.Redirect("Login.aspx");
            } 
            
            

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

                lblEnvioOk.Text = "";
                lblNroEnvio.Text = Envio.UltimoNroEnvio.ToString();
                lblPrecio.Text = "";
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

        protected void cbModificarDir_CheckedChanged(object sender, EventArgs e)
        {
            txtCalle.ReadOnly = false;
            txtNroPuerta.ReadOnly = false;
            txtCodPos.ReadOnly = false;
            txtCiudad.ReadOnly = false;
            txtPais.ReadOnly = false;

        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
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

            bool legal = false;
            string ci = txtCI.Text;
            string calleC = txtCalle.Text;
            string nroPuertaC = txtNroPuerta.Text;
            string codPostalC = txtCodPos.Text;
            string ciudadC = txtCiudad.Text;
            string paisC = txtCiudad.Text;

            string nombreD = txtNomDest.Text;
            string calleD = txtCalleD.Text;
            string nroPuertaD = txtNroPuertaD.Text;
            string codPostalD = txtCodPosD.Text;
            string ciudadD = txtCiudadD.Text;
            string paisD = txtPaisD.Text;

            //Validar que los campos no sea vacios
            if (admin != "" && campoFecha != "" && campoPeso != "" && peso != 0 && ci != "" && calleC != "" && nroPuertaC != ""
                && codPostalC != "" && ciudadC != "" && paisC != "" && calleD != "" && nroPuertaD != ""
                && codPostalD != "" && ciudadD != "" && paisD != "")
            {
                if (nroOfiOrig != nroOfiFinal)
                {
                    lblOfiFinal.Text = "";
                    if (Herramientas.FechaValida(fecha))
                    {
                        lblFecha.Text = "";
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
                                                if (Herramientas.esNumero(nroPuertaC))
                                                {
                                                    lblNroPuertaC.Text = "";
                                                    if (Herramientas.esNumero(nroPuertaD))
                                                    {
                                                        lblNroPuertaD.Text = "";
                                                        if (resultFecha)
                                                        {
                                                            if (rbLegal.Checked)
                                                            {
                                                                legal = true;
                                                            }
                                                            decimal precio = Controladora.Instancia.CalcularEnvioDoc(legal, peso);
                                                            lblPrecio.Text = precio.ToString();

                                                            Usuario adm = Controladora.Instancia.BuscarAdminXId(int.Parse(admin));
                                                            Cliente cli = Controladora.Instancia.BuscarClienteXCi(ci);
                                                            Oficina ofiOrig = Controladora.Instancia.BuscarOficina(int.Parse(nroOfiOrig));
                                                            Oficina ofiFinal = Controladora.Instancia.BuscarOficina(int.Parse(nroOfiFinal));

                                                            Direccion dirD = new Direccion(calleD, int.Parse(nroPuertaD), codPostalD, ciudadD, paisD);
                                                            Destinatario dest = new Destinatario(nombreD, dirD);
                                                            Direccion dirO = new Direccion(calleC, int.Parse(nroPuertaC), codPostalC, ciudadC, paisC);

                                                            if (Controladora.Instancia.AltaDocumento(legal, peso, precio, fecha, cli, adm, dest, dirO,
                                                                ofiOrig, ofiFinal))
                                                            {
                                                                lblEnvioOk.Text = "Alta de documento exitoso";
                                                                this.LimpiarCampos();
                                                            }
                                                            else
                                                            {
                                                                lblEnvioOk.Text = "Compruebe los valores por favor";
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
                                                    lblNroPuertaC.Text = "El nro de puerta ingresado no es valido";
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
                        lblFecha.Text = "La fecha debe ser menor al dia actual";
                    }
                }
                else
                {
                    lblOfiFinal.Text = "La oficina de retiro debe de ser distinta a la de entrega";
                }
            }
        }


        protected void btnCargaDatos_Click(object sender, EventArgs e)
        {
            txtFecha.Text = "20/06/2015";
            txtAdmin.Text = "2";
            txtPeso.Text = "20";
            txtCI.Text = "1111";
            txtNomDest.Text = "Edinson Cavani";
            txtCalleD.Text = "18 de Julio";
            txtNroPuertaD.Text = "5555";
            txtCodPosD.Text = "11000";
            txtCiudadD.Text = "Montevideo";
            txtPaisD.Text = "Uruguay";
        }

        public void LimpiarCampos()
        {
            txtFecha.Text = "";
            txtAdmin.Text = "";
            txtPeso.Text = "";
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
            string campoPeso = txtPeso.Text;
            decimal pesoResult;
            bool resultPeso = Decimal.TryParse(this.txtPeso.Text, out pesoResult);
            decimal peso = pesoResult;

            bool legal = false;

            if (rbLegal.Checked)
            {
                legal = true;
            }

            decimal precio = Controladora.Instancia.CalcularEnvioDoc(legal, peso);
            lblPrecio.Text = precio.ToString();
        }

        protected void dropDownOficinaActual_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void rbLegal_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void rbPersonal_CheckedChanged(object sender, EventArgs e)
        {

        }

     
       
    }
}