using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dominio
{
    public class OrdenadoPorFechaEntregado: IComparer<Envio>
    {

        public int Compare(Envio uno, Envio otro)
        {
            int retorno = 0;

            if (uno != null && otro != null)
            {
                retorno = otro.FechaSalida.CompareTo(uno.FechaSalida);
            }

            return retorno;
        }
    }
}