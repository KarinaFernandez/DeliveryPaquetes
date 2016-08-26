using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilidades
{
    public class Herramientas
    {
        
        public static bool esNumero(string pCadena)
        {
            bool retorno = false;
            double resultado = 0;

            retorno = double.TryParse(pCadena, out resultado);
            return retorno;
        }

        public static bool esDecimal(string pCadena) {
            bool retorno = false;
            decimal resultado = 0;

            retorno = decimal.TryParse(pCadena, out resultado);
            return retorno;
        }

        public static bool esFecha(string pFecha)
        {
            bool retorno = false;
            DateTime resultado;

            retorno = DateTime.TryParse(pFecha, out resultado);
            return retorno;
        }

        public static bool FechaValida(DateTime pFecha) {
            bool retorno = false;
            DateTime fechaActual = DateTime.Today;
            if(pFecha.CompareTo(fechaActual) <= 0){
                retorno = true;
            }
            return retorno;
        }
    }
}