using Experteam.DataAccessLayer.Model;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Experteam.BusinessLayer.Repositorio
{
    public class PaisRepositorio: RepositorioDAL, IDisposable
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Obtiene una lista de los tipos de pago existentes
        /// </summary>
        /// <returns>List<Pais></returns>
        public List<Pais> GetAll()
        {
            return _db.Pais.ToList();
        }
        /// <summary>
        /// Obtiene el tipo de pago filtrado por id
        /// </summary>
        /// <param name="id">id del tipo de pago</param>
        /// <returns>Pais</returns>
        public Pais GetById(int id)
        {
            return _db.Pais.FirstOrDefault(x => x.IdPais.Equals(id));
        }
}
}
