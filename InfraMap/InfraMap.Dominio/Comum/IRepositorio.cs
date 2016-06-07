using System.Collections.Generic;

namespace InfraMap.Dominio.Comum
{
    public interface IRepositorio<TEntity> where TEntity : EntidadeBase
    {
        TEntity Adicionar(TEntity entity);

        TEntity Atualizar(TEntity entity);

        void Deletar(int id);

        TEntity BuscarPorId(int id);

        IList<TEntity> Buscar(params IQuery<TEntity>[] queries);
    }
}
