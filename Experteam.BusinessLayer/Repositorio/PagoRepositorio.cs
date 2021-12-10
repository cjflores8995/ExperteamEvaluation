using Experteam.BusinessLayer.Helpers;
using Experteam.DataAccessLayer.Model;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Experteam.BusinessLayer.Repositorio
{
    public class PagoRepositorio : RepositorioDAL, IDisposable
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public Pago GetById(int id)
        {
            try
            {
                return _db.Pago.FirstOrDefault(x => x.IdPago.Equals(id));
            }
            catch (Exception)
            {
                return null;
            }
        }

        public BaseMensaje ActualizarValorPagos(int idFactura/*, decimal decValorNuevo, decimal decValorActual*/)
        {
            BaseMensaje resp = new BaseMensaje();
            decimal decValorActualizar = 0;

            try
            {
                Factura factura = new FacturaRepositorio().GetById(idFactura);
                decValorActualizar = factura.Total;

                //if(decValorNuevo > decValorActual)
                //{
                    //restar al pago de menor valor
                    Pago pago = GetPagoMenorValor(idFactura);

                    foreach(var itemPago in factura.Pago)
                    {
                        if(itemPago.IdPago != pago.IdPago)
                        {
                            decValorActualizar -= itemPago.Valor;
                        }
                    }

                    pago.Valor = decValorActualizar;
                    _db.Entry(pago).State = System.Data.Entity.EntityState.Modified;
                    _db.SaveChanges();

                //}
                //else
                //{
                //    //se resta al pago de menor valor
                //decimal diferenciaEntreFacturas = decValorActual - decValorNuevo;
                //List<Pago> pagos = factura.Pago.OrderByDescending(x => x.Valor).ToList();

                //foreach (var pago in pagos)
                //{
                //    if (pago.Valor <= diferenciaEntreFacturas)
                //    {
                //        diferenciaEntreFacturas = diferenciaEntreFacturas - pago.Valor;

                //        Pago CurrentPago = GetById(pago.IdPago);

                //        _db.Entry(CurrentPago).State = System.Data.Entity.EntityState.Deleted;
                //    }
                //    else
                //    {
                //        Pago CurrentPago = GetById(pago.IdPago);
                //        CurrentPago.Valor = pago.Valor - diferenciaEntreFacturas;
                //        _db.Entry(CurrentPago).State = System.Data.Entity.EntityState.Modified;
                //        break;
                //    }
                //}

                //_db.SaveChanges();

                //}

            }
            catch (Exception ex)
            {
                resp = GeneralBaseMensaje.Bad(ex.Message);
            }

            return resp;
        }

        public Pago GetPagoMenorValor(int idFactura)
        {
            return _db.Factura.FirstOrDefault(x => x.IdFactura == idFactura).Pago.OrderBy(x => x.Valor).FirstOrDefault();
        }

        public BaseMensaje AcualizaPagoCuandoRestaSaldo(Factura factura, decimal totalActualFactura, decimal totalNuevoFactura)
        {
            BaseMensaje resp = new BaseMensaje();

            try
            {
                decimal diferenciaEntreFacturas = totalActualFactura - totalNuevoFactura;
                List<Pago> pagos = factura.Pago.OrderByDescending(x => x.Valor).ToList();

                foreach (var pago in pagos)
                {
                    if (pago.Valor <= diferenciaEntreFacturas)
                    {
                        diferenciaEntreFacturas = diferenciaEntreFacturas - pago.Valor;

                        Pago CurrentPago = GetById(pago.IdPago);

                        _db.Entry(CurrentPago).State = System.Data.Entity.EntityState.Deleted;
                    }
                    else
                    {
                        Pago CurrentPago = GetById(pago.IdPago);
                        CurrentPago.Valor = pago.Valor - diferenciaEntreFacturas;
                        _db.Entry(CurrentPago).State = System.Data.Entity.EntityState.Modified;
                        break;
                    }
                }

                _db.SaveChanges();
            }
            catch (Exception)
            {
                return null;
            }

            return resp;
        }
    }
}
