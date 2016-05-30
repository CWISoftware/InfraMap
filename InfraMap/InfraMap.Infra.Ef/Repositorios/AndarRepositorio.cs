using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfraMap.Dominio.Mesa;
using InfraMap.Dominio.Sede.Andar;
using System.Data.Entity;

namespace InfraMap.Infraestrutura.Ef.Repositorios
{
    public class AndarRepositorio : IAndarRepositorio
    {
        public Andar BuscarPorId(int id)
        {
            using (var db = new DataBaseContext())
            {
                return db.Andar.Include("Mesas.Colaborador").FirstOrDefault(t => t.Id == id);
            }
        }

        public Andar BuscarPorMesa(Mesa mesa)
        {
            using (var db = new DataBaseContext())
            {
                return db.Andar.Include("Mesas").FirstOrDefault(m => m.Mesas.Any(t => t.Id == mesa.Id));
            }
        }

        public Andar BuscarPorNomeColaborador(string nome)
        {
            using (var db = new DataBaseContext())
            {
                return db.Andar.Include("Mesas.Colaborador").FirstOrDefault(a => a.Mesas.Any(m => m.Colaborador.Nome == nome));
            }
        }
    }
}
