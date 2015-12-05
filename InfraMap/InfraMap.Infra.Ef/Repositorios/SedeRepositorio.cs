using InfraMap.Dominio.ModuloSede;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfraMap.Comum;

namespace InfraMap.Infraestrutura.Ef.Repositorios
{
    public class SedeRepositorio : RepositorioBase<Sede>, ISedeRepositorio
    {
        public List<Sede> BuscarTodasAsSedes()
        {
            using (var db = new DataBaseContext())
            {
                return db.Sede.ToList();
            }
        }

        public List<Sede> BuscarSedesComAndares()
        {
            using (var db = new DataBaseContext())
            {
                return db.Sede.ToList();
            }
        }
    }
}
