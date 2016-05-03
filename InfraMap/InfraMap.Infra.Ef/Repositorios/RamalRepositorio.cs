using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfraMap.Dominio.Mesa.Ramal;

namespace InfraMap.Infraestrutura.Ef.Repositorios
{
    public class RamalRepositorio : RepositorioBase<Ramal>, IRamalRepositorio
    {
        public new void Deletar(Ramal entity)
        {
            using (var dbContext = new DataBaseContext())
            {
                var dbEntity = this.BuscarPorId(entity.Id);
                dbContext.Ramal.Attach(dbEntity);
                dbContext.Ramal.Remove(dbEntity);
                dbContext.SaveChanges();
            }
        }
    }
}
