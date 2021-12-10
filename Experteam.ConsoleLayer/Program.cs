using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Experteam.ConsoleLayer
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new Experteam.DataAccessLayer.ExperteamContext())
            {
                var data = db.Guia.FirstOrDefault();
            }

                //using (var db = new Experteam.DataAccessLayer.ExperteamContext())
                //{
                //    var estado = db.Status.ToList();

                //    estado.ForEach(item => { Console.WriteLine(item.Nombre); });
                //}

                //using (var db = new Experteam.DataAccessLayer.ExperteamContext())
                //{
                //    var lstEstablecimientos = db.Establecimiento.ToList();

                //    if (lstEstablecimientos.Any())
                //    {
                //        lstEstablecimientos.ForEach(item => {
                //            Console.WriteLine($"{item.IdEstablecimiento}. {item.Nombre}");
                //        });
                //    }
                //    else
                //    {
                //        Console.WriteLine($"No se ha encontrado información.");
                //    }
                //}

                Console.ReadKey();
        }
    }
}
