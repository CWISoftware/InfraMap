using System.Linq;

namespace InfraMap.Dominio.Comum
{
    public interface IQuery<TEntity> where TEntity : EntidadeBase
    {
        IQueryable<TEntity> CriarQuery(IQueryable<TEntity> src);
    }
}
