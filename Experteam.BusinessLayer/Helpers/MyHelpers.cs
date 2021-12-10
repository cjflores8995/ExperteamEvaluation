using Experteam.DataAccessLayer.Model;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Experteam.BusinessLayer.Helpers
{
    public static class MyHelpers
    {
        public static decimal ObtenerTotalGuias(List<Guia> guias)
        {
            decimal totalGuias = 0;

            foreach(var guia in guias)
            {
                totalGuias += guia.Total;
            }

            return Math.Round(totalGuias, 2) ;
        }

        public static decimal ObtenerIva(decimal totalGuias)
        {
            return Math.Round((decimal)totalGuias * 12 / 100, 2);
        }

        public static decimal ObtenerTotalFactura(decimal totalGuias, decimal Iva)
        {
            return Math.Round(totalGuias + Iva, 2);
        }
    }
}
