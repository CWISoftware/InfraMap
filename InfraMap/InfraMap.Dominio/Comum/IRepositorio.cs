using System.Collections.Generic;

namespace InfraMap.Dominio.Comum
{
    public interface IRepositorio<TEntity> where TEntity : EntidadeBase
    {
        TEntity Adicionar(TEntity entity);

        void Atualizar(TEntity entity);

        void Deletar(TEntity entity);

        TEntity BuscarPorId(int id);

        IList<TEntity> Buscar(params IQuery<TEntity>[] queries);
    }
}
