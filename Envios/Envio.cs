using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dominio
{
    public abstract class Envio
    {
        #region variables
        private int nroEnvio; //atriburto de instancia  //guarda el ultimo
        private static int ultNroEnvio; //atributo de clase  le voy a tener que pasar Envio.Metodo //nroEnvio + 1
        private string nombreReceptor = "";
        private string firmaReceptor = "";
        private decimal precio = 0;
        private DateTime fechaEnvio;
        private Usuario admin;
        private Cliente cliente;
        private Destinatario destinatiario;
        private Direccion dirOrigen;
        private EstadoEnvios estado;
        private Oficina nroOfiOrig;
        private Oficina nroOfiFinal;        
        private Recorrido recorrido;
        private List<Recorrido> listaRecorrido;
        #endregion

        #region properties
        public int NroEnvio
        {
            get
            {
                return this.nroEnvio;
            }
            set
            {
                this.nroEnvio = value;
            }
        }

        //Le paso Envio.ultimoNroEnvio para distingir que es un atributo static
        public static int UltimoNroEnvio
        {
            get
            {
                return Envio.ultNroEnvio;
            }
            set
            {
                Envio.ultNroEnvio = value;
            }
        }

        public string NombreReceptor
        {
            get
            {
                return this.nombreReceptor;
            }
            set
            {
                this.nombreReceptor = value;
            }
        }

        public string FirmaReceptor
        {
            get
            {
                return this.firmaReceptor;
            }
            set
            {
                this.firmaReceptor = value;
            }
        }

        public decimal Precio
        {
            get
            {
                return this.precio;
            }
            set
            {
                this.precio = value;
            }
        }

        public DateTime FechaEnvio
        {
            get
            {
                return this.fechaEnvio;
            }
            set
            {
                this.fechaEnvio = value;
            }
        }
        
        public DateTime FechaSalida
        {
            get
            {
                return Recorrido.FechaSalida;
            }
            
        }

        public EstadoEnvios Estado
        {
            get { return this.estado; }
            set { this.estado = value; }
        }

        public Cliente Cliente
        {
            get
            {
                return this.cliente;
            }
            set
            {
                this.cliente = value;
            }
        }

        public Usuario Admin
        {
            get
            {
                return this.admin;
            }
            set
            {
                this.admin = value;
            }
        }

        public Destinatario Destinatario
        {
            get
            {
                return this.destinatiario;
            }
            set
            {
                this.destinatiario = value;
            }
        }

        public Direccion Direccion
        {
            get
            {
                return this.dirOrigen;
            }
            set
            {
                this.dirOrigen = value;
            }
        }

        public Oficina NroOfiOrig
        {
            get { return this.nroOfiOrig; }
            set { this.nroOfiOrig = value; }
        }

        public int OficinaAct
        {
            get
            {
                return Recorrido.Oficina.NroOficina;
            }

        }
        
        public Oficina NroOfiFinal
        {
            get { return this.nroOfiFinal; }
            set { this.nroOfiFinal = value; }
        }

        public Recorrido Recorrido
        {
            get { return this.recorrido; }
            set { this.recorrido = value; }
        }

        public List<Recorrido> ListaRecorrido
        {
            get { return this.listaRecorrido; }
            set { this.listaRecorrido = value; }
        }
        #endregion

        #region constructores

        public Envio()
        {
        }

        //Constructor cuando se esta registrando el envio (aun no sabe la firma, ni fechaRecepcion, ni nombreReceptor)
        //Tampoco le paso el status, porque status cuando inicializa = "En origen"
        public Envio(decimal pPrecio, DateTime pFechaEnvio, Cliente pCliente, Usuario pAdmin, Destinatario pDestinatario,
            Direccion pDirOrigen, Oficina pNroOfiOrig, Oficina pNroOfiFinal)
        {
            //al ultimo numero que traigo (Envio.ultimoNroEnvio) le sumo uno y lo cargo en nroEnvio
            this.nroEnvio = Envio.ultNroEnvio + 1;
            Envio.ultNroEnvio = nroEnvio;
            this.precio = pPrecio;
            this.fechaEnvio = pFechaEnvio;            
            this.cliente = pCliente;
            this.admin = pAdmin;
            this.destinatiario = pDestinatario;
            this.nombreReceptor = pDestinatario.NombreDest;
            this.dirOrigen = pDirOrigen;
            this.estado = EstadoEnvios.En_origen;            
            this.nroOfiOrig = pNroOfiOrig;
            this.nroOfiFinal = pNroOfiFinal;
            this.listaRecorrido = new List<Recorrido>();  //Cada envio genera una nueva lista con sus recorridos
            this.recorrido = new Recorrido(pNroOfiOrig, pFechaEnvio);
            Recorrido recAux = new Recorrido(pNroOfiOrig, pFechaEnvio);
            this.listaRecorrido.Add(recAux);


        }

        #endregion

        public enum EstadoEnvios
        {
            En_origen,
            En_transito,
            Para_entregar,
            Entregado
        }

        public abstract decimal CalcularPrecio();

        #region validaciones
        public bool OficinaYaIngresada(Oficina pOfi)
        {
            bool encontre = false;

            int i = 0;
            while (i < this.ListaRecorrido.Count && !encontre)
            {
                Recorrido aux = this.ListaRecorrido[i];

                if (aux.NroOficina == pOfi.NroOficina)
                {
                    encontre = true;
                }
                i++;
            }
            return encontre;
        }

        #endregion
    }
}