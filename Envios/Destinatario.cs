using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Utilidades;
using Dominio;

namespace Dominio
{
    public class Destinatario
    {
        #region variables
        private string nombreDest = "";
        private Direccion dirDest;
        #endregion

        #region properties
        public string NombreDest
        {
            get
            {
                return this.nombreDest;
            }
            set
            {
                this.nombreDest = value;
            }
        }

        public Direccion DirDest
        {
            get
            {
                return this.dirDest;
            }
            set
            {
                this.dirDest = value;
            }
        }

        #endregion

        #region constructor
        public Destinatario(string pNombreDest, Direccion pDirDest)
        {
            this.nombreDest = pNombreDest;
            this.dirDest = pDirDest;
        }
        #endregion

        public static bool validarDest(Destinatario pDest) {
            bool valido = false;
            string nombre = pDest.nombreDest;
            Direccion dir = pDest.dirDest;

            if (nombre != "" && !(Herramientas.esNumero(nombre)) && Dominio.Direccion.validarDireccion(dir))
            {
                valido = true;
            }
            return valido;
        }

    }
}