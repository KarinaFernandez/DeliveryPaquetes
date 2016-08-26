using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Utilidades;


namespace Dominio
{
    public class Controladora
    {
        #region variables
        private List<Usuario> listaUsuario = new List<Usuario>();
        private List<Oficina> listaOficinas = new List<Oficina>();
        private List<Envio> listaEnvios = new List<Envio>();
        private static Controladora instancia;
        #endregion

        #region properties
        public List<Usuario> ListaUsuario
        {
            get
            {
                return this.listaUsuario;
            }
            set
            {
                this.listaUsuario = value;
            }
        }

        public List<Oficina> ListaOfi
        {
            get
            {
                return this.listaOficinas;
            }
            set
            {
                this.listaOficinas = value;
            }
        }

        public static Controladora Instancia
        {
            get
            {
                //Me fijo si no existe una instancia sistema, si no existe lo creo (unica)
                if (Controladora.instancia == null)
                {
                    Controladora.instancia = new Controladora();
                }
                return Controladora.instancia;
            }
        }

        private Controladora()
        {
            this.CargaDatosDePrueba();
        }

        public List<Usuario> ListaUsuarios()
        {
            return listaUsuario;
        }

        public List<Oficina> ListaOficinas()
        {
            return listaOficinas;
        }

        public List<Envio> ListaEnvios()
        {
            return listaEnvios;
        }

        private void CargaDatosDePrueba()
        {
            Direccion dir1 = new Direccion("25 de Mayo", 123, "11300", "Montevideo", "Uruguay");
            this.ListaUsuario.Add(new Cliente("Ana", "Juarez", "1111", 27000000, dir1, "AnaJuarez", "usuario1"));

            Direccion dir2 = new Direccion("18 de Julio", 1010, "11800", "Montevideo", "Uruguay");
            this.ListaUsuario.Add(new Cliente("Mario", "Perez", "2222", 27111111, dir2, "MarioPerez", "usuario2"));

            Usuario admin1 = new Usuario("admin1", "admin1", true);
            this.listaUsuario.Add(admin1);

            Usuario admin2 = new Usuario("admin2", "admin2", true);
            this.listaUsuario.Add(admin2);

            Direccion dir3 = new Direccion("25 de Mayo", 0000, "10000", "Montevideo", "Uruguay");
            Oficina ofi1 = new Oficina(dir3, "Sucursal Pocitos");
            this.ListaOfi.Add(ofi1);

            Direccion dir4 = new Direccion("Tierra", 1111, "11111", "Rio Negro", "Uruguay");
            Oficina ofi2 = new Oficina(dir4, "Sucursal Rio Negro");
            this.ListaOfi.Add(ofi2);

            Direccion dir5 = new Direccion("Lejano", 2222, "12222", "Salto", "Uruguay");
            Oficina ofi3 = new Oficina(dir4, "Sucursal Salto");
            this.ListaOfi.Add(ofi3);
        }


        #endregion
        
        #region Logica
        public bool AltaAdmin(string pUsuario, string pPassword)
        {
            bool resultado = false;

            //Busco si el usuario ya no existe
            if (pUsuario != "" && pPassword != "")
            {
                bool usuarioEncontrado = Controladora.BuscarUsuario(pUsuario);
                if (!usuarioEncontrado)
                {
                    Usuario nuevoAdmin = new Usuario(pUsuario, pPassword, true);
                    this.listaUsuario.Add(nuevoAdmin);
                    resultado = true;
                }
            }
            return resultado;
        }

        //Creo el cliente y usuario a la vez, tengo que ver que no exista ci del cliente ni el nombre de usuario
        public bool AltaCliente(string pNombre, string pApellido, string pCi, int pTel, Direccion pDir, string pUsuario, string pPassword)
        {
            bool resultado = false;

            //Busco si es una ci valida (no nula y sea numero) y no este ingresada
            bool ciValida = Cliente.CiValida(pCi);
            bool ciIngresada = Cliente.EncontreCi(pCi);
            //Busco que ya no se haya ingresado es nombre de usuario
            bool usuarioEncontrado = Controladora.BuscarUsuario(pUsuario);

            //Si no hay campos nulos
            if (pNombre != "" && pApellido != "" && pCi != "" && pTel != 0 && pUsuario != "" && pPassword != "")
            {
                //Doy de alta si es un ci valida, no se encuentra ingresada y no se encuentra el nombre del usuario
                if (ciValida && !ciIngresada && !usuarioEncontrado)
                {
                    Cliente nuevoCli = new Cliente(pNombre, pApellido, pCi, pTel, pDir, pUsuario, pPassword);
                    this.listaUsuario.Add(nuevoCli);
                    resultado = true;
                }
            }
            return resultado;
        }

