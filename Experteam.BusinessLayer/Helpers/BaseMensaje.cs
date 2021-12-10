using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Experteam.BusinessLayer.Helpers
{
    public class BaseMensaje
    {
        public bool Ok { get; set; }
        public string Mensaje { get; set; }
        public string Data { get; set; }

        public BaseMensaje()
        {
            Ok = true;
            Mensaje = "Información procesada correctamente.";
        }

        public BaseMensaje(string message, string data = null)
        {
            this.Ok = false;
            this.Mensaje = message;
            this.Data = data;
        }

        public BaseMensaje Bad(string error)
        {
            BaseMensaje resp = new BaseMensaje();

            resp.Ok = false;
            resp.Mensaje = error;

            return resp;
        }
    }
}

