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
    public partial class Listados : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario aux = (Usuario)Session["usuarioLog"];
            if (aux == null || !aux.Admin)
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void btnBuscarEnvios_Click(object sender, EventArgs e)
        {

            string campoCi = txtCI.Text;
            int ciResult;
            bool resultCI = int.TryParse(this.txtCI.Text, out ciResult);
            int ci = ciResult;

            string campoFechaIni = txtFechaIni.Text;
            DateTime fechaIniResult;
            bool resultFechaIni = DateTime.TryParse(this.txtFechaIni.Text, out fechaIniResult);
            DateTime fechaIni = fechaIniResult;

            string campoFechaFin = txtFechaFin.Text;
            DateTime fechaFinResult;
            bool resultFechaFin = DateTime.TryParse(this.txtFechaFin.Text, out fechaFinResult);
            DateTime fechaFin = fechaFinResult;

            string campoPrecio = txtPrecio.Text;
            decimal precioResult;
            bool resultPrecio = decimal.TryParse(this.txtPrecio.Text, out precioResult);
            decimal precio = precioResult;
            List<Envio> listaVacia = new List<Envio>();

            //Envios entregados o por entregar
            if (rbEnviosEntreg.Checked)
            {
                this.LimpiarCampos();
                GridViewRastreoEnv.DataSource = listaVacia;
                GridViewRastreoEnv.DataBind();
                if (resultCI)
                {
                    if (Controladora.Instancia.ExisteCliente(ci))
                    {
                        if (Controladora.Instancia.ListaEnvios().Count != 0)
                        {
                            IComparer<Envio> criterio = new OrdenadoPorFechaEntregado();
                            List<Envio> listaAux = Controladora.Instancia.EnviosDeCli(campoCi);
                            List<Envio> listaParaEntregar = Controladora.Instancia.EnviosYaEntregados(listaAux);
                            if (listaParaEntregar.Count != 0)
                            {
                                listaParaEntregar.Sort(criterio);
                                GridViewRastreoEnv.DataSource = listaParaEntregar;
                                GridViewRastreoEnv.DataBind();
                            }
                            else
                            {
                                lblMensaje.Text = "No se encuentran envios entregados o para enviar";
                            }
                        }
                        else
                        {
                            lblMensaje.Text = "No se encontraron envios para ese cliente";
                        }
                    }
                    else
                    {
                        lblMensaje.Text = "No se encontro el cliente";
                    }
                }
                else
                {
                    lblMensaje.Text = "Ci no valida";
                }
            }

            //Cuanto se facturo con un cliente entre dos fechas 
            else if (rbFacturado.Checked)
            {
                this.LimpiarCampos();
                GridViewRastreoEnv.DataSource = listaVacia;
                GridViewRastreoEnv.DataBind();

                if (campoFechaIni != "" && campoFechaFin != "" && Herramientas.esFecha(campoFechaIni) && Herramientas.esFecha(campoFechaFin)
                    && Herramientas.FechaValida(fechaFin))
                {
                    if (Controladora.Instancia.ListaEnvios().Count != 0)
                    {
                        List<Envio> listaAux = Controladora.Instancia.EnviosDeCli(campoCi);
                        decimal total = Controladora.Instancia.FacturadoEntreFechas(listaAux);
                        lblTotal.Text = total.ToString();
                    }
                    else
                    {
                        lblMensaje.Text = "No se encontraron envios para ese cliente";
                    }
                }
                else
                {
                    lblFechaIni.Text = "Por favor verifique la fecha ingresada";
                }
            }
            //Dado un cliente y un precio, listar todos los envíos de ese cliente cuyo precio supera el monto dado.
            else if (rbEnviosMonto.Checked)
            {
                this.LimpiarCampos();
                GridViewRastreoEnv.DataSource = listaVacia;
                GridViewRastreoEnv.DataBind();

                if (resultCI)
                {
                    if (Controladora.Instancia.ExisteCliente(ci))
                    {
                        if (campoPrecio != "")
                        {
                            if (Controladora.Instancia.ListaEnvios().Count != 0)
                            {
                                List<Envio> listaAux = Controladora.Instancia.EnviosDeCli(campoCi);
                                List<Envio> listaParaEntregar = Controladora.Instancia.EnviosSegunPrecio(listaAux, precio);
                                if (listaParaEntregar.Count != 0)
                                {
                                    GridViewRastreoEnv.DataSource = listaParaEntregar;
                                    GridViewRastreoEnv.DataBind();
                                }
                                else
                                {
                                    lblMensaje.Text = "No se encuentran envios que superen el monto ingresado";
                                }
                            }
                            else
                            {
                                lblMensaje.Text = "No se encontraron envios para ese cliente";
                            }
                        }
                        else
                        {
                            lblPrecio.Text = "Debe ingresar un valor";
                        }
                    }
                    else
                    {
                        lblMensaje.Text = "No se encontro el cliente";
                    }
                }
                else
                {
                    lblMensaje.Text = "Ci no valida";
                }
            }
            //Listar todos los envíos que tienen estado ‘en tránsito’ y más de 5 días de enviados ordenados por
            //fecha de ingreso del envío ascendente y luego por documento del cliente descendente
            else if (rbEnviosTransito.Checked)
            {
                if (Controladora.Instancia.ListaEnvios().Count != 0)
                {
                    List<Envio> listaAux = Controladora.Instancia.ListaEnvios();
                    List<Envio> listaParaEntregar = Controladora.Instancia.EnviosEnTransito(listaAux);
                    IComparer<Envio> criterio = new OrdenarporDosCriterios();

                    if (listaParaEntregar.Count != 0)
                    {
                        listaParaEntregar.Sort(criterio);
                        GridViewRastreoEnv.DataSource = listaParaEntregar;
                        GridViewRastreoEnv.DataBind();
                    }
                    else
                    {
                        lblMensaje.Text = "No se encuentran envios con mas de 5 dias de enviados";
                    }
                }
                else
                {
                    lblMensaje.Text = "No se encontraron envios ingresados";
                }                
            }
        }

        #region Checked
        protected void rbEnviosEntreg_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void rbRastreoEnv_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void rbFacturado_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void rbEnviosSup_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void rbEnviosTransito_CheckedChanged(object sender, EventArgs e)
        {

        }
        #endregion

        public void LimpiarCampos()
        {
            lblFechaFin.Text = "";
            lblFechaIni.Text = "";
            lblMensaje.Text = "";
            lblPrecio.Text = "";
            lblTotal.Text = "";
        }

        protected void btnCargaDatos_Click(object sender, EventArgs e)
        {
            txtCI.Text = "1111";
            txtFechaFin.Text = "25/06/2015";
            txtFechaIni.Text = "15/06/2015";
        }

    }
}