        public bool AltaDocumento(bool pEsLegal, decimal pPeso, decimal pPrecio, DateTime pFechaEnvio, Cliente pCli, Usuario pAdmin,
            Destinatario pDest, Direccion pDirO, Oficina pNroOfiOrig, Oficina pNroOfiFinal)
        {
            bool resultado = false;

            //Busco si existe el cliente, el admin, el destinatario es valido y la dir de origen es valida
            bool cliValido = Cliente.EncontreCi(pCli.Ci);
            bool adminValido = this.ExisteAdmin(pAdmin.Id);
            bool destValido = Destinatario.validarDest(pDest);
            bool dirValida = Direccion.validarDireccion(pDirO);

            //Si no hay campos nulos
            if (pPeso != 0 && cliValido && adminValido && destValido && dirValida)
            {
                Documento nuevoDoc = new Documento(pEsLegal, pPeso, pPrecio, pFechaEnvio, pCli, pAdmin, pDest, pDirO, pNroOfiOrig, pNroOfiFinal);
                this.listaEnvios.Add(nuevoDoc);
                resultado = true;
            }
            return resultado;
        }


        public bool AltaPaquete(string pDesc, decimal pValCont, decimal pAncho, decimal pAlto, decimal pLargo,
            bool pSeguro, decimal pPeso, decimal pPrecio, DateTime pFechaEnvio, Cliente pCli, Usuario pAdmin,
            Destinatario pDest, Direccion pDirO, Oficina pNroOfiOrig, Oficina pNroOfiFinal)
        {
            bool resultado = false;
            bool cliValido = Cliente.EncontreCi(pCli.Ci);
            bool adminValido = this.ExisteAdmin(pAdmin.Id);
            bool destValido = Destinatario.validarDest(pDest);

            if (pDesc != "" && pValCont != 0 && pAncho != 0 && pAlto != 0 && pLargo != 0 && pPeso != 0 && pPrecio != 0 &&
               cliValido && adminValido && destValido)
            {
                Paquete nuevoPaq = new Paquete(pAlto, pAncho, pLargo, pPeso, pValCont, pSeguro, pDesc, pPrecio, pFechaEnvio,
                    pCli, pAdmin, pDest, pDirO, pNroOfiOrig, pNroOfiFinal);
                this.listaEnvios.Add(nuevoPaq);
                resultado = true;
            }

            return resultado;
        }



        public bool AltaOficina(string pCalle, int pNroPuerta, string pCodPost, string pCiudad, string pPais, string pDesc)
        {
            bool resultado = false;
            Direccion dir = new Direccion(pCalle, pNroPuerta, pCodPost, pCiudad, pPais);
            Oficina nuevaOfi = new Oficina(dir, pDesc);

            if (pCalle != "" && pNroPuerta != 0 && pCiudad != "" && pCodPost != "" && pPais != "" && pDesc != "" &&
               (!Oficina.EncontreDirOficina(pCalle, pNroPuerta, pCodPost, pCiudad, pPais)))
            {
                this.ListaOfi.Add(nuevaOfi);
                resultado = true;
            }
            return resultado;
        }


