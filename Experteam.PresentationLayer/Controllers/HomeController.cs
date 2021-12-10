using Experteam.PresentationLayer.App_Start;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Experteam.PresentationLayer.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var tipoPago = ParameterConfig.TipoPago.GetAll();
            var pais = ParameterConfig.Pais.GetAll();
            var establecimiento = ParameterConfig.Establecimiento.GetById(1);

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}