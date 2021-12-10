using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Experteam.BusinessLayer.Helpers
{
    public static class Mensajes
    {
        public const string NULL_OBJECT = "El objeto enviado se encuentra vacio.";
        public const string NO_SE_ENCONTRO_INFORMACION = "No se ha encontrado información."; 
        public const string NO_VALOR_EN_CERO = "El valor total no puede ser menor o igual a 0."; 
        public const string SELECCIONA_GUIAS = "Debes seleccionar al menos una guía para continuar."; 
        public const string GUIA_NO_PUEDE_SER_CERO = "El valor de la guia no puede ser menor o igual a cero. Actualiza el valor el la seccion de guías."; 
        public const string VALOR_NO_COINCIDE = "Los valores de pago no coinciden con el total de la factura. Por favor revisar."; 
    }

    public static class Ruta
    {
        /*public const string*/
        public const string GUIA_PRINCIPAL = "~/Views/Dashboard/Guia/Index.cshtml";
        public const string GUIA_SECUNDARIA = "~/Views/Dashboard/Guia/{0}.cshtml";
        public const string FACTURA_PRINCIPAL = "~/Views/Dashboard/Factura/Index.cshtml";
        public const string FACTURA_SECUNDARIA = "~/Views/Dashboard/Factura/{0}.cshtml";
    }
}
