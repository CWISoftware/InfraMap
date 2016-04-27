using InfraMap.Dominio.Mesa.Maquina;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraMap.Infraestrutura.Ef.Repositorios
{
    public class MaquinaPessoalRepositorio : RepositorioBase<MaquinaPessoal>,IMaquinaPessoalRepositorio
    {
        public new MaquinaPessoal Adicionar(MaquinaPessoal entity)
        {
            using (var db = new DataBaseContext())
            {
                db.Entry(entity.Maquina.ModeloMaquina).State = System.Data.Entity.EntityState.Unchanged;
                db.Entry(entity).State = System.Data.Entity.EntityState.Added;
                db.SaveChanges();
                return entity;
            }
        }

        public new void Deletar(MaquinaPessoal entity)
        {
            using (var dbContext = new DataBaseContext())
            {
                var dbEntity = this.BuscarPorId(entity.Id);
                dbContext.MaquinaPessoal.Attach(dbEntity);
                dbContext.MaquinaPessoal.Remove(dbEntity);
                dbContext.SaveChanges();
            }
        }

    }
}
