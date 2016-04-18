using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfraMap.Dominio.Sede;
using InfraMap.Dominio.Sede.Andar;

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
                return db.Sede.Include("Andares.Mesas").ToList();
            }
        }

        public Sede BuscarSedePorNome(string nome)
        {
            using (var db = new DataBaseContext())
            {
                return db.Sede.Include("Andares.Mesas.Colaborador")
                    .Include("Andares.Mesas.MaquinaPessoal")
                    .Include("Andares.Mesas.Ramal")
                    .FirstOrDefault(t => t.Nome.Equals(nome));
            }
        }

        public Sede BuscarSedePorAndar(Andar andar)
        {
            using (var db = new DataBaseContext())
            {
                return db.Sede.Include("Andares").FirstOrDefault(a => a.Andares.FirstOrDefault(t => t.Id == andar.Id) is Andar);
            }
        }
    }
}
