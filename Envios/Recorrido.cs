using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dominio
{
    public class Recorrido
    {
        private Envio.EstadoEnvios status;
        private DateTime fechaRecepcion; 
        private DateTime fechaSalida;        
        private Oficina oficina;

        #region properties
        public Envio.EstadoEnvios Status
        {
            get
            {
                return this.status;
            }
            set
            {
                this.status = value;
            }
        }

        public DateTime FechaRecepcion
        {
            get
            {
                return this.fechaRecepcion;
            }
            set
            {
                this.fechaRecepcion = value;
            }
        }

        public DateTime FechaSalida
        {
            get
            {
                return this.fechaSalida;
            }
            set
            {
                this.fechaSalida = value;
            }
        }

        public Oficina Oficina
        {
            get
            {
                return this.oficina;
            }
            set
            {
                this.oficina = value;
            }
        }

        public int NroOficina
        {
            get {
                return Oficina.NroOficina;
            }
        }

        #endregion

        #region constructores
        public Recorrido()
        {
        }

        //Estado, oficina actual y solo la fecha de salida (es el caso cuando recien creo un envio y solo tengo la fecha de salida)
        public Recorrido(Oficina pOfi, DateTime pFechaSal) // Cambiar 
        {
            this.status = Envio.EstadoEnvios.En_origen;
            this.oficina = pOfi;
            this.fechaSalida = pFechaSal;
            this.fechaRecepcion = pFechaSal;
        }

        //Estado, oficina actual, fecha de recepcion y salida de esa oficina (cuando ya tengo creado un recorrido)
        public Recorrido(Envio.EstadoEnvios pStatus, Oficina pOfi, DateTime pFechaRec, DateTime pFechaSal)
        {
            this.status = pStatus;
            this.oficina = pOfi;
            this.fechaRecepcion = pFechaRec;
            this.fechaSalida = pFechaSal;            
        }

        

        #endregion

        
    }
}