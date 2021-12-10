using Experteam.BusinessLayer.Helpers;
using Experteam.DataAccessLayer.Model;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Experteam.BusinessLayer.Repositorio
{
    public class GuiaRepositorio: RepositorioDAL
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Obtiene un lstado de status
        /// </summary>
        /// <returns>List<Status></returns>
        public List<Guia> GetAll()
        {
            return _db.Guia.ToList();

        }

        public List<Guia> GetAllDescending()
        {
            return _db.Guia.OrderByDescending(x => x.FechaEnvio).ToList();

        }

        public List<Guia> GetAllByStatus(int idStatus)
        {
            return _db.Guia.Where(x => x.IdStatus.Equals(idStatus)).ToList();
        }

        /// <summary>
        /// Obtiene el status por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Status</returns>
        public Guia GetById(string id)
        {
            try
            {
                int intId = int.Parse(id);

                return _db.Guia.FirstOrDefault(x => x.IdGuia.Equals(intId));
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// Obtiene el status por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Status</returns>
        public Guia GetById(int id)
        {
            try
            {
                return _db.Guia.FirstOrDefault(x => x.IdGuia.Equals(id));
            }
            catch (Exception)
            {
                return null;
            }
        }

        public BaseMensaje Create(Guia guia)
        {
            BaseMensaje resp = new BaseMensaje();

            try
            {
                _db.Entry(guia).State = System.Data.Entity.EntityState.Added;
                _db.SaveChanges();

            }
            catch (Exception ex)
            {
                resp = GeneralBaseMensaje.Bad(ex.Message);
            }

            return resp;
        }

        public BaseMensaje Edit(Guia guia)
        {
            BaseMensaje resp = new BaseMensaje();

            try
            {
                _db.Entry(guia).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();

            }
            catch (Exception ex)
            {
                resp = GeneralBaseMensaje.Bad(ex.Message);
            }

            return resp;
        }

        public BaseMensaje Delete(int id)
        {
            BaseMensaje resp = new BaseMensaje();

            try
            {
                    Guia guia = GetById(id);
                    _db.Entry(guia).State = System.Data.Entity.EntityState.Deleted;
                    _db.SaveChanges();
            }
            catch (Exception ex)
            {
                resp = GeneralBaseMensaje.Bad(ex.Message);
            }

            return resp;
        }

        public decimal ObtenerTotal(int id)
        {
            return _db.Guia.FirstOrDefault(x => x.IdGuia == id).Total;
        }
    }
}
