using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dominio
{
    //Hereda de Envio
    public class Paquete : Envio
    {
        #region parametros
        private string descripcion = "";
        private decimal valorContenido = 0;
        private decimal ancho = 0; 
        private decimal largo = 0; 
        private decimal alto = 0; 
        private bool seguro = false;
        private decimal peso = 0; //kg
        private decimal precioXGramo = 2;
        #endregion

        #region properties
        public string Descripcion
        {
            get
            {
                return this.descripcion;
            }
            set
            {
                this.descripcion = value;
            }
        }

        public decimal ValorContenido
        {
            get
            {
                return this.valorContenido;
            }
            set
            {
                this.valorContenido = value;
            }
        }

        public decimal Ancho
        {
            get
            {
                return this.ancho;
            }
            set
            {
                this.ancho = value;
            }
        }

        public decimal Largo
        {
            get
            {
                return this.largo;
            }
            set
            {
                this.largo = value;
            }
        }

        public decimal Alto
        {
            get
            {
                return this.alto;
            }
            set
            {
                this.alto = value;
            }
        }

        public bool Seguro
        {
            get
            {
                return this.seguro;
            }
            set
            {
                this.seguro = value;
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

        public decimal PrecioXGramo
        {
            get
            {
                return this.precioXGramo;
            }
            set
            {
                this.precioXGramo = value;
            }
        }
        #endregion

        #region constructor
        //Constructor cuando se esta registrando el envio (aun no sabe la firma, ni fechaRecepcion, ni nombreReceptor)
        //Tampoco le paso el status, porque status cuando inicializa = "En origen"
        public Paquete(decimal pAlto, decimal pAncho, decimal pLargo, decimal pPeso, decimal pValorCont, bool pSeguro,
            string pDescripcion,
            decimal pPrecio, DateTime pFechaEnvio, Cliente pCliente, Usuario pAdmin, Destinatario pDest, Direccion pDirOrigen,
            Oficina pNroOfiOrig, Oficina pNroOfiFinal)
            : base(pPrecio, pFechaEnvio, pCliente, pAdmin, pDest, pDirOrigen, pNroOfiOrig, pNroOfiFinal)
        {
            this.alto = pAlto;
            this.ancho = pAncho;
            this.largo = pLargo;
            this.peso = pPeso;
            this.valorContenido = pValorCont;
            this.seguro = pSeguro;
            this.descripcion = pDescripcion;

            base.Precio = pPrecio;
            base.FechaEnvio = pFechaEnvio;
            base.Cliente = pCliente;
            base.Admin = pAdmin;
            base.Destinatario = pDest;
            base.Direccion = pDirOrigen;
            base.NroOfiOrig = pNroOfiOrig;
            base.NroOfiFinal = pNroOfiFinal;
        }

        public Paquete(decimal pAlto, decimal pAncho, decimal pLargo, decimal pPeso, decimal pValorCont, bool pSeguro)
        {
            this.ancho = pAncho;
            this.largo = pLargo;
            this.alto = pAlto;
            this.peso = pPeso;
            this.valorContenido = pValorCont;
            this.seguro = pSeguro;
        }
        #endregion


        //Costo base por g/1000 * peso en Kg o el peso volumétrico (el que sea mayor)
        public override decimal CalcularPrecio()
        {
            decimal costo = 0;            
            decimal pesoVol = (this.alto * this.ancho * this.largo) / 6000;
            if (this.Peso >= pesoVol)
            {
                costo = (this.precioXGramo * 1000) * this.Peso;
            }
            else
            {
                costo = (this.precioXGramo * 1000) * pesoVol;
            }
            //Si contrato seguro es + el 1% del valor declarado 
            if (seguro)
            {
                decimal costoSeg = (valorContenido * 1) / 100;
                costo = costo + costoSeg;
            }
            return costo;
        }
    }
}