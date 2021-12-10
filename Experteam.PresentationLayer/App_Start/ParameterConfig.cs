using Experteam.BusinessLayer.Repositorio;
using Experteam.DataAccessLayer.Model;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Experteam.PresentationLayer.App_Start
{
    public class ParameterConfig
    {
        public static TipoPagoRepositorio TipoPago { get; set; }
        public static PaisRepositorio Pais { get; set; }
        public static EstablecimientoRepositorio Establecimiento { get; set; }
        public static PuntoEmisionRepositorio PuntoEmision { get; set; }
        public static StatusRepositorio Status { get; set; }
        /// <summary>
        /// Se inicializa los valores de las listas de data necesaria a lo largo del ciclo de vida del aplicativo
        /// </summary>
        public static void Initialize()
        {
            TipoPago = new TipoPagoRepositorio();
            Pais = new PaisRepositorio();
            Establecimiento = new EstablecimientoRepositorio();
            PuntoEmision = new PuntoEmisionRepositorio();
            Status = new StatusRepositorio();
        }
    }
}