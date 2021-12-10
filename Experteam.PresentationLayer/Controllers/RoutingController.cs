using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Experteam.BusinessLayer.Helpers;
using Experteam.PresentationLayer.Models;
using Experteam.BusinessLayer.Repositorio;
using Experteam.DataAccessLayer.Model;
using Experteam.PresentationLayer.Helpers;
using Experteam.PresentationLayer.App_Start;

namespace Experteam.PresentationLayer.Controllers
{
    public class RoutingController : Controller
    {
        // GET: Routing
        public ActionResult Index()
        {
            return HttpNotFound();// View();
        }

        public ActionResult RoutingGuia(string pagina, string parametro)
        {
            PaginaViewModel Pagina = new PaginaViewModel();
            Pagina.VistaPrincipal = Ruta.GUIA_PRINCIPAL;
            Pagina.VistaSecundaria = Ruta.GUIA_SECUNDARIA;

            if (!ExStringHelper.ValidateNotNullString(pagina))
            {
                ViewBag.Guias = new GuiaRepositorio().GetAllDescending();

                Pagina.TituloPagina = "Guias";
                Pagina.VistaSecundaria = string.Format(Pagina.VistaSecundaria, "Listar");
            } 
            else
            {
                List<Pais> PaisList = new List<Pais>();

                switch (pagina)
                {
                    case "Crear":

                        PaisList = ParameterConfig.Pais.GetAll();
                        ViewBag.PaisListOrigen = new SelectList(PaisList, "IdPais", "Nombre");
                        ViewBag.PaisListDestino = new SelectList(PaisList, "IdPais", "Nombre");

                        Pagina.TituloPagina = "Crear Nueva Guia";
                        Pagina.VistaSecundaria = string.Format(Pagina.VistaSecundaria, "Crear");
                        break;
                    case "Ver":
                        if (ExStringHelper.ValidateNotNullString(parametro))
                        {
                            Pagina.Guia = new GuiaRepositorio().GetById(parametro);

                            if (Pagina.Guia != null)
                            {
                                Pagina.TituloPagina = string.Format($"Ver guía {Pagina.Guia.NumeroGuia}");
                                Pagina.VistaSecundaria = string.Format(Pagina.VistaSecundaria, "Ver");
                            }
                            else
                            {
                                return HttpNotFound();
                            }
                        }
                        else
                        {
                            return RedirectToAction("Guia", "Dashboard");
                        }
                        break;
                    case "Editar":
                        if (ExStringHelper.ValidateNotNullString(parametro))
                        {
                            //buscar guia a editar
                            Pagina.Guia = new GuiaRepositorio().GetById(parametro);

                            if (Pagina.Guia == null)
                                return HttpNotFound();


                            PaisList = ParameterConfig.Pais.GetAll();
                            ViewBag.PaisListOrigen = new SelectList(PaisList, "IdPais", "Nombre", Pagina.Guia.IdPaisOrigen);
                            ViewBag.PaisListDestino = new SelectList(PaisList, "IdPais", "Nombre", Pagina.Guia.IdPaisDestino);

                            Pagina.TituloPagina = "Editar Guia";
                            Pagina.VistaSecundaria = string.Format(Pagina.VistaSecundaria, "Editar");
                        } 
                        else
                        {
                            return RedirectToAction("Guia", "Dashboard");
                        }
                        break;
                    default:
                        return new HttpNotFoundResult();
                }
            }
            return View(Pagina.VistaPrincipal, Pagina);
        }