        public void ModificarEstado(int pNroEnvio, Oficina pOfiActual, DateTime pFechaRec, DateTime pFechaSal)
        {
            Envio nuevoEnv = this.BuscarEnvio(pNroEnvio);

            //Si encuentro oficina y envio
            if (nuevoEnv != null && pOfiActual != null)
            {
                //Si la oficina actual no es la de origen ni la final
                if (pOfiActual.NroOficina != nuevoEnv.NroOfiOrig.NroOficina && pOfiActual.NroOficina != nuevoEnv.NroOfiFinal.NroOficina)
                {
                    //Si el estatus no es "entregado" o "para entregar"
                    if (nuevoEnv.Recorrido.Status != Dominio.Envio.EstadoEnvios.Entregado && nuevoEnv.Recorrido.Status != Dominio.Envio.EstadoEnvios.Para_entregar)
                    {
                        nuevoEnv.Estado = Envio.EstadoEnvios.En_transito;
                        nuevoEnv.Recorrido.Status = Envio.EstadoEnvios.En_transito;
                        nuevoEnv.Recorrido.Oficina = pOfiActual;
                        nuevoEnv.Recorrido.FechaRecepcion = pFechaRec;
                        nuevoEnv.Recorrido.FechaSalida = pFechaSal;

                        Recorrido recNuevo = new Recorrido(nuevoEnv.Recorrido.Status, nuevoEnv.Recorrido.Oficina, nuevoEnv.Recorrido.FechaRecepcion,
                            nuevoEnv.Recorrido.FechaSalida);
                        nuevoEnv.ListaRecorrido.Add(recNuevo);
                    }
                }
                //Si la oficina actual es igual al nro de oficina final y ya no esta entregada o en para entregar, cambiar estado a "Para entregar"
                else if (pOfiActual.NroOficina == nuevoEnv.NroOfiFinal.NroOficina && nuevoEnv.Recorrido.Status != Dominio.Envio.EstadoEnvios.Entregado
                    && nuevoEnv.Recorrido.Status != Dominio.Envio.EstadoEnvios.Para_entregar)
                {
                    nuevoEnv.Estado = Envio.EstadoEnvios.Para_entregar;
                    nuevoEnv.Recorrido.Status = Envio.EstadoEnvios.Para_entregar;
                    nuevoEnv.Recorrido.Oficina = pOfiActual;
                    nuevoEnv.Recorrido.FechaRecepcion = pFechaRec;
                    nuevoEnv.Recorrido.FechaSalida = pFechaSal;

                    Recorrido recNuevo = new Recorrido(nuevoEnv.Recorrido.Status, nuevoEnv.Recorrido.Oficina, nuevoEnv.Recorrido.FechaRecepcion,
                        nuevoEnv.Recorrido.FechaSalida);
                    nuevoEnv.ListaRecorrido.Add(recNuevo);
                }
            }
        }

        public bool EnvioEntregado(int pNroEnvio, Oficina pOficina, DateTime pFechaRec, DateTime pFechaSal, string pNombreRec, string pFotoFirma)
        {

            bool valido = true;
            Envio nuevoEnv = this.BuscarEnvio(pNroEnvio);


            if (pFechaRec != null && pFechaSal != null && pNombreRec != "" && pFotoFirma != "" && nuevoEnv != null
                && nuevoEnv.Recorrido.Status == Dominio.Envio.EstadoEnvios.Para_entregar)
            {
                if (nuevoEnv is Documento)
                {
                    Documento docAux = nuevoEnv as Documento;
                    if (docAux.EsLegal)
                    {
                        if (docAux.NombreReceptor != pNombreRec)
                        {
                            valido = false;
                        }
                    }
                }
                if (valido)
                {
                    nuevoEnv.Recorrido.Status = Envio.EstadoEnvios.Entregado;
                    nuevoEnv.Recorrido.FechaRecepcion = pFechaRec;
                    nuevoEnv.Recorrido.FechaSalida = pFechaSal;
                    nuevoEnv.Recorrido.Oficina = pOficina;
                    nuevoEnv.NombreReceptor = pNombreRec;
                    nuevoEnv.FirmaReceptor = pFotoFirma;

                    Recorrido recNuevo = new Recorrido(nuevoEnv.Recorrido.Status, nuevoEnv.Recorrido.Oficina, nuevoEnv.Recorrido.FechaRecepcion, nuevoEnv.Recorrido.FechaSalida);
                    nuevoEnv.ListaRecorrido.Add(recNuevo);
                }
            }
            return valido;
        }
        #endregion

        #region validaciones
        //Validar que el usuario no este ingresado en la lista del cliente
        public static bool BuscarUsuario(string pNombreUsuario)
        {
            Controladora sistema = Controladora.Instancia;
            bool encontre = false;
            int i = 0;

            while (i < sistema.ListaUsuario.Count && !encontre)
            {
                if (sistema.ListaUsuario[i].NombreUsuario == pNombreUsuario)
                {
                    encontre = true;
                }
                i++;
            }
            return encontre;
        }

