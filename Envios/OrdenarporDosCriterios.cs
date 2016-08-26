using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dominio
{
    public class OrdenarporDosCriterios:IComparer<Envio>
    {
        public int Compare(Envio envio1, Envio envio2) {
            int resultado = 0;
            if(envio1 != null && envio2 != null ){
                resultado = int.Parse(envio2.Cliente.Ci) - int.Parse(envio1.Cliente.Ci);

                if(resultado == 0){
                    resultado = envio1.FechaEnvio.CompareTo(envio2.FechaEnvio);
                }
            }
            return resultado;
        }
    }
}