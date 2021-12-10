using Experteam.DataAccessLayer.Model;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Experteam.BusinessLayer.Repositorio
{
    public class PuntoEmisionRepositorio : RepositorioDAL, IDisposable
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Ontiene un listado de puntos de emision
        /// </summary>
        /// <returns>List<PuntoEmision></returns>
        public List<PuntoEmision> GetAll() => _db.PuntoEmision.ToList();

        /// <summary>
        /// Obtiene un punto de emision por su id
        /// </summary>
        /// <param name="id">id del punto de emision</param>
        /// <returns>PuntoEmision</returns>
        public PuntoEmision GetById(int id) => _db.PuntoEmision.FirstOrDefault(x => x.IdPuntoEmision.Equals(id));
    }
}
