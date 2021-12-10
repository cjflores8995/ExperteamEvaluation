using Experteam.BusinessLayer.Helpers;
using Experteam.DataAccessLayer.Model;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Experteam.BusinessLayer.Repositorio
{
    public class FacturaRepositorio : RepositorioDAL, IDisposable
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public List<Factura> GetAll()
        {
            return _db.Factura.ToList();
        }

        public List<Factura> GetAllByDescending()
        {
            return _db.Factura.OrderByDescending(x => x.FechaEmision).ToList();
        }

        public Factura GetById(string id)
        {
            try
            {
                int intId = int.Parse(id);

                return _db.Factura.FirstOrDefault(x => x.IdFactura.Equals(intId));
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Factura GetById(int id)
        {
            try
            {
                return _db.Factura.FirstOrDefault(x => x.IdFactura.Equals(id));
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Factura GetFacturaByIdGuia(int id)
        {
            try
            {
                return _db.Guia.FirstOrDefault(x => x.IdGuia == id).Factura.FirstOrDefault();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public BaseMensaje ActualizaValorFactura(int idGuia)
        {
            BaseMensaje resp = new BaseMensaje();
            decimal decSubtotal = 0, decIva = 0, decTotal = 0;

            try
            {
                Factura factura = GetFacturaByIdGuia(idGuia);

                decSubtotal = MyHelpers.ObtenerTotalGuias(factura.Guia.ToList());
                decIva = MyHelpers.ObtenerIva(decSubtotal);
                decTotal = MyHelpers.ObtenerTotalFactura(decSubtotal, decIva);

                factura.Subtotal = decSubtotal;
                factura.Impuesto = decIva;
                factura.Total = decTotal;

                _db.Entry(factura).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();

                resp.Data = factura.IdFactura.ToString();
            }
            catch (Exception ex)
            {
                resp = GeneralBaseMensaje.Bad(ex.Message);
            }

            return resp;
        }
    }
}


