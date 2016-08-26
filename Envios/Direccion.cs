using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Utilidades;

namespace Dominio
{
    public class Direccion
    {
        #region variables
        private string calle = "";
        private int numPuerta = 0;
        private string codPostal = "";
        private string ciudad = "";
        private string pais = "";
        #endregion

        #region properties
        public string Calle
        {
            get
            {
                return this.calle;
            }
            set
            {
                this.calle = value;
            }
        }

        public int NumPuerta
        {
            get
            {
                return this.numPuerta;
            }
            set
            {
                this.numPuerta = value;
            }
        }

        public string CodPostal
        {
            get
            {
                return this.codPostal;
            }
            set
            {
                this.codPostal = value;
            }
        }

        public string Ciudad
        {
            get
            {
                return this.ciudad;
            }
            set
            {
                this.ciudad = value;
            }
        }

        public string Pais
        {
            get
            {
                return this.pais;
            }
            set
            {
                this.pais = value;
            }
        }
        #endregion

        #region constructor
        public Direccion(string pCalle, int pNumPuerta, string pCodPostal, string pciudad, string pPais)
        {
            this.calle = pCalle;
            this.numPuerta = pNumPuerta;
            this.codPostal = pCodPostal;
            this.ciudad = pciudad;
            this.pais = pPais;
        }
        #endregion

        #region validaciones
        //Validar que la direccion no tengo campos vacios
        public static bool validarDireccion(string pCalle, int pNumPuerta, string pCodPostal, string pciudad, string pPais)
        {
            bool valido = false;
            bool calleEsNum = Herramientas.esNumero(pCalle);
            bool ciudadEsNum = Herramientas.esNumero(pciudad);
            bool paisEsNum = Herramientas.esNumero(pPais);
            if (pCalle != "" && !calleEsNum  && pNumPuerta != 0 && Herramientas.esNumero(pCodPostal) &&pCodPostal != "" && pciudad != "" 
                && !ciudadEsNum && pPais != "" && !paisEsNum)
            {
                valido = true;
            }
            return valido;
        }

        public static bool validarDireccion(Direccion pDir)
        {
            bool valido = false;
            string calle = pDir.calle;
            int nroPuerta = pDir.numPuerta;
            string codPostal = pDir.codPostal;
            string ciudad = pDir.ciudad;
            string pais = pDir.pais;

            if (calle != "" && !(Herramientas.esNumero(calle)) && nroPuerta != 0 && codPostal != "" && ciudad != "" && !(Herramientas.esNumero(ciudad))
                 && pais != "" && !(Herramientas.esNumero(pais)))
            {
                valido = true;
            }
            return valido;
        }
        #endregion
    }
}