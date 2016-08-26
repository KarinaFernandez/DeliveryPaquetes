using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Utilidades;

namespace Dominio
{
    //Hereda de Envio
    public class Documento : Envio
    {
        #region variables
        private bool esLegal = false;
        private static decimal precioXGramo = 1;
        private decimal peso; //Gr

        #endregion

        #region properties
        public bool EsLegal
        {
            get
            {
                return this.esLegal;
            }
            set
            {
                this.esLegal = value;
            }
        }

        public static decimal PrecioXGramo
        {
            get
            {
                return Documento.PrecioXGramo;
            }
            set
            {
                Documento.PrecioXGramo = value;
            }
        }

        public decimal Peso
        {
            get
            {
                return this.peso;
            }
            set
            {
                this.peso = value;
            }
        }

        #endregion

        #region constructor
        //Constructor cuando se esta registrando el envio (aun no sabe la firma, ni fechaRecepcion, ni nombreReceptor)
        //Tampoco le paso el status, porque status cuando inicializa = "En origen"
        public Documento(bool pEsLegal, decimal pPeso, decimal pPrecio,
            DateTime pFechaEnvio, Cliente pCliente, Usuario pAdmin, 
            Destinatario pDestinatario, Direccion pDirOrigen, Oficina pNroOfiOrig, Oficina pNroOfiFinal)
            : base(pPrecio, pFechaEnvio, pCliente, pAdmin, pDestinatario, pDirOrigen, pNroOfiOrig, pNroOfiFinal)
        {
            this.esLegal = pEsLegal;
            this.peso = pPeso;
            base.Precio = pPrecio;
            base.FechaEnvio = pFechaEnvio;            
            base.Cliente = pCliente;
            base.Admin = pAdmin;
            base.Destinatario = pDestinatario;
            base.Direccion = pDirOrigen;
            base.NroOfiOrig = pNroOfiOrig;
            base.NroOfiFinal = pNroOfiFinal;
            
        }

        public Documento(bool pEsLegal, decimal pPeso)
        {
            this.esLegal = pEsLegal;
            this.peso = pPeso;
           
        }
        #endregion

        //Calcular precio 
        public override decimal CalcularPrecio()
        {
            decimal costo = 0;
            costo = precioXGramo * peso; //NO ESTOY CONTROLANDO QUE PESO SEA DECIMAL
            if (esLegal)
            {
                decimal porcent = (costo * 5) / 100;
                costo = costo + porcent;
            }
            return costo;
        }
       
    }
}