        public ActionResult RoutingFactura(string pagina, string parametro)
        {
            PaginaViewModel Pagina = new PaginaViewModel();
            Pagina.VistaPrincipal = Ruta.FACTURA_PRINCIPAL;
            Pagina.VistaSecundaria = Ruta.FACTURA_SECUNDARIA;

            if (!ExStringHelper.ValidateNotNullString(pagina))
            {
                ViewBag.Facturas = new FacturaRepositorio().GetAllByDescending();

                Pagina.TituloPagina = "Facturas";
                Pagina.VistaSecundaria = string.Format(Pagina.VistaSecundaria, "Listar");
            }
            else
            {
                //List<Pais> PaisList = new List<Pais>();

                switch (pagina)
                {
                    case "Crear":
                        System.Web.HttpContext.Current.Session["SessionFactura"] = null;

                        List<Establecimiento> EstablecimientoList = ParameterConfig.Establecimiento.GetAll();
                        ViewBag.EstablecimientoList = new SelectList(EstablecimientoList, "IdEstablecimiento", "Nombre");

                        List<PuntoEmision> PuntoEmisionList = ParameterConfig.PuntoEmision.GetAll();
                        ViewBag.PuntoEmisionList = new SelectList(PuntoEmisionList, "IdPuntoEmision", "Nombre");


                        Pagina.TituloPagina = "Crear Nueva Factura";
                        Pagina.VistaSecundaria = string.Format(Pagina.VistaSecundaria, "Crear");
                        break;
                    case "Crear1":
                        //System.Web.HttpContext.Current.Session["SessionFactura"] = null;

                        //List<Establecimiento> EstablecimientoList = ParameterConfig.Establecimiento.GetAll();
                        //ViewBag.EstablecimientoList = new SelectList(EstablecimientoList, "IdEstablecimiento", "Nombre");

                        //List<PuntoEmision> PuntoEmisionList = ParameterConfig.PuntoEmision.GetAll();
                        //ViewBag.PuntoEmisionList = new SelectList(PuntoEmisionList, "IdPuntoEmision", "Nombre");
                        Pagina.Guias = new GuiaRepositorio().GetAllByStatus((int)enumStatus.Ingresado);
                        Pagina.Factura = (Factura)System.Web.HttpContext.Current.Session["SessionFactura"];

                        System.Web.HttpContext.Current.Session["SessionGuias"] = null;

                        Pagina.TituloPagina = "Crear Nueva Factura 1";
                        Pagina.VistaSecundaria = string.Format(Pagina.VistaSecundaria, "Crear1");
                        break;
                    case "Crear2":
                        if (System.Web.HttpContext.Current.Session["SessionFactura"] == null || System.Web.HttpContext.Current.Session["SessionGuias"] == null)
                            return RedirectToAction("Factura", "Dashboard", new { pagina = "Crear" });
                        //System.Web.HttpContext.Current.Session["SessionFactura"] = null;

                        //List<Establecimiento> EstablecimientoList = ParameterConfig.Establecimiento.GetAll();
                        //ViewBag.EstablecimientoList = new SelectList(EstablecimientoList, "IdEstablecimiento", "Nombre");

                        //List<PuntoEmision> PuntoEmisionList = ParameterConfig.PuntoEmision.GetAll();
                        //ViewBag.PuntoEmisionList = new SelectList(PuntoEmisionList, "IdPuntoEmision", "Nombre");
                        //Pagina.Guias = new GuiaRepositorio().GetAllByStatus((int)enumStatus.Ingresado);
                        Pagina.Factura = (Factura)System.Web.HttpContext.Current.Session["SessionFactura"];
                        List<Guia> tmpGuias = new List<Guia>();

                        string idGuias = (string)System.Web.HttpContext.Current.Session["SessionGuias"];
                        string[] arrIdGuias = idGuias.Split('|');

                        for(int i=0; i<arrIdGuias.Length-1; i++)
                        {
                            Guia tmpGuia = new GuiaRepositorio().GetById(arrIdGuias[i]);
                            tmpGuias.Add(tmpGuia);
                        }
                        Pagina.Factura.Guia = tmpGuias;
                        System.Web.HttpContext.Current.Session["SessionListaGuias"] = tmpGuias;

                        //obtener subtotal de guias
                        ViewBag.TotalGuia = MyHelpers.ObtenerTotalGuias(tmpGuias.ToList());
                        //obtener iva
                        ViewBag.Iva = MyHelpers.ObtenerIva((decimal)ViewBag.TotalGuia);
                        ViewBag.TotalFactura = MyHelpers.ObtenerTotalFactura((decimal)ViewBag.TotalGuia, (decimal)ViewBag.Iva);

                        Pagina.TituloPagina = "Crear Nueva Factura 1";
                        Pagina.VistaSecundaria = string.Format(Pagina.VistaSecundaria, "Crear2");

                        //vacio las sesiones orque ya no las necesito
                        //System.Web.HttpContext.Current.Session["SessionFactura"] = null;
                        
                        break;
                    case "Ver":
                        if (ExStringHelper.ValidateNotNullString(parametro))
                        {
                            Pagina.Factura = new FacturaRepositorio().GetById(parametro);

                            if (Pagina.Factura != null)
                            {
                                Pagina.TituloPagina = string.Format($"Ver Factura {Pagina.Factura.IdFactura}");
                                Pagina.VistaSecundaria = string.Format(Pagina.VistaSecundaria, "Ver");

                                //obtener subtotal de guias
                                ViewBag.TotalGuia = MyHelpers.ObtenerTotalGuias(Pagina.Factura.Guia.ToList());

                                //obtener iva
                                ViewBag.Iva = MyHelpers.ObtenerIva((decimal)ViewBag.TotalGuia);

                                ViewBag.TotalFactura = MyHelpers.ObtenerTotalFactura((decimal)ViewBag.TotalGuia, (decimal)ViewBag.Iva);
                            }
                            else
                            {
                                return HttpNotFound();
                            }
                        }
                        else
                        {
                            return RedirectToAction("Guia", "Dashboard");
                        }
                        break;
                    case "Editar":
                        if (ExStringHelper.ValidateNotNullString(parametro))
                        {
                            //buscar guia a editar
                            //Pagina.Guia = new GuiaRepositorio().GetById(parametro);

                            //if (Pagina.Guia == null)
                            //    return HttpNotFound();


                            //PaisList = new PaisRepositorio().GetAll();
                            //ViewBag.PaisListOrigen = new SelectList(PaisList, "IdPais", "Nombre", Pagina.Guia.IdPaisOrigen);
                            //ViewBag.PaisListDestino = new SelectList(PaisList, "IdPais", "Nombre", Pagina.Guia.IdPaisDestino);

                            Pagina.TituloPagina = "Editar Factura";
                            Pagina.VistaSecundaria = string.Format(Pagina.VistaSecundaria, "Editar");
                        }
                        else
                        {
                            return RedirectToAction("Guia", "Dashboard");
                        }
                        break;
                    default:
                        return new HttpNotFoundResult();
                }
            }
            return View(Pagina.VistaPrincipal, Pagina);
        }
    }
}