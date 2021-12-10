using Experteam.DataAccessLayer.Model;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Experteam.BusinessLayer.Repositorio
{
    public class EstablecimientoRepositorio: RepositorioDAL, IDisposable
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Obtiene un listado de establecimientos
        /// </summary>
        /// <returns>List<Establecimiento></returns>
        public List<Establecimiento> GetAll() => _db.Establecimiento.ToList();

        /// <summary>
        /// Obtiene in establecimiento por Id
        /// </summary>
        /// <param name="id">id del estableciiento</param>
        /// <returns>Establecimiento</returns>
        public Establecimiento GetById(int id) => _db.Establecimiento.FirstOrDefault(x => x.IdEstablecimiento.Equals(id));
    }
}
