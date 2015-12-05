using InfraMap.Dominio.ModuloAndar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfraMap.Dominio.ModuloMesa;

namespace InfraMap.Infraestrutura.Ef.Repositorios
{
    public class AndarRepositorio : RepositorioBase<Andar>, IAndarRepositorio
    {
        public List<Andar> BuscarAndaresPorSede(int idSede)
        {
            using (var db = new DataBaseContext())
            {
                return null;
            }
        }

        public Andar BuscarAndarComMesas(int id)
        {
            using (var db = new DataBaseContext())
            {
                return db.Andar.Include("Mesas").Where(a => a.Id == id).SingleOrDefault();
            }
        }
    }
}
