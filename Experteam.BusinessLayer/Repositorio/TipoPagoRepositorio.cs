using Experteam.DataAccessLayer.Model;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Experteam.BusinessLayer.Repositorio
{
    public class TipoPagoRepositorio : RepositorioDAL, IDisposable
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Obtiene una lista de los tipos de pago existentes
        /// </summary>
        /// <returns>List<TipoPago></returns>
        public List<TipoPago> GetAll()
        {
            return _db.TipoPago.ToList() ?? new List<TipoPago>();
        }

        /// <summary>
        /// Obtiene el tipo de pago filtrado por id
        /// </summary>
        /// <param name="id">id del tipo de pago</param>
        /// <returns>TipoPago</returns>
        public TipoPago GetById(int id)
        {
            return _db.TipoPago.FirstOrDefault(x => x.IdTipoPago.Equals(id));
        }
    }
}
