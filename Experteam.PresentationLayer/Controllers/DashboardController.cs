using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Experteam.PresentationLayer.Controllers
{
    public class DashboardController : Controller
    {
        private readonly string strRouteViews = "~/Views/Dashboard/{0}/{1}.cshtml";

        // GET: Dashboard
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Guia(string pagina = null, string parametro = null)
        {
            ActionResult actionResult;

            actionResult = new RoutingController().RoutingGuia(pagina, parametro);

            return actionResult;
        }

        public ActionResult Factura(string pagina = null, string parametro = null)
        {
            ActionResult actionResult;

            actionResult = new RoutingController().RoutingFactura(pagina, parametro);

            return actionResult;
        }
    }
}