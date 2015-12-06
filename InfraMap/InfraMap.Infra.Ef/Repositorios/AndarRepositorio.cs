using InfraMap.Dominio.ModuloAndar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfraMap.Dominio.ModuloMesa;

namespace InfraMap.Infraestrutura.Ef.Repositorios
{
    public class AndarRepositorio : IAndarRepositorio
    {
        public Andar BuscarPorId(int id)
        {
            using (var db = new DataBaseContext())
            {
                return db.Andar.Include("Mesas").FirstOrDefault(t => t.Id == id);
            }
        }
       
    }
}
