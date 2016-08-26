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
    public partial class ModificarStatus : System.Web.UI.Page
    {
        List<Envio> listEnv = new List<Envio>();

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


            }
        }


        protected void btnModificarEstado_Click(object sender, EventArgs e)
        {
            string campoNroEnvio = txtNroEnvio.Text;
            int nroResult;
            bool resultNro = int.TryParse(this.txtNroEnvio.Text, out nroResult);
            int nroEnvio = nroResult;

            string campoFechaRec = txtFechaRec.Text;
            DateTime fechaRecResult;
            bool resultFechaRec = DateTime.TryParse(this.txtFechaRec.Text, out fechaRecResult);
            DateTime fechaRec = fechaRecResult;

            string campoFechaSal = txtFechaSal.Text;
            DateTime fechaSalResult;
            bool resultFechaSal = DateTime.TryParse(this.txtFechaSal.Text, out fechaSalResult);
            DateTime fechaSal = fechaSalResult;

            string adm = txtIdAdm.Text;
            int admResult;
            bool resultAdm = int.TryParse(this.txtIdAdm.Text, out admResult);
            int idAdm = admResult;

            bool existeEnvio = Controladora.Instancia.ExisteEnvio(nroEnvio);
            bool existeAdm = Controladora.Instancia.ExisteAdmin(idAdm);
            string nroOfiActual = this.dropDownOficinaActual.SelectedValue;

            if (existeAdm)
            {
                lblIdAdm.Text = "";
                //Si las fechas son validas
                if (resultFechaRec && Herramientas.FechaValida(fechaRec))
                {
                    lblFechaRec.Text = "";

                    if (resultFechaSal && Herramientas.FechaValida(fechaSal))
                    {
                        lblFechaSal.Text = "";

                        //Si ingreso un numero y existe el envio
                        if (resultNro && existeEnvio)
                        {
                            DesbloquearValores();
                            lblMensaje.Text = "";
                            lblFechaRec.Text = "";
                            Envio env = Controladora.Instancia.BuscarEnvio(nroEnvio);
                            Oficina ofiActual = Controladora.Instancia.BuscarOficina(int.Parse(nroOfiActual));

                            //Creo una lista temporal con los recorridos de ese envio
                            List<Recorrido> listaTemporal = Controladora.Instancia.BuscarEnvio(nroEnvio).ListaRecorrido;
                            GridViewRastreoEnv.DataSource = listaTemporal;
                            GridViewRastreoEnv.DataBind();                            


                            //Si la oficina actual es igual a la de origen, no permitir
                            if (ofiActual.NroOficina == env.NroOfiOrig.NroOficina && env.Recorrido.Status != Envio.EstadoEnvios.Entregado &&
                                env.OficinaYaIngresada(ofiActual))
                            {
                                lblOficina.Text = "Debe seleccionar una oficina distinta a la de origen";
                            }
                            //Si la oficina actual no es la de origen ni la final, estado "En transito"                             
                            else if (ofiActual.NroOficina != env.NroOfiFinal.NroOficina && env.Recorrido.Status != Envio.EstadoEnvios.Entregado && !env.OficinaYaIngresada(ofiActual))
                            {
                                
                                lblMensaje.Text = "";
                                lblOficina.Text = "";

                                Controladora.Instancia.ModificarEstado(nroEnvio, ofiActual, fechaRec, fechaSal);

                            }
                            //Si la oficina actual es igual a la de origen, estado "Para entregar"
                            else if (ofiActual.NroOficina == env.NroOfiFinal.NroOficina && env.Recorrido.Status != Envio.EstadoEnvios.Entregado 
                                 && !env.OficinaYaIngresada(ofiActual))
                            {
                                
                                lblMensaje.Text = "";
                                lblOficina.Text = "";

                                Controladora.Instancia.ModificarEstado(nroEnvio, ofiActual, fechaRec, fechaSal);

                                cbEntregar.Enabled = true;
                                txtReceptor.Enabled = true;
                                FileUploadFirma.Enabled = true;

                            }
                            //Si no es ninguno de los casos, estado "Entregado"
                            if (cbEntregar.Checked && env.Recorrido.Status == Envio.EstadoEnvios.Para_entregar)
                            {
                                lblMensaje.Text = "";
                                string nombreRecep = txtReceptor.Text;
                                string ruta = "";
                                string fotoFirma = "";

                                if (txtReceptor.Text != "")
                                {
                                    lblReceptor.Text = "";
                                    if (this.FileUploadFirma.HasFile)
                                    {
                                        lblFirma.Text = "";
                                        string archivo = this.FileUploadFirma.FileName;
                                        ruta = HttpRuntime.AppDomainAppPath + "/firma";
                                        fotoFirma = nroEnvio + archivo.Substring(archivo.LastIndexOf("."));

                                        if (Controladora.Instancia.EnvioEntregado(nroEnvio, ofiActual, fechaRec, fechaSal, nombreRecep, fotoFirma))
                                        {
                                            this.FileUploadFirma.SaveAs(ruta + fotoFirma);
                                        }
                                        else
                                        {
                                            if (env.NombreReceptor != nombreRecep)
                                            {
                                                lblReceptor.Text = "El receptor no es valido";
                                            }
                                        }
                                    }
                                    else
                                    {
                                        lblFirma.Text = "Debe seleccionar el archivo con la firma del receptor";
                                    }
                                }
                                else
                                {
                                    lblReceptor.Text = "Debe ingresar el nombre del receptor";
                                }
                            }
                           

                            if (!cbEntregar.Checked && env.Recorrido.Status == Envio.EstadoEnvios.Para_entregar)
                            {
                                lblMensaje.Text = "Seleccione 'Entregar' para marcar un envio como entregado"; //Marcar checkbox
                            }

                            if (env.Recorrido.Status == Envio.EstadoEnvios.Entregado)
                            {
                                BloquearValores();
                                lblMensaje.Text = "No puede modificar un envio ya entregado, seleccione otro envio";
                                lblFirma.Text = "";
                            }
                        }
                        else
                        {
                            lblMensaje.Text = "Numero de envio no valido";
                        }
                    }
                    else
                    {
                        lblFechaSal.Text = "Fecha no valida";
                    }
                }
                else
                {
                    lblFechaRec.Text = "Fecha no valida";
                }
            }
            else
            {
                lblIdAdm.Text = "No se encontro ese id de administrador";
            }

        }



        protected void dropDownOficinaActual_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void cbEntregar_CheckedChanged(object sender, EventArgs e)
        {

        }


        public void BloquearValores()
        {
            txtFechaRec.Enabled = false;
            txtFechaSal.Enabled = false;
            dropDownOficinaActual.Enabled = false;
            txtReceptor.Enabled = false;
            FileUploadFirma.Enabled = false;
            cbEntregar.Enabled = false;
        }
        public void DesbloquearValores()
        {
            txtFechaRec.Enabled = true;
            txtFechaSal.Enabled = true;
            dropDownOficinaActual.Enabled = true;
            txtReceptor.Enabled = true;
        }

        protected void btnVerEstado_Click(object sender, EventArgs e)
        {

            string nroEnvio = txtNroEnvio.Text;
            
            int numeroEnvio;
            bool parse = int.TryParse(txtNroEnvio.Text, out numeroEnvio);
            List<Recorrido> listaTemporal = Controladora.Instancia.BuscarEnvio(numeroEnvio).ListaRecorrido;
            GridViewRastreoEnv.DataSource = listaTemporal;
            GridViewRastreoEnv.DataBind(); 
        }

        protected void btnCargaDatos_Click(object sender, EventArgs e)
        {
            txtIdAdm.Text = "1";
            txtNroEnvio.Text = "5";
            txtFechaRec.Text = "24/06/2015";
            txtFechaSal.Text = "25/06/2015";            
        }
    }
}
