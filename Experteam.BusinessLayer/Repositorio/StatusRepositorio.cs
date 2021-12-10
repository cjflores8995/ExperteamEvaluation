using Experteam.DataAccessLayer.Model;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Experteam.BusinessLayer.Repositorio
{
    public class StatusRepositorio : RepositorioDAL, IDisposable
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Obtiene un lstado de status
        /// </summary>
        /// <returns>List<Status></returns>
        public List<Status> GetAll()
        {
            return _db.Status.ToList();
        }

        /// <summary>
        /// Obtiene el status por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Status</returns>
        public Status GetById(int id)
        {
            return _db.Status.FirstOrDefault(x => x.IdStatus.Equals(id));
        }
    }
}