        public Usuario DevuelveUsuario(string pNombre)
        {
            bool encontre = false;
            Usuario aux = null;
            int i = 0;

            while (i < Controladora.Instancia.ListaUsuario.Count && !encontre)
            {
                if (Controladora.Instancia.ListaUsuario[i].NombreUsuario == pNombre)
                {
                    encontre = true;
                    aux = Controladora.Instancia.ListaUsuario[i];

                }
                i++;
            }
            return aux;
        }

        public bool ExisteUsuario(string pNombre)
        {
            bool encontre = false;
            int i = 0;

            while (i < Controladora.Instancia.ListaUsuario.Count && !encontre)
            {
                if (Controladora.Instancia.ListaUsuario[i].NombreUsuario == pNombre)
                {
                    encontre = true;
                }
                i++;
            }
            return encontre;
        }

        public bool ExisteCliente(int pCi)
        {
            bool encontre = false;

            int i = 0;
            while (i < this.listaUsuario.Count && !encontre)
            {
                Cliente aux = this.listaUsuario[i] as Cliente;
                if (this.listaUsuario[i] is Cliente)
                {
                    if (int.Parse(aux.Ci) == pCi)
                    {
                        encontre = true;
                    }
                }

                i++;
            }
            return encontre;
        }

        public Cliente BuscarCliente(int pId)
        {
            Cliente buscado = null;
            bool encontre = false;

            int i = 0;

            while (i < this.listaUsuario.Count && !encontre)
            {
                Cliente aux = this.listaUsuario[i] as Cliente;
                if (this.listaUsuario[i] is Cliente)
                {

                    if (aux.Id == pId)
                    {
                        buscado = aux;
                        encontre = true;
                    }
                }

                i++;
            }

            return buscado;
        }

        public Cliente BuscarClienteXCi(string pCI)
        {
            Cliente buscado = null;
            bool encontre = false;

            int i = 0;

            while (i < this.listaUsuario.Count && !encontre)
            {
                Cliente aux = this.listaUsuario[i] as Cliente;

                if (this.listaUsuario[i] is Cliente)
                {
                    if (aux.Ci == pCI)
                    {
                        buscado = aux;
                        encontre = true;
                    }
                }
                i++;
            }
            return buscado;
        }

        public Usuario BuscarAdminXId(int pId)
        {
            Usuario buscado = null;
            bool encontre = false;

            int i = 0;
            while (i < this.listaUsuario.Count && !encontre)
            {
                Usuario aux = this.listaUsuario[i];
                if (!(aux is Cliente))      //Si no es cliente
                {
                    if (aux.Id == pId)
                    {
                        buscado = aux;
                        encontre = true;
                    }
                }
                i++;
            }
            return buscado;
        }

        public bool ExisteAdmin(int pId)
        {
            bool encontre = false;

            int i = 0;
            while (i < this.listaUsuario.Count && !encontre)
            {
                Usuario aux = this.listaUsuario[i];
                if (!(aux is Cliente))      //Si no es cliente
                {
                    if (aux.Id == pId)
                    {
                        encontre = true;
                    }
                }
                i++;
            }
            return encontre;
        }

        public Oficina BuscarOficina(int pNroOfi)
        {
            Oficina buscada = null;
            bool encontre = false;
            int i = 0;

            while (i < this.listaOficinas.Count && !encontre)
            {
                Oficina aux = this.listaOficinas[i];

                if (aux.NroOficina == pNroOfi)
                {
                    buscada = aux;
                    encontre = true;
                }

                i++;
            }
            return buscada;
        }

        public Envio BuscarEnvio(int pNroEnvio)
        {
            Envio buscado = null;
            bool encontre = false;
            int i = 0;

            while (i < this.listaEnvios.Count && !encontre)
            {
                Envio aux = this.listaEnvios[i];

                if (aux.NroEnvio == pNroEnvio)
                {
                    buscado = aux;
                    encontre = true;
                }

                i++;
            }

            return buscado;
        }

