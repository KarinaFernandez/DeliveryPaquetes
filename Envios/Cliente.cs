using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Utilidades;


namespace Dominio
{
    public class Cliente : Usuario
    { 
        #region variables
        private int idCli = 0;
        private static int ultIdCli = 0;
        private string nombreCli = "";
        private string apellido = "";
        private string ci = "";
        private int tel = 0;
        private Direccion dirCliente;
        #endregion

        #region properties
        public int IdCli
        {
            get
            {
                return this.idCli;
            }
            set
            {
                this.idCli = value;
            }
        }

        public static int UltIdCli
        {
            get
            {
                return Cliente.ultIdCli;
            }
            set
            {
                Cliente.ultIdCli = value;
            }
        }

        public string NombreCli
        {
            get
            {
                return this.nombreCli;
            }
            set
            {
                this.nombreCli = value;
            }
        }

        public string Apellido
        {
            get
            {
                return this.apellido;
            }
            set
            {
                this.apellido = value;
            }

        }

        public string Ci
        {
            get
            {
                return this.ci;
            }
            set
            {
                this.ci = value;
            }
        }

        public int Tel
        {
            get
            {
                return this.tel;
            }
            set
            {
                this.tel = value;
            }
        }

        public Direccion DirCliente
        {
            get
            {
                return this.dirCliente;
            }
            set
            {
                this.dirCliente = value;
            }
        }


        #endregion

        #region constructor
        //Constructor
        public Cliente(string pNom, string pApellido, string pCi, int pTel, Direccion pDir,
            string pUsuario, string pPassword)
            : base(pUsuario, pPassword)
        {
            int id = Cliente.UltIdCli + 1;
            Cliente.UltIdCli = id;
            this.idCli = id;

            this.nombreCli = pNom;
            this.apellido = pApellido;
            this.ci = pCi;
            this.tel = pTel;
            this.dirCliente = pDir;
            base.NombreUsuario = pUsuario;
            base.Password = pPassword;
        }

        #endregion

        #region validaciones

        //Si la ci no es nula y no tiene letra, es ci valida
        public static bool CiValida(string pCi)
        {
            bool retorno = false;

            if (pCi != "" && Herramientas.esNumero(pCi))
            {
                retorno = true;
            }
            return retorno;
        }


        //Validar que la ci ya no este ingresada
        public static bool EncontreCi(string pCi)
        {
            Controladora sistema = Controladora.Instancia;
            bool encontre = false;
            int i = 0;

            
            //Mientras que sea menor al largo de la lista y no encuentre coincidencia
            while (i < sistema.ListaUsuario.Count && !encontre)
            {
                
                //Tengo que convertir lo que me viene en la lista al tipo cliente para poder obtener la ci
                if (sistema.ListaUsuario[i] is Cliente)
                {
                    Cliente clienteAux = sistema.ListaUsuario[i] as Cliente;
                    if (clienteAux.Ci == pCi)
                    {
                        encontre = true;
                    }
                }
               
                i++;
            }
            return encontre;
        }
             
        #endregion

    }
}
