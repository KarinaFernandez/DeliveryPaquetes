using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dominio
{
    public class Oficina
    {
        #region variables
        private int nroOficina = 0;
        private static int ultOficina = 0;
        private string desc = "";
        private Direccion dirOficina;
        #endregion

        #region properties
        public int NroOficina
        {
            get
            {
                return this.nroOficina;
            }
            set
            {
                this.nroOficina = value;
            }
        }

        public static int UltOficina
        {
            get
            {
                return Oficina.ultOficina;
            }
            set
            {
                Oficina.ultOficina = value;
            }
        }

        public Direccion DirOficina
        {
            get
            {
                return this.dirOficina;
            }
            set
            {
                this.dirOficina = value;
            }
        }

        public string Desc
        {
            get { 
                return this.desc; 
            }
            set {
                this.desc = value; 
            }
        }


        #endregion

        #region constructor
        public Oficina(Direccion pDireccion, string pDesc)
        {
            int oficina = Oficina.ultOficina + 1;
            Oficina.ultOficina = oficina;
            this.nroOficina = oficina;

            this.dirOficina = pDireccion;
            this.desc = pDesc;
        }
        #endregion

        #region validar que dir de oficina no se encuentre
        //Validar que la direccion ya no se encuentre en la lista de oficinas
        public static bool EncontreDirOficina(string pCalle, int pNroPuerta, string pCodPost, string pCiudad, string pPais)
        {
            bool encontre = false;
            if (pCalle != "" && pNroPuerta != 0 && pCodPost != "" && pCiudad != "" && pPais != "")
            {
                int i = 0;
                Controladora sistema = Controladora.Instancia;
               // Direccion dirIngresada = new Direccion(pCalle, pNroPuerta, pCodPost, pCiudad, pPais);

                //Recorro la lista de oficinas para saber si no existe ya la dir ingresada
                while (i < sistema.ListaOfi.Count && !encontre)
                {
                    Direccion dirAux = sistema.ListaOfi[i].DirOficina;
                    if (dirAux.Calle == pCalle && dirAux.NumPuerta == pNroPuerta && dirAux.CodPostal == pCodPost && dirAux.Ciudad == pCiudad
                        && dirAux.Pais == pCiudad)
                    {
                        encontre = true;
                    }
                    i++;
                }
            }
            return encontre;
        }

        
         
        #endregion

    }
}