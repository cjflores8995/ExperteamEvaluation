using Experteam.BusinessLayer.Helpers;
using Experteam.DataAccessLayer;
using Experteam.DataAccessLayer.Model;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Experteam.BusinessLayer
{
    public class RepositorioDAL
    {
        public ExperteamContext _db;
        public BaseMensaje GeneralBaseMensaje;

        public RepositorioDAL()
        {
            _db = new ExperteamContext();
            GeneralBaseMensaje = new BaseMensaje();
        }
    }
}
