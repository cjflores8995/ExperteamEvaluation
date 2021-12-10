using Experteam.DataAccessLayer.Model;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Experteam.PresentationLayer.Models
{
    public class PaginaViewModel
    {
        public string TituloPagina { get; set; }
        public string VistaPrincipal { get; set; }
        public string VistaSecundaria { get; set; }
        public Guia Guia { get; set; }
        public Factura Factura { get; set; }
        public List<Guia> Guias { get; set; }

        public decimal Efectivo { get; set; }
        public decimal Cheque { get; set; }
        public decimal Tarjeta { get; set; }
    }
}