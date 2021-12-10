using Experteam.BusinessLayer.Helpers;
using Experteam.BusinessLayer.Repositorio;
using Experteam.DataAccessLayer.Model;
using Experteam.PresentationLayer.Helpers;
using Experteam.PresentationLayer.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using static Experteam.BusinessLayer.Helpers.BaseMensaje;

namespace Experteam.PresentationLayer.Controllers
{
    public class LogicController : Controller
    {
        // GET: Logic
        public ActionResult Index()
        {
            return HttpNotFound();
        }

        public ActionResult GuiaCrear(Guia Guia)
        {
            BaseMensaje resp = new BaseMensaje();
            try
            {
                if (Guia.Total <= 0)
                    throw new ApplicationException(Mensajes.NO_VALOR_EN_CERO);

                Guia.IdStatus = (int)enumStatus.Ingresado;
                resp = new GuiaRepositorio().Create(Guia);

                if (resp.Ok)
                    resp.Data = Url.Action("Guia", "Dashboard");
            } 
            catch(Exception ex)
            {
                resp.Ok = false;
                resp.Mensaje = ex.Message;
            }

            return Json(resp);
        }

        public ActionResult GuiaEditar(Guia Guia)
        {
            BaseMensaje resp = new BaseMensaje();
            try
            {
                if (Guia.Total <= 0)
                    throw new ApplicationException(Mensajes.NO_VALOR_EN_CERO);

                decimal totalGuia = new GuiaRepositorio().ObtenerTotal(Guia.IdGuia);

                resp = new GuiaRepositorio().Edit(Guia);

                if(Guia.Total != totalGuia && Guia.IdStatus == (int)enumStatus.Asignado)
                {
                    decimal valorActualFactura = new FacturaRepositorio().GetFacturaByIdGuia(Guia.IdGuia).Total; 
                    BaseMensaje respFactura = new FacturaRepositorio().ActualizaValorFactura(Guia.IdGuia);
                    Factura factura = new FacturaRepositorio().GetFacturaByIdGuia(Guia.IdGuia);

                    if (Guia.Total > totalGuia)
                    {
                        new PagoRepositorio().ActualizarValorPagos(int.Parse(respFactura.Data)/*, Guia.Total, totalGuia*/);
                    } 
                    else if(Guia.Total < totalGuia)
                    {
                        new PagoRepositorio().AcualizaPagoCuandoRestaSaldo(factura, valorActualFactura, factura.Total);
                    }

                    
                }

                if (resp.Ok)
                    resp.Data = Url.Action("Guia", "Dashboard", new { pagina = "Ver", parametro = Guia.IdGuia});
            }
            catch (Exception ex)
            {
                resp.Ok = false;
                resp.Mensaje = ex.Message;
            }

            return Json(resp);
        }

        public ActionResult GuiaEliminar(int intIdGuia)
        {
            BaseMensaje resp = new BaseMensaje();
            try
            {
                var guia = new GuiaRepositorio().GetById(intIdGuia);

                if (guia == null)
                    throw new ApplicationException(Mensajes.NO_SE_ENCONTRO_INFORMACION);

                resp = new GuiaRepositorio().Delete(intIdGuia);

                if (resp.Ok)
                    resp.Data = Url.Action("Guia", "Dashboard");

            }
            catch (Exception ex)
            {
                resp.Ok = false;
                resp.Mensaje = ex.Message;
            }

            return Json(resp);
        }

        public ActionResult Crear1(Factura factura)
        {
            //System.Web.HttpContext.Current.Session["SessionFactura"] = null;

            System.Web.HttpContext.Current.Session["SessionFactura"] = factura;

            return RedirectToAction("Factura", "Dashboard", new { pagina = "Crear1" });
        }

        public ActionResult AgregarSessionGuia(int idGuia)
        {
            BaseMensaje resp = new BaseMensaje();
            try
            {
                Guia guia = new GuiaRepositorio().GetById(idGuia);
                if (guia.Total <= 0)
                    throw new ApplicationException(Mensajes.GUIA_NO_PUEDE_SER_CERO);


                System.Web.HttpContext.Current.Session["SessionGuias"] += string.Format($"{guia.IdGuia}|");

                resp.Data = string.Format($"Guia_{idGuia}"); 
            }
            catch (Exception ex)
            {
                resp.Ok = false;
                resp.Mensaje = ex.Message;
            }

            return Json(resp);
        }

        public ActionResult ValidarElementosGuia()
        {
            BaseMensaje resp = new BaseMensaje();
            try
            {
                string idGuias = (string)System.Web.HttpContext.Current.Session["SessionGuias"];

                if (string.IsNullOrEmpty(idGuias) || string.IsNullOrWhiteSpace(idGuias))
                    throw new ApplicationException(Mensajes.SELECCIONA_GUIAS);

                resp.Data = Url.Action("Factura", "Dashboard", new { pagina = "Crear2" });
            }
            catch (Exception ex)
            {
                resp.Ok = false;
                resp.Mensaje = ex.Message;
            }

            return Json(resp);
        }

        [ValidateAntiForgeryToken]
        public ActionResult CrearFactura(PaginaViewModel modelo)
        {
            BaseMensaje resp = new BaseMensaje();
            try
            {
                Factura factura = (Factura)System.Web.HttpContext.Current.Session["SessionFactura"];
                factura.Subtotal = modelo.Factura.Subtotal;
                factura.Impuesto = modelo.Factura.Impuesto;
                factura.Total = modelo.Factura.Total;
                factura.Guia = (List<Guia>)System.Web.HttpContext.Current.Session["SessionListaGuias"];

                decimal totalPagos = (modelo.Efectivo + modelo.Cheque + modelo.Tarjeta);

                if (factura.Total != totalPagos)
                    throw new ApplicationException(Mensajes.VALOR_NO_COINCIDE);
            }
            catch (Exception ex)
            {
                resp.Ok = false;
                resp.Mensaje = ex.Message;
            }

            return Json(resp);
        }


    }
}