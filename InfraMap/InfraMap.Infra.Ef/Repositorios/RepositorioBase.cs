using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfraMap.Dominio.Comum;

namespace InfraMap.Infraestrutura.Ef.Repositorios
{
    public class RepositorioBase<TEntity> : IRepositorio<TEntity> where TEntity : EntidadeBase
    {
        public void Adicionar(TEntity entity)
        {
            using (var dbContext = new DataBaseContext())
            {
                dbContext.Set<TEntity>().Add(entity);
                dbContext.SaveChanges();
            }
        }

        public void Atualizar(TEntity entity)
        {
            using (var dbContext = new DataBaseContext())
            {
                dbContext.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                dbContext.SaveChanges();
            }
        }

        public void Deletar(TEntity entity)
        {
            using (var dbContext = new DataBaseContext())
            {
                var dbEntity = this.BuscarPorId(entity.Id);
                dbContext.Set<TEntity>().Remove(dbEntity);
                dbContext.SaveChanges();
            }
        }

        public TEntity BuscarPorId(int id)
        {
            using (var dbContext = new DataBaseContext())
            {
                return dbContext.Set<TEntity>().Find(id);
            }
        }

        public IList<TEntity> Buscar(params IQuery<TEntity>[] queries)
        {
            using (var dbContext = new DataBaseContext())
            {
                IQueryable<TEntity> query = dbContext.Set<TEntity>();

                foreach (var q in queries)
                {
                    query = q.CriarQuery(query);
                }

                return query.ToList();
            }
        }
    }
}