        public bool ExisteEnvio(int pNroEnvio)
        {
            bool encontre = false;

            int i = 0;
            while (i < this.listaEnvios.Count && !encontre)
            {
                Envio aux = this.listaEnvios[i];

                if (aux.NroEnvio == pNroEnvio)
                {
                    encontre = true;
                }
                i++;
            }
            return encontre;
        }

        //Todos los envios de un cliente
        public List<Envio> EnviosDeCli(string pCi)
        {
            int i = 0;
            List<Envio> listaAux = new List<Envio>();

            while (i < this.listaEnvios.Count)
            {
                Envio aux = this.listaEnvios[i];

                if (aux.Cliente.Ci == pCi)
                {
                    listaAux.Add(aux);
                }
                i++;
            }
            return listaAux;
        }

        /*Solo los envios que esten para entregar o entregados, ordenados por fecha de entrega descendente
        Recibe lista de todos los envios de un cliente*/
        public List<Envio> EnviosYaEntregados(List<Envio> listaEnvios)
        {

            int i = 0;
            List<Envio> listaAux = new List<Envio>();

            while (i < this.listaEnvios.Count)
            {
                Envio aux = this.listaEnvios[i];

                if (aux.Estado == Envio.EstadoEnvios.Para_entregar || aux.Estado == Envio.EstadoEnvios.Entregado)
                {
                    listaAux.Add(aux);
                }
                i++;
            }
            return listaAux;
        }

        /*Segun un cliente y un precio, listar todos los envios de ese cliente que superen el precio dado
        Le paso una lista de todos los envios del cliente*/
        public List<Envio> EnviosSegunPrecio(List<Envio> listaEnvios, decimal pPrecio)
        {
            int i = 0;
            List<Envio> listaAux = new List<Envio>();

            while (i < this.listaEnvios.Count)
            {
                Envio aux = this.listaEnvios[i];

                if (aux.Precio > pPrecio)
                {
                    listaAux.Add(aux);
                }
                i++;
            }
            return listaAux;
        }

        //Mostrar los envios de un cliente entre dos fechas dadas y mostrar el total facturado hasta ese momento
        public List<Envio> EnviosFacturados(List<Envio> listaEnvios, DateTime pFechaIni, DateTime pFechaFin)
        {
            int i = 0;
            List<Envio> listaAux = new List<Envio>();

            while (i < this.listaEnvios.Count)
            {
                Envio aux = this.listaEnvios[i];

                if (aux.FechaEnvio >= pFechaIni && aux.FechaEnvio < pFechaFin)
                {
                    listaAux.Add(aux);
                }
                i++;
            }
            return listaAux;
        }

        public decimal FacturadoEntreFechas(List<Envio> listaEnvios)
        {
            decimal facturado = 0;
            for (int i = 0; i < this.listaEnvios.Count; i++)
            {
                Envio aux = this.listaEnvios[i];
                facturado = facturado + aux.Precio;
            }
            return facturado;
        }

        /*Listar todos los envíos que tienen estado ‘en tránsito’ y más de 5 días de enviados ordenados por
        fecha de ingreso del envío ascendente y luego por documento del cliente descendente*/
        public List<Envio> EnviosEnTransito(List<Envio> listaEnvios)
        {
            int i = 0;
            List<Envio> listaAux = new List<Envio>();

            while (i < this.listaEnvios.Count)
            {
                Envio aux = this.listaEnvios[i];
                DateTime fechaActual = DateTime.Today;
                
                if (aux.Estado == Envio.EstadoEnvios.En_transito && (aux.FechaEnvio.CompareTo(fechaActual) <= 5))
                {
                    listaAux.Add(aux);
                }
                i++;
            }
            return listaAux;
        }

        public decimal CalcularEnvioDoc(bool pLegal, decimal pPeso)
        {
            decimal precio = 0;
            Documento aux = new Documento(pLegal, pPeso);
            precio = aux.CalcularPrecio();

            return precio;
        }

        public decimal CalcularEnvioPaquete(decimal pAlto, decimal pAncho, decimal pLargo, decimal pPeso, decimal pValorCont,
            bool pSeguro)
        {
            decimal precio = 0;
            Paquete aux = new Paquete(pAlto, pAncho, pLargo, pPeso, pValorCont, pSeguro);
            precio = aux.CalcularPrecio();

            return precio;
        }
        #endregion
    